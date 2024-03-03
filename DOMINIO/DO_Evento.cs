using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMINIO
{
    public class DO_Evento
    {
        public int ID_Evento { get; set; }
        public int ID_Estado_Evento { get; set; }
        public int ID_Tipo_Evento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; } 
        public string DNI { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set; }
        public DateTime Fecha { get; set; }
        public string Direccion { get; set; }
        public string Direccion_Evento { get; set; }
        public string Detalles { get; set; }
        public string Otro_Evento { get; set; }
    }
}
