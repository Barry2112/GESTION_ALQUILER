using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMINIO
{
    public class DO_Imagen_Usuario
    {
        public int ID_Imagen_Usuario { get; set; }
        public int ID_Usuario { get; set; }
        public string Nombre_Imagen_Usuario { get; set; }
        public string Ruta_Imagen_Usuario { get; set; }
    }
}
