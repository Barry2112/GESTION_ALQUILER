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
    public class N_Equipo
    {
        DAO_Equipo _Dat = new DAO_Equipo();

        public string Registrar_Equipo(DO_Equipo DOE)
        {
            return _Dat.Registrar_Equipo(DOE);
        }

        public DataTable Validar_Codigo_Equipo(DO_Equipo DOE)
        {
            return _Dat.Validar_Codigo_Equipo(DOE);
        }

        public void Registrar_Imagen_Equipo(DO_Imagen_Equipo DOIE)
        {
            _Dat.Registrar_Imagen_Equipo(DOIE);
        }

        public DataTable Consultar_Equipo(int ID_Tipo_Equipo)
        {
            return _Dat.Consultar_Equipo(ID_Tipo_Equipo);
        }

        public DataTable ObtenerDetallesEquipo(int ID_Equipo)
        {
            return _Dat.ObtenerDetallesEquipo(ID_Equipo);
        }


        public DataTable ObtenerDetallesEquipoEditar(int ID_Equipo)
        {
            return _Dat.ObtenerDetallesEquipoEditar(ID_Equipo);
        }

        public DataTable Obtener_Equipo_X_Tipo_Equipo(int ID_Tipo_Equipo)
        {
            return _Dat.Obtener_Equipo_X_Tipo_Equipo(ID_Tipo_Equipo);
        }

        public DataTable Obtener_Codigo_Equipo_X_Tipo_Equipo_Agregar(int ID_Tipo_Equipo, int ID_Trabajador)
        {
            return _Dat.Obtener_Codigo_Equipo_X_Tipo_Equipo_Agregar(ID_Tipo_Equipo, ID_Trabajador);
        }

        public DataTable Obtener_Codigo_Equipo_X_Tipo_Equipo_Quitar(int ID_Tipo_Equipo, int ID_Trabajador)
        {
            return _Dat.Obtener_Codigo_Equipo_X_Tipo_Equipo_Quitar(ID_Tipo_Equipo, ID_Trabajador);
        }

        public DataTable Obtener_Detalles_Equipo_Agregar_X_Quitar_Asignacion(int ID_Equipo)
        {
            return _Dat.Obtener_Detalles_Equipo_Agregar_X_Quitar_Asignacion(ID_Equipo);
        }

        public DataTable Obtener_Detalles_Equipo_Quitar_Asignacion(int ID_TRABAJADOR, int ID_TIPO_EQUIPO)
        {
            return _Dat.Obtener_Detalles_Equipo_Quitar_Asignacion(ID_TRABAJADOR, ID_TIPO_EQUIPO);
        }

        public void Editar_Equipo(DO_Equipo DOE)
        {
            _Dat.Editar_Equipo(DOE);
        }

        public DataTable Listar_Codigo_Equipo_X_ID_Tipo_Equipo(int ID_Tipo_Equipo)
        {
            return _Dat.Listar_Codigo_Equipo_X_ID_Tipo_Equipo(ID_Tipo_Equipo);
        }

        public DataTable ObtenerDetallesxCodigoEquipo(string Codigo_Equipo)
        {
            return _Dat.ObtenerDetallesxCodigoEquipo(Codigo_Equipo);
        }

        public void Eliminar_Equipo(int ID_Equipo)
        {
            _Dat.Eliminar_Equipo(ID_Equipo);
        }

        public DataTable Consultar_Equipo_Asignados(int ID_Trabajador)
        {
            return _Dat.Consultar_Equipo_Asignados(ID_Trabajador);
        }

        public DataTable Consultar_Equipo_Organizado(int ID_Trabajador)
        {
            return _Dat.Consultar_Equipo_Organizado(ID_Trabajador);
        }

        public DataTable Obtener_Detalles_Equipo_Incidencia(int ID_Equipo)
        {
            return _Dat.Obtener_Detalles_Equipo_Incidencia(ID_Equipo);
        }

        public void Registrar_Incidencia_Equipo(int ID_Equipo, int ID_Trabajador, string Detalles_Problema)
        {
            _Dat.Registrar_Incidencia_Equipo(ID_Equipo, ID_Trabajador, Detalles_Problema);
        }

        public DataTable Cargar_Incidencia_Equipos()
        {
            return _Dat.Cargar_Incidencia_Equipos();
        }
        public DataTable Obtener_Detalles_Gestionar_Equipo_Incidencia(int ID_Equipo)
        {
            return _Dat.Obtener_Detalles_Gestionar_Equipo_Incidencia(ID_Equipo);
        }

        public void Deshabilitar_Estado_Equipo(int ID_Equipo)
        {
            _Dat.Deshabilitar_Estado_Equipo(ID_Equipo);
        }

        public DataTable Deshabilitar_Equipo(int ID_Equipo)
        {
            return _Dat.Deshabilitar_Equipo(ID_Equipo);
        }

    }
}
