using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMINIO
{
    public class DO_Equipo
    {
        public int ID_Equipo { get; set; }
        public int ID_Tipo_Equipo { get; set; }
        public int ID_Estado_Equipo { get; set; }
        public int ID_Marca_Equipo { get; set; }
        public string Codigo_Equipo { get; set; }
        public string Nombre_Equipo { get; set; }
        public double Precio_Equipo { get; set; }
        public string Otro_Equipo { get; set; }
    }
}
