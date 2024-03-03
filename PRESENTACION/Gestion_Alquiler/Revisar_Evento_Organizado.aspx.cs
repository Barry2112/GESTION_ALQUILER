using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Reflection;
using System.Security.Cryptography;
using NEGOCIO;
using DOMINIO;
using System.Text;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace PRESENTACION.Gestion_Alquiler
{
  public partial class Revisar_Evento_Organizado : System.Web.UI.Page
  {
    N_Evento NEvento = new N_Evento();
    N_Equipo NEquipo = new N_Equipo();
    N_Tipo_Evento NTipoEvento = new N_Tipo_Evento();

    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack)
      {
        string ID_Usuario = (string)Session["ID_Usuario"];
        string ID_Tipo_Usuario = (string)Session["ID_Tipo_Usuario"];

        if (string.IsNullOrEmpty(ID_Usuario))
        {
          Inicie_Sesion();
          Response.Redirect("~/Gestion_Alquiler/Iniciar_Sesion.aspx");
        }
        else if (ID_Tipo_Usuario != "4")
        {
          Permisos_Insuficientes();
          Response.Redirect("~/Gestion_Alquiler/Pagina_Principal.aspx");
        }
        else
        {
          if (!IsPostBack)
          {
            Limpiar();
            Llenar_GV_Eventos();
          }
        }
        /*regresarprincipal();
        Llenar_Tipo_Evento();
        div_Filtrar_X_Tipo_Evento.Visible = false;
        div_Filtrar_X_Fecha.Visible = false;

        GV_Gestionar_Solicitud_Evento.DataSource = NEvento.Cargar_Solicitud_Evento();
        GV_Gestionar_Solicitud_Evento.DataBind();*/
      }
    }

    public void Inicie_Sesion()
    {
      labelerror.Text = "ADVERTENCIA: Debe de iniciar sesion";
      ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
    }

    public void Permisos_Insuficientes()
    {
      labelerror.Text = "ADVERTENCIA: Tipo de usuario no adminitido";
      ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
    }

    public void Limpiar()
    {
      DIV_Principal.Visible = true;
      DIV_Equipos_Asignados_Trabajador.Visible = false;
      Label_ID_Evento.Visible = false;
      DIV_ANEXAR.Visible = false;
    }

    public void Llenar_GV_Eventos()
    {
      GV_Eventos.DataSource = NEvento.Cargar_Evento_Organizado();
      GV_Eventos.DataBind();
    }

    protected void OnPageIndexChangingGV_Eventos(object sender, GridViewPageEventArgs e)
    {
      GV_Eventos.PageIndex = e.NewPageIndex;
      GV_Eventos.DataSource = NEvento.Cargar_Evento();
      GV_Eventos.DataBind();
    }

    // GV_Evento_RowCommand
    protected void GV_Evento_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      DO_Evento DOE = new DO_Evento();

      int rowIndex = int.Parse(e.CommandArgument.ToString());
      object obj = GV_Eventos.DataKeys[rowIndex][0];
      string id_solicitud_evento = obj.ToString();
      int ID_Evento = Convert.ToInt32(id_solicitud_evento);
      Label_ID_Evento.Text = id_solicitud_evento.ToString();

      switch (e.CommandName)
      {
        case "REVISAR_EQUIPOS_ASIGNADOS":
          DIV_Principal.Visible = false;
          DIV_Equipos_Asignados_Trabajador.Visible = true;

          int ID_EVENTITO = int.Parse(Label_ID_Evento.Text);
          DL_T_X_E_A.DataSource = NEquipo.Consultar_Equipo_Organizado(ID_EVENTITO);
          DL_T_X_E_A.DataBind();

          break;

        case "ADJUNTAR_ACTA_EVENTO":

          DIV_ANEXAR.Visible = true;
          DIV_Principal.Visible = false;
          DIV_Equipos_Asignados_Trabajador.Visible = false;
          break;
      }
    }



    public void btn_Atras_Click(object sender, EventArgs e)
    {
      Limpiar();
    }

    protected void btn_Anexar_Acta_Click(object sender, EventArgs e)
    {
      int ID_EVENTITO = int.Parse(Label_ID_Evento.Text);
      ReportDocument RepDoc = new ReportDocument();
      RepDoc.Load(Server.MapPath(@"~/Reportes/Acta_Conformidad.rpt"));
      RepDoc.SetParameterValue("@ID_EVENTO", ID_EVENTITO);
      RepDoc.DataSourceConnections[0].SetConnection("BARRY_2112\\SQLEXPRESS", "GESTION_ALQUILER", true);
      RepDoc.ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath(@"~/Documento_Satisfaccion/Acta_Conformidad_" + ID_EVENTITO + ".pdf"));

      string path = Server.MapPath(@"~/Documento_Satisfaccion/Acta_Conformidad_" + ID_EVENTITO + ".pdf");
      bool fileExist = File.Exists(path);
      if (fileExist)
      {

        labelerror.Text = "ADVERTENCIA: Ya se genero el acta de conformidad";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }
      else
      {
        FileStream fstream = new FileStream(Server.MapPath(@"~/Documento_Satisfaccion/Acta_Conformidad_" + ID_EVENTITO + ".pdf"), FileMode.Open);
        BinaryReader binaryReader = new BinaryReader(fstream);
        byte[] bytes = binaryReader.ReadBytes((int)fstream.Length);
      }
    }

    protected void btn_Adjuntar_Acta_Click(object sender, EventArgs e)
    {
      int ID_EVENTITO = int.Parse(Label_ID_Evento.Text);

      if (FU_Adjuntar_Acta.HasFile)
      {
        string fisica = "~/Documento_Satisfaccion/";
        string nombredocument = "Firmado_" + FU_Adjuntar_Acta.PostedFile.FileName;
        string ruta = fisica + nombredocument;
        FU_Adjuntar_Acta.SaveAs(Server.MapPath(ruta));

        NEvento.Evento_Satisfecho(ID_EVENTITO);
      }
      else
      {

        labelerror.Text = "ADVERTENCIA: Debe de adjuntar una acta de conformidad";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }

    }
  }
}
