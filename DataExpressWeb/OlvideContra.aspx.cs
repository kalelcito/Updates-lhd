using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Control;
using Datos;
using System.Data.Common;
using System.Threading;


namespace DataExpressWeb
{
    public partial class Formulario_web15 : System.Web.UI.Page
    {
        EnviarMail mail = new EnviarMail();
        BasesDatos BD = new BasesDatos();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bLimpiar0_Click(object sender, EventArgs e)
        {
            Session["otra"] = null;
            Response.Redirect("~/cuenta/Login.aspx");
        }

        protected void bLimpiar_Click(object sender, EventArgs e)
        {
            string servidor = "", emailCredencial = "", passCredencial = "", emailEnviar = "";
            string passAct="",corre="";
            bool ssl = true;
            bool dat;
            int puerto = 0;
            BD.Conectar();
            BD.CrearComando("select servidorSMTP,puertoSMTP,sslSMTP,userSMTP,passSMTP,emailEnvio from ParametrosSistema");

            DbDataReader DR1 = BD.EjecutarConsulta();

            if (DR1.Read())
            {
                servidor = DR1[0].ToString();
                puerto = Convert.ToInt32(DR1[1]);
                ssl = Convert.ToBoolean(DR1[2]);
                emailCredencial = DR1[3].ToString();
                passCredencial = DR1[4].ToString();
                emailEnviar = DR1[5].ToString();
            }
            BD.Desconectar();

            BD.Conectar();
            BD.CrearComando("SELECT pass,correo FROM Proveedores WHERE usuario=@us AND rfc=@rfc");
            BD.AsignarParametroCadena("@us",usu.Text);
            BD.AsignarParametroCadena("@rfc", rfc.Text);
            DbDataReader DR = BD.EjecutarConsulta();

            if (DR.Read())
            {
                passAct = DR[0].ToString();
                corre = DR[1].ToString();
                dat = true;
            }
            else { dat = false; }

            if (dat == true)
            {
                mail.servidorSTMP(servidor, puerto, ssl, emailCredencial, passCredencial);

                string mensaje = "Estimado proveedor:<br><br>";
                mensaje += "<br>Recuerde que su contraseña es el único acceso a recepcion DHL<br>";
                mensaje += "<br>Su contraseña actual es la siguinete<br>";
                mensaje += "<br>Contraseña: " + passAct + "<br><br>";
                mensaje += "<br> Designada al Usuario: " + usu.Text + "<br>";
                mensaje += "<br>NO CONTESTE ESTE CORREO, HA SIDO ENVIADO DESDE UNA CUENTA DESATENDIDA";

                mail.llenarEmail(emailEnviar, corre, "", "", "Recuperación de cotraseña", mensaje);

                try
                {
                    mail.enviarEmail();
                    Session["confirmacion"] = 2;
                    Session["mensajeCon"] = "EN BREVE RECIBIRA SU CONTRASEÑA A SU CORREO";
                    Session["redi"] = 2;
                    Session["adSub"]="";
                    Response.Redirect("notificacion.aspx");
                   // Response.Redirect("~/cuenta/Login.aspx");

                }
                catch (System.Net.Mail.SmtpException ex)
                {

                }
            }
            else {
                Session["estNot"] = false;
                Session["msjNoti"] = "RFC O USUARIO INCORRECTOS";
                Session["estPan"] = true;
            }


        }
    }
}