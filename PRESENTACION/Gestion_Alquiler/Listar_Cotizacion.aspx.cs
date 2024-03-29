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
using PRESENTACION.Reportes;
using System.Web.Hosting;
using System.Configuration;
using System.Drawing;
using System.Reflection.Emit;
using static System.Net.WebRequestMethods;

namespace PRESENTACION.Gestion_Alquiler
{
  public partial class Listar_Cotizacion : System.Web.UI.Page
  {
    N_Evento NEvento = new N_Evento();
    N_Tipo_Evento NTipoEvento = new N_Tipo_Evento();
    N_Email NEmail = new N_Email();

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
      //DO_Evento DOE = new DO_Evento();

      int rowIndex = int.Parse(e.CommandArgument.ToString());
      object obj = GV_Listar_Cotizacion.DataKeys[rowIndex][0];
      string id_solicitud_evento = obj.ToString();
      int ID_Cotizacion = Convert.ToInt32(id_solicitud_evento);

      switch (e.CommandName)
      {
        case "REVISAR_SOLICITUD":

          Session["Diego"] = "~/Cotizacion/" + "Cotizacion" + "_" + ID_Cotizacion + ".pdf";
          string _open = "window.open('Reporte.aspx', '_blank');";
          ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

          break;
        case "VER_DETALLES":
          string script = "$('#popupVerDetallesCotizacion').modal('show');";
          ClientScript.RegisterStartupScript(this.GetType(), "Popup", script, true);

          txtCotizacionSeleccionada.Text = GV_Listar_Cotizacion.Rows[rowIndex].Cells[1].Text;
          txtCotizacionSeleccionadaFecha.Text = GV_Listar_Cotizacion.Rows[rowIndex].Cells[2].Text;
          txtCotizacionSeleccionadaSubtotal.Text = GV_Listar_Cotizacion.Rows[rowIndex].Cells[3].Text == "&nbsp;" ? "" : GV_Listar_Cotizacion.Rows[rowIndex].Cells[3].Text;
          txtCotizacionSeleccionadaTotalIGV.Text = GV_Listar_Cotizacion.Rows[rowIndex].Cells[4].Text == "&nbsp;" ? "" : GV_Listar_Cotizacion.Rows[rowIndex].Cells[4].Text;
          txtCotizacionSeleccionadaTotal.Text = GV_Listar_Cotizacion.Rows[rowIndex].Cells[5].Text == "&nbsp;" ? "" : GV_Listar_Cotizacion.Rows[rowIndex].Cells[5].Text;

          GV_Detalles_Cotizacion.DataSource = NEvento.Cargar_Detalles_Cotizacion(ID_Cotizacion);
          GV_Detalles_Cotizacion.DataBind();

          break;
        case "CORREO":
          /*OBTENER ID COTIZACION Y ABRIR POPUP*/
          Session["IDCotizacionCorreo"] = ID_Cotizacion;
          txtAlertaPopupCorreoInvalido.Visible = false;
          string ingresarCorreoPopupString = "$('#popupIngresarCorreoParaMail').modal({backdrop: 'static',keyboard: false});";
          ClientScript.RegisterStartupScript(this.GetType(), "Popup", ingresarCorreoPopupString, true);
          break;
      }
    }
    protected void btnEnviarCorreoFinal_Click(object sender, EventArgs e)
    {
      if (!string.IsNullOrEmpty(txtCorreoParaMail.Text.Trim()))
      {
        System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        bool isValid = regex.IsMatch(txtCorreoParaMail.Text.Trim());
        if (!isValid)
        {
          txtAlertaPopupCorreoInvalido.Visible = true;
          txtAlertaPopupCorreoInvalido. InnerText = "Email inválido.";
        }
        else
        {
          DO_Email email = new DO_Email();
          email.Para = txtCorreoParaMail.Text;
          email.Asunto = "SWACE - COTIZACIÓN EMITIDA";
          email.Contenido = @"<b>Se adjunta la cotización que solicito. ¡Muchas grácias por su preferencia!</b>";

          email.Ubicacion_Archivo = HostingEnvironment.MapPath("~\\Cotizacion\\" + "Cotizacion" + "_" + Session["IDCotizacionCorreo"] + ".pdf");

          ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Pop", "$('#popupIngresarCorreoParaMail').modal('hide');", true);
          NEmail.EnviarMail(email);         
        }
      }
      else
      {
        txtAlertaPopupCorreoInvalido.Visible = true;
        txtAlertaPopupCorreoInvalido.InnerText = "Error, debe ingresar un correo.";
      }
    }
  }
}
