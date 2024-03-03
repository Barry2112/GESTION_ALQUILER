using System;
using System.Collections.Generic;
using System.Data;
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

namespace PRESENTACION.Gestion_de_Alquiler
{
  public partial class Gestionar_Equipo1 : System.Web.UI.Page
  {
    N_Marca NMarca = new N_Marca();
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
        else if (ID_Tipo_Usuario != "3")
        {
          Permisos_Insuficientes();
          Response.Redirect("~/Gestion_Alquiler/Pagina_Principal.aspx");
        }
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
      DIV_Gestionar_Equipo.Visible = true;
      DIV_Detalles_Equipo.Visible = false;
      DIV_Editar_Equipo.Visible = false;
      labelIDEquipo.Visible = false;
      labelNameEquipo.Visible = false;
      labelRutaImagenEquipo.Visible = false;
    }

    public void Limpiar_Gestionar()
    {
      DIV_Gestionar_Equipo.Visible = true;
      DIV_Detalles_Equipo.Visible = true;
      DIV_Editar_Equipo.Visible = false;
      labelIDEquipo.Visible = false;
      labelNameEquipo.Visible = false;
      labelRutaImagenEquipo.Visible = false;
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
      GV_Mostrar_Equipos_X_Tipo.AutoGenerateColumns = false;
      GV_Mostrar_Equipos_X_Tipo.DataSource = NEquipo.Obtener_Equipo_X_Tipo_Equipo(ID_Tipo_Equipo);
      GV_Mostrar_Equipos_X_Tipo.DataBind();
    }

    protected void DDL_Listar_Tipo_Equipos_SelectedIndexChanged(object sender, EventArgs e)
    {
      CargarEquipoTipoEquipo();
      DIV_Gestionar_Equipo.Visible = true;
      DIV_Detalles_Equipo.Visible = true;
      DIV_Editar_Equipo.Visible = false;
    }

    public void CargarTipoEquipoEditar()
    {
      DDL_Tipo_Equipo_Editar.DataSource = NTipoEquipo.Listar_Tipo_Equipo();
      DDL_Tipo_Equipo_Editar.DataTextField = "DESCRIPCION";
      DDL_Tipo_Equipo_Editar.DataValueField = "ID";
      DDL_Tipo_Equipo_Editar.DataBind();
      DDL_Tipo_Equipo_Editar.Items.Insert(0, new ListItem("SELECCIONE", "0"));
    }

    public void Listar_Marca_X_ID_Equipo(int ID_Equipo)
    {
      DDL_Marca_Editar.DataSource = NMarca.Listar_Marcas_ID_Equipo(ID_Equipo);
      DDL_Marca_Editar.DataTextField = "DESCRIPCION";
      DDL_Marca_Editar.DataValueField = "ID";
      DDL_Marca_Editar.DataBind();
      DDL_Marca_Editar.Items.Insert(0, new ListItem("SELECCIONE", "0"));
      int csmr = DDL_Marca_Editar.Items.Count;
      DDL_Marca_Editar.Items.Insert(csmr, new ListItem("OTRO", "17"));
    }

    protected void DDL_Tipo_Equipo_Editar_SelectedIndexChanged(object sender, EventArgs e)
    {
      int ID_Tipo_Equipo = DDL_Tipo_Equipo_Editar.SelectedIndex;
      DDL_Marca_Editar.DataSource = NMarca.Listar_Marca_X_Tipo_Equipo(ID_Tipo_Equipo);
      DDL_Marca_Editar.DataTextField = "DESCRIPCION";
      DDL_Marca_Editar.DataValueField = "ID";
      DDL_Marca_Editar.DataBind();
      DDL_Marca_Editar.Items.Insert(0, new ListItem("SELECCIONE", "0"));

      int csmr = DDL_Marca_Editar.Items.Count;
      DDL_Marca_Editar.Items.Insert(csmr, new ListItem("OTRO", "17"));
    }

