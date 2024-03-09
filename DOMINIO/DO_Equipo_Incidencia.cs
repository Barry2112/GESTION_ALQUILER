using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMINIO
{
    public class DO_Equipo_Incidencia
    {
        public int ID_Equipo_Incidencia { get; set; }
        public int ID_Equipo { get; set; }
        public int? ID_Evento { get; set; }
        public string Descripcion { get; set; }
        public int ID_Estado_Equipo_Incidencia { get; set; }
        public DateTime? Fecha_Creacion { get; set; }
        public DateTime? Fecha_Resolución { get; set; }
        public string Comentario { get; set; }
    }
}
