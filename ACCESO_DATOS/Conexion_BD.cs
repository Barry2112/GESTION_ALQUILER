using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ACCESO_DATOS
{
    public class Conexion_BD
    {
        public static string Conexion()
        {
            //return "server = DESKTOP-K904IT3\\SQLEXPRESS; database = GESTION_ALQUILER; integrated security = true;"; 
            return "server = BARRY_2112\\SQLEXPRESS; database = GESTION_ALQUILER; integrated security = true;";
        }

        public string Server()
        {
            //return "DESKTOP-K904IT3\\SQLEXPRESS";
            return "server = BARRY_2112\\SQLEXPRESS";
        }
    }
}
