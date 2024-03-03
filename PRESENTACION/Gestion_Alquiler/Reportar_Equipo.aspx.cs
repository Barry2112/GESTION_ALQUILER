using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Reflection;
using System.Security.Cryptography;
using DOMINIO;
using NEGOCIO;
using System.Text;
using static System.Net.WebRequestMethods;
using File = System.IO.File;
using System.Data;
using static System.Net.Mime.MediaTypeNames;

namespace PRESENTACION.Gestion_Alquiler
{
  public partial class Reportar_Equipo : System.Web.UI.Page
  {
    N_Marca NMarca = new N_Marca();
    N_Equipo NEquipo = new N_Equipo();
    N_Tipo_Equipo NTipoEquipo = new N_Tipo_Equipo();

    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack)
      {
        CargarTipoEquipo();
        LimpiarPrincipal();
      }
    }

    public void LimpiarPrincipal()
    {
      labelNameEquipo.Visible = false;
      labelIDTipoEquipo.Visible = false;
      labelIDEquipo.Visible = false;
      labelRutaImagenEquipo.Visible = false;
      DIV_Reportar_Equipo.Visible = false;
    }

    public void CargarTipoEquipo()
    {
      DDL_Listar_Tipo_Equipos.DataSource = NTipoEquipo.Listar_Tipo_Equipo();
      DDL_Listar_Tipo_Equipos.DataTextField = "DESCRIPCION";
      DDL_Listar_Tipo_Equipos.DataValueField = "ID";
      DDL_Listar_Tipo_Equipos.DataBind();
      DDL_Listar_Tipo_Equipos.Items.Insert(0, new ListItem("SELECCIONE", "0"));
    }

    public void CargarEquipoTipoEquipo()
    {
      int ID_Tipo_Equipo;
      ID_Tipo_Equipo = int.Parse(DDL_Listar_Tipo_Equipos.SelectedValue);
      labelIDTipoEquipo.Text = ID_Tipo_Equipo.ToString();
      GV_Mostrar_Equipos_X_Tipo.AutoGenerateColumns = false;
      GV_Mostrar_Equipos_X_Tipo.DataSource = NEquipo.Obtener_Equipo_X_Tipo_Equipo(ID_Tipo_Equipo);
      GV_Mostrar_Equipos_X_Tipo.DataBind();
    }

    protected void DDL_Listar_Tipo_Equipos_SelectedIndexChanged(object sender, EventArgs e)
    {
      CargarEquipoTipoEquipo();
      DIV_Gestionar_Equipo.Visible = true;
      DIV_Detalles_Equipo.Visible = true;
      DIV_Reportar_Equipo.Visible = false;
    }

    protected void GV_Mostrar_Equipos_X_Tipo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      int rowIndex = int.Parse(e.CommandArgument.ToString());
      object obj = GV_Mostrar_Equipos_X_Tipo.DataKeys[rowIndex][0];
      string idEquipo = obj.ToString();
      int ID_Equipo_Editar = int.Parse(idEquipo);
      labelIDEquipo.Text = ID_Equipo_Editar.ToString();
      //labelcodequi.Text = _N_Equipo.TraerCodigo_Equipo_x_ID_Equipo(int.Parse(idEquipo)).ToString();
      switch (e.CommandName)
      {
        case "REPORTAR_EQUIPO":
          DIV_Reportar_Equipo.Visible = true;
          DIV_Gestionar_Equipo.Visible = false;
          DIV_Detalles_Equipo.Visible = false; 

          DataTable dtParametrosP = NEquipo.ObtenerDetallesEquipoEditar(ID_Equipo_Editar);

          if (dtParametrosP.Rows.Count > 0)
          {
            DataRow filaA = dtParametrosP.Rows[0];

            Tipo_Equipo_Reportar.InnerText = filaA[0].ToString();
            Marca_Equipo_Reportar.InnerText = filaA[1].ToString();
            Codigo_Equipo_Reportar.InnerText = filaA[2].ToString();
            Nombre_Equipo_Reportar.InnerText = filaA[3].ToString();
            Precio_Equipo_Reportar.InnerText = filaA[4].ToString();
            Image_Equipo_Reportar.ImageUrl = filaA[6].ToString();
          }
          break;
      }
    }

    public void Limpiar_Gestionar()
    {
      DIV_Gestionar_Equipo.Visible = true;
      DIV_Detalles_Equipo.Visible = true;
      DIV_Reportar_Equipo.Visible = false;
      labelIDEquipo.Visible = false;
      labelNameEquipo.Visible = false;
      labelRutaImagenEquipo.Visible = false;
    }

    protected void btnAtras_Click(object sender, EventArgs e)
    {
      Limpiar_Gestionar();
    }

    protected void btn_Reportar_Equipo_Click(object sender, EventArgs e)
    {

      if (txtdetalle.InnerText == "")
      {
        labelerror.Text = "ADVERTENCIA: El campo direccion del evento no puede estar vacio";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }
      else
      {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#Modal_Advertencia_Reportar_Equipo').modal('show');", true);
      }
    }

    protected void Reportar_Equipo_detalle(object sender, EventArgs e)
    {
      string ID_Equipo = labelIDEquipo.Text;
      NEquipo.Deshabilitar_Estado_Equipo(Convert.ToInt32(ID_Equipo));

      ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#Modal_Equipo_Reportado').modal('show');", true);
    }
  }
}
