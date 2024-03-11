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
    public class DAO_Dashboard
    {
        SqlConnection _conn = new SqlConnection(Conexion_BD.Conexion());

        public DataTable Dashboard_Datos_Principales()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand _comm = new SqlCommand("SP_DASHBOARD_DATOS", _conn);
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

        public DataTable Dashboard_EventosPorTipo()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand _comm = new SqlCommand("SP_DASHBOARD_EVENTOS_POR_TIPO", _conn);
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

        public DataTable Dashboard_EventosPorEstado()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand _comm = new SqlCommand("SP_DASHBOARD_EVENTOS_POR_ESTADO", _conn);
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

        public DataTable Dashboard_EventosPorAnio()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand _comm = new SqlCommand("SP_DASHBOARD_EVENTOS_POR_ANIO", _conn);
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


    }
}
