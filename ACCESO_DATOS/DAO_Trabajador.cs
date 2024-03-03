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
    public class DAO_Trabajador
    {
        SqlConnection _conn = new SqlConnection(Conexion_BD.Conexion());

        public DataTable Cargar_Trabajadores()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand _comm = new SqlCommand("SP_CARGAR_TRABAJADORES", _conn);
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

        public DataTable Mostrar_Tipo_Equipo_Asignados(int ID_Trabajador)
        {
            try
            {
                _conn.Open();
                SqlDataAdapter _Data = new SqlDataAdapter("SP_LISTAR_TIPO_EQUIPOS_ASIGNADOS", _conn);
                _Data.SelectCommand.CommandType = CommandType.StoredProcedure;
                _Data.SelectCommand.Parameters.AddWithValue("@ID_Trabajador", ID_Trabajador);
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
        public DataTable Mostrar_Tipo_Equipo_No_Asignados(int ID_Trabajador)
        {
            try
            {
                _conn.Open();
                SqlDataAdapter _Data = new SqlDataAdapter("SP_LISTAR_TIPO_EQUIPOS_NO_ASIGNADOS", _conn);
                _Data.SelectCommand.CommandType = CommandType.StoredProcedure;
                _Data.SelectCommand.Parameters.AddWithValue("@ID_Trabajador", ID_Trabajador);
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

        public void Registrar_Asignacion_Equipo_Trabajador(int ID_Trabajador, int ID_Equipo, int ID_Tipo_Equipo)
        {
            try
            {
                _conn.Open();
                SqlCommand _comm = new SqlCommand("SP_REGISTRAR_TRABAJADOR_X_EQUIPO_X_TIPO_EQUIPO", _conn);
                _comm.CommandType = CommandType.StoredProcedure;
                _comm.Parameters.AddWithValue("@ID_TRABAJADOR", ID_Trabajador);
                _comm.Parameters.AddWithValue("@ID_Equipo", ID_Equipo);
                _comm.Parameters.AddWithValue("@ID_Tipo_Equipo", ID_Tipo_Equipo); 
                _comm.ExecuteNonQuery();
                _conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Eliminar_Registro_Asignacion_Equipo_Trabajador(int ID_Trabajador, int ID_Tipo_Equipo)
        {
            try
            {
                _conn.Open();
                SqlCommand _comm = new SqlCommand("SP_ELIMINAR_REGISTRO_TRABAJADOR_X_EQUIPO_X_TIPO_EQUIPO", _conn);
                _comm.CommandType = CommandType.StoredProcedure;
                _comm.Parameters.AddWithValue("@ID_TRABAJADOR", ID_Trabajador);
                _comm.Parameters.AddWithValue("@ID_Tipo_Equipo", ID_Tipo_Equipo);
                _comm.ExecuteNonQuery();
                _conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
