using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MailKit.Security;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using DOMINIO;
using Org.BouncyCastle.Asn1.Ocsp;
using System.IO;
using System.Web.Hosting;

namespace NEGOCIO
{
    public class N_Email
    {
        public void EnviarMail(DO_Email _DO_Email)
        {
            var message = new MimeMessage();
            message.From.Add(MailboxAddress.Parse("rloayzacampos@gmail.com"));
            message.To.Add(MailboxAddress.Parse(_DO_Email.Para));
            message.Subject = _DO_Email.Asunto;

            var builder = new BodyBuilder();
            builder.HtmlBody = _DO_Email.Contenido;
            var path = _DO_Email.Ubicacion_Archivo;

            //ATTACKMENT IF EXISTS PATH
            if (_DO_Email.Ubicacion_Archivo != "" & _DO_Email.Ubicacion_Archivo != null)
            {                
                builder.Attachments.Add(_DO_Email.Ubicacion_Archivo);
            }
            message.Body = builder.ToMessageBody();    

            var smtp = new SmtpClient();
            //SERVIDOR, PUERTO, SEGURIDAD
            smtp.Connect("smtp.gmail.com", 587,SecureSocketOptions.StartTls);
            //CORREO DEL USUARIO, CONTRASEÑA DE APLICACION
            smtp.Authenticate("rloayzacampos@gmail.com", "tscooeffyjqqaptm");

            smtp.Send(message);
            smtp.Disconnect(true);
        }
    }
}
