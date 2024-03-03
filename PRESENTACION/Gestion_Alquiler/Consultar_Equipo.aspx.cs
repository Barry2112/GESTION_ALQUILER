using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DOMINIO;
using NEGOCIO;

namespace PRESENTACION.Gestion_de_Alquiler
{
  public partial class Consultar_Equipo : System.Web.UI.Page
  {
    N_Equipo NEquipo = new N_Equipo();
    N_Tipo_Equipo NTipoEquipo = new N_Tipo_Equipo();

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
        /*else if (ID_Tipo_Usuario = "4")
        {
          Permisos_Insuficientes();
          Response.Redirect("~/Gestion_Alquiler/Pagina_Principal.aspx");
        }*/
        else
        {
          if (!IsPostBack)
          {
            Limpiar();
            CargarTipoEquipo();
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

    public void Limpiar()
    {
      DIV_Consultar_Equipo.Visible = true;
      DIV_Detalle_Equipo.Visible = false;
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
      if (DDL_Listar_Tipo_Equipos.SelectedItem.Text.Equals("SELECCIONE"))
      {
        labelerror.Text = "ADVERTENCIA: Debe selecionar un tipo de equipo";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }
      else
      {
        int ID_Tipo_Equipo = int.Parse(DDL_Listar_Tipo_Equipos.SelectedValue);
        DataListEquipos.DataSource = NEquipo.Consultar_Equipo(ID_Tipo_Equipo);
        DataListEquipos.DataBind();
      }
    }

    protected void DDL_Listar_Tipo_Equipos_SelectedIndexChanged(object sender, EventArgs e)
    {
      CargarEquipoTipoEquipo();
    }

    protected void DataListEquipos_ItemCommand(object source, DataListCommandEventArgs e)
    {
      DIV_Consultar_Equipo.Visible = false;
      DIV_Detalle_Equipo.Visible = true;

      string ID_Producto = DataListEquipos.DataKeys[e.Item.ItemIndex].ToString();

      int ID_p = int.Parse(ID_Producto);

      DataTable dtParametrosE = NEquipo.ObtenerDetallesEquipo(ID_p);

      if (dtParametrosE.Rows.Count > 0)
      {
        DataRow filaA = dtParametrosE.Rows[0];

        txtCodigoEquipo.Text = filaA[0].ToString();
        txtNombre.Text = filaA[1].ToString();
        txtMarca.Text = filaA[2].ToString();
        txtEstadoEquipo.Text = filaA[3].ToString();
        txtTipoEquipo.Text = filaA[4].ToString();
        txtPrecio.Text = filaA[5].ToString();
        Imagen.ImageUrl = filaA[6].ToString();
      }
    }

    protected void btnAtras_Click(object sender, EventArgs e)
    {
      Limpiar();
    }
  }
}
