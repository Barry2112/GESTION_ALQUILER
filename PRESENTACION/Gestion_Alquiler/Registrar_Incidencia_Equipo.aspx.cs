using DOMINIO;
using NEGOCIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRESENTACION.Gestion_Alquiler
{
  public partial class Registrar_Incidencia_Equipo : System.Web.UI.Page
  {
    N_Equipo NEquipo = new N_Equipo();
    N_Tipo_Equipo NTipoEquipo = new N_Tipo_Equipo();
    N_Equipo_Incidencia NEquipoIncidencia = new N_Equipo_Incidencia();
    N_Evento NEvento = new N_Evento();
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack)
      {
        //ON INIT
        string ID_Incidencia_Aux = Request.QueryString["id_incidencia"];
        string ID_Evento_Aux = Request.QueryString["id_evento"];
        if (string.IsNullOrEmpty(ID_Incidencia_Aux) || string.IsNullOrEmpty(ID_Evento_Aux))
        {
          Response.Redirect("~/Gestion_Alquiler/Gestionar_Incidencias_Equipos.aspx");
        }
        else
        {
          if (ID_Incidencia_Aux == "0")
          {
            //REGISTRO DE NUEVO EQUIPO
            LabelTitulo.Text = "REGISTRAR INCIDENCIA DE EQUIPO";
            Llenar_Tipo_Equipo();
            Llenar_Estados_Incidencias_Equipo();
            Llenar_Lista_Equipos();
            btn_Registrar_Editar.Text = "Registrar nueva incidencia";
            DDL_Estados_Incidencias_Equipo_Registro.SelectedValue = "1";//CREAR
            DDL_Estados_Incidencias_Equipo_Registro.Enabled = false;
            Session["ID_Incidencia_Principal"] = 0;

            divFechas.Visible = false;
            divLogsIncidencias.Visible = false;

            //CARGO EVENTO ASOCIADO POR URL
            if (ID_Evento_Aux == "0")
            {
              //NO CARGA DATOS DEL EVENTO
              Session["ID_Evento_Principal"] = 0;
              datosEventoDIV.Visible = false;
            }
            else
            {
              //CARGA DATOS DEL EVENTO
              Session["ID_Evento_Principal"] = ID_Evento_Aux;
              datosEventoDIV.Visible = true;
              obtenerEvento(int.Parse(Session["ID_Evento_Principal"].ToString()));
            }
          }
          else
          {
            //EDICIÓN DE EQUIPO
            Session["ID_Incidencia_Principal"] = int.Parse(ID_Incidencia_Aux);
            LabelTitulo.Text = "EDITAR INCIDENCIA DE EQUIPO";
            Llenar_Tipo_Equipo();
            Llenar_Estados_Incidencias_Equipo();
            Llenar_Lista_Equipos();
            btn_Registrar_Editar.Text = "Editar la incidencia";
            DDL_Estados_Incidencias_Equipo_Registro.Enabled = true;
            divFechas.Visible = true;
            divLogsIncidencias.Visible = true;

            //CARGA LOGS DE EQUIPOS
            GV_Logs_Incidencias.AutoGenerateColumns = false;
            GV_Logs_Incidencias.DataSource = NEquipoIncidencia.Obtener_Logs_de_Incidencias_Equipos(int.Parse(Session["ID_Incidencia_Principal"].ToString()));
            GV_Logs_Incidencias.DataBind();
            
            DDL_Equipos_Incidencias_Registro.Enabled = false;
            DDL_Listar_Tipo_Equipos_Registro.Enabled = false;
            obtenerIncidencia();
          }
        }
      }
    }

    public void Llenar_Tipo_Equipo()
    {
      DDL_Listar_Tipo_Equipos_Registro.DataSource = NTipoEquipo.Listar_Tipo_Equipo();
      DDL_Listar_Tipo_Equipos_Registro.DataTextField = "DESCRIPCION";
      DDL_Listar_Tipo_Equipos_Registro.DataValueField = "ID";
      DDL_Listar_Tipo_Equipos_Registro.DataBind();
      DDL_Listar_Tipo_Equipos_Registro.Items.Insert(0, new ListItem("Todos", "0"));
    }
    public void Llenar_Estados_Incidencias_Equipo()
    {
      DDL_Estados_Incidencias_Equipo_Registro.DataSource = NEquipoIncidencia.Listar_Estados_Equipo_Incidencia();
      DDL_Estados_Incidencias_Equipo_Registro.DataTextField = "Estado";
      DDL_Estados_Incidencias_Equipo_Registro.DataValueField = "ID_Estado_Equipo_Incidencia";
      DDL_Estados_Incidencias_Equipo_Registro.DataBind();
      DDL_Estados_Incidencias_Equipo_Registro.Items.Insert(0, new ListItem("Seleccione", "0"));
    }
    public void Llenar_Lista_Equipos()
    {
      DDL_Equipos_Incidencias_Registro.DataSource = NEquipo.Listar_Equipos_por_Tipo((int.Parse(DDL_Listar_Tipo_Equipos_Registro.SelectedValue)));
      DDL_Equipos_Incidencias_Registro.DataTextField = "Codigo_Equipo";
      DDL_Equipos_Incidencias_Registro.DataValueField = "ID_Equipo";
      DDL_Equipos_Incidencias_Registro.DataBind();
      DDL_Equipos_Incidencias_Registro.Items.Insert(0, new ListItem("Seleccione", "0"));
    }
    protected void DDL_Listar_Tipo_Equipos_Registro_SelectedIndexChanged(object sender, EventArgs e)
    {
      Llenar_Lista_Equipos();
    }
    public void obtenerIncidencia()
    {
      DataTable dtIncidencia = NEquipoIncidencia.Obtener_Incidencia_Por_ID(int.Parse(Session["ID_Incidencia_Principal"].ToString()));

      if (dtIncidencia.Rows.Count > 0)
      {
        DataRow filaA = dtIncidencia.Rows[0];
        string ID_Evento_Aux;

        //0 es la id
        DDL_Equipos_Incidencias_Registro.SelectedValue = filaA[1].ToString(); //ID_Equipo
        ID_Evento_Aux = filaA[2].ToString();
        txtAreaDescripcion.InnerText = filaA[3].ToString(); //Descripcion
        txtFechaCreacion.Text = filaA[4].ToString(); //Fcreacion
        txtFechaResolucion.Text = filaA[5].ToString(); //Fresolucion
        txtAreaComentario.InnerText = filaA[6].ToString(); //Comentario
        DDL_Estados_Incidencias_Equipo_Registro.SelectedValue = filaA[7].ToString(); //ID_Estado
        DDL_Listar_Tipo_Equipos_Registro.SelectedValue = filaA[8].ToString(); //ID_Tipo_Equipo

        if(DDL_Estados_Incidencias_Equipo_Registro.SelectedValue == "4") {
          DDL_Estados_Incidencias_Equipo_Registro.Enabled = false;
        }

        //EVENTO OBTENIDO DE LA BD
        if (string.IsNullOrEmpty(ID_Evento_Aux))
        {
          //NO CARGA DATOS DEL EVENTO
          Session["ID_Evento_Principal"] = 0;
          datosEventoDIV.Visible = false;
        }
        else
        {
          //CARGA DATOS DEL EVENTO
          Session["ID_Evento_Principal"] = ID_Evento_Aux;
          datosEventoDIV.Visible = true;
          obtenerEvento(int.Parse(Session["ID_Evento_Principal"].ToString()));
        }
      }
    }

    public void obtenerEvento(int ID_Evento)
    {
      DataTable dtEvento = NEvento.Cargar_Evento_Por_ID(ID_Evento);

      if (dtEvento.Rows.Count > 0)
      {
        DataRow filaA = dtEvento.Rows[0];

        lvlDescripcionEvento.Text = filaA[1].ToString();
        lvlCliente.Text = filaA[2].ToString();
        lvlDNI.Text = filaA[3].ToString();
        lvlCorreo.Text = filaA[4].ToString();
        lvlCelular.Text = filaA[5].ToString();
        lvlFecha.Text = filaA[6].ToString();
        lvlEstadoEvento.Text = filaA[7].ToString();
      }
    }
    public void btn_Registrar_Editar_Click(object sender, EventArgs e)
    {
      //VALIDACIONES
      if (DDL_Equipos_Incidencias_Registro.SelectedIndex == 0)
      {
        labelerror.Text = "ADVERTENCIA: Debe selecionar un tipo de equipo.";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
        return;
      }
      if (DDL_Estados_Incidencias_Equipo_Registro.SelectedIndex == 0)
      {
        labelerror.Text = "ADVERTENCIA: Debe selecionar un estado para la incidencia.";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
        return;
      }
      if (txtAreaDescripcion.InnerText.Length == 0)
      {
        labelerror.Text = "ADVERTENCIA: Debe ingresar una descripción de la incidencia.";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalError').modal('show');", true);
        return;
      }

      //INSERT O UPDATE, ESTA COSA JALA PA AMBOS ;3
      DO_Equipo_Incidencia DOI = new DO_Equipo_Incidencia();
      DOI.ID_Equipo_Incidencia = int.Parse(Session["ID_Incidencia_Principal"].ToString());
      DOI.ID_Equipo = int.Parse(DDL_Equipos_Incidencias_Registro.SelectedValue);
      DOI.ID_Evento = int.Parse(Session["ID_Evento_Principal"].ToString()); //Si es que hay
      DOI.Descripcion = txtAreaDescripcion.InnerText;
      DOI.Comentario = txtAreaComentario.InnerText;
      DOI.ID_Estado_Equipo_Incidencia = int.Parse(DDL_Estados_Incidencias_Equipo_Registro.SelectedValue);

      string arreglo = NEquipoIncidencia.Modificar_Incidencia_de_Equipo(DOI);
      ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " $('#ModalIncidenciaModificada').modal('show');", true);
      Response.Redirect("~/Gestion_Alquiler/Gestionar_Incidencias_Equipos.aspx");
    }


  }
}
