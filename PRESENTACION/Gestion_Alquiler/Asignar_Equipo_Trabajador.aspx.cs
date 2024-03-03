using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DOMINIO;
using NEGOCIO;

namespace PRESENTACION.Gestion_Alquiler
{
  public partial class Asignar_Equipo_Trabajador : System.Web.UI.Page
  {
    N_Trabajador NTrabajador = new N_Trabajador();
    N_Equipo NEquipo = new N_Equipo();

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
            Limpiar();
            CargarTrabajadores();
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
      DIV_Lista_Trabajador.Visible = true;
      DIV_Asignar.Visible = false;
      DIV_Agregar_Asignacion.Visible = false;
      DIV_Quitar_Asignacion.Visible = false;
      DIV_Codigo_Equipo.Visible = false;
      DIV_Producto.Visible = false;
      DIV_Agregar_Quitar_Asignacion_Equipo.Visible = false;
      DIV_Equipos_Asignados_Trabajador.Visible = false;

      Label_id_List_Trabajadores.Visible = false;
    }

    public void CargarTrabajadores()
    {
      GV_Lista_Trabajadores.DataSource = NTrabajador.Cargar_Trabajadores();
      GV_Lista_Trabajadores.DataBind();
    }

    protected void GV_LT_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      int rowIndex = int.Parse(e.CommandArgument.ToString());
      object obj = GV_Lista_Trabajadores.DataKeys[rowIndex][0];
      string ID_Trabajador = obj.ToString();
      Label_id_List_Trabajadores.Text = ID_Trabajador;

