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
    public class N_Evento
    {
        DAO_Evento _Dat = new DAO_Evento();

        public void RegistrarSolicitudEvento(DO_Evento DOE)
        {
            _Dat.RegistrarSolicitudEvento(DOE);
        }

        public DataTable Cargar_Solicitud_Evento()
        {
            return _Dat.Cargar_Solicitud_Evento();
        }

        public DataTable Cargar_Solicitud_Evento_X_Tipo_Evento(DO_Evento DOE)
        {
            return _Dat.Cargar_Solicitud_Evento_X_Tipo_Evento(DOE);
        }

        public DataTable Cargar_Solicitud_Evento_X_Fecha(DateTime fechaini, DateTime fechafin)
        {
            return _Dat.Cargar_Solicitud_Evento_X_Fecha(fechaini, fechafin);
        }

        public DataTable Atender_Solicitud_Evento(int ID_Evento)
        {
            return _Dat.Atender_Solicitud_Evento(ID_Evento);
        }

        public void AprobarSolicitudEvento(DO_Evento DOE)
        {
            _Dat.AprobarSolicitudEvento(DOE);
        }

        public void SolicitudEventoEditado(DO_Evento DOE)
        {
            _Dat.SolicitudEventoEditado(DOE);
        }

            public void Insertar_Evento_X_Tipo_Equipo(int ID_Evento, int ID_Tipo_Equipo, int Cantidad)
        {
            _Dat.Insertar_Evento_X_Tipo_Equipo(ID_Evento, ID_Tipo_Equipo, Cantidad);
        }

        public DataTable Cargar_Evento()
        {
            return _Dat.Cargar_Evento();
        }

        public DataTable Ver_Tipo_Equipos_Solicitados(int ID_Evento)
        {
            return _Dat.Ver_Tipo_Equipos_Solicitados(ID_Evento);
        }

        public DataSet Cargar_Trabajador_Disponible(int ID_Evento, int ID_Tipo_Equipo)
        {
            return _Dat.Cargar_Trabajador_Disponible(ID_Evento, ID_Tipo_Equipo);
        }

        public void Actualizar_Cant_Tipo_Equipo_X_Evento(int ID_Evento, int ID_Tipo_Equipo)
        {
            _Dat.Actualizar_Cant_Tipo_Equipo_X_Evento(ID_Evento, ID_Tipo_Equipo);
        }

        public void Registrar_Evento_X_Trabajador_X_Equipo(int ID_Evento, int ID_Trabajador, int ID_Tipo_Equipo, int ID_Equipo, DateTime Fecha)
        {
            _Dat.Registrar_Evento_X_Trabajador_X_Equipo(ID_Evento, ID_Trabajador, ID_Tipo_Equipo, ID_Equipo, Fecha);
        }

        public void Aprobar_Evento(int ID_Evento)
        {
            _Dat.Aprobar_Evento(ID_Evento);
        }

        public void Organizar_Evento(int ID_Evento)
        {
            _Dat.Organizar_Evento(ID_Evento);
        }

        public void Guardar_Boleta(int ID_Evento, DO_Boleta DOB)
        {
            _Dat.Guardar_Boleta(ID_Evento, DOB);
        }

        public DataTable Obtener_ID_Cotizacion()
        {
            return _Dat.Obtener_ID_Cotizacion();
        }

        public void Registrar_Cotizacion(int ID_Cotizacion, int ID_Tipo_Equipo, int ID_Equipo)
        {
            _Dat.Registrar_Cotizacion(ID_Cotizacion, ID_Tipo_Equipo, ID_Equipo);
        }

        public void Guardar_Reporte_Cotizacion(int ID_Cotizacion, DO_Reporte_Cotizacion DORC)
        {
            _Dat.Guardar_Reporte_Cotizacion(ID_Cotizacion, DORC);
        }

        public DataTable Cargar_Cotizacion()
        {
            return _Dat.Cargar_Cotizacion();
        }

        public DataTable Cargar_Evento_Organizado()
        {
            return _Dat.Cargar_Evento_Organizado();
        }

        public void Registrar_Nota_Credito(int ID_Nota_Credito, DO_Nota_Credito DONC)
        {
            _Dat.Registrar_Nota_Credito(ID_Nota_Credito, DONC);
        }

        public void Guardar_Contrato(int ID_Evento, DO_Contrato DOC)
        {
            _Dat.Guardar_Contrato(ID_Evento, DOC);
        }

        public void Evento_Satisfecho(int ID_Evento)
        {
            _Dat.Evento_Satisfecho(ID_Evento);
        }


        public void Evento_Eliminado(int ID_Evento) 
        {

            _Dat.Evento_Eliminado(ID_Evento);
        }
    }
}
