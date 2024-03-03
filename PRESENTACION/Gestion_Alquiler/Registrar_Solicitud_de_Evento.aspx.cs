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

namespace PRESENTACION.Gestion_de_Alquiler
{
  public partial class Registrar_Solicitud_de_Evento : System.Web.UI.Page
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
        /*
        else if (ID_Tipo_Usuario == "3")
        {
          Permisos_Insuficientes();
          Response.Redirect("~/Gestion_Alquiler/Pagina_Principal.aspx");
        }*/
        else
        {
          if (!IsPostBack)
          {
            Llenar_Tipo_Evento();
            Limpiar_Registro_Solicitud_Evento();
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
      DDL_Tipo_Evento.DataSource = NTipoEvento.Listar_Tipo_Evento();
      DDL_Tipo_Evento.DataTextField = "DESCRIPCION";
      DDL_Tipo_Evento.DataValueField = "ID";
      DDL_Tipo_Evento.DataBind();
      DDL_Tipo_Evento.Items.Insert(0, new ListItem("SELECCIONE", "0"));
    }

    protected void DDL_Tipo_Evento_SelectedIndexChanged(object sender, EventArgs e)
    {
      int cste = DDL_Tipo_Evento.Items.Count - 1;

      if (DDL_Tipo_Evento.SelectedIndex == cste)
      {
        pruebax.Visible = true;
      }
      else
      {
        pruebax.Visible = false;
      }
    }

    protected void btnEnviarSolicitud_Click(object sender, EventArgs e)
    {
      DO_Evento DOE = new DO_Evento();

      DateTime ExceptionDate1 = DateTime.Today;
      DateTime ExceptionDate2 = ExceptionDate1.AddDays(15);
      DateTime ExceptionDate3 = ExceptionDate1.AddMonths(6);

      if (txtNombre.Text.Length == 0)
      {
        labelerror.Text = "ADVERTENCIA: El campo nombre no puede estar vacio";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }
      else if (txtDNI.Text.Length == 0)
      {
        labelerror.Text = "ADVERTENCIA: El campo DNI no puede estar vacio";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }
      else if (txtDNI.Text.Length != 8)
      {
        labelerror.Text = "ADVERTENCIA: El campo DNI debe  de tener 8 caracteres numericos";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }
      else if (txtCelular.Text.Length == 0)
      {
        labelerror.Text = "ADVERTENCIA: El campo celular no puede estar vacio";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }
      else if (txtCelular.Text.Length != 9)
      {
        labelerror.Text = "ADVERTENCIA: El campo celular debe  de tener 9 caracteres numericos";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }
      else if (DDL_Tipo_Evento.SelectedItem.Text.Equals("SELECCIONE"))
      {
        labelerror.Text = "ADVERTENCIA: Debe selecionar un tipo de evento";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }
      else if (DDL_Tipo_Evento.SelectedItem.Text.Equals("OTRO") && (txt_otro_evento.Text.Length == 0))
      {
        labelerror.Text = "ADVERTENCIA: Debe especificar su tipo de evento";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }
      else if (txtApellido.Text.Length == 0)
      {
        labelerror.Text = "ADVERTENCIA: El campo apellido no puede estar vacio";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }
      else if (txtCorreo.Text.Length == 0)
      {
        labelerror.Text = "ADVERTENCIA: El campo correo no puede estar vacio";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }
      else if (txtFechayHora.Value.Length == 0)
      {
        labelerror.Text = "ADVERTENCIA: Debe de seleccionar una fecha";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }
      else if (DateTime.Parse(txtFechayHora.Value) < ExceptionDate1)
      {
        labelerror.Text = "ADVERTENCIA: La fecha seleccionada no puede ser inferior a la de hoy";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }
      else if (DateTime.Parse(txtFechayHora.Value) < ExceptionDate2)
      {
        labelerror.Text = "ADVERTENCIA: La fecha del evento debe de ser 15 dias despues de hoy";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }
      else if (DateTime.Parse(txtFechayHora.Value) > ExceptionDate3)
      {
        labelerror.Text = "ADVERTENCIA: La fecha del evento debe estar dentro del rango de 6 meses";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }
      else if (txtdireccion.Text.Length == 0)
      {
        labelerror.Text = "ADVERTENCIA: El campo direccion del cliente no puede estar vacio";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }
      else if (txtdireccion_evento.Text.Length == 0)
      {
        labelerror.Text = "ADVERTENCIA: El campo direccion del evento no puede estar vacio";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }
      else
      {
        DOE.ID_Estado_Evento = 1;
        DOE.ID_Tipo_Evento = DDL_Tipo_Evento.SelectedIndex;
        DOE.Nombres = txtNombre.Text;
        DOE.Apellidos = txtApellido.Text;
        DOE.DNI = txtDNI.Text;
        DOE.Celular = txtCelular.Text;
        DOE.Correo = txtCorreo.Text;
        DOE.Fecha = Convert.ToDateTime(txtFechayHora.Value);
        DOE.Direccion = txtdireccion.Text;
        DOE.Direccion_Evento = txtdireccion_evento.Text;
        DOE.Detalles = txtdetalle.Value;

        if (DDL_Tipo_Evento.SelectedIndex == 9)
        {
          DOE.Otro_Evento = txt_otro_evento.Text;
        }
        else
        {
          DOE.Otro_Evento = "";
        }

        NEvento.RegistrarSolicitudEvento(DOE);

        Limpiar_Registro_Solicitud_Evento();

        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalSolicitudRegistrado').modal('show');", true);
      }
    }

    public void Limpiar_Registro_Solicitud_Evento()
    {
      txtNombre.Text = "";
      txtDNI.Text = "";
      txtCelular.Text = "";
      txt_otro_evento.Text = "";
      txtApellido.Text = "";
      txtCorreo.Text = "";
      txtFechayHora.Value = "";
      txtdireccion.Text = "";
      txtdireccion_evento.Text = "";
      txtdetalle.Value = "";
      DDL_Tipo_Evento.SelectedIndex = 0;
      pruebax.Visible = false;
    }
  }
}