      switch (e.CommandName)
      {
        case "REVISAR_EQUIPOS_ASIGNADOS":
          DIV_Lista_Trabajador.Visible = false;
          DIV_Asignar.Visible = false;
          DIV_Agregar_Asignacion.Visible = false;
          DIV_Quitar_Asignacion.Visible = false;
          DIV_Codigo_Equipo.Visible = false;
          DIV_Producto.Visible = false;
          DIV_Equipos_Asignados_Trabajador.Visible = true;
          Label_id_List_Trabajadores.Visible = false;

          int ID_Trabajadorx = int.Parse(Label_id_List_Trabajadores.Text);
          DL_T_X_E_A.DataSource = NEquipo.Consultar_Equipo_Asignados(ID_Trabajadorx);
          DL_T_X_E_A.DataBind();
          break;

        case "AGREGAR_QUITAR_ASIGNACION":
          DIV_Lista_Trabajador.Visible = false;
          DIV_Asignar.Visible = true;
          DIV_Agregar_Asignacion.Visible = false;
          DIV_Quitar_Asignacion.Visible = false;
          DIV_Codigo_Equipo.Visible = false;
          DIV_Producto.Visible = false;
          Label_id_List_Trabajadores.Visible = false;
          break;
      }
    }

    public void btn_Atras_Click(object sender, EventArgs e)
    {
      Limpiar();
    }

    public void Mostrar_Tipo_Equipo_Pertenece_Trabajadores()
    {
      int ID_Trabajador = Convert.ToInt32(Label_id_List_Trabajadores.Text);

      DDL_TEQT.DataSource = NTrabajador.Mostrar_Tipo_Equipo_Asignados(ID_Trabajador);
      DDL_TEQT.DataValueField = "ID";
      DDL_TEQT.DataTextField = "Descripcion";
      DDL_TEQT.DataBind();
      DDL_TEQT.Items.Insert(0, new ListItem("SELECCIONE", "0"));
    }

    public void Mostrar_Tipo_Equipo_No_Pertenece_Trabajadores()
    {
      int ID_Trabajador = Convert.ToInt32(Label_id_List_Trabajadores.Text);

      DDL_TEAT.DataSource = NTrabajador.Mostrar_Tipo_Equipo_No_Asignados(ID_Trabajador);
      DDL_TEAT.DataValueField = "ID";
      DDL_TEAT.DataTextField = "Descripcion";
      DDL_TEAT.DataBind();
      DDL_TEAT.Items.Insert(0, new ListItem("SELECCIONE", "0"));
    }

    protected void btn_Agregar_Asignacion_Equipo_Click(object sender, EventArgs e)
    {
      DIV_Lista_Trabajador.Visible = false;
      DIV_Asignar.Visible = true;
      DIV_Agregar_Asignacion.Visible = true;
      DIV_Quitar_Asignacion.Visible = false;
      DIV_Codigo_Equipo.Visible = false;
      DIV_Producto.Visible = false;
      DIV_Agregar_Quitar_Asignacion_Equipo.Visible = false;

      btnAtras.Visible = true;
      btn_A_Asignacion.Visible = true;
      btn_Q_Asignacion.Visible = false;

      Mostrar_Tipo_Equipo_No_Pertenece_Trabajadores();
    }

    protected void btn_Quitar_Asignacion_Equipo_Click(object sender, EventArgs e)
    {
      DIV_Lista_Trabajador.Visible = false;
      DIV_Asignar.Visible = true;
      DIV_Agregar_Asignacion.Visible = false;
      DIV_Quitar_Asignacion.Visible = true;
      DIV_Codigo_Equipo.Visible = false;
      DIV_Producto.Visible = false;
      DIV_Agregar_Quitar_Asignacion_Equipo.Visible = false;

      btnAtras.Visible = true;
      btn_A_Asignacion.Visible = false;
      btn_Q_Asignacion.Visible = true;

      Mostrar_Tipo_Equipo_Pertenece_Trabajadores();
    }

    public void Obtener_Codigo_Equipo_X_Tipo_Equipo_Agregar(int ID_Tipo_Equipo)
    {
      int ID_Trabajador = Convert.ToInt32(Label_id_List_Trabajadores.Text);

      DDL_Equipo_X_Codigo.DataSource = NEquipo.Obtener_Codigo_Equipo_X_Tipo_Equipo_Agregar(ID_Tipo_Equipo, ID_Trabajador);
      DDL_Equipo_X_Codigo.DataValueField = "ID";
      DDL_Equipo_X_Codigo.DataTextField = "CODIGO";
      DDL_Equipo_X_Codigo.DataBind();
      DDL_Equipo_X_Codigo.Items.Insert(0, new ListItem("SELECCIONE", "0"));
    }

    protected void DDL_TEAT_SelectedIndexChanged(object sender, EventArgs e)
    {
      int ID_Tipo_Equipo_Asignado = 0;
      ID_Tipo_Equipo_Asignado = int.Parse(DDL_TEAT.SelectedValue);

      if (DDL_TEAT.SelectedItem.Text.Equals("SELECCIONE"))
      {
        labelerror.Text = "ADVERTENCIA: Debe selecionar un tipo de equipo para agregar";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }
      else
      {
        DIV_Lista_Trabajador.Visible = false;
        DIV_Asignar.Visible = true;
        DIV_Agregar_Asignacion.Visible = true;
        DIV_Quitar_Asignacion.Visible = false;
        DIV_Codigo_Equipo.Visible = true;
        DIV_Producto.Visible = false;
        DIV_Agregar_Quitar_Asignacion_Equipo.Visible = false;

        Obtener_Codigo_Equipo_X_Tipo_Equipo_Agregar(ID_Tipo_Equipo_Asignado);
      }
    }

    protected void DDL_TEQT_SelectedIndexChanged(object sender, EventArgs e)
    {
      int ID_Trabajador = Convert.ToInt32(Label_id_List_Trabajadores.Text);
      int ID_Tipo_Equipo = 0;
      ID_Tipo_Equipo = int.Parse(DDL_TEQT.SelectedValue);

      if (DDL_TEQT.SelectedItem.Text.Equals("SELECCIONE"))
      {
        labelerror.Text = "ADVERTENCIA: Debe selecionar un tipo de equipo para quitar";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }
      else
      {
        DIV_Lista_Trabajador.Visible = false;
        DIV_Asignar.Visible = true;
        DIV_Agregar_Asignacion.Visible = false;
        DIV_Quitar_Asignacion.Visible = true;
        DIV_Codigo_Equipo.Visible = false;
        DIV_Producto.Visible = true;
        DIV_Agregar_Quitar_Asignacion_Equipo.Visible = false;

        //int ID_Equipo = int.Parse(DDL_Equipo_X_Codigo.SelectedValue);

        DataTable dtParametrosE = NEquipo.Obtener_Detalles_Equipo_Quitar_Asignacion(ID_Trabajador, ID_Tipo_Equipo);

        if (dtParametrosE.Rows.Count > 0)
        {
          DataRow filaA = dtParametrosE.Rows[0];

          cod_equipo.Visible = true;

          txtNombre.Text = filaA[0].ToString();
          txtCodigo.Text = filaA[1].ToString();
          txtMarca.Text = filaA[2].ToString();
          txtPrecio.Text = filaA[3].ToString();
          Imagen.ImageUrl = filaA[4].ToString(); ;
        }

        DIV_Agregar_Quitar_Asignacion_Equipo.Visible = true;
      }
    }

    protected void DDL_Equipo_X_Codigo_SelectedIndexChanged(object sender, EventArgs e)
    {
      DIV_Lista_Trabajador.Visible = false;
      DIV_Asignar.Visible = true;
      DIV_Codigo_Equipo.Visible = true;
      DIV_Producto.Visible = true;
      DIV_Agregar_Quitar_Asignacion_Equipo.Visible = false;

      int ID_Equipo = int.Parse(DDL_Equipo_X_Codigo.SelectedValue);

      DataTable dtParametrosE = NEquipo.Obtener_Detalles_Equipo_Agregar_X_Quitar_Asignacion(ID_Equipo);

      if (dtParametrosE.Rows.Count > 0)
      {
        DataRow filaA = dtParametrosE.Rows[0];

        cod_equipo.Visible = false;

        txtNombre.Text = filaA[0].ToString();
        txtMarca.Text = filaA[1].ToString();
        txtPrecio.Text = filaA[2].ToString();
        Imagen.ImageUrl = filaA[3].ToString(); ;
      }

      DIV_Agregar_Quitar_Asignacion_Equipo.Visible = true;
    }

    protected void btnAtras_Click(object sender, EventArgs e)
    {
      Limpiar();
    }
    protected void btn_A_Asignacion_Click(object sender, EventArgs e)
    {
      int ID_Trabajador = Convert.ToInt32(Label_id_List_Trabajadores.Text);
      int ID_Equipo = int.Parse(DDL_Equipo_X_Codigo.SelectedValue);
      int ID_Tipo_Equipo_Asignado = 0;
      ID_Tipo_Equipo_Asignado = int.Parse(DDL_TEAT.SelectedValue);

      NTrabajador.Registrar_Asignacion_Equipo_Trabajador(ID_Trabajador, ID_Equipo, ID_Tipo_Equipo_Asignado);

      Limpiar();
      CargarTrabajadores();

      ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalAgregarTipoequipo').modal('show');", true);
    }

    protected void btn_Q_Asignacion_Click(object sender, EventArgs e)
    {
      ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#Modal_Advertencia_Quitar_Asignacion_Tipo_Equipo').modal('show');", true);
    }

    protected void Eliminar_Tipo_Equipo(object sender, EventArgs e)
    {
      int ID_Trabajador = Convert.ToInt32(Label_id_List_Trabajadores.Text);
      int ID_Tipo_Equipo_Asignado = 0;
      ID_Tipo_Equipo_Asignado = int.Parse(DDL_TEQT.SelectedValue);

      NTrabajador.Eliminar_Registro_Asignacion_Equipo_Trabajador(ID_Trabajador, ID_Tipo_Equipo_Asignado);

      Limpiar();
      CargarTrabajadores();

      ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalQuitarTipoequipo').modal('show');", true);
    }
  }
}
