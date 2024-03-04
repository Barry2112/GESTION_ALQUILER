using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using DOMINIO;
using NEGOCIO;

namespace PRESENTACION.Gestion_Alquiler
{
  public partial class Iniciar_Sesion : System.Web.UI.Page
  { 
    N_Usuario NUsuario = new N_Usuario();

    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        txt_password.TextMode = TextBoxMode.Password;
        ImageButton_HidePass.Visible = false;
        ImageButton_ShowPass.Visible = true;
      }
    }

    protected void btn_Iniciar_Sesion_Click(object sender, EventArgs e)
    {
      if (txt_email.Text.Equals(""))
      {
        labelerror.Text = "ADVERTENCIA: El campo correo no puede estar vacio";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }
      else if (txt_password.Text.Equals(""))
      {
        labelerror.Text = "ADVERTENCIA: El campo contraseña no puede estar vacio";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }
      else
      {
        DO_Usuario DOU = new DO_Usuario();

        DOU.Correo = txt_email.Text;
        DOU.Contraseña = txt_password.Text;

        bool valor = NUsuario.Iniciar_Sesion(DOU);

        if (valor)
        {
          DataTable dtParametros = NUsuario.Obtener_Datos_Usuario(txt_email.Text, txt_password.Text);

          if (dtParametros.Rows.Count > 0)
          {
            DataRow fila = dtParametros.Rows[0];

            Session["ID_Usuario"] = Convert.ToString(fila[0]);
            Session["ID_Tipo_Usuario"] = Convert.ToString(fila[1]);
            Session["Apellidos_Nombres"] = Convert.ToString(fila[2]);

            Response.Redirect("Pagina_Principal.aspx");
          }
        }
        else
        {
          txt_email.Text = "";
          txt_password.Text = "";
          labelerror.Text = "ADVERTENCIA: Los datos ingresados no coinciden con ninguna cuenta";
          ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
        }
      }
    } 

    protected void btn_Registrar_Usuario_Nuevo_Click(object sender, EventArgs e)
    {
      Response.Redirect("Registrar_Usuario.aspx");
    }

    protected void Ir_Principal(object sender, EventArgs e)
    {
      Response.Redirect("Pagina_Principal.aspx");
    }

    protected void ImageButton_ShowPass_Click(object sender, ImageClickEventArgs e)
    {
      txt_password.TextMode = TextBoxMode.SingleLine;

      ImageButton_HidePass.Visible = true;
      ImageButton_ShowPass.Visible = false;
    }

    protected void ImageButton_HidePass_Click(object sender, ImageClickEventArgs e)
    {
      var aux = txt_password.Text;
      System.Diagnostics.Debug.WriteLine(aux);
      txt_password.TextMode = TextBoxMode.Password;
      txt_password.Attributes.Add("value", aux);

      ImageButton_HidePass.Visible = false;
      ImageButton_ShowPass.Visible = true;
    }
  }
}
