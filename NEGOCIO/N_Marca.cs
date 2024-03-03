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
    public class N_Marca
    {
        DAO_Marca _Dat = new DAO_Marca();

        public DataTable Listar_Marca_X_Tipo_Equipo(int ID_Tipo_Equipo)
        {
            return _Dat.Listar_Marca_X_Tipo_Equipo(ID_Tipo_Equipo);
        }

        public DataTable Listar_Marcas_ID_Equipo(int ID_Equipo)
        {
            return _Dat.Listar_Marcas_ID_Equipo(ID_Equipo);
        }
    }
}
