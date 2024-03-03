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
    public class N_Tipo_Equipo
    {
        DAO_Tipo_Equipo _Dat = new DAO_Tipo_Equipo();

        public DataTable Listar_Tipo_Equipo()
        {
            return _Dat.Listar_Tipo_Equipo();
        }
    }
}
