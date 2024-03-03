using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DOMINIO;
using NEGOCIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRESENTACION.Gestion_Alquiler
{
  public partial class Cancelar_Evento : System.Web.UI.Page
  {
    N_Evento NEvento = new N_Evento();
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
            //regresarprincipal();//actualizarfiltro:D
            Llenar_Tipo_Evento();
            div_Filtrar_X_Tipo_Evento.Visible = false;
            div_Filtrar_X_Fecha.Visible = false;
            Label_ID_Evento.Visible = false;
            GV_Gestionar_Solicitud_Evento.DataSource = NEvento.Cargar_Evento_Organizado();
            GV_Gestionar_Solicitud_Evento.DataBind();
          }
        }
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

    public void Llenar_Tipo_Evento()
    {
      DDL_Filtrar_X_Tipo_Evento.DataSource = NTipoEvento.Listar_Tipo_Evento();
      DDL_Filtrar_X_Tipo_Evento.DataTextField = "DESCRIPCION";
      DDL_Filtrar_X_Tipo_Evento.DataValueField = "ID";
      DDL_Filtrar_X_Tipo_Evento.DataBind();
      DDL_Filtrar_X_Tipo_Evento.Items.Insert(0, new ListItem("SELECCIONE", "0"));
    }

    protected void btn_Filtrar_Fecha_Click(object sender, EventArgs e)
    {
      div_Filtrar_X_Fecha.Visible = true;
      div_Filtrar_X_Tipo_Evento.Visible = false;
    }

    protected void btn_Filtrar_Tipo_Evento_Click(object sender, EventArgs e)
    {
      div_Filtrar_X_Tipo_Evento.Visible = true;
      div_Filtrar_X_Fecha.Visible = false;
    }

    protected void btn_Buscar_Evento_X_Fecha_Click(object sender, EventArgs e)
    {
      if (txt_fecha.Text.Length == 0)
      {
        // labelerror.Text = "ADVERTENCIA: Debe ingresar una fecha";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }
      else
      {
        string fecha = txt_fecha.Text;
        DateTime Fecha1 = Convert.ToDateTime(fecha);
        DateTime Fecha2 = Fecha1.AddDays(1);

        GV_Gestionar_Solicitud_Evento.AutoGenerateColumns = false;
        GV_Gestionar_Solicitud_Evento.DataSource = NEvento.Cargar_Solicitud_Evento_X_Fecha(Fecha1, Fecha2);
        GV_Gestionar_Solicitud_Evento.DataBind();
      }
    }

    protected void DDL_Filtrar_X_Tipo_Evento_Changed(object sender, EventArgs e)
    {
      AUX_MostrarSolicitudXTipoEquipo();
    }

    public void AUX_MostrarSolicitudXTipoEquipo()
    {
      if (DDL_Filtrar_X_Tipo_Evento.SelectedItem.Text.Equals("SELECCIONE"))
      {
        //labelerror.Text = "ADVERTENCIA: Debe selecionar un tipo de evento";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }
      else
      {
        DO_Evento DOE = new DO_Evento();
        DOE.ID_Tipo_Evento = int.Parse(DDL_Filtrar_X_Tipo_Evento.SelectedValue);
        GV_Gestionar_Solicitud_Evento.AutoGenerateColumns = false;
        GV_Gestionar_Solicitud_Evento.DataSource = NEvento.Cargar_Solicitud_Evento_X_Tipo_Evento(DOE);
        GV_Gestionar_Solicitud_Evento.DataBind();
      }
    }

    protected void OnPageIndexChangingRevisarSolicitud(object sender, GridViewPageEventArgs e)
    {
      GV_Gestionar_Solicitud_Evento.PageIndex = e.NewPageIndex;
      GV_Gestionar_Solicitud_Evento.DataSource = NEvento.Cargar_Evento_Organizado();
      GV_Gestionar_Solicitud_Evento.DataBind();
    }

    protected void GV_Gestionar_Solicitud_Evento_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      DO_Evento DOE = new DO_Evento();

      int rowIndex = int.Parse(e.CommandArgument.ToString());
      object obj = GV_Gestionar_Solicitud_Evento.DataKeys[rowIndex][0];
      string id_solicitud_evento = obj.ToString();
      int ID_Evento = Convert.ToInt32(id_solicitud_evento);
      Label_ID_Evento.Text = id_solicitud_evento.ToString();

      switch (e.CommandName)
      {
        case "CANCELAR_EVENTO":

          ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#Modal_Advertencia_Eliminar_Evento_Organizado').modal('show');", true);

          break;
      }
    }

    protected void Eliminar_Evento_Organizado(object sender, EventArgs e)
    {
      int ID_Evento = Convert.ToInt32(Label_ID_Evento.Text);

      ReportDocument RepDoc = new ReportDocument();
      RepDoc.Load(Server.MapPath(@"~/Reportes/Nota_Credito.rpt"));
      RepDoc.SetParameterValue("@ID", ID_Evento);
      RepDoc.DataSourceConnections[0].SetConnection("BARRY_2112\\SQLEXPRESS", "GESTION_ALQUILER", true);
      RepDoc.ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath(@"~/Nota_Credito/Nota_Credito_" + ID_Evento + ".pdf"));
      FileStream fstream = new FileStream(Server.MapPath(@"~/Nota_Credito/Nota_Credito_" + ID_Evento + ".pdf"), FileMode.Open);
      BinaryReader binaryReader = new BinaryReader(fstream);
      byte[] bytes = binaryReader.ReadBytes((int)fstream.Length);

      DO_Nota_Credito DONC = new DO_Nota_Credito();
      DONC.Nota_Credito = bytes;
      fstream.Close();
      NEvento.Registrar_Nota_Credito(ID_Evento, DONC);
      Session["Diego"] = "~/Nota_Credito/Nota_Credito_" + ID_Evento + ".pdf";
      string _open = "window.open('Reporte.aspx', '_blank');";
      ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

      NEvento.Evento_Eliminado(ID_Evento);
      Llenar_Tipo_Evento();
    }
  }
}
