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
    public class N_Equipo_Incidencia
    {
        DAO_Equipo_Incidencia _Dat = new DAO_Equipo_Incidencia();

        public DataTable Listar_Estados_Equipo_Incidencia()
        {
            return _Dat.Listar_Estados_Equipo_Incidencia();
        }
        public DataTable Obtener_Incidencias_Equipos(int ID_Tipo_Equipo, int ID_Equipo, int ID_Estado_Equipo_Incidencia)
        {
            return _Dat.Obtener_Incidencias_Equipos(ID_Tipo_Equipo, ID_Equipo, ID_Estado_Equipo_Incidencia);
        }
        public DataTable Obtener_Incidencia_Por_ID(int ID_Equipo_Incidencia)
        {
            return _Dat.Obtener_Incidencia_Por_ID(ID_Equipo_Incidencia);
        }
        public string Modificar_Incidencia_de_Equipo(DO_Equipo_Incidencia DOI)
        {
            return _Dat.Modificar_Incidencia_de_Equipo(DOI);
        }
        public DataTable Obtener_Logs_de_Incidencias_Equipos(int ID_Equipo_Incidencia)
        {
            return _Dat.Obtener_Logs_de_Incidencias_Equipos(ID_Equipo_Incidencia);
        }

    }
}
