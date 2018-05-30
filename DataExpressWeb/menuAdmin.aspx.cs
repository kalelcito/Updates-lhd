using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using System.Data;
using System.Data.Common;
using Control;
using System.Threading;
using System.Globalization;

namespace DataExpressWeb
{
    public partial class Formulario_web18 : System.Web.UI.Page
    {
        BasesDatos BD = new BasesDatos();
        EnviarMail mail = new EnviarMail();
        private DataTable DT = new DataTable();
        string modulo = "";
        string rfcEmisor = "";
        private String separador = "|";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BD.Conectar();
                BD.CrearComando(@"SELECT rfc FROM Proveedores"); 
                DbDataReader DRM = BD.EjecutarConsulta();
                while (DRM.Read())
                {
                    modulo += separador + DRM[0].ToString();
                }
                BD.Desconectar();

                modulo = modulo.Trim('|');
                try
                {
                    BD.Conectar();
                    BD.CrearComandoProcedimiento("PA_facturas_basico_rec_2");
                    BD.AsignarParametroProcedimiento("@QUERY", System.Data.DbType.String, "-");
                    BD.AsignarParametroProcedimiento("@RFC", System.Data.DbType.String, "");
                    BD.AsignarParametroProcedimiento("@MODULO", System.Data.DbType.String, modulo);
                    DT.Load(BD.EjecutarConsulta());
                    BD.Desconectar();
                }
                catch (Exception ex)
                {
                   // tbSerie.Text = ex.ToString();
                }

                gvFacturas.DataSourceID = null;
                gvFacturas.DataSource = DT;
                gvFacturas.DataBind();
            }
        }

        protected void bSesion_Click(object sender, EventArgs e)
        {
            string servidor = "", emailCredencial = "", passCredencial = "", emailEnviar = "";
            bool ssl = true;
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

            Random ranSer = new Random();

            string[] letras = { "A", "B","1", "C", "D","2", "E", "F","3", "G","4", "H"
                            ,"5", "I", "J","6", "K", "L","7", "M", "N","8", "O"
                            , "P","9", "Q", "R", "S","0", "T", "U", "V"
                            , "W", "Y", "Z" };
            int var = 0;
            string cla;

            string[] uno = new string[6];

            for (int x = 0; x < 6; x++)
            {
                var = ranSer.Next(1, 35);
                uno[x] = letras[var].ToString();
            }

            cla = "CLA" + string.Join("", uno);

            BD.Conectar();
            BD.CrearComando("INSERT INTO Proveedores (rfc,razonSocial,contacto,telefono,correo,usuario,pass,tipo) values (@rfc,@rz,@con,@tel,@cor,@us,@ps,@tip)");
            BD.AsignarParametroCadena("@rfc", Trfc.Text);
            BD.AsignarParametroCadena("@rz", Trz.Text);
            BD.AsignarParametroCadena("@con", Tct.Text);
            BD.AsignarParametroCadena("@tel", Ttel.Text);
            BD.AsignarParametroCadena("@cor", Tcor.Text);
            BD.AsignarParametroCadena("@us", Tus.Text);
            BD.AsignarParametroCadena("@ps", cla);
            BD.AsignarParametroEntero("@tip", 1);
            BD.EjecutarConsulta();
            BD.Desconectar();

            BD.Conectar();
            BD.CrearComando("INSERT INTO Modulos(RFC, MODULO) values (@rf,@mod)");
            BD.AsignarParametroCadena("@rf", Trfc.Text);
            BD.AsignarParametroCadena("@mod", Trz.Text);
            BD.EjecutarConsulta();
            BD.Desconectar();

            mail.servidorSTMP(servidor, puerto, ssl, emailCredencial, passCredencial);

            string mensaje = "Estimado proveedor:<br><br>";
            mensaje += "<br>Su solicitud de registro en el portal de recepción DHL ha sido aprobada";
            mensaje += "<br>Para ingresar al sistema dirijase a la página<br>";
            mensaje += "<br>----------------";
            mensaje += "<br>Ingrese su RFC y los siguientes datos:<br>";
            mensaje += "<br>Usuario: " + Tus.Text + "<br>";
            mensaje += "<br>Contraseña: " + cla + "<br><br>";
            mensaje += "<br>La primera vez que ingrese al sistema deberá cambiar su contraseña<br><br>";
            mensaje += "<br>NO CONTESTE ESTE CORREO, HA SIDO ENVIADO DESDE UNA CUENTA DESATENDIDA";

            mail.llenarEmail(emailEnviar, Tcor.Text, "", "", "Acceso-Recepcion-DHL", mensaje);


            mail.enviarEmail();

            Trfc.Text = "";
            Tus.Text = "";
            Trz.Text = "";
            Tct.Text = "";
            Ttel.Text = "";
            Tcor.Text = "";

            Session["confirmacion"] = 2;
            Session["mensajeCon"] = "Su acceso se esta procesando, en breve recibirá un correo a la cuenta antes designada";
            Session["redi"] = 2;
            Session["adSub"] = "";
            Response.Redirect("notificacion.aspx", false);

            // Response.Redirect("~/cuenta/Login.aspx");
            //}
            //catch (Exception ex) 
            //{ 

            //}
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            
            Panel1.Visible = false;
            Panel5.Visible = false;
            Panel4.Visible = true;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Panel4.Visible = false;
            Panel1.Visible = false;
            Panel5.Visible = true;

        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Panel5.Visible = false;
            Panel4.Visible = false;
            Panel1.Visible = true;
            
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {

        }

      

       
    }
}