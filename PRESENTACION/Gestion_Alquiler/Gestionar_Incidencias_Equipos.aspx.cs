using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DOMINIO;
using Microsoft.Win32;
using NEGOCIO;

namespace PRESENTACION.Gestion_Alquiler
{
  public partial class Gestionar_Incidencias_Equipo : System.Web.UI.Page
  {
    N_Equipo NEquipo = new N_Equipo();
    N_Tipo_Equipo NTipoEquipo = new N_Tipo_Equipo();
    N_Equipo_Incidencia NEquipoIncidencia = new N_Equipo_Incidencia();

    public void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack)
      {
        //ON INIT
        DIV_Principal.Visible = true;
        Llenar_Tipo_Equipo();
        Llenar_Lista_Equipos_Incidencia();
        Llenar_Estados_Incidencias_Equipo();

        buscarIncidenciasEquipos();
      }
    }
    public void DDL_Listar_Tipo_Equipos_SelectedIndexChanged(object sender, EventArgs e)
    {
      Llenar_Lista_Equipos_Incidencia();
    }

    public void Llenar_Tipo_Equipo()
    {
      DDL_Listar_Tipo_Equipos.DataSource = NTipoEquipo.Listar_Tipo_Equipo();
      DDL_Listar_Tipo_Equipos.DataTextField = "DESCRIPCION";
      DDL_Listar_Tipo_Equipos.DataValueField = "ID";
      DDL_Listar_Tipo_Equipos.DataBind();
      DDL_Listar_Tipo_Equipos.Items.Insert(0, new ListItem("Todos", "0"));
    }

    public void Llenar_Lista_Equipos_Incidencia()
    {
      DDL_Equipos_Incidencias.DataSource = NEquipo.Listar_Equipos_con_Incidencias((int.Parse(DDL_Listar_Tipo_Equipos.SelectedValue)));
      DDL_Equipos_Incidencias.DataTextField = "Codigo_Equipo";
      DDL_Equipos_Incidencias.DataValueField = "ID_Equipo";
      DDL_Equipos_Incidencias.DataBind();
      DDL_Equipos_Incidencias.Items.Insert(0, new ListItem("Todos", "0"));
    }

    public void Llenar_Estados_Incidencias_Equipo()
    {
      DDL_Estados_Incidencias_Equipo.DataSource = NEquipoIncidencia.Listar_Estados_Equipo_Incidencia();
      DDL_Estados_Incidencias_Equipo.DataTextField = "Estado";
      DDL_Estados_Incidencias_Equipo.DataValueField = "ID_Estado_Equipo_Incidencia";
      DDL_Estados_Incidencias_Equipo.DataBind();
      DDL_Estados_Incidencias_Equipo.Items.Insert(0, new ListItem("Todos", "0"));
    }

    public void btn_Buscar_Click(object sender, EventArgs e)
    {
      buscarIncidenciasEquipos();
    }

    public void buscarIncidenciasEquipos()
    {
      //BUSCA INCIDENCIAS DE EQUIPOS
      GV_Incidencias_Equipos.AutoGenerateColumns = false;
      GV_Incidencias_Equipos.DataSource = NEquipoIncidencia.Obtener_Incidencias_Equipos(
        int.Parse(DDL_Listar_Tipo_Equipos.SelectedValue),
        int.Parse(DDL_Equipos_Incidencias.SelectedValue),
        int.Parse(DDL_Estados_Incidencias_Equipo.SelectedValue)
      );
      GV_Incidencias_Equipos.DataBind();
    }

    public void btn_Registrar_GO_Click(object sender, EventArgs e)
    {
      Response.Redirect("~/Gestion_Alquiler/Registrar_Incidencia_Equipo.aspx?id_incidencia=0" + "&id_evento=" + 0);
    }
    public void GV_Incidencias_Equipos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      switch (e.CommandName)
      {
        case "EDITAR_INCIDENCIA":

          int rowIndex = int.Parse(e.CommandArgument.ToString());
          object obj = GV_Incidencias_Equipos.DataKeys[rowIndex][0];
          string idIncidencia = obj.ToString();
          int ID_Incidencia_Editar = int.Parse(idIncidencia);

          Response.Redirect("~/Gestion_Alquiler/Registrar_Incidencia_Equipo.aspx?id_incidencia=" + ID_Incidencia_Editar + "&id_evento=" + 0);
          break;
      }
    }

    public void TEST_Click(object sender, EventArgs e)
    {
      Response.Redirect("~/Gestion_Alquiler/Registrar_Incidencia_Equipo.aspx?id_incidencia=" + 0 + "&id_evento=" + 1);
    }
  }
}