    protected void DDL_Marca_Editar_SelectedIndexChanged(object sender, EventArgs e)
    {
      int csmr = DDL_Marca_Editar.Items.Count - 1;

      if (DDL_Marca_Editar.SelectedIndex == csmr)
      {
        txtmarca_editar.Visible = true;
      }
      else
      {
        txtmarca_editar.Visible = false;
      }
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
        case "EDITAR_EQUIPO":
          DIV_Editar_Equipo.Visible = true;
          DIV_Gestionar_Equipo.Visible = false;
          DIV_Detalles_Equipo.Visible = false;

          CargarTipoEquipoEditar();
          Listar_Marca_X_ID_Equipo(ID_Equipo_Editar);

          DataTable dtParametrosP = NEquipo.ObtenerDetallesEquipoEditar(ID_Equipo_Editar);

          if (dtParametrosP.Rows.Count > 0)
          {
            DataRow filaA = dtParametrosP.Rows[0];

            DDL_Tipo_Equipo_Editar.SelectedIndex = -1;
            DDL_Tipo_Equipo_Editar.Items.FindByValue(filaA[0].ToString()).Selected = true;
            DDL_Marca_Editar.SelectedIndex = -1;
            DDL_Marca_Editar.Items.FindByValue(filaA[1].ToString()).Selected = true;
            txtCodigo_Equipo_Editar.Text = filaA[2].ToString();
            txtNombre_Editar.Text = filaA[3].ToString();
            txtPrecio_Editar.Text = filaA[4].ToString();
            txtmarca_editar.Text = filaA[5].ToString();
            Image_Equipo_Editar.ImageUrl = filaA[6].ToString();

            labelNameEquipo.Text = filaA[3].ToString();
            labelRutaImagenEquipo.Text = filaA[6].ToString();

            if (DDL_Marca_Editar.SelectedIndex == 17)
            {
              DIV_marca_equipo_editar.Visible = true;
              DIV_txt_marca_equipo_editar.Visible = true;
            }
            else
            {
              DIV_marca_equipo_editar.Visible = false;
              DIV_txt_marca_equipo_editar.Visible = false;
            }
          }
          break;
          
       /* case "ELIMINAR_EQUIPO":
          ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#Modal_Advertencia_Eliminar_Equipo').modal('show');", true);

          break;*/
      }
    }

    protected void btnAtras_Click(object sender, EventArgs e)
    {
      Limpiar_Gestionar();
    }

    protected void btn_Editar_Equipo_Click(object sender, EventArgs e)
    {
      double valdouble2;

      if (DDL_Marca_Editar.SelectedItem.Text.Equals("SELECCIONE"))
      {
        labelerror.Text = "ADVERTENCIA: Debe selecionar una marca de equipo";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }
      else if (txtPrecio_Editar.Text.Length == 0)
      {
        labelerror.Text = "ADVERTENCIA: El campo precio no puede estar vacio";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }
      else if (!double.TryParse(txtPrecio_Editar.Text, out valdouble2))
      {
        labelerror.Text = "ADVERTENCIA: Debe ingresar valor real ";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }
      else if (txtPrecio_Editar.Text.IndexOf('.') != -1)
      {
        labelerror.Text = "ADVERTENCIA: El campo precio no permite puntos, solo comas.";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }
      else if (double.Parse(txtPrecio_Editar.Text) <= 0)
      {
        labelerror.Text = "ADVERTENCIA: El campo precio no puede ser negativo o 0";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }
      else if (double.Parse(txtPrecio_Editar.Text) > 400.00)
      {
        labelerror.Text = "ADVERTENCIA: Precio Maximo de Alquiler es de 300.00";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }
      else if (double.Parse(txtPrecio_Editar.Text) < 20.00)
      {
        labelerror.Text = "ADVERTENCIA: Precio Minimo de Alquiler es de 20.00";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }
      else if (DDL_Marca_Editar.SelectedIndex == 0)
      {
        labelerror.Text = "ADVERTENCIA: Debe de seleccionar una marca según el tipo de equipo elegido";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }
      else if (DDL_Marca_Editar.SelectedValue == "OTRO" && txtmarca_editar.Text == "")
      {
        labelerror.Text = "ADVERTENCIA: Debe de ingresar un nombre de marca del equipo";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }
      else
      {
        DO_Equipo DOE = new DO_Equipo();
        DOE.ID_Equipo = Convert.ToInt32(labelIDEquipo.Text);
        DOE.ID_Tipo_Equipo = int.Parse(DDL_Tipo_Equipo_Editar.SelectedValue);
        DOE.ID_Marca_Equipo = int.Parse(DDL_Marca_Editar.SelectedValue);
        DOE.Codigo_Equipo = txtCodigo_Equipo_Editar.Text;
        DOE.Nombre_Equipo = txtNombre_Editar.Text;
        DOE.Precio_Equipo = double.Parse(txtPrecio_Editar.Text);
        DOE.Otro_Equipo = txtmarca_editar.Text;

        NEquipo.Editar_Equipo(DOE);
        Limpiar_Gestionar();
        CargarEquipoTipoEquipo();

        if (FU_Equipo_Editar.HasFile)
        {
          var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
          string path = outPutDirectory;
          path = path.Replace("file:\\", "");
          path = path.Replace("\\bin", "");

          var backPathr = Path.Combine(path, "Imagenes\\Basura");

          string valordeimagen = labelRutaImagenEquipo.Text;
          string[] array = valordeimagen.Split(new string[] { "~" }, StringSplitOptions.None);
          string vacio = array[0];
          string rutaimagenequipo = array[1];

          //var Pathr = Path.Combine(path, rutaimagenequipo);

          string rutaimagen = rutaimagenequipo.Replace("/", "\\");

          var rutadestino = path + "" + rutaimagen;
          File.Delete(Server.MapPath(rutaimagen));

          FU_Equipo_Editar.SaveAs(Server.MapPath(rutaimagen));
          //File.Replace(rutax, rutadestino, backPathr);


        }
        else { }


        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalSolicitudRegistrado').modal('show');", true);
      }
    }
    protected void Eliminar_Equipo(object sender, EventArgs e)
    {
      string nombretipoequipo = "";

      if (DDL_Listar_Tipo_Equipos.SelectedIndex == 8)
      {
        nombretipoequipo = labelNameEquipo.Text;
      }
      else
      {
        nombretipoequipo = DDL_Listar_Tipo_Equipos.SelectedItem.Text;
      }

      label_tipo_equipo_eliminar.Text = nombretipoequipo.ToUpper();

      int idequipo = Convert.ToInt32(labelIDEquipo.Text);

      NEquipo.Eliminar_Equipo(idequipo);

      Limpiar_Gestionar();
      CargarEquipoTipoEquipo();

      ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#Modal_Equipo_Elimindado').modal('show');", true);
    }
  }
}
