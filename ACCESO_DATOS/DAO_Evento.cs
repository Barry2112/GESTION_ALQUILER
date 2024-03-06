using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DOMINIO;

namespace ACCESO_DATOS
{
    public class DAO_Evento
    {
        SqlConnection _conn = new SqlConnection(Conexion_BD.Conexion());
        public void RegistrarSolicitudEvento(DO_Evento DOE)
        {
            try
            {
                SqlCommand _Com = new SqlCommand("SP_REGISTRAR_SOLICITUD_EVENTO", _conn);
                _Com.CommandType = System.Data.CommandType.StoredProcedure;
                _conn.Open();
                _Com.Parameters.AddWithValue("@ID_Tipo_Evento", DOE.ID_Tipo_Evento);
                _Com.Parameters.AddWithValue("@Nombres", DOE.Nombres);
                _Com.Parameters.AddWithValue("@Apellidos", DOE.Apellidos);
                _Com.Parameters.AddWithValue("@DNI", DOE.DNI);
                _Com.Parameters.AddWithValue("@Celular", DOE.Celular);
                _Com.Parameters.AddWithValue("@Correo", DOE.Correo);
                _Com.Parameters.AddWithValue("@Fecha", DOE.Fecha);
                _Com.Parameters.AddWithValue("@Direccion", DOE.Direccion);
                _Com.Parameters.AddWithValue("@Direccion_Evento", DOE.Direccion_Evento);
                _Com.Parameters.AddWithValue("@Detalles ", DOE.Detalles);
                _Com.Parameters.AddWithValue("@Otro_Tipo_Evento", DOE.Otro_Evento);
                _Com.ExecuteNonQuery();
                _conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Cargar_Solicitud_Evento()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand _comm = new SqlCommand("SP_CARGAR_SOLICITUD_EVENTO", _conn);
                _comm.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(_comm);
                sda.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Cargar_Solicitud_Evento_X_Tipo_Evento(DO_Evento DOE)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand _comm = new SqlCommand("SP_CARGAR_SOLICITUD_EVENTO_X_TIPO_EVENTO", _conn);
                _comm.CommandType = CommandType.StoredProcedure;
                _comm.Parameters.AddWithValue("@Tipo_Evento", DOE.ID_Tipo_Evento);
                SqlDataAdapter sda = new SqlDataAdapter(_comm);
                sda.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Cargar_Solicitud_Evento_X_Fecha(DateTime fecha1, DateTime fecha2)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand _comm = new SqlCommand("SP_CARGAR_SOLICITUD_EVENTO_X_FECHA", _conn);
                _comm.CommandType = CommandType.StoredProcedure;
                _comm.Parameters.AddWithValue("@Fechaini", fecha1);
                _comm.Parameters.AddWithValue("@Fechafin", fecha2);
                SqlDataAdapter sda = new SqlDataAdapter(_comm);
                sda.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Registrar_Evento_X_Tipo_Equipo(DO_Evento_X_Tipo_Equipo DOETE)
        {
            try
            {
                _conn.Open();
                SqlCommand _comm = new SqlCommand("SP_REGISTRAR_EVENTO_X_TIPO_EQUIPO", _conn);
                _comm.CommandType = CommandType.StoredProcedure;
                _comm.Parameters.AddWithValue("@ID_Evento", DOETE.ID_Evento);
                _comm.Parameters.AddWithValue("@ID_Tipo_Equipo", DOETE.ID_Tipo_Equipo);
                _comm.Parameters.AddWithValue("@Cantidad", DOETE.Cantidad);
                _comm.ExecuteNonQuery();
                _conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Atender_Solicitud_Evento(int ID_Evento)
        {
            try
            {
                DataSet _Ds = new DataSet();
                SqlCommand _comm = new SqlCommand("SP_ATENDER_SOLICITUD_EVENTO", _conn);
                _comm.CommandType = CommandType.StoredProcedure;
                _comm.Parameters.AddWithValue("@ID_EVENTO", ID_Evento);
                SqlDataAdapter sda = new SqlDataAdapter(_comm);
                sda.Fill(_Ds);
                return _Ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AprobarSolicitudEvento(DO_Evento DOE)
        {
            try
            {
                SqlCommand _Com = new SqlCommand("SP_APROBAR_SOLICITUD_EVENTO", _conn);
                _Com.CommandType = System.Data.CommandType.StoredProcedure;
                _conn.Open();
                _Com.Parameters.AddWithValue("@ID_Evento", DOE.ID_Evento);
                _Com.Parameters.AddWithValue("@ID_Tipo_Evento", DOE.ID_Tipo_Evento);
                _Com.Parameters.AddWithValue("@Nombres", DOE.Nombres);
                _Com.Parameters.AddWithValue("@Apellidos", DOE.Apellidos);
                _Com.Parameters.AddWithValue("@DNI", DOE.DNI);
                _Com.Parameters.AddWithValue("@Celular", DOE.Celular);
                _Com.Parameters.AddWithValue("@Correo", DOE.Correo);
                _Com.Parameters.AddWithValue("@Fecha", DOE.Fecha);
                _Com.Parameters.AddWithValue("@Direccion", DOE.Direccion);
                _Com.Parameters.AddWithValue("@Detalles ", DOE.Detalles);
                _Com.Parameters.AddWithValue("@Otro_Tipo_Evento", DOE.Otro_Evento);
                _Com.ExecuteNonQuery();
                _conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SolicitudEventoEditado(DO_Evento DOE)
        {
            try
            {
                SqlCommand _Com = new SqlCommand("SP_SOLICITUD_EVENTO_EDITADO", _conn);
                _Com.CommandType = System.Data.CommandType.StoredProcedure;
                _conn.Open();
                _Com.Parameters.AddWithValue("@ID_Evento", DOE.ID_Evento);
                _Com.Parameters.AddWithValue("@ID_Tipo_Evento", DOE.ID_Tipo_Evento);
                _Com.Parameters.AddWithValue("@Nombres", DOE.Nombres);
                _Com.Parameters.AddWithValue("@Apellidos", DOE.Apellidos);
                _Com.Parameters.AddWithValue("@DNI", DOE.DNI);
                _Com.Parameters.AddWithValue("@Celular", DOE.Celular);
                _Com.Parameters.AddWithValue("@Correo", DOE.Correo);
                _Com.Parameters.AddWithValue("@Fecha", DOE.Fecha);
                _Com.Parameters.AddWithValue("@Direccion", DOE.Direccion);
                _Com.Parameters.AddWithValue("@Detalles ", DOE.Detalles);
                _Com.Parameters.AddWithValue("@Otro_Tipo_Evento", DOE.Otro_Evento);
                _Com.ExecuteNonQuery();
                _conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insertar_Evento_X_Tipo_Equipo(int ID_Evento, int ID_Tipo_Equipo, int Cantidad)
        {
            try
            {
                SqlCommand comand = new SqlCommand("SP_REGISTRAR_SOLICITUD_EVENTO_X_ID_TIPO_EQUIPO", _conn);
                comand.CommandType = System.Data.CommandType.StoredProcedure;
                _conn.Open();
                comand.Parameters.AddWithValue("@ID_Evento", ID_Evento);
                comand.Parameters.AddWithValue("@ID_Tipo_Equipo", ID_Tipo_Equipo);
                comand.Parameters.AddWithValue("@Cantidad", Cantidad);
                comand.ExecuteNonQuery();
                _conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Cargar_Evento()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand _comm = new SqlCommand("SP_CARGAR_EVENTO", _conn);
                _comm.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(_comm);
                sda.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Ver_Tipo_Equipos_Solicitados(int ID_Evento)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand _comm = new SqlCommand("SP_VER_TIPO_EQUIPO_SOLICITADOS_X_EVENTO", _conn);
                _comm.CommandType = CommandType.StoredProcedure;

                _comm.Parameters.AddWithValue("@ID_Evento", ID_Evento);
                SqlDataAdapter sda = new SqlDataAdapter(_comm);
                sda.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Cargar_Trabajador_Disponible(int ID_Evento, int ID_Tipo_Equipo)
        {
            try
            { 
                _conn.Open();
                SqlDataAdapter _Data = new SqlDataAdapter("SP_CARGAR_TRABAJADOR_DISPONIBLE", _conn);
                _Data.SelectCommand.CommandType = CommandType.StoredProcedure;
                _Data.SelectCommand.Parameters.AddWithValue("@ID_Evento", ID_Evento);
                _Data.SelectCommand.Parameters.AddWithValue("@ID_Tipo_Equipo", ID_Tipo_Equipo);
                _conn.Close();
                DataSet _Ds = new DataSet();
                _Data.Fill(_Ds);
                return _Ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Actualizar_Cant_Tipo_Equipo_X_Evento(int ID_Evento, int ID_Tipo_Equipo)
        {
            try
            {
                SqlCommand comand = new SqlCommand("SP_ACTUALIZAR_CANTIDAD_TIPO_EQUIPO_SOLICITADOS_X_EVENTO", _conn);
                comand.CommandType = System.Data.CommandType.StoredProcedure;
                _conn.Open();
                comand.Parameters.AddWithValue("@ID_Evento", ID_Evento);
                comand.Parameters.AddWithValue("@ID_Tipo_Equipo", ID_Tipo_Equipo);
                comand.ExecuteNonQuery();
                _conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Registrar_Evento_X_Trabajador_X_Equipo(int ID_Evento, int ID_Trabajador, int ID_Tipo_Equipo, int ID_Equipo, DateTime Fecha)
        {
            try
            {
                SqlCommand comand = new SqlCommand("SP_REGISTRAR_EVENTO_TRABAJADOR_EQUIPO", _conn);
                comand.CommandType = System.Data.CommandType.StoredProcedure;
                _conn.Open();
                comand.Parameters.AddWithValue("@ID_EVENTO", ID_Evento);
                comand.Parameters.AddWithValue("@ID_TRABAJADOR", ID_Trabajador);
                comand.Parameters.AddWithValue("@ID_TIPO_EQUIPO", ID_Tipo_Equipo);
                comand.Parameters.AddWithValue("@ID_EQUIPO", ID_Equipo);
                comand.Parameters.AddWithValue("@FECHA", Fecha); 
                comand.ExecuteNonQuery();
                _conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Aprobar_Evento(int ID_Evento)
        {
            try
            {
                SqlCommand comand = new SqlCommand("SP_APROBADO_EVENTO", _conn);
                comand.CommandType = System.Data.CommandType.StoredProcedure;
                _conn.Open();
                comand.Parameters.AddWithValue("@ID_Evento", ID_Evento);
                comand.ExecuteNonQuery();
                _conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Organizar_Evento(int ID_Evento)
        {
            try
            {
                SqlCommand comand = new SqlCommand("SP_ORGANIZAR_EVENTO", _conn);
                comand.CommandType = System.Data.CommandType.StoredProcedure;
                _conn.Open();
                comand.Parameters.AddWithValue("@ID_Evento", ID_Evento);
                comand.ExecuteNonQuery();
                _conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Guardar_Boleta(int ID_Evento, DO_Boleta DOB)
        {
            try
            {
                SqlCommand _Com = new SqlCommand("SP_REGISTRAR_BOLETA", _conn);
                _Com.CommandType = System.Data.CommandType.StoredProcedure; 
                _conn.Open();
                _Com.Parameters.AddWithValue("@ID_Evento", ID_Evento);
                _Com.Parameters.AddWithValue("@Boleta", DOB.Boleta);
                _Com.ExecuteNonQuery();
                _conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 

        public DataTable Obtener_ID_Cotizacion()
        {
            try
            {
                SqlDataAdapter _Data = new SqlDataAdapter("SP_ID_COTIZACION", _conn);
                _Data.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet _Ds = new DataSet();
                _Data.Fill(_Ds);
                return _Ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Registrar_Cotizacion(int ID_Cotizacion, int ID_Tipo_Equipo, int ID_Equipo, int cantidad, double precio_unitario, double sub_total)
        {
            try
            {
                SqlCommand _Com = new SqlCommand("SP_REGISTRAR_COTIZACION", _conn);
                _Com.CommandType = System.Data.CommandType.StoredProcedure; 
                _conn.Open();
                _Com.Parameters.AddWithValue("@ID_COTIZACION", ID_Cotizacion);
                _Com.Parameters.AddWithValue("@ID_TIPO_EQUIPO", ID_Tipo_Equipo);
                _Com.Parameters.AddWithValue("@ID_EQUIPO", ID_Equipo);

                _Com.Parameters.AddWithValue("@CANTIDAD", cantidad);
                _Com.Parameters.AddWithValue("@PRECIO_UNITARIO ", precio_unitario);
                _Com.Parameters.AddWithValue("@SUB_TOTAL", sub_total);
                _Com.ExecuteNonQuery();
                _conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Registrar_Datos_Cotizacion(int ID_Cotizacion, double numero_IGV, double sub_total, double total_IGV, double total)
        {
            try
            {
                SqlCommand _Com = new SqlCommand("SP_REGISTRAR_DATOS_COTIZACION", _conn);
                _Com.CommandType = System.Data.CommandType.StoredProcedure;
                _conn.Open();
                _Com.Parameters.AddWithValue("@ID_COTIZACION", ID_Cotizacion);
                _Com.Parameters.AddWithValue("@NUMERO_IGV", numero_IGV);
                _Com.Parameters.AddWithValue("@SUB_TOTAL", sub_total);
                _Com.Parameters.AddWithValue("@TOTAL_IGV", total_IGV);
                _Com.Parameters.AddWithValue("@TOTAL", total);

                _Com.ExecuteNonQuery();
                _conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Guardar_Reporte_Cotizacion(int ID_Cotizacion, DO_Reporte_Cotizacion DORC)
        {
            try
            {
                SqlCommand _Com = new SqlCommand("SP_REGISTRAR_REPORTE_COTIZACION", _conn);
                _Com.CommandType = System.Data.CommandType.StoredProcedure;
                _conn.Open();
                _Com.Parameters.AddWithValue("@ID_COTIZACION", ID_Cotizacion);
                _Com.Parameters.AddWithValue("@COTIZACION", DORC.Cotizacion);

                _Com.ExecuteNonQuery();
                _conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Cargar_Cotizacion()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand _comm = new SqlCommand("SP_LISTAR_COTIZACION", _conn);
                _comm.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(_comm);
                sda.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable Cargar_Evento_Organizado()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand _comm = new SqlCommand("SP_CARGAR_EVENTO_ORGANIZADO", _conn);
                _comm.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(_comm);
                sda.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Registrar_Nota_Credito(int ID_Nota_Credito, DO_Nota_Credito DONC)
        {
            try
            {
                SqlCommand _Com = new SqlCommand("SP_REGISTRAR_NOTA_CREDITO", _conn);
                _Com.CommandType = System.Data.CommandType.StoredProcedure;
                _conn.Open();
                _Com.Parameters.AddWithValue("@ID_Nota_Credito", ID_Nota_Credito);
                _Com.Parameters.AddWithValue("@Nota_Credito", DONC.Nota_Credito);
                _Com.ExecuteNonQuery();
                _conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Guardar_Contrato(int ID_Evento, DO_Contrato DOC)
        {
            try
            {
                SqlCommand _Com = new SqlCommand("SP_REGISTRAR_CONTRATO", _conn);
                _Com.CommandType = System.Data.CommandType.StoredProcedure;
                _conn.Open();
                _Com.Parameters.AddWithValue("@ID_Evento", ID_Evento);
                _Com.Parameters.AddWithValue("@Contrato", DOC.Contrato);
                _Com.ExecuteNonQuery();
                _conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Evento_Satisfecho(int ID_Evento)
        {
            try
            {
                SqlCommand _Com = new SqlCommand("SP_CARGAR_EVENTO_SATISFECHO", _conn);
                _Com.CommandType = System.Data.CommandType.StoredProcedure;
                _conn.Open();
                _Com.Parameters.AddWithValue("@ID_EVENTO", ID_Evento); 
                _Com.ExecuteNonQuery();
                _conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Evento_Eliminado(int ID_Evento)
        {
            try
            {
                SqlCommand _Com = new SqlCommand("SP_ELIMINAR_EVENTO_ORGANIZADO", _conn);
                _Com.CommandType = System.Data.CommandType.StoredProcedure;
                _conn.Open();
                _Com.Parameters.AddWithValue("@ID_EVENTO", ID_Evento);
                _Com.ExecuteNonQuery();
                _conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}

