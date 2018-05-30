using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Windows.Forms;
using System.IO;
using Datos;
using System.Data.Common;

namespace Control
{
    public class EnviarMail
    {
        SmtpClient mSmtpClient = new SmtpClient();
        MailMessage mMailMessage = new MailMessage();
        string email_enviado;
        BasesDatos BD3 = new BasesDatos();

        /// <summary>
        /// Envia un Email
        /// </summary>
        /// <param name="from">Remitente</param>
        /// <param name="to">Receptor</param>
        /// <param name="bcc">Bcc Receptor</param>
        /// <param name="cc">Cc Receptor</param>
        /// <param name="subject">Cabecero del mensaje</param>
        /// <param name="body">Cuerpo del mensaje</param>
        public void servidorSTMP(String servidor, Int32 puerto, Boolean ssl, String emailCredencial, String passCredencial)
        {
            if (servidor == null || servidor == "") { servidor = "abc"; }
            if (puerto == null) { puerto = 123; }
            mSmtpClient.Host = servidor; //aqui poner el smtp de mexexpress
            mSmtpClient.Port = puerto;
            mSmtpClient.EnableSsl = ssl;
            mSmtpClient.Credentials = new System.Net.NetworkCredential(emailCredencial, passCredencial);
        }

        public void adjuntar(String ruta)
        {
            mMailMessage.Attachments.Add(new Attachment(ruta));
        }

        public void llenarEmail(string from, string to, string bcc, string cc, string subject, string body)
        {
            if (bcc == null || bcc == "") { bcc = "FacturacionElectronica@Dataexpressintmx.com"; }
            if (from == null || from == "") { from = "FacturacionElectronica@Dataexpressintmx.com"; }
            mMailMessage.From = new MailAddress(from);
            String[] destinatarios = to.Split(',');
            foreach (String email in destinatarios)
            {
                if (email != null && email != "")
                {
                    mMailMessage.To.Add(new MailAddress(email));
                }
            }
            if ((bcc != null) && (bcc != string.Empty)) mMailMessage.Bcc.Add(new MailAddress(bcc));
            if ((cc != null) && (cc != string.Empty)) mMailMessage.CC.Add(new MailAddress(cc));

            mMailMessage.Subject = subject;
            mMailMessage.Body = body;
            mMailMessage.IsBodyHtml = true;
            mMailMessage.Priority = MailPriority.Normal;
        }
        public bool enviarEmail()
        {
            if (String.IsNullOrEmpty(email_enviado))
            {
                email_enviado = "";
            }

            try
            {
                //if (mSmtpClient.EnableSsl)
                //{
                //    System.Net.ServicePointManager.ServerCertificateValidationCallback +=
                //    delegate(object sender1, System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                //    System.Security.Cryptography.X509Certificates.X509Chain chain,
                //    System.Net.Security.SslPolicyErrors sslPolicyErrors)
                //    {
                //        return true;
                //    };
                //}
                //if (email_enviado == "" || email_enviado == null) { email_enviado = "No Hay correo para envio"; }
                mSmtpClient.Send(mMailMessage);
                //BD3.Conectar();
                //BD3.CrearComando("INSERT INTO LogErrorFacturas (detalle, fecha) values (@detalle, GETDATE())");
                //BD3.AsignarParametroCadena("@detalle", "email enviado "+email_enviado);
                //BD3.EjecutarConsulta();
                //BD3.Desconectar();
                return true;
            }
            catch (Exception ex)
            {
                //if (email_enviado == "" || email_enviado == null) { email_enviado = "No hay email para enviar"; }                
                //BD3.Conectar();
                //BD3.CrearComando("INSERT INTO LogErrorFacturas (detalle, fecha) values (@detalle, GETDATE())");
                //BD3.AsignarParametroCadena("@detalle", ex.ToString()+" "+email_enviado);
                //BD3.EjecutarConsulta();
                //BD3.Desconectar();
                return false;
            }
        }
        public string obtener_mail(string mail, string idFactura)
        {
            string correo = "";
            email_enviado = mail;
            try
            {
                BD3.Conectar();
                BD3.CrearComando(@"select Erick.Nombre, Erick.Correo                
                             from GENERAL,Erick
                             where          		   
                             GENERAL.idFactura=@idFactura
                             and CONCAT((SUBSTRING(GENERAL.codcont,1,4)),(SUBSTRING(GENERAL.codcont,6,4)))=CONCAT(Erick.FCC,Erick.Cliente)");
                BD3.AsignarParametroCadena("@idFactura", idFactura);
                DbDataReader DR = BD3.EjecutarConsulta();
                while (DR.Read())
                {
                    correo = DR[1].ToString();
                }
                BD3.Desconectar();
                //BD3.Conectar();
                //BD3.CrearComando("INSERT INTO LogErrorFacturas (detalle, fecha) values (@detalle, GETDATE())");
                //BD3.AsignarParametroCadena("@detalle", "correo obtenido " + correo);
                //BD3.EjecutarConsulta();
                //BD3.Desconectar();
            }
            catch (Exception ex)
            {
                //if (correo == "" || correo == null) { correo = "No hay email para enviar"; }
                BD3.Desconectar();
                //    BD3.Conectar();
                //    BD3.CrearComando("INSERT INTO LogErrorFacturas (detalle, fecha) values (@detalle, GETDATE())");
                //    BD3.AsignarParametroCadena("@detalle", ex.ToString()+" "+correo);
                //    BD3.EjecutarConsulta();
                //    BD3.Desconectar();
            }
            return correo;
        }

    }
}
