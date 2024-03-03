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
  public partial class Gestionar_Incidencia_Equipos : System.Web.UI.Page
  {
    N_Evento NEvento = new N_Evento();
    N_Equipo NEquipo = new N_Equipo();

    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack)
      { 
        GV_Mostrar_Equipos_Incidencia.DataSource = NEquipo.Cargar_Incidencia_Equipos();
        GV_Mostrar_Equipos_Incidencia.DataBind();
        label_ID_Equipo.Visible = false;
        DIV_GESTIONAR_Incidencia_Equipo.Visible = true;
        DIV_Detalles_Equipo.Visible = true;
        DIV_DETALLES_EQUIPO_incidencia.Visible = false;
        DIV_IMAGEN_EQUIPO.Visible = false;
      }

    }

    protected void GV_Mostrar_Equipos_Incidencia_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      int rowIndex = int.Parse(e.CommandArgument.ToString());
      object obj = GV_Mostrar_Equipos_Incidencia.DataKeys[rowIndex][0];
      string idEquipo = obj.ToString();
      int ID_Equipo_Editar = int.Parse(idEquipo);
      label_ID_Equipo.Text = ID_Equipo_Editar.ToString();
      //labelcodequi.Text = _N_Equipo.TraerCodigo_Equipo_x_ID_Equipo(int.Parse(idEquipo)).ToString();
      switch (e.CommandName)
      {
        case "REVISAR_INCIDENCIA_EQUIPO": 

          DataTable dtParametrosP = NEquipo.Obtener_Detalles_Gestionar_Equipo_Incidencia(ID_Equipo_Editar);

          if (dtParametrosP.Rows.Count > 0)
          {
            DataRow filaA = dtParametrosP.Rows[0];
              
            txtCodigo_Equipo_Editar.Text = filaA[0].ToString();
            txtNombre.Text = filaA[1].ToString();
            txtmarca.Text = filaA[2].ToString();
            txtPrecio.Text = filaA[3].ToString();
            txtTrabajador.Text = filaA[5].ToString();
            Image_Equipo_Editar.ImageUrl = filaA[4].ToString();
            label_ID_Trabajador.Text = filaA[6].ToString();
            txtdetalle.InnerText = filaA[7].ToString();

            DIV_DETALLES_EQUIPO_incidencia.Visible = true;
            DIV_GESTIONAR_Incidencia_Equipo.Visible = true;
            DIV_Detalles_Equipo.Visible = false; 
            DIV_IMAGEN_EQUIPO.Visible = true;
          } 
          break; 
      }
    }

    protected void btn_Registrar_Incidencia_Equipo_Click(object sender, EventArgs e)
    {

       // NEquipo.Registrar_Incidencia_Equipo(ID_Equipo, ID_Trabajador, Detalles_Problema);
        
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalIncidenciaRegistrado').modal('show');", true);
    }

  }
}
