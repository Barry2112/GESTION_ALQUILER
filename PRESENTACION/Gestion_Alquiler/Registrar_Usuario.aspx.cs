using DOMINIO;
using NEGOCIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRESENTACION.Gestion_Alquiler
{
  public partial class Registrar_Usuario : System.Web.UI.Page
  {
    N_Usuario NUsuario = new N_Usuario();

    protected void Page_Load(object sender, EventArgs e)
    {  
    } 

    public bool Validar_Usuario_Registrado(string DNI, string Celular, string Correo)
    {
      DO_Usuario DOU = new DO_Usuario();

      DOU.DNI = DNI;
      DOU.Celular = Celular;
      DOU.Correo = Correo;
       
      DataRow Fila = NUsuario.Validar_Usuario_Registrado(DOU).Rows[0];
      if (Fila[0].ToString() == "1")
      {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
        labelerror.Text = "Ya hay un usuario con ese DNI registrado";
        return false;
      }
      else if (Fila[0].ToString() == "2")
      {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
        labelerror.Text = "Ya hay un usuario con ese celular registrado";
        return false;
      }
      else if (Fila[0].ToString() == "3")
      {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
        labelerror.Text = "Ya hay un usuario con ese correo registrado";
        return false;
      }
      else
      {
        return true;
      }
    }

    public void LimpiarRegistrar_Usuario()
    {
      txt_nombre.Text = "";
      txt_apellido.Text = "";
      txt_dni.Text = "";
      txt_celular.Text = "";
      txt_direccion.Text = "";
      txt_correo.Text = "";
      txt_contra.Text = "";
      txt_contrase_validar.Text = "";
      FU_Imagen_Usuario.Dispose();
    }

    protected void btn_Registrar_Usuario_Click(object sender, EventArgs e)
    {
      if (txt_nombre.Text.Equals(""))
      {
        labelerror.Text = "ADVERTENCIA: El campo nombre no puede estar vacio";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }

      else if (txt_apellido.Text.Equals(""))
      {
        labelerror.Text = "ADVERTENCIA: El campo apellido no puede estar vacio";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }

      else if (txt_dni.Text.Equals(""))
      {
        labelerror.Text = "ADVERTENCIA: El campo DNI no puede estar vacio";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }

      else if (txt_celular.Text.Equals(""))
      {
        labelerror.Text = "ADVERTENCIA: El campo celular no puede estar vacio";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }

      else if (txt_direccion.Text.Equals(""))
      {
        labelerror.Text = "ADVERTENCIA: El campo direccion no puede estar vacio";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }

      else if (txt_correo.Text.Equals(""))
      {
        labelerror.Text = "ADVERTENCIA: El campo correo no puede estar vacio";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }

      else if (txt_contra.Text.Equals(""))
      {
        labelerror.Text = "ADVERTENCIA: El campo contraseña no puede estar vacio";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }

      else if (txt_dni.Text.Length != 8)
      {
        labelerror.Text = "ADVERTENCIA: El campo DNI debe contener 8 digitos";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }

      else if (txt_celular.Text.Length != 9)
      {
        labelerror.Text = "ADVERTENCIA: El campo celular debe contener 9 digitos";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }

      else if (txt_contra.Text != txt_contrase_validar.Text)
      {
        labelerror.Text = "ADVERTENCIA: Las contraseñas debe de coincidir";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
      }

      else
      {
        if (Validar_Usuario_Registrado(txt_dni.Text, txt_celular.Text, txt_correo.Text))
        {
          DO_Usuario DOU = new DO_Usuario();
          DO_Imagen_Usuario DOIU = new DO_Imagen_Usuario();

          DOU.ID_Tipo_Usuario = 1;
          DOU.Nombres = txt_nombre.Text;
          DOU.Apellidos = txt_apellido.Text;
          DOU.DNI = txt_dni.Text;
          DOU.Celular = txt_celular.Text;
          DOU.Direccion = txt_direccion.Text;
          DOU.Correo = txt_correo.Text;
          DOU.Contraseña = txt_contra.Text;

          string nombreimg = NUsuario.Registrar_Usuario(DOU);

          string[] array = nombreimg.Split(new string[] { "_" }, StringSplitOptions.None);
          string id = array[3];

          var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
          string path = outPutDirectory; 
          path = path.Replace("file:\\", "");
          path = path.Replace("\\bin", "");
          //rutacarpeta
          var Pathr = Path.Combine(path, "Imagenes\\Usuarios");

          if (!Directory.Exists(Pathr))
          {
            Directory.CreateDirectory(Pathr);
          }

          if (FU_Imagen_Usuario.HasFile)
          {
            string fileName = Server.HtmlEncode(FU_Imagen_Usuario.FileName);
            string extension = System.IO.Path.GetExtension(fileName);

            string nombreimagen = nombreimg + extension;
             
            string archivoubicacion = "~/Imagenes/Usuarios/" + nombreimagen;
            string rutaimagen = "~/Imagenes/Usuarios/";

            FU_Imagen_Usuario.SaveAs(Server.MapPath(archivoubicacion));
             
            Pathr = Pathr + "\\";
             
            DOIU.ID_Usuario = Convert.ToInt32(id);
            DOIU.Nombre_Imagen_Usuario = nombreimagen;
            DOIU.Ruta_Imagen_Usuario = rutaimagen;

            NUsuario.Registrar_Imagen_Usuario(DOIU);
             
            Response.Redirect("Iniciar_Sesion.aspx");
          }
          else
          {
            Pathr = Pathr + "\\";

            string nombreimagen = nombreimg +"_"+ id + ".jpg"; 
            string rutaimagennd = Pathr + nombreimagen;

            Pathr = Pathr + "\\" + "Usuario_Sin_Imagen.jpg";
            // archivoubicacion = "~/Imagenes/Equipos/" + rutaalt;

            string rutax = "~/Imagenes/Usuarios/"; 

            File.Copy(Pathr, rutaimagennd);
             
            DOIU.ID_Usuario = Convert.ToInt32(id);
            DOIU.Nombre_Imagen_Usuario = nombreimagen;
            DOIU.Ruta_Imagen_Usuario = rutax;

            NUsuario.Registrar_Imagen_Usuario(DOIU);

            Response.Redirect("Iniciar_Sesion.aspx");
          }
          //LimpiarRegistrar_Usuario();
        } 
      }
    }

    protected void Ir_Login(object sender, EventArgs e)
    {
      Response.Redirect("Iniciar_Sesion.aspx");
    }
  }
}
