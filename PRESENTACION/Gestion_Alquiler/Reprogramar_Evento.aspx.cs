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
  public partial class Reprogramar_Evento : System.Web.UI.Page
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
            Llenar_Tipo_Evento();
            regresarprincipal();
            div_Filtrar_X_Tipo_Evento.Visible = false;
            div_Filtrar_X_Fecha.Visible = false;

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
    public void regresarprincipal()
    {
      Label_ID_Evento.Visible = false;
      txt_fecha.Visible = false;
      DIV_Atender_Solicitud_de_Evento.Visible = true;
      DIV_REVISAR_SOLICITUD_EVENTO.Visible = false;
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
        labelerror.Text = "ADVERTENCIA: Debe ingresar una fecha";
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

    public void Llenar_Tipo_Evento_Detalle()
    {
      DDL_Tipo_Evento_Atender.DataSource = NTipoEvento.Listar_Tipo_Evento();
      DDL_Tipo_Evento_Atender.DataTextField = "DESCRIPCION";
      DDL_Tipo_Evento_Atender.DataValueField = "ID";
      DDL_Tipo_Evento_Atender.DataBind();
      DDL_Tipo_Evento_Atender.Items.Insert(0, new ListItem("SELECCIONE", "0"));
    }

    protected void DDL_Tipo_Evento_Atender_SelectedIndexChanged(object sender, EventArgs e)
    {
      int cste = DDL_Tipo_Evento_Atender.Items.Count - 1;

      if (DDL_Tipo_Evento_Atender.SelectedIndex == cste)
      {
        pruebax.Visible = true;
      }
      else
      {
        pruebax.Visible = false;
      }
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
        case "REVISAR_SOLICITUD":

          DIV_Atender_Solicitud_de_Evento.Visible = false;
          //DIV_ATENDER_SOLICITUD_EVENTO.Visible = false;
          DIV_REVISAR_SOLICITUD_EVENTO.Visible = true;

          Llenar_Tipo_Evento_Detalle();
          pruebax.Visible = false;

          DataTable DTEvento = NEvento.Atender_Solicitud_Evento(ID_Evento);

          if (DTEvento.Rows.Count > 0)
          {
            DataRow FilEvento = DTEvento.Rows[0];

            string ID_Eventox = FilEvento[0].ToString();
            string tipo_evento = FilEvento[2].ToString();
            txtNombre.Text = FilEvento[3].ToString();
            txtApellido.Text = FilEvento[4].ToString();
            txtDNI.Text = FilEvento[5].ToString();
            txtCelular.Text = FilEvento[6].ToString();
            txtCorreo.Text = FilEvento[7].ToString();
            DateTime fecha = DateTime.Parse(FilEvento[8].ToString());
            txtFechayHora.Value = fecha.ToString("yyyy-MM-ddThh:mm");
            txtdireccion.Text = FilEvento[9].ToString();
            txtdetalle.Value = FilEvento[10].ToString();
            txt_otro_evento.Text = FilEvento[11].ToString();

            DDL_Tipo_Evento_Atender.SelectedIndex = -1;
            DDL_Tipo_Evento_Atender.Items.FindByValue(tipo_evento).Selected = true;

            if (DDL_Tipo_Evento_Atender.SelectedIndex == 9)
            {
              pruebax.Visible = true;
            }
            else
            {
              pruebax.Visible = false;
            }

          }
          break;
      }
    }
    protected void btnAtras1_Click(object sender, EventArgs e)
    {
       regresarprincipal();
    }

    protected void btnAceptarSolicitud_Click(object sender, EventArgs e)
    {
      DO_Evento DOE = new DO_Evento();

      DOE.ID_Evento = Convert.ToInt32(Label_ID_Evento.Text);
      DOE.Nombres = txtNombre.Text;
      DOE.Apellidos = txtApellido.Text;
      DOE.DNI = txtDNI.Text;
      DOE.Correo = txtCorreo.Text;
      DOE.Celular = txtCelular.Text;
      DOE.Fecha = Convert.ToDateTime(txtFechayHora.Value);
      DOE.ID_Tipo_Evento = DDL_Tipo_Evento_Atender.SelectedIndex;
      DOE.Direccion = txtdireccion.Text;
      DOE.Otro_Evento = txt_otro_evento.Text;
      DOE.Detalles = txtdetalle.Value;

      NEvento.AprobarSolicitudEvento(DOE);

      GV_Gestionar_Solicitud_Evento.DataSource = NEvento.Cargar_Solicitud_Evento();
      GV_Gestionar_Solicitud_Evento.DataBind();
      
      regresarprincipal();
      ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#Modal_Advertencia_Reprogramar_Evento').modal('show');", true);
    }

    protected void btn_Reprogramar_Evento(object sender, EventArgs e)
    {


      ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#Modal_Evento_Reprogramado').modal('show');", true);
    }
  }
}
