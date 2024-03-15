using ACCESO_DATOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEGOCIO
{
    public class N_Conexion_BD
    {
        Conexion_BD _con = new Conexion_BD();

        public string getServidor()
        {
            return _con.Server();
        }
        public string getUser()
        {
            return _con.User();
        }
        public string getPassword()
        {
            return _con.Password();
        }
    }
}
