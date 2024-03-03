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
  public partial class Reportar_Incidencia_Equipo : System.Web.UI.Page
  {
    N_Tipo_Equipo NTipoEquipo = new N_Tipo_Equipo();
    N_Equipo NEquipo = new N_Equipo();
    N_Marca NMarca = new N_Marca();

    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack)
      {
        Llenar_Tipo_Equipo();
        Cargar_Principal();
      }
    }

    public void Llenar_Tipo_Equipo()
    {
      DDL_Listar_Tipo_Equipos_Registro.DataSource = NTipoEquipo.Listar_Tipo_Equipo();
      DDL_Listar_Tipo_Equipos_Registro.DataTextField = "DESCRIPCION";
      DDL_Listar_Tipo_Equipos_Registro.DataValueField = "ID";
      DDL_Listar_Tipo_Equipos_Registro.DataBind();
      DDL_Listar_Tipo_Equipos_Registro.Items.Insert(0, new ListItem("SELECCIONE", "0"));
    }

    protected void DDL_Listar_Tipo_Equipos_Registro_SelectedIndexChanged(object sender, EventArgs e)
    {
      int ID_Tipo_Equipo = int.Parse(DDL_Listar_Tipo_Equipos_Registro.SelectedValue);
      DDL_Codigo_Equipos_Incidencia.DataSource = NEquipo.Listar_Codigo_Equipo_X_ID_Tipo_Equipo(ID_Tipo_Equipo);
      DDL_Codigo_Equipos_Incidencia.DataTextField = "Codigo_Equipo";
      DDL_Codigo_Equipos_Incidencia.DataValueField = "ID_Equipo";
      DDL_Codigo_Equipos_Incidencia.DataBind();
      DDL_Codigo_Equipos_Incidencia.Items.Insert(0, new ListItem("SELECCIONE", "0"));
    }

    protected void DDL_Codigo_Equipos_Incidencia_SelectedIndexChanged(object sender, EventArgs e)
    {
      int ID_Equipo = int.Parse(DDL_Codigo_Equipos_Incidencia.SelectedValue);
      NEquipo.Obtener_Detalles_Equipo_Incidencia(ID_Equipo);

      DataTable dtParametrosE = NEquipo.Obtener_Detalles_Equipo_Incidencia(ID_Equipo);

      if (dtParametrosE.Rows.Count > 0)
      {
        DataRow filaA = dtParametrosE.Rows[0];

        txtCodigo_Equipo_Editar.Text = filaA[0].ToString();
        txtNombre.Text = filaA[1].ToString();
        txtmarca.Text = filaA[2].ToString();
        txtPrecio.Text = filaA[3].ToString();
        txtTrabajador.Text = filaA[5].ToString();
        Image_Equipo_Editar.ImageUrl = filaA[4].ToString();
        label_ID_Trabajador.Text = filaA[6].ToString();
      }
      DIV_DETALLES_EQUIPO.Visible = true;
      DIV_IMAGEN_EQUIPO.Visible = true;
    }

    protected void btn_Registrar_Incidencia_Equipo_Click(object sender, EventArgs e)
    {

      if (DDL_Listar_Tipo_Equipos_Registro.SelectedItem.Text.Equals("SELECCIONE"))
      {
        labelerror.Text = "ADVERTENCIA: Debe selecionar una tipo de equipo";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }
      else if (DDL_Codigo_Equipos_Incidencia.SelectedItem.Text.Equals("SELECCIONE"))
      {
        labelerror.Text = "ADVERTENCIA: Debe selecionar una codigo de equipo";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }
      else
      {
        int ID_Equipo = int.Parse(DDL_Codigo_Equipos_Incidencia.SelectedValue);
        int ID_Trabajador = Convert.ToInt32(label_ID_Trabajador.Text);
        string Detalles_Problema = txtdetalle.Value;

        NEquipo.Registrar_Incidencia_Equipo(ID_Equipo, ID_Trabajador, Detalles_Problema);

        Cargar_Principal();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalIncidenciaRegistrado').modal('show');", true);
      }

    }

    public void Cargar_Principal()
    {
      DIV_IMAGEN_EQUIPO.Visible = false;
      DIV_DETALLES_EQUIPO.Visible = false;

      label_ID_Trabajador.Visible = false;

      txtdetalle.Value = "";

      DDL_Listar_Tipo_Equipos_Registro.SelectedIndex = 0;
      DDL_Codigo_Equipos_Incidencia.SelectedIndex = 0;
    }
  }
}
