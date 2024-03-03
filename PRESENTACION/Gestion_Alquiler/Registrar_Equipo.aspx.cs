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
  public partial class Gestionar_Equipo : System.Web.UI.Page
  {
    N_Tipo_Equipo NTipoEquipo = new N_Tipo_Equipo();
    N_Equipo NEquipo = new N_Equipo();
    N_Marca NMarca = new N_Marca();

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
            Llenar_Tipo_Equipo();
            ddl_marca_reg.Items.Insert(0, new ListItem("SELECCIONE UN TIPO DE EQUIPO", "0"));
            otro_marca_equipo.Visible = false;
            LimpiarAgregarEquipo();
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

    public void Llenar_Tipo_Equipo()
    {
      ddl_tipo_equipo_reg.DataSource = NTipoEquipo.Listar_Tipo_Equipo();
      ddl_tipo_equipo_reg.DataTextField = "DESCRIPCION";
      ddl_tipo_equipo_reg.DataValueField = "ID";
      ddl_tipo_equipo_reg.DataBind();
      ddl_tipo_equipo_reg.Items.Insert(0, new ListItem("SELECCIONE", "0"));
    }

    protected void DDL_tipo_equipo_reg_SelectedIndexChanged(object sender, EventArgs e)
    {
      int ID_Tipo_Equipo = ddl_tipo_equipo_reg.SelectedIndex;
      ddl_marca_reg.DataSource = NMarca.Listar_Marca_X_Tipo_Equipo(ID_Tipo_Equipo);
      ddl_marca_reg.DataTextField = "DESCRIPCION";
      ddl_marca_reg.DataValueField = "ID";
      ddl_marca_reg.DataBind();
      ddl_marca_reg.Items.Insert(0, new ListItem("SELECCIONE", "0"));

      int csmr = ddl_marca_reg.Items.Count;
      ddl_marca_reg.Items.Insert(csmr, new ListItem("OTRO", "17"));
    }

    protected void DDL_marca_reg_SelectedIndexChanged(object sender, EventArgs e)
    {
      int csmr = ddl_marca_reg.Items.Count - 1;

      if (ddl_marca_reg.SelectedIndex == csmr)
      {
        otro_marca_equipo.Visible = true;
      }
      else
      {
        otro_marca_equipo.Visible = false;
      }
    }

    protected void btn_Equipo_Agregar_Click(object sender, EventArgs e)
    {
      double valdouble;

      if (ddl_tipo_equipo_reg.SelectedItem.Text.Equals("SELECCIONE"))
      {
        labelerror.Text = "ADVERTENCIA: Debe selecionar un tipo de equipo";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }
      else if (cod_equipo_reg.Text.Length == 0)
      {
        labelerror.Text = "ADVERTENCIA: El campo codigo del equipo no puede estar vacio";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }
      else if (nombe_equipo_reg.Text.Length == 0)
      {
        labelerror.Text = "ADVERTENCIA: El campo nombre no puede estar vacio";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }
      else if (ddl_marca_reg.SelectedItem.Text.Equals("SELECCIONE"))
      {
        labelerror.Text = "ADVERTENCIA: Debe selecionar una marca de equipo";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }
      else if (ddl_marca_reg.SelectedItem.Text.Equals("OTRO") && otro_marca_equipo_reg.Text.Length == 0)
      {
        labelerror.Text = "ADVERTENCIA: El campo marca de equipo no puede estar vacio";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }
      else if (precio_reg.Text.Length == 0)
      {
        labelerror.Text = "ADVERTENCIA: El campo precio no puede estar vacio";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }
      else if (!double.TryParse(precio_reg.Text, out valdouble))
      {
        labelerror.Text = "ADVERTENCIA: Debe ingresar valor real ";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }
      else if (precio_reg.Text.IndexOf('.') != -1)
      {
        labelerror.Text = "ADVERTENCIA: El campo precio no permite puntos, solo comas.";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }
      else if (double.Parse(precio_reg.Text) <= 0)
      {
        labelerror.Text = "ADVERTENCIA: El campo precio no puede ser negativo o 0";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }
      else if (double.Parse(precio_reg.Text) > 400.00)
      {
        labelerror.Text = "ADVERTENCIA: Precio Maximo de Alquiler es de 400.00";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }
      else if (double.Parse(precio_reg.Text) < 20.00)
      {
        labelerror.Text = "ADVERTENCIA: Precio Minimo de Alquiler es de 20.00";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }
      else if (cod_equipo_reg.Text.Length <= 5)
      {
        labelerror.Text = "ADVERTENCIA: El campo codigo de equipo debe tener mas de 5 caracteres";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }
      else
      {
        if (Validad_Codigo_Equipo(cod_equipo_reg.Text))
        {
          DO_Equipo DOE = new DO_Equipo();

          int ID_Tipo_Equipo = int.Parse(ddl_tipo_equipo_reg.SelectedValue);
          string codigoequipo = cod_equipo_reg.Text;
          string nombre = nombe_equipo_reg.Text;
          int ID_Marca = int.Parse(ddl_marca_reg.SelectedValue);
          string otroequipo = otro_marca_equipo_reg.Text;
          double precio = double.Parse(precio_reg.Text);

          DOE.ID_Marca_Equipo = ID_Marca;
          DOE.ID_Tipo_Equipo = ID_Tipo_Equipo;
          DOE.Codigo_Equipo = codigoequipo;
          DOE.Nombre_Equipo = nombre;
          DOE.Precio_Equipo = precio;

          if (ID_Marca == 17)
          {
            DOE.Otro_Equipo = otroequipo;
          }
          else
          {
            DOE.Otro_Equipo = "";
          }

          string arreglo = NEquipo.Registrar_Equipo(DOE);

          string[] array = arreglo.Split(new string[] { "|" }, StringSplitOptions.None);
          string id = array[0];
          string tipoequipo = array[1];
          string marcaequipo = array[2];
          string otroquipo = array[3];

          var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);

          string path = outPutDirectory;
          path = path.Replace("file:\\", "");
          path = path.Replace("\\bin", "");

          var Pathr = Path.Combine(path, "Imagenes\\Equipos");//rutacarpeta

          string ruta = "";
          string rutaalt = "";
          string archivoubicacion = "";

          if (otroequipo == "")
          {
            ruta = Pathr + "\\" + tipoequipo + "\\" + marcaequipo;
            rutaalt = tipoequipo + "/" + marcaequipo + "/";
          }
          else
          {
            ruta = Pathr + "\\" + tipoequipo + "\\" + marcaequipo + "\\" + otroequipo;
            rutaalt = tipoequipo + "/" + marcaequipo + "/" + otroequipo + "/";
          }

          if (!Directory.Exists(ruta))
          {
            Directory.CreateDirectory(ruta);
          }

          if (FU_Equipo_Agregar.HasFile)
          {
            string fileName = Server.HtmlEncode(FU_Equipo_Agregar.FileName);
            string extension = System.IO.Path.GetExtension(fileName);

            string nombreequipo = tipoequipo + "_" + id + extension;

            archivoubicacion = "~/Imagenes/Equipos/" + rutaalt + nombreequipo;
            string archivoubicacionx = "~/Imagenes/Equipos/" + rutaalt;

            FU_Equipo_Agregar.SaveAs(Server.MapPath(archivoubicacion));

            ruta = ruta + "\\";

            DO_Imagen_Equipo DOIE = new DO_Imagen_Equipo();
            DOIE.ID_Equipo = Convert.ToInt32(id);
            DOIE.Nombre_Imagen_Equipo = nombreequipo;
            DOIE.Ruta_Imagen_Equipo = archivoubicacionx;

            NEquipo.Registrar_Imagen_Equipo(DOIE);

            LimpiarAgregarEquipo();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalEquipoRegistrado').modal('show');", true);
          }
          else
          {
            ruta = ruta + "\\";
            string nombreequipo = tipoequipo + "_" + id + ".jpg";
            string rutaimagennd = ruta + nombreequipo;

            Pathr = Pathr + "\\" + "Equipo_Sin_Imagen.jpg";
            // archivoubicacion = "~/Imagenes/Equipos/" + rutaalt;

            string rutax = "~/Imagenes/Equipos/";
            if (otroequipo == "")
            {
              rutax = rutax + tipoequipo + "/" + marcaequipo + "/";
            }
            else
            {
              rutax = rutax + tipoequipo + "/" + marcaequipo + "/" + otroequipo + "/";
            }

            File.Copy(Pathr, rutaimagennd);

            DO_Imagen_Equipo DOIE = new DO_Imagen_Equipo();
            DOIE.ID_Equipo = Convert.ToInt32(id);
            DOIE.Nombre_Imagen_Equipo = nombreequipo;
            DOIE.Ruta_Imagen_Equipo = rutax;

            NEquipo.Registrar_Imagen_Equipo(DOIE);

            LimpiarAgregarEquipo();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalEquipoRegistrado').modal('show');", true);
          }
        }
      }
    }

    public bool Validad_Codigo_Equipo(string codigoequipo)
    {
      DO_Equipo DOE = new DO_Equipo();
      DOE.Codigo_Equipo = codigoequipo;
      DataRow Fila = NEquipo.Validar_Codigo_Equipo(DOE).Rows[0];
      if (Fila[0].ToString() != "0")
      {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
        labelerror.Text = "Ya hay un Equipo con ese codigo";
        return false;
      }
      return true;
    }

    public void LimpiarAgregarEquipo()
    {
      ddl_tipo_equipo_reg.SelectedIndex = 0;
      cod_equipo_reg.Text = "";
      nombe_equipo_reg.Text = "";
      ddl_marca_reg.Items.Clear();
      otro_marca_equipo_reg.Text = "";
      precio_reg.Text = "";
    }
  }
}
