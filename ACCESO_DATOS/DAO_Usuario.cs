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
    public class DAO_Usuario
    {
        SqlConnection _conn = new SqlConnection(Conexion_BD.Conexion());

        public Boolean Iniciar_Sesion(DO_Usuario DOU)
        {
            try
            {
                _conn.Open();
                SqlCommand _comm = new SqlCommand("SP_INICIAR_SESION", _conn);
                _comm.CommandType = CommandType.StoredProcedure;
                _comm.Parameters.AddWithValue("@Correo", DOU.Correo);
                _comm.Parameters.AddWithValue("@Contraseña", DOU.Contraseña);

                int count = (int)_comm.ExecuteScalar();
                _conn.Close();

                if (count == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            { 
                throw ex;
            }
        }

        public DataTable Obtener_Datos_Usuario(string Correo, string Contraseña)
        {
            try
            {
                SqlDataAdapter _dat = new SqlDataAdapter("SP_OBTENER_DATOS_USUARIO", _conn);
                _dat.SelectCommand.CommandType = CommandType.StoredProcedure;
                _dat.SelectCommand.Parameters.AddWithValue("@Correo", Correo);
                _dat.SelectCommand.Parameters.AddWithValue("@Contraseña", Contraseña);
                DataSet _DS = new DataSet();
                _dat.Fill(_DS);
                return _DS.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Validar_Usuario_Registrado(DO_Usuario DOU)
        {
            try
            {
                SqlDataAdapter _dat = new SqlDataAdapter("SP_VALIDAR_REGISTRO_USUARIO", _conn); 
                _dat.SelectCommand.CommandType = CommandType.StoredProcedure;
                _dat.SelectCommand.Parameters.AddWithValue("@DNI", DOU.DNI);
                _dat.SelectCommand.Parameters.AddWithValue("@Celular", DOU.Celular);
                _dat.SelectCommand.Parameters.AddWithValue("@Correo", DOU.Correo);
                DataSet _DS = new DataSet();
                _dat.Fill(_DS);
                return _DS.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 

        public string Registrar_Usuario(DO_Usuario DOU)
        {
            string arreglo = "";

            try
            {
                _conn.Open();
                SqlCommand _comm = new SqlCommand("SP_REGISTRAR_USUARIO", _conn);
                _comm.CommandType = CommandType.StoredProcedure;
                _comm.Parameters.Add(new SqlParameter("@Nombres", DOU.Nombres));
                _comm.Parameters.Add(new SqlParameter("@Apellidos", DOU.Apellidos));
                _comm.Parameters.Add(new SqlParameter("@DNI", DOU.DNI));
                _comm.Parameters.Add(new SqlParameter("@Celular", DOU.Celular));
                _comm.Parameters.Add(new SqlParameter("@Direccion", DOU.Direccion));
                _comm.Parameters.Add(new SqlParameter("@Correo", DOU.Correo));
                _comm.Parameters.Add(new SqlParameter("@Contraseña", DOU.Contraseña));

                arreglo = _comm.ExecuteScalar().ToString();
                _conn.Close();

                return arreglo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Registrar_Imagen_Usuario(DO_Imagen_Usuario DOIU)
        {
            try
            {
                _conn.Open();
                SqlCommand _comm = new SqlCommand("SP_REGISTRAR_IMAGEN_USUARIO", _conn);
                _comm.CommandType = CommandType.StoredProcedure;
                _comm.Parameters.AddWithValue("@ID_Usuario", DOIU.ID_Usuario);
                _comm.Parameters.AddWithValue("@Nombre_Imagen_Usuario", DOIU.Nombre_Imagen_Usuario);
                _comm.Parameters.AddWithValue("@Ruta_Imagen_Usuario", DOIU.Ruta_Imagen_Usuario);
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
