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
    public class DAO_Equipo
    {
        SqlConnection _conn = new SqlConnection(Conexion_BD.Conexion());

        public string Registrar_Equipo(DO_Equipo DOE)
        {
            string arreglo = "";

            try
            {
                _conn.Open();
                SqlCommand _comm = new SqlCommand("SP_REGISTRAR_EQUIPO", _conn);
                _comm.CommandType = CommandType.StoredProcedure;
                _comm.Parameters.AddWithValue("@ID_Tipo_Equipo", DOE.ID_Tipo_Equipo);
                _comm.Parameters.AddWithValue("@ID_Marca", DOE.ID_Marca_Equipo);
                _comm.Parameters.AddWithValue("@Codigo_Equipo", DOE.Codigo_Equipo);
                _comm.Parameters.AddWithValue("@Nombre_Equipo", DOE.Nombre_Equipo);
                _comm.Parameters.AddWithValue("@Precio_Equipo", DOE.Precio_Equipo);
                _comm.Parameters.AddWithValue("@Otro_Equipo", DOE.Otro_Equipo);

                arreglo = _comm.ExecuteScalar().ToString();
                _conn.Close();

                return arreglo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Validar_Codigo_Equipo(DO_Equipo DOE)
        {
            try
            {
                _conn.Open();
                SqlDataAdapter _comm = new SqlDataAdapter("SP_VALIDAR_CODIGO_EQUIPO", _conn);
                _comm.SelectCommand.CommandType = CommandType.StoredProcedure;
                _comm.SelectCommand.Parameters.AddWithValue("@Codigo_Equipo", DOE.Codigo_Equipo);
                _conn.Close();
                DataTable _DT = new DataTable();
                _comm.Fill(_DT);
                return _DT;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Registrar_Imagen_Equipo(DO_Imagen_Equipo DOIE)
        {
            try
            {
                _conn.Open();
                SqlCommand _comm = new SqlCommand("SP_REGISTRAR_IMAGEN_EQUIPO", _conn);
                _comm.CommandType = CommandType.StoredProcedure;
                _comm.Parameters.AddWithValue("@ID_Equipo", DOIE.ID_Equipo);
                _comm.Parameters.AddWithValue("@Nombre_Imagen_Equipo", DOIE.Nombre_Imagen_Equipo);
                _comm.Parameters.AddWithValue("@Ruta_Imagen_Equipo", DOIE.Ruta_Imagen_Equipo);
                _comm.ExecuteNonQuery();
                _conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Consultar_Equipo(int ID_Tipo_Equipo)
        {
            try
            {
                _conn.Open();
                SqlDataAdapter _comm = new SqlDataAdapter("SP_CONSULTAR_EQUIPO", _conn);
                _comm.SelectCommand.CommandType = CommandType.StoredProcedure;
                _comm.SelectCommand.Parameters.AddWithValue("@Tipo_Equipo", ID_Tipo_Equipo);
                _conn.Close();
                DataTable _DT = new DataTable();
                _comm.Fill(_DT);
                return _DT;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ObtenerDetallesEquipo(int ID_Equipo)
        {
            try
            {
                SqlDataAdapter _Data = new SqlDataAdapter("SP_OBTENER_DETALLES_EQUIPO", _conn);
                _Data.SelectCommand.CommandType = CommandType.StoredProcedure;
                _Data.SelectCommand.Parameters.AddWithValue("ID_Equipo", ID_Equipo);
                DataSet _Ds = new DataSet();
                _Data.Fill(_Ds);
                return _Ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ObtenerDetallesEquipoEditar(int ID_Equipo)
        {
            try
            {
                SqlDataAdapter _Data = new SqlDataAdapter("SP_OBTENER_DETALLES_EQUIPO_EDITAR", _conn);
                _Data.SelectCommand.CommandType = CommandType.StoredProcedure;
                _Data.SelectCommand.Parameters.AddWithValue("@ID_Equipo", ID_Equipo);
                DataSet _Ds = new DataSet();
                _Data.Fill(_Ds);
                return _Ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Obtener_Equipo_X_Tipo_Equipo(int ID_Tipo_Equipo)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand _comm = new SqlCommand("SP_CARGAR_EQUIPO_X_TIPO_EQUIPO", _conn);
                _comm.CommandType = CommandType.StoredProcedure;
                _comm.Parameters.AddWithValue("@Tipo_Equipo", ID_Tipo_Equipo);
                SqlDataAdapter sda = new SqlDataAdapter(_comm);
                sda.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Obtener_Codigo_Equipo_X_Tipo_Equipo_Agregar(int ID_Tipo_Equipo, int ID_Trabajador)
        {
            try
            {
                SqlDataAdapter _Data = new SqlDataAdapter("SP_CARGAR_CODIGO_EQUIPO_X_TIPO_EQUIPO_AGREGAR", _conn);
                _Data.SelectCommand.CommandType = CommandType.StoredProcedure;
                _Data.SelectCommand.Parameters.AddWithValue("@ID_Tipo_Equipo", ID_Tipo_Equipo);
                _Data.SelectCommand.Parameters.AddWithValue("@ID_Trabajador", ID_Trabajador);
                DataSet _Ds = new DataSet();
                _Data.Fill(_Ds);
                return _Ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Obtener_Codigo_Equipo_X_Tipo_Equipo_Quitar(int ID_Tipo_Equipo, int ID_Trabajador)
        {
            try
            {
                SqlDataAdapter _Data = new SqlDataAdapter("SP_CARGAR_CODIGO_EQUIPO_X_TIPO_EQUIPO_QUITAR", _conn);
                _Data.SelectCommand.CommandType = CommandType.StoredProcedure;
                _Data.SelectCommand.Parameters.AddWithValue("@ID_Tipo_Equipo", ID_Tipo_Equipo);
                _Data.SelectCommand.Parameters.AddWithValue("@ID_Trabajador", ID_Trabajador);
                DataSet _Ds = new DataSet();
                _Data.Fill(_Ds);
                return _Ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Obtener_Detalles_Equipo_Agregar_X_Quitar_Asignacion(int ID_Equipo)
        {
            try
            {
                SqlDataAdapter _Data = new SqlDataAdapter("SP_OBTENER_DETALLES_EQUIPO_AGREGAR_QUITAR_ASIGNACION", _conn);
                _Data.SelectCommand.CommandType = CommandType.StoredProcedure;
                _Data.SelectCommand.Parameters.AddWithValue("@ID_Equipo", ID_Equipo);
                DataSet _Ds = new DataSet();
                _Data.Fill(_Ds);
                return _Ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Obtener_Detalles_Equipo_Quitar_Asignacion(int ID_TRABAJADOR, int ID_TIPO_EQUIPO)
        {
            try
            {
                SqlDataAdapter _Data = new SqlDataAdapter("SP_OBTENER_DETALLES_EQUIPO_QUITAR_ASIGNACION", _conn);
                _Data.SelectCommand.CommandType = CommandType.StoredProcedure;
                _Data.SelectCommand.Parameters.AddWithValue("@ID_TRABAJADOR", ID_TRABAJADOR);
                _Data.SelectCommand.Parameters.AddWithValue("@ID_TIPO_EQUIPO", ID_TIPO_EQUIPO);
                DataSet _Ds = new DataSet();
                _Data.Fill(_Ds);
                return _Ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Editar_Equipo(DO_Equipo DOE)
        {  
            try
            {
                _conn.Open();
                SqlCommand _comm = new SqlCommand("SP_EDITAR_EQUIPO", _conn);
                _comm.CommandType = CommandType.StoredProcedure;
                _comm.Parameters.AddWithValue("@ID_Equipo", DOE.ID_Equipo);
                _comm.Parameters.AddWithValue("@ID_Tipo_Equipo", DOE.ID_Tipo_Equipo);
                _comm.Parameters.AddWithValue("@ID_Marca", DOE.ID_Marca_Equipo);
                _comm.Parameters.AddWithValue("@Codigo_Equipo", DOE.Codigo_Equipo);
                _comm.Parameters.AddWithValue("@Nombre_Equipo", DOE.Nombre_Equipo);
                _comm.Parameters.AddWithValue("@Precio_Equipo", DOE.Precio_Equipo);
                _comm.Parameters.AddWithValue("@Otro_Equipo", DOE.Otro_Equipo);
                _comm.ExecuteNonQuery();
                _conn.Close();  
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Eliminar_Equipo(int ID_Equipo)
        {
            try
            {
                _conn.Open();
                SqlCommand _comm = new SqlCommand("SP_ELIMINAR_EQUIPO", _conn);
                _comm.CommandType = CommandType.StoredProcedure;
                _comm.Parameters.AddWithValue("@ID_Equipo", ID_Equipo); 
                _comm.ExecuteNonQuery();
                _conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Listar_Codigo_Equipo_X_ID_Tipo_Equipo(int ID_Tipo_Equipo)
        {
            try
            {
                _conn.Open();
                SqlDataAdapter _Data = new SqlDataAdapter("SP_LISTAR_CODIGO_EQUIPO_X_ID_TIPO_EQUIPO", _conn);
                _Data.SelectCommand.CommandType = CommandType.StoredProcedure;
                _Data.SelectCommand.Parameters.AddWithValue("@ID_Tipo_Equipo", ID_Tipo_Equipo);
                _conn.Close();
                DataSet _Ds = new DataSet();
                _Data.Fill(_Ds);
                return _Ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ObtenerDetallesxCodigoEquipo(string Codigo_Equipo)
        {
            try
            {
                SqlDataAdapter _Data = new SqlDataAdapter("SP_OBTENER_DETALLES_CODIGO_EQUIPO", _conn);
                _Data.SelectCommand.CommandType = CommandType.StoredProcedure;
                _Data.SelectCommand.Parameters.AddWithValue("@CODIGO_EQUIPO", Codigo_Equipo);
                DataSet _Ds = new DataSet();
                _Data.Fill(_Ds);
                return _Ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Consultar_Equipo_Asignados(int ID_Trabajador)
        {
            try
            {
                _conn.Open();
                SqlDataAdapter _comm = new SqlDataAdapter("SP_CONSULTAR_EQUIPO_ASIGNADO", _conn);
                _comm.SelectCommand.CommandType = CommandType.StoredProcedure;
                _comm.SelectCommand.Parameters.AddWithValue("@ID_Trabajador", ID_Trabajador);
                _conn.Close();
                DataTable _DT = new DataTable();
                _comm.Fill(_DT);
                return _DT;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Consultar_Equipo_Organizado(int ID_Trabajador)
        {
            try
            {
                _conn.Open();
                SqlDataAdapter _comm = new SqlDataAdapter("SP_CONSULTAR_EQUIPO_ORGANIZADO", _conn);
                _comm.SelectCommand.CommandType = CommandType.StoredProcedure;
                _comm.SelectCommand.Parameters.AddWithValue("@ID_Trabajador", ID_Trabajador);
                _conn.Close();
                DataTable _DT = new DataTable();
                _comm.Fill(_DT);
                return _DT;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Obtener_Detalles_Equipo_Incidencia(int ID_Equipo)
        {
            try
            {
                SqlDataAdapter _Data = new SqlDataAdapter("SP_TRAER_INFO_EQUIPO_X_CODIGO_EQUIPO", _conn);
                _Data.SelectCommand.CommandType = CommandType.StoredProcedure;
                _Data.SelectCommand.Parameters.AddWithValue("@ID_Equipo", ID_Equipo);
                DataSet _Ds = new DataSet();
                _Data.Fill(_Ds);
                return _Ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 

        public void Registrar_Incidencia_Equipo(int ID_Equipo, int ID_Trabajador, string Detalles_Problema)
        {
            try
            {
                _conn.Open();
                SqlCommand _comm = new SqlCommand("SP_REGISTRAR_INCIDENCIA_EQUIPO", _conn);
                _comm.CommandType = CommandType.StoredProcedure;
                _comm.Parameters.AddWithValue("@ID_Equipo", ID_Equipo);
                _comm.Parameters.AddWithValue("@ID_Trabajador", ID_Trabajador);
                _comm.Parameters.AddWithValue("@Detalles_Problema", Detalles_Problema);
                _comm.ExecuteNonQuery();
                _conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Cargar_Incidencia_Equipos()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand _comm = new SqlCommand("SP_CARGAR_INCIDENCIAS_DE_EQUIPOS", _conn);
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

        public DataTable Obtener_Detalles_Gestionar_Equipo_Incidencia(int ID_Equipo)
        {
            try
            {
                SqlDataAdapter _Data = new SqlDataAdapter("SP_TRAER_INFO_TO_GESTIONAR_EQUIPO_X_CODIGO_EQUIPO", _conn);
                _Data.SelectCommand.CommandType = CommandType.StoredProcedure;
                _Data.SelectCommand.Parameters.AddWithValue("@ID_Equipo", ID_Equipo);
                DataSet _Ds = new DataSet();
                _Data.Fill(_Ds);
                return _Ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Deshabilitar_Estado_Equipo(int ID_Equipo)
        {
            try
            {
                _conn.Open();
                SqlCommand _comm = new SqlCommand("Deshabilitar_Estado_Equipo", _conn);
                _comm.CommandType = CommandType.StoredProcedure; 
                _comm.ExecuteNonQuery();
                _conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Deshabilitar_Equipo(int ID_Equipo)
        {
            try
            {
                SqlDataAdapter _Data = new SqlDataAdapter("SP_DESHABILITAR_ESTADO_EQUIPO", _conn);
                _Data.SelectCommand.CommandType = CommandType.StoredProcedure;
                _Data.SelectCommand.Parameters.AddWithValue("@ID_Equipo", ID_Equipo);
                DataSet _Ds = new DataSet();
                _Data.Fill(_Ds);
                return _Ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Listar_Equipos_con_Incidencias(int ID_Tipo_Equipo)
        {
            try
            {
                _conn.Open();
                SqlDataAdapter _comm = new SqlDataAdapter("SP_LISTAR_EQUIPOS_CON_INCIDENCIAS", _conn);
                _comm.SelectCommand.CommandType = CommandType.StoredProcedure;
                _comm.SelectCommand.Parameters.AddWithValue("@ID_Tipo_Equipo", ID_Tipo_Equipo);
                _conn.Close();
                DataSet _Ds = new DataSet();
                _comm.Fill(_Ds);
                return _Ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Listar_Equipos_por_Tipo(int ID_Tipo_Equipo)
        {
            try
            {
                _conn.Open();
                SqlDataAdapter _comm = new SqlDataAdapter("SP_LISTAR_EQUIPOS_POR_TIPO", _conn);
                _comm.SelectCommand.CommandType = CommandType.StoredProcedure;
                _comm.SelectCommand.Parameters.AddWithValue("@ID_Tipo_Equipo", ID_Tipo_Equipo);
                _conn.Close();
                DataSet _Ds = new DataSet();
                _comm.Fill(_Ds);
                return _Ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
