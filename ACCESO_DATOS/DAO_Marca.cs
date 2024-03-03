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
    public class DAO_Marca
    {
        SqlConnection _conn = new SqlConnection(Conexion_BD.Conexion()); 

        public DataTable Listar_Marca_X_Tipo_Equipo(int ID_Tipo_Equipo)
        {
            try
            {
                _conn.Open();
                SqlDataAdapter _Data = new SqlDataAdapter("SP_LISTAR_MARCA_X_ID_TIPO_EQUIPO", _conn);
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

        public DataTable Listar_Marcas_ID_Equipo(int ID_Equipo)
        {
            try
            {
                _conn.Open();
                SqlDataAdapter _Data = new SqlDataAdapter("SP_LISTAR_MARCAS_X_ID_EQUIPO", _conn);
                _Data.SelectCommand.CommandType = CommandType.StoredProcedure;
                _Data.SelectCommand.Parameters.AddWithValue("@ID_Equipo", ID_Equipo);
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
