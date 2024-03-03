using System;
using System.Data;
using System.Data.SqlClient;

namespace ACCESO_DATOS
{
    public class DAO_Tipo_Equipo
    {
        SqlConnection _conn = new SqlConnection(Conexion_BD.Conexion());

        public DataTable Listar_Tipo_Equipo()
        {
            try
            {
                _conn.Open();
                SqlDataAdapter _Data = new SqlDataAdapter("SP_LISTAR_TIPO_EQUIPO", _conn);
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
    }
}
