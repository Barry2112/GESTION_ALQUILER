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
    public class N_Trabajador
    {
        DAO_Trabajador _Dat = new DAO_Trabajador();

        public DataTable Cargar_Trabajadores()
        {
            return _Dat.Cargar_Trabajadores();
        }

        public DataTable Mostrar_Tipo_Equipo_Asignados(int ID_Trabajador)
        {
            return _Dat.Mostrar_Tipo_Equipo_Asignados(ID_Trabajador);
        }

        public DataTable Mostrar_Tipo_Equipo_No_Asignados(int ID_Trabajador)
        {
            return _Dat.Mostrar_Tipo_Equipo_No_Asignados(ID_Trabajador);
        }

        public void Registrar_Asignacion_Equipo_Trabajador(int ID_Trabajador, int ID_Equipo, int ID_Tipo_Equipo)
        {
            _Dat.Registrar_Asignacion_Equipo_Trabajador(ID_Trabajador, ID_Equipo, ID_Tipo_Equipo);
        }

        public void Eliminar_Registro_Asignacion_Equipo_Trabajador(int ID_Trabajador, int ID_Tipo_Equipo)
        {
            _Dat.Eliminar_Registro_Asignacion_Equipo_Trabajador(ID_Trabajador, ID_Tipo_Equipo);

        }
    }
}
