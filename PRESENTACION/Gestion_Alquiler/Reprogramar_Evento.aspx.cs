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

            buscarEventoProgramadoXFechaYTipo_Auxiliar(null);
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
    public void buscarEventoProgramadoXFechaYTipo_Auxiliar(GridViewPageEventArgs e)
    {
      int ID_Tipo_Evento = new int();

      if (DDL_Filtrar_X_Tipo_Evento.SelectedItem.Text.Equals("SELECCIONE"))
      {
        ID_Tipo_Evento = -1;
      }
      else
      {
        ID_Tipo_Evento = int.Parse(DDL_Filtrar_X_Tipo_Evento.SelectedValue);
      }

      GV_Gestionar_Solicitud_Evento.AutoGenerateColumns = false;
      if (txt_fecha.Text.Length == 0)
      {
        GV_Gestionar_Solicitud_Evento.DataSource = NEvento.Cargar_EventoOrganizado_X_TipoYFecha(ID_Tipo_Evento, null, null);
      }
      else
      {
        GV_Gestionar_Solicitud_Evento.DataSource = NEvento.Cargar_EventoOrganizado_X_TipoYFecha(ID_Tipo_Evento, Convert.ToDateTime(txt_fecha.Text), Convert.ToDateTime(txt_fecha.Text).AddDays(1));
      }
      if (e != null) { GV_Gestionar_Solicitud_Evento.PageIndex = e.NewPageIndex; }
      GV_Gestionar_Solicitud_Evento.DataBind();
    }
    protected void btnBuscarEventoProgramadoXTipoYFecha_Click(object sender, EventArgs e)
    {
      buscarEventoProgramadoXFechaYTipo_Auxiliar(null);
    }

    protected void OnPageIndexChangingRevisarSolicitud(object sender, GridViewPageEventArgs e)
    {
      buscarEventoProgramadoXFechaYTipo_Auxiliar(e);
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

      buscarEventoProgramadoXFechaYTipo_Auxiliar(null);

      regresarprincipal();
      ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#Modal_Advertencia_Reprogramar_Evento').modal('show');", true);
    }

    protected void btn_Reprogramar_Evento(object sender, EventArgs e)
    {
      ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#Modal_Evento_Reprogramado').modal('show');", true);
    }
  }
}
