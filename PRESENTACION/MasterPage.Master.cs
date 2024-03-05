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
using DOMINIO;
using NEGOCIO;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace PRESENTACION
{
  public partial class MasterPage : System.Web.UI.MasterPage
  {
    N_Usuario NUsuario = new N_Usuario();

    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack)
      {
        Permisos(0);
      }
      try
      {
        string ID_U = (string)Session["ID_Usuario"];
        string ID_TU = (string)Session["ID_Tipo_Usuario"];
        string APELLIDOSNOMBRES = (string)Session["Apellidos_Nombres"];

        int ID_Usuario = Convert.ToInt32(ID_U);
        int ID_Tipo_Usuario = Convert.ToInt32(ID_TU);

        //int ID_Usuario = int.Parse(Session["ID_Usuario"].ToString());
        //int ID_Tipo_Usuario = int.Parse(Session["ID_Tipo_Usuario"].ToString());

        switch (ID_Tipo_Usuario)
        {
          case 0:
            label_tipo_usuario_min.Text = "USUARIO";
            break;
          case 1:
            label_tipo_usuario_min.Text = "CLIENTE";
            label_nombre_usuario.Text = APELLIDOSNOMBRES;
            label_nombre_usuario_min.Text = APELLIDOSNOMBRES;
            break;
          case 2:
            label_tipo_usuario_min.Text = "TRABAJADOR";
            label_nombre_usuario.Text = APELLIDOSNOMBRES;
            label_nombre_usuario_min.Text = APELLIDOSNOMBRES;
            break;
          case 3:
            label_tipo_usuario_min.Text = "ENCARGADO DE ALMACEN";
            label_nombre_usuario.Text = APELLIDOSNOMBRES;
            label_nombre_usuario_min.Text = APELLIDOSNOMBRES;
            break;
          case 4:
            label_tipo_usuario_min.Text = "ADMINISTRADOR";
            label_nombre_usuario.Text = APELLIDOSNOMBRES;
            label_nombre_usuario_min.Text = APELLIDOSNOMBRES;
            break;
        }
        Permisos(ID_Tipo_Usuario);
      }
      catch (Exception ex)
      {
      }
    }

    public void Permisos(int ID_Tipo_Usuario)
    {
      switch (ID_Tipo_Usuario)
      {
        case 0:
          mainSidebar.Visible = false;
          contentWrapperMain.Attributes.Add("class", "content-wrapper no-margin");

          btn_Logout.Visible = false;
          btn_Perfil.Visible = false;
          Usuario_Menu.Visible = false;
          headerdivvv.Visible = false;

          GestionAlquiler.Visible = false;

          ModuloEquipo.Visible = false;
          RegistrarEquipo.Visible = false;
          ConsultarEquipo.Visible = false;
          GestionarEquipo.Visible = false;
          AsignarEquipoTrabajador.Visible = false;

          ModuloEvento.Visible = false;
          RegistrarSolicitudEvento.Visible = false;
          AtenderSolicitudEvento.Visible = false;
          AsignarTrabajadorEvento.Visible = false;
          RevisarEventoOrganizado.Visible = false;
          ReprogramarEvento.Visible = false;
          CancelarEveto.Visible = false;

          ModuloCotizaciones.Visible = false;
          GenerarCotizacion.Visible = false;
          ListarCotizacion.Visible = false;


          /*
           -----------------------------------
        modulo incidencias
        reportar incedencia de equipo
        reportar incedencia de evento
        gestionar incidencia
           */

          break;

        case 1:
          mainSidebar.Visible = true;
          contentWrapperMain.Attributes.Add("class", contentWrapperMain.Attributes["class"].ToString().Replace("no-margin", ""));

          btn_Logout.Visible = true;
          btn_Perfil.Visible = true;
          Usuario_Menu.Visible = true;
          headerdivvv.Visible = true;

          GestionAlquiler.Visible = true;

          ModuloEquipo.Visible = false;
          RegistrarEquipo.Visible = false;
          ConsultarEquipo.Visible = true;
          GestionarEquipo.Visible = false;
          AsignarEquipoTrabajador.Visible = false;

          ModuloEvento.Visible = true;
          RegistrarSolicitudEvento.Visible = true;
          AtenderSolicitudEvento.Visible = false;
          AsignarTrabajadorEvento.Visible = false;
          RevisarEventoOrganizado.Visible = false;
          ReprogramarEvento.Visible = false;
          CancelarEveto.Visible = false;

          ModuloCotizaciones.Visible = true;
          GenerarCotizacion.Visible = true;
          ListarCotizacion.Visible = false;
          /*
          -----------------------------------
          modulo incidencias
          reportar incedencia de equipo
          reportar incedencia de evento
          gestionar incidencia
          */
          break;

        case 2:
          mainSidebar.Visible = true;
          contentWrapperMain.Attributes.Add("class", contentWrapperMain.Attributes["class"].ToString().Replace("no-margin", ""));

          btn_Logout.Visible = true;
          btn_Perfil.Visible = true;
          Usuario_Menu.Visible = true;
          headerdivvv.Visible = true;

          GestionAlquiler.Visible = true;
          ModuloEquipo.Visible = true;

          RegistrarEquipo.Visible = false;
          ConsultarEquipo.Visible = true;
          GestionarEquipo.Visible = false;
          AsignarEquipoTrabajador.Visible = false;

          ModuloEvento.Visible = true;
          RegistrarSolicitudEvento.Visible = true;
          AtenderSolicitudEvento.Visible = false;
          AsignarTrabajadorEvento.Visible = false;
          RevisarEventoOrganizado.Visible = false;
          ReprogramarEvento.Visible = false;
          CancelarEveto.Visible = false;

          ModuloCotizaciones.Visible = true;
          GenerarCotizacion.Visible = true;
          ListarCotizacion.Visible = false;
          /*
          -----------------------------------
          modulo incidencias
          reportar incedencia de equipo
          reportar incedencia de evento
          gestionar incidencia
          */
          break;

        case 3:
          mainSidebar.Visible = true;
          contentWrapperMain.Attributes.Add("class", contentWrapperMain.Attributes["class"].ToString().Replace("no-margin", ""));

          btn_Logout.Visible = true;
          btn_Perfil.Visible = true;
          Usuario_Menu.Visible = true;
          headerdivvv.Visible = true;

          GestionAlquiler.Visible = true;
          ModuloEquipo.Visible = true;

          RegistrarEquipo.Visible = true;
          ConsultarEquipo.Visible = true;
          GestionarEquipo.Visible = true;
          AsignarEquipoTrabajador.Visible = false;

          ModuloEvento.Visible = true;
          RegistrarSolicitudEvento.Visible = true;
          AtenderSolicitudEvento.Visible = false;
          AsignarTrabajadorEvento.Visible = false;
          RevisarEventoOrganizado.Visible = false;
          ReprogramarEvento.Visible = false;
          CancelarEveto.Visible = false;

          ModuloCotizaciones.Visible = true;
          GenerarCotizacion.Visible = true;
          ListarCotizacion.Visible = false;
          /*
          -----------------------------------
          modulo incidencias
          reportar incedencia de equipo
          reportar incedencia de evento
          gestionar incidencia
          */
          break;

        case 4:
          mainSidebar.Visible = true;
          contentWrapperMain.Attributes.Add("class", contentWrapperMain.Attributes["class"].ToString().Replace("no-margin", ""));

          btn_Logout.Visible = true;
          btn_Perfil.Visible = true;
          Usuario_Menu.Visible = true;
          headerdivvv.Visible = true;

          GestionAlquiler.Visible = true;
          ModuloEquipo.Visible = true;

          RegistrarEquipo.Visible = false;
          ConsultarEquipo.Visible = true;
          GestionarEquipo.Visible = false;
          AsignarEquipoTrabajador.Visible = true;

          ModuloEvento.Visible = true;
          RegistrarSolicitudEvento.Visible = true;
          AtenderSolicitudEvento.Visible = true;
          AsignarTrabajadorEvento.Visible = true;
          RevisarEventoOrganizado.Visible = true;
          ReprogramarEvento.Visible = true;
          CancelarEveto.Visible = true;

          ModuloCotizaciones.Visible = true;
          GenerarCotizacion.Visible = true;
          ListarCotizacion.Visible = true;
          /*
          -----------------------------------
          modulo incidencias
          reportar incedencia de equipo
          reportar incedencia de evento
          gestionar incidencia
          */
          break;
      }
    }

    public void Perfil(object sender, EventArgs e)
    {
      Response.Redirect("~/Gestion_Alquiler/Pagina_Principal.aspx");
    }

    protected void btn_Logout_Click(object sender, EventArgs e)
    {
      Session.Remove("ID_Usuario");
      Session.Remove("ID_Tipo_Usuario");
      Session.Remove("Apellidos_Nombres");
      Permisos(0);
      btn_Logout.Visible = false;
      btn_Perfil.Visible = false;
      Usuario_Menu.Visible = false;
      Response.Redirect("~/Gestion_Alquiler/Iniciar_Sesion.aspx");
    }
  }
}
