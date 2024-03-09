using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOMINIO;

namespace ACCESO_DATOS
{
    public class DAO_Equipo_Incidencia
    {
        SqlConnection _conn = new SqlConnection(Conexion_BD.Conexion());

        public DataTable Listar_Estados_Equipo_Incidencia()
        {
            try
            {
                _conn.Open();
                SqlDataAdapter _Data = new SqlDataAdapter("SP_LISTAR_ESTADOS_DE_INCIDENCIAS_DE_EQUIPO", _conn);
                _Data.SelectCommand.CommandType = CommandType.StoredProcedure;
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

        public DataTable Obtener_Incidencias_Equipos(int ID_Tipo_Equipo, int ID_Equipo, int ID_Estado_Equipo_Incidencia)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand _comm = new SqlCommand("SP_CARGAR_INCIDENCIAS_DE_EQUIPOS", _conn);
                _comm.CommandType = CommandType.StoredProcedure;
                _comm.Parameters.AddWithValue("@ID_Tipo_Equipo", ID_Tipo_Equipo);
                _comm.Parameters.AddWithValue("@ID_Equipo", ID_Equipo);
                _comm.Parameters.AddWithValue("@ID_Estado_Equipo_Incidencia", ID_Estado_Equipo_Incidencia);
                SqlDataAdapter sda = new SqlDataAdapter(_comm);
                sda.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Obtener_Incidencia_Por_ID(int ID_Equipo_Incidencia)
        {
            try
            {
                SqlDataAdapter _Data = new SqlDataAdapter("SP_OBTENER_INCIDENCIA_POR_ID", _conn);
                _Data.SelectCommand.CommandType = CommandType.StoredProcedure;
                _Data.SelectCommand.Parameters.AddWithValue("@ID_Equipo_Incidencia", ID_Equipo_Incidencia);
                DataSet _Ds = new DataSet();
                _Data.Fill(_Ds);
                return _Ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //INSERTA Y HACE UPDATES
        public string Modificar_Incidencia_de_Equipo(DO_Equipo_Incidencia DOI)
        {
            string respuesta = "";

            try
            {
                _conn.Open();
                SqlCommand _comm = new SqlCommand("SP_MODIFICAR_INCIDENCIA_EQUIPO", _conn);
                _comm.CommandType = CommandType.StoredProcedure;

                _comm.Parameters.AddWithValue("@ID_Equipo_Incidencia", DOI.ID_Equipo_Incidencia);
                _comm.Parameters.AddWithValue("@ID_Equipo", DOI.ID_Equipo);
                _comm.Parameters.AddWithValue("@ID_Evento", DOI.ID_Evento);
                _comm.Parameters.AddWithValue("@Descripcion", DOI.Descripcion);
                _comm.Parameters.AddWithValue("@Comentario", DOI.Comentario);
                _comm.Parameters.AddWithValue("@ID_Estado_Equipo_Incidencia", DOI.ID_Estado_Equipo_Incidencia);

                respuesta = _comm.ExecuteScalar().ToString();
                _conn.Close();

                return respuesta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Obtener_Logs_de_Incidencias_Equipos(int ID_Equipo_Incidencia)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand _comm = new SqlCommand("SP_LISTAR_LOGS_EQUIPO_INCIDENCIA", _conn);
                _comm.CommandType = CommandType.StoredProcedure;
                _comm.Parameters.AddWithValue("@ID_Equipo_Incidencia", ID_Equipo_Incidencia);
                SqlDataAdapter sda = new SqlDataAdapter(_comm);
                sda.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
