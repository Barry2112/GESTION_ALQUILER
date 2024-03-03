using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ACCESO_DATOS;
using DOMINIO;

namespace NEGOCIO
{
    public class N_Usuario
    {
        DAO_Usuario _Dat = new DAO_Usuario();
        public Boolean Iniciar_Sesion(DO_Usuario DOU)
        {
            return _Dat.Iniciar_Sesion(DOU);
        }

        public DataTable Obtener_Datos_Usuario(string Correo, string Contraseña)
        {
            return _Dat.Obtener_Datos_Usuario(Correo, Contraseña);
        }

        public DataTable Validar_Usuario_Registrado(DO_Usuario DOU)
        {
            return _Dat.Validar_Usuario_Registrado(DOU);
        }

        public string Registrar_Usuario(DO_Usuario DOU)
        {
            return _Dat.Registrar_Usuario(DOU);
        }

        public void Registrar_Imagen_Usuario(DO_Imagen_Usuario DOIU)
        {
            _Dat.Registrar_Imagen_Usuario(DOIU);
        } 
    }
}
