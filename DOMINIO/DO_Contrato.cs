using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMINIO
{
    public class DO_Contrato
    {
        public int ID_Contrato { get; set; }
        public int ID_Evento { get; set; }
        public byte[] Contrato { get; set; }
    }
}
