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
            return "workstation id=GESTION_ALQUILER.mssql.somee.com;packet size=4096;user id=rloayza96_SQLLogin_1;pwd=bjngv5zr7y;data source=GESTION_ALQUILER.mssql.somee.com;persist security info=False;initial catalog=GESTION_ALQUILER;TrustServerCertificate=True";
            //return "server = DESKTOP-K904IT3\\SQLEXPRESS; database = GESTION_ALQUILER; integrated security = true;"; 
            //return "server = BARRY_2112\\SQLEXPRESS; database = GESTION_ALQUILER; integrated security = true;";
            //return "server = MG-L0DSALAZARP\\MSSQLSERVER01; database = GESTION_ALQUILER; integrated security = true;";

        }

        public string Server()
        {
            return "GESTION_ALQUILER.mssql.somee.com";
            //return "DESKTOP-K904IT3\\SQLEXPRESS";
            //return "BARRY_2112\\SQLEXPRESS";
            //return "MG-L0DSALAZARP\\MSSQLSERVER01"; 
        }
        //DATOS PARA EL SERVIDOR EN SOMEE.COM
        public string User()
        {
            return "rloayza96_SQLLogin_1";
        }
        public string Password()
        {
            return "bjngv5zr7y";
        }
    }
}
