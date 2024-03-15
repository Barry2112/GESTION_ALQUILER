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
  public partial class Asignar_Trabajador_Evento : System.Web.UI.Page
  {
    N_Evento NEvento = new N_Evento();
    N_Equipo NEquipo = new N_Equipo();
    N_Tipo_Evento NTipoEvento = new N_Tipo_Evento();
    N_Conexion_BD NConexionBD = new N_Conexion_BD();

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
            Llenar_Eventos();
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

    public void Limpiar()
    {
      DIV_Principal.Visible = true;
      DIV_Asignar_Trabajador_Evento.Visible = false;
      DIV_Tipo_Equipo.Visible = false;
      Label_Fecha.Visible = false;
      Label_ID_Equipo.Visible = false;
      Label_ID_Evento.Visible = false;
      Label_ID_Trabajador.Visible = false;
      Label_ID_Tipo_Equipo.Visible = false;
    }

    public void Llenar_Eventos()
    {
      GV_Eventos.DataSource = NEvento.Cargar_Evento();
      GV_Eventos.DataBind();
    }

    protected void OnPageIndexChangingGV_Eventos(object sender, GridViewPageEventArgs e)
    {
      GV_Eventos.PageIndex = e.NewPageIndex;
      GV_Eventos.DataSource = NEvento.Cargar_Evento();
      GV_Eventos.DataBind();
    }

    protected void GV_Evento_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      int rowIndex = int.Parse(e.CommandArgument.ToString());
      object obj = GV_Eventos.DataKeys[rowIndex][0];
      string ID_Evento = obj.ToString();
      Label_ID_Evento.Text = ID_Evento;

      switch (e.CommandName)
      {
        case "ASIGNAR_TRABAJADOR_EVENTO":
          DIV_Tipo_Equipo.Visible = true;
          DIV_Principal.Visible = false;
          DIV_Asignar_Trabajador_Evento.Visible = false;

          GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
          string Fecha = row.Cells[6].Text;
          Label_Fecha.Text = Fecha;
          Label_Fecha.Visible = true;
          Ver_Tipo_Equipo_Cantidad_X_ID_Evento();

          break;
      }
    }

    public void Ver_Tipo_Equipo_Cantidad_X_ID_Evento()
    {
      int ID_Evento = int.Parse(Label_ID_Evento.Text);
      GV_TEAE.DataSource = NEvento.Ver_Tipo_Equipos_Solicitados(ID_Evento);
      GV_TEAE.DataBind();
    }

    protected void GV_TEAE_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      DO_Tipo_Equipo DOTE = new DO_Tipo_Equipo();

      int rowIndex = int.Parse(e.CommandArgument.ToString());
      object obj = GV_TEAE.DataKeys[rowIndex][0];
      string ID_Tipo_Equipo = obj.ToString();
      DOTE.ID_Tipo_Equipo = int.Parse(ID_Tipo_Equipo);
      Label_ID_Tipo_Equipo.Text = ID_Tipo_Equipo;
      DIV_Asignar_Trabajador_Evento.Visible = true;
      switch (e.CommandName)
      {
        case "MOSTRAR_TRABAJADOR":
          Label_ID_Tipo_Equipo.Visible = false;
          mostrardatostrabajadores();
          break;
      }
    }

    public void mostrardatostrabajadores()
    {
      int ID_Evento = int.Parse(Label_ID_Evento.Text);
      int ID_Tipo_Equipo = int.Parse(Label_ID_Tipo_Equipo.Text);

      GV_Trabajadores_Disponibles.DataSource = NEvento.Cargar_Trabajador_Disponible(ID_Evento, ID_Tipo_Equipo);
      GV_Trabajadores_Disponibles.DataBind();
    }

    protected void GV_Trabajadores_Disponibles_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      int rowIndex = int.Parse(e.CommandArgument.ToString());
      object obj = GV_Trabajadores_Disponibles.DataKeys[rowIndex][0];
      string ID_Trabajador = obj.ToString();

      Label_ID_Trabajador.Text = ID_Trabajador;
      Label_ID_Trabajador.Visible = false;

      object obj2 = GV_Trabajadores_Disponibles.DataKeys[rowIndex][1];
      string ID_Equipo = obj2.ToString();
      Label_ID_Equipo.Text = ID_Equipo;

      Label_ID_Equipo.Visible = false;

      switch (e.CommandName)
      {
        case "ASIGNAR_TRABAJADOR_X_EVENTO":
          int ID_Evento = int.Parse(Label_ID_Evento.Text);
          int ID_Trabajadorint = int.Parse(Label_ID_Trabajador.Text);
          int ID_Equipoint = int.Parse(Label_ID_Equipo.Text);
          int ID_Tipo_Equipo = int.Parse(Label_ID_Tipo_Equipo.Text);
          DateTime Fecha = DateTime.Parse(Label_Fecha.Text);

          NEvento.Actualizar_Cant_Tipo_Equipo_X_Evento(ID_Evento, ID_Tipo_Equipo);
          NEvento.Registrar_Evento_X_Trabajador_X_Equipo(ID_Evento, ID_Trabajadorint, ID_Tipo_Equipo, ID_Equipoint, Fecha);
          Ver_Tipo_Equipo_Cantidad_X_ID_Evento();

          DIV_Asignar_Trabajador_Evento.Visible = false;

          int rowcount = GV_TEAE.Rows.Count;

          if (rowcount == 0)
          {
            NEvento.Organizar_Evento(ID_Evento);
            Limpiar();
            Llenar_Eventos();

            ReportDocument RepDoc = new ReportDocument();
            RepDoc.Load(Server.MapPath(@"~/Reportes/Boleta.rpt"));
            RepDoc.SetParameterValue("@id", ID_Evento);            
            RepDoc.DataSourceConnections[0].SetConnection(NConexionBD.getServidor(), "GESTION_ALQUILER", NConexionBD.getUser(), NConexionBD.getPassword());
            //RepDoc.DataSourceConnections[0].SetConnection(NConexionBD.getServidor(), "GESTION_ALQUILER", true);
            RepDoc.ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath(@"~/Boleta/Boleta_" + ID_Evento + ".pdf"));
            FileStream fstream = new FileStream(Server.MapPath(@"~/Boleta/Boleta_" + ID_Evento + ".pdf"), FileMode.Open);
            BinaryReader binaryReader = new BinaryReader(fstream);
            byte[] bytes = binaryReader.ReadBytes((int)fstream.Length);

            DO_Boleta DOB = new DO_Boleta();
            DOB.Boleta = bytes;
            fstream.Close();
            NEvento.Guardar_Boleta(ID_Evento, DOB);
            Session["Diego"] = "~/Boleta/Boleta_" + ID_Evento + ".pdf";
            string _open = "window.open('Reporte.aspx', '_blank');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

            ReportDocument RepDoc2 = new ReportDocument();
            RepDoc2.Load(Server.MapPath(@"~/Reportes/Contrato.rpt"));
            RepDoc2.SetParameterValue("@ID_EVENTO", ID_Evento);
            RepDoc2.DataSourceConnections[0].SetConnection(NConexionBD.getServidor(), "GESTION_ALQUILER", NConexionBD.getUser(), NConexionBD.getPassword());
            //RepDoc2.DataSourceConnections[0].SetConnection(NConexionBD.getServidor(), "GESTION_ALQUILER", true);
            RepDoc2.ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath(@"~/Contrato/Contrato_" + ID_Evento + ".pdf"));
            FileStream fstream2 = new FileStream(Server.MapPath(@"~/Contrato/Contrato_" + ID_Evento + ".pdf"), FileMode.Open);
            BinaryReader binaryReader2 = new BinaryReader(fstream2);
            byte[] bytes2 = binaryReader2.ReadBytes((int)fstream2.Length);

            DO_Contrato DOC = new DO_Contrato();
            DOC.Contrato = bytes2;
            fstream2.Close();
            NEvento.Guardar_Contrato(ID_Evento, DOC);


            /* Session["Diego"] = "~/Contrato/Contrato_" + ID_Evento + ".pdf";
             string _open2 = "window.open('Reporte.aspx', '_blank');";
             ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open2, true);
            */

            //SE GENERO EVENTO XXXX


            /*
             //ReportDocument oRep = new ReportDocument();
            //ParameterField pf = new ParameterField();
            //ParameterFields pfs = new ParameterFields();
            //ParameterDiscreteValue pdv = new ParameterDiscreteValue();

            //oRep.Load(Server.MapPath(@"~/BoletaPedido.rpt"));
            //oRep.SetParameterValue("@id", _NP.Id_Pedido);
            //oRep.ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath(@"~/Boletas/Boletas" + _NP.Id_Pedido + ".pdf"));
            //_DOE.consultarCorreoUsuario(_DOPe, _NP);
            //string[] words = _DOPe.Correo.Split(' ');
            //MailMessage ms = new MailMessage();
            //ms.To.Add(new MailAddress(words[0]));
            //ms.From = (new MailAddress("solorosasicaperu@gmail.com"));
            //ms.Subject = "Boleta Solo Rosas";
            //ms.IsBodyHtml = true;
            //ms.Body = "Boleta:";
            //ms.Attachments.Add(new Attachment(Server.MapPath(@"~/Boletas/Boletas" + _NP.Id_Pedido + ".pdf")));

            //SmtpClient cliente = new SmtpClient("smtp.gmail.com");
            //using (cliente)
            //{
            //    cliente.Port = 587;
            //    cliente.EnableSsl = true;
            //    cliente.Credentials = new NetworkCredential("solorosasicaperu@gmail.com", "SR123456");
            //    cliente.Send(ms);
            //}
             */

          }
          else
          {

          }

          break;
      }
    }
  }
}
