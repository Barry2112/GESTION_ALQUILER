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

namespace PRESENTACION.Gestion_Alquiler
{
  public partial class Listar_Cotizacion : System.Web.UI.Page
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
          GV_Listar_Cotizacion.DataSource = NEvento.Cargar_Cotizacion();
          GV_Listar_Cotizacion.DataBind();
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

    protected void OnPageIndexChangingRevisarSolicitud(object sender, GridViewPageEventArgs e)
    {
      GV_Listar_Cotizacion.PageIndex = e.NewPageIndex;
      GV_Listar_Cotizacion.DataSource = NEvento.Cargar_Cotizacion();
      GV_Listar_Cotizacion.DataBind();
    }

    protected void GV_Gestionar_Solicitud_Evento_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      DO_Evento DOE = new DO_Evento();

      int rowIndex = int.Parse(e.CommandArgument.ToString());
      object obj = GV_Listar_Cotizacion.DataKeys[rowIndex][0];
      string id_solicitud_evento = obj.ToString();
      int ID_Evento = Convert.ToInt32(id_solicitud_evento);
      //Label_ID_Evento.Text = id_solicitud_evento.ToString();

      switch (e.CommandName)
      {
        case "REVISAR_SOLICITUD":

          Session["Diego"] = "~/Cotizacion/" + "Cotizacion" + "_" + ID_Evento + ".pdf";
          string _open = "window.open('Reporte.aspx', '_blank');";
          ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

          break;
      }
    }
  }
}
