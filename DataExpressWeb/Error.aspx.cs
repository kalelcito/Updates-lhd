using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Control;
using Datos;
using System.Data.Common;

namespace DataExpressWeb
{
    public partial class Error : System.Web.UI.Page
    {
        BasesDatos BD = new BasesDatos();
        EnviarMail mail;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ErrorTec"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                GdError(Session["ErrorTec"].ToString().Replace("<br>", "|"));
            }
        }

        protected void bSesion_Click(object sender, EventArgs e)
        {
            string servidor = "", emailCredencial = "", passCredencial = "", emailEnviar = "", emailNoti = "", mensaje = "";
            string rutaLog = System.AppDomain.CurrentDomain.BaseDirectory + @"LogError\";
            bool ssl = true;
            int puerto = 0;

            mail = new EnviarMail();

            try
            {
                BD.Conectar();
                BD.CrearComando("select servidorSMTP,puertoSMTP,sslSMTP,userSMTP,passSMTP,emailEnvio,emailNotificacion from ParametrosSistema");

                DbDataReader DR1 = BD.EjecutarConsulta();

                if (DR1.Read())
                {
                    servidor = DR1[0].ToString();
                    puerto = Convert.ToInt32(DR1[1]);
                    ssl = Convert.ToBoolean(DR1[2]);
                    emailCredencial = DR1[3].ToString();
                    passCredencial = DR1[4].ToString();
                    emailEnviar = DR1[5].ToString();
                    emailNoti = DR1[6].ToString();
                }
                BD.Desconectar();

                mensaje = Session["ErrorTec"].ToString();

                mail.servidorSTMP(servidor, puerto, ssl, emailCredencial, passCredencial);

                mail.llenarEmail(emailEnviar, "facturaciondhldataexpress@gmail.com", "", "", "Error en aplicación web - Recepción DHL", mensaje);

                mail.enviarEmail();

                String archivo = rutaLog + @"Log" + System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss").Replace("-", "").Replace(":", "") + ".txt";
                using (System.IO.StreamWriter escritor = new System.IO.StreamWriter(archivo))
                {
                    escritor.WriteLine(mensaje.Replace("<br>", "\n"));
                }

                GdError(mensaje.Replace("<br>", "|"));
                Session["ErrorTec"] = null;
                Response.Redirect("~/Cerrar.aspx");
            }
            catch (Exception EM)
            {
                String archivo = rutaLog + @"Log" + System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss").Replace("-", "").Replace(":", "") + ".txt";
                //Label2.Text = archivo;
                using (System.IO.StreamWriter escritor = new System.IO.StreamWriter(archivo))
                {
                    escritor.WriteLine(EM.Message);
                    escritor.WriteLine(mensaje.Replace("<br>", "\n"));
                }

            }
        }

        private void GdError(string ms)
        {
            try
            {
                BD.Conectar();
                BD.CrearComando(@"insert into LogErrorFacturas
                                (detalle,fecha,archivo,linea,numeroDocumento,tipo,detalleTecnico, resultadoValidacion) 
                                values 
                                (@detalle,@fecha,@archivo,@linea,@numeroDocumento,@tipo,@detalleTecnico,@resultadoValidacion)");

                BD.AsignarParametroCadena("@detalle", "Error no controlado de la aplicacion Web");
                BD.AsignarParametroCadena("@fecha", System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
                BD.AsignarParametroCadena("@archivo", "-");
                BD.AsignarParametroCadena("@linea", "-");
                BD.AsignarParametroCadena("@tipo", "Error-WEB");
                BD.AsignarParametroCadena("@numeroDocumento", "-");
                BD.AsignarParametroCadena("@detalleTecnico", ms);
                BD.AsignarParametroCadena("@resultadoValidacion", "-");
                BD.EjecutarConsulta1();
                BD.Desconectar();
            }
            catch (Exception q)
            {

            }
        }


    }
}