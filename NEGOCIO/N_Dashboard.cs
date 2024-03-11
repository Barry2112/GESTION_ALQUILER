using ACCESO_DATOS;
using DOMINIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEGOCIO
{
    public class N_Dashboard
    {
        DAO_Dashboard _DAO = new DAO_Dashboard();

        public DataTable Dashboard_Datos_Principales()
        {
            return _DAO.Dashboard_Datos_Principales();
        }
        public DataTable Dashboard_EventosPorEstado()
        {
            return _DAO.Dashboard_EventosPorEstado();
        }
        public DataTable Dashboard_EventosPorTipo()
        {
            return _DAO.Dashboard_EventosPorTipo();
        }
        public DataTable Dashboard_EventosPorAnio()
        {
            return _DAO.Dashboard_EventosPorAnio();
        }
    }
}
