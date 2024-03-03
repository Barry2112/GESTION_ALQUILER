using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ACCESO_DATOS;
using DOMINIO;

namespace NEGOCIO
{
    public class N_Tipo_Evento
    {
        DAO_Tipo_Evento _Dat = new DAO_Tipo_Evento();

        public DataTable Listar_Tipo_Evento()
        {
            return _Dat.Listar_Tipo_Evento();
        }
    }
}
