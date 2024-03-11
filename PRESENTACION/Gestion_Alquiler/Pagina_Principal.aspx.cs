using DOMINIO;
using NEGOCIO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRESENTACION.Gestion_Alquiler
{
  public partial class Pagina_Principal : System.Web.UI.Page
  {
    N_Dashboard NDashboard = new N_Dashboard();

    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack)
      {
        cargarDatosGeneralesDashboard();
        cargarEventosPorTipoDonut();
      }
      else
      {

      }

    }

    public void cargarDatosGeneralesDashboard()
    {
      DataTable n = NDashboard.Dashboard_Datos_Principales();
      DO_Dashboard dashboard = new DO_Dashboard();
      dashboard.total_cotizaciones = Int32.Parse(n.Rows[0][0].ToString());
      dashboard.total_cotizaciones_mes = Int32.Parse(n.Rows[0][1].ToString());
      dashboard.total_cotizaciones_anio = Int32.Parse(n.Rows[0][2].ToString());
      dashboard.total_incidencias = Int32.Parse(n.Rows[0][3].ToString());
      dashboard.total_incidencias_mes = Int32.Parse(n.Rows[0][4].ToString());
      dashboard.total_incidencias_anio = Int32.Parse(n.Rows[0][5].ToString());
      dashboard.total_equipos = Int32.Parse(n.Rows[0][6].ToString());
      dashboard.total_eventos = Int32.Parse(n.Rows[0][7].ToString());
      dashboard.total_eventos_mes = Int32.Parse(n.Rows[0][8].ToString());
      dashboard.total_eventos_anio = Int32.Parse(n.Rows[0][9].ToString());

      txtCotizacionesCreadas.InnerText = dashboard.total_cotizaciones.ToString();
      txtCotizacionesCreadasMes.InnerText = dashboard.total_cotizaciones_mes.ToString();
      txtCotizacionesCreadasAnio.InnerText = dashboard.total_cotizaciones_anio.ToString();

      txtIncidenciasCreadas.InnerText = dashboard.total_incidencias.ToString();
      txtIncidenciasCreadasMes.InnerText = dashboard.total_incidencias_mes.ToString();
      txtIncidenciasCreadasAnio.InnerText = dashboard.total_incidencias_anio.ToString();

      txtEquiposRegistradosAnio.InnerText = dashboard.total_equipos.ToString();

      txtEventosRegistrados.InnerText = dashboard.total_eventos.ToString();
      txtEventosRegistradosMes.InnerText = dashboard.total_eventos_mes.ToString();
      txtEventosRegistradosAnio.InnerText = dashboard.total_eventos_anio.ToString();
    }

    public void cargarEventosPorTipoDonut()
    {
      DataTable n = NDashboard.Dashboard_EventosPorTipo();
      DataTable n2 = NDashboard.Dashboard_EventosPorEstado();
      DataTable n3 = NDashboard.Dashboard_EventosPorAnio();

      int tamañoMaximoEventosAnio = new int();

      for (int i = 0; i < n.Rows.Count; i++)
      {
        ClientScript.RegisterArrayDeclaration("listaEventosTipo", "'" + n.Rows[i][0].ToString() + "'");
        ClientScript.RegisterArrayDeclaration("listaEventosTipoCantidad", n.Rows[i][1].ToString());
      }

      for (int i = 0; i < n2.Rows.Count; i++)
      {
        ClientScript.RegisterArrayDeclaration("listaEventosEstado", "'" + n2.Rows[i][0].ToString() + "'");
        ClientScript.RegisterArrayDeclaration("listaEventosEstadoCantidad", n2.Rows[i][1].ToString());
      }

      for (int i = 0; i < n3.Rows.Count; i++)
      {
        ClientScript.RegisterArrayDeclaration("listaEventosAnio", "'" + n3.Rows[i][0].ToString() + "'");
        ClientScript.RegisterArrayDeclaration("listaEventosAnioCantidad", "'" + n3.Rows[i][1].ToString() + "'");

        if (i == 0)
        {
          tamañoMaximoEventosAnio = int.Parse(n3.Rows[i][1].ToString());
        }
        else
        {
          if (tamañoMaximoEventosAnio < int.Parse(n3.Rows[i][1].ToString()))
          {
            tamañoMaximoEventosAnio = int.Parse(n3.Rows[i][1].ToString());
          }
        }
      }

      Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "cargarDatosEventos("+ tamañoMaximoEventosAnio + ")", true);
    }


  }
}
