using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMINIO
{
    public class DO_Boleta
    {
        public int ID_Boleta { get; set; }
        public int ID_Evento { get; set; }
        public byte[] Boleta { get; set; }
    }
}
