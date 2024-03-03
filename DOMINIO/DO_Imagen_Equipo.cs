using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMINIO
{
    public class DO_Imagen_Equipo
    {
        public int ID_Imagen_Equipo { get; set; }
        public int ID_Equipo { get; set; }
        public string Nombre_Imagen_Equipo { get; set; }
        public string Ruta_Imagen_Equipo { get; set; }
    }
}
