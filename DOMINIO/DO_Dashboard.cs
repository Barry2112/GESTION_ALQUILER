using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMINIO
{
    public class DO_Dashboard
    {
        public int total_cotizaciones { get; set; }
        public int total_cotizaciones_mes { get; set; }
        public int total_cotizaciones_anio { get; set; }
        public int total_incidencias { get; set; }
        public int total_incidencias_mes { get; set; }
        public int total_incidencias_anio { get; set; }
        public int total_equipos { get; set; }
        public int total_eventos { get; set; }
        public int total_eventos_mes { get; set; }
        public int total_eventos_anio { get; set; }
    }

    public class DO_EventoTipoDashboard
    {
        public string tipo_evento { get; set; }
        public int cantidad { get; set; }
    }

    public class DO_EventoEstadoDashboard
    {
        public string estado_evento { get; set; }
        public int cantidad { get; set; }
    }
}
