using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Control;
using System.Data.Common;
using System.Threading;
using System.Data.Common;
using System.IO;


namespace DataExpressWeb
{
    public partial class Formulario_web14 : System.Web.UI.Page
    {
        BasesDatos BD = new BasesDatos();
        EnviarMail mail = new EnviarMail();
        EnviarMail mail2 = new EnviarMail();
        protected void Page_Load(object sender, EventArgs e)
        {
           if(Session["identificador"] ==null){
               Session["otra"] = null;
               Response.Redirect("~/cuenta/Login.aspx");
           }
        }

        protected void bSesion0_Click(object sender, EventArgs e)
        {
            if (Session["adSub"].ToString() == "Admin")
            {
                Session["adSub"] = null;
                Session["identificador"] = null;
                Response.Redirect("~/menuReceDHL/proveedoresDhl.aspx");
            }
            else
            {
                Session["identificador"] = null;
                Session["otra"] = null;
                Response.Redirect("~/cuenta/Login.aspx");
            }
            
        }

        protected void bSesion_Click(object sender, EventArgs e)
        {
            if (Trz.Text != "" && Trfc.Text != "" && Tct.Text != "" && Ttel.Text != "" && Tcor.Text != "" && Tus.Text != "")
            {
                if (!(Tcor.Text.IndexOf("@") < 0))
                {
                    if (verRfc(Trfc.Text))
                    {
                        if (valRfc(Trfc.Text))
                        {
                            string servidor = "", emailCredencial = "", passCredencial = "", emailEnviar = "", emailNoti = "";
                            bool ssl = true;
                            int puerto = 0;
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

                            string res2 = DatosProv(Trfc.Text);

                            if (res2 == "")
                            {
                                try
                                {
                                    BD.Conectar();
                                    BD.CrearComando(@"INSERT INTO Proveedores (rfc,razonSocial,contacto,telefono,correo,usuario,pass,tipo,privacidad,status,fechaSolicitud) 
                                                values (@rfc,@rz,@con,@tel,@cor,@us,@ps,@tip,@proveedor,@st,@fh)");
                                    BD.AsignarParametroCadena("@rfc", Trfc.Text.ToUpper());
                                    BD.AsignarParametroCadena("@rz", Trz.Text.ToUpper().Replace(",", "").Replace(".", ""));
                                    BD.AsignarParametroCadena("@con", Tct.Text);
                                    BD.AsignarParametroCadena("@tel", Ttel.Text);
                                    BD.AsignarParametroCadena("@cor", Tcor.Text);
                                    BD.AsignarParametroCadena("@us", Tus.Text);
                                    BD.AsignarParametroCadena("@ps", cla);
                                    BD.AsignarParametroEntero("@tip", 3);
                                    BD.AsignarParametroCadena("@proveedor", Session["identificador"].ToString());
                                    BD.AsignarParametroCadena("@st", "pendiente");
                                    BD.AsignarParametroCadena("@fh", System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
                                    BD.EjecutarConsulta();
                                    BD.Desconectar();
                                }
                                catch (Exception t)
                                {
                                    String archivo = System.AppDomain.CurrentDomain.BaseDirectory + @"ErrorBD.txt";
                                    //Label2.Text = archivo;
                                    using (System.IO.StreamWriter escritor = new System.IO.StreamWriter(archivo))
                                    {
                                        escritor.WriteLine(t.ToString());
                                    }
                                }

                                BD.Conectar();
                                BD.CrearComando("INSERT INTO Modulos(RFC, MODULO) values (@rf,@mod)");
                                BD.AsignarParametroCadena("@rf", Trfc.Text);
                                BD.AsignarParametroCadena("@mod", Trz.Text);
                                BD.EjecutarConsulta();
                                BD.Desconectar();

                                mail.servidorSTMP(servidor, puerto, ssl, emailCredencial, passCredencial);

                                string mensaje = "Estimado proveedor:<br><br>";
                                mensaje += "<br>Su solicitud de registro en el portal de recepción DHL esta en proceso<br>";
                                mensaje += "<br>Tus datos enviados fuerón los siguientes:<br>";
                                mensaje += "<br>RFC: " + Trfc.Text + "<br>";
                                mensaje += "<br>Razón Social: " + Trz.Text + "<br>";
                                mensaje += "<br>Contacto: " + Tct.Text + "<br>";
                                mensaje += "<br>Teléfono: " + Tus.Text + "<br><br>";
                                mensaje += "<br>En breve recibirá una respuesta de su solicitud.<br><br>";
                                mensaje += "<br>NO CONTESTE ESTE CORREO, HA SIDO ENVIADO DESDE UNA CUENTA DESATENDIDA";

                                mail.llenarEmail(emailEnviar, Tcor.Text, "", "", "Acceso-Recepcion-DHL", mensaje);


                                mail.enviarEmail();


                                if (emailNoti != "")
                                {
                                    mail2.servidorSTMP(servidor, puerto, ssl, emailCredencial, passCredencial);

                                    string mensaje2 = "Estimado Analista:<br><br>";
                                    mensaje2 += "<br>El Proveedor " + Trz.Text + " con RFC: " + Trfc.Text + " no cuenta con Vendor ID y/o Vendor Site";
                                    mensaje2 += "<br>Favor de ingresar estos valores en el catálogo de Proveedores<br>";
                                    mensaje2 += "<br>Se deberá aprobar la solicitud de ingreso<br>";
                                    mensaje2 += "<br>http://www.facturasdscm.com/" + "<br><br>";
                                    mensaje2 += "<br>NO CONTESTE ESTE CORREO, HA SIDO ENVIADO DESDE UNA CUENTA DESATENDIDA";

                                    mail2.llenarEmail(emailEnviar, emailNoti, "", "", "Proveedor en espera-RecepciónDHL", mensaje2);
                                    mail2.enviarEmail();
                                }
                            }
                            else
                            {
                                string[] ArraPr = res2.Split('|');
                                try
                                {
                                    BD.Conectar();
                                    BD.CrearComando(@"INSERT INTO Proveedores 
                                        (rfc,razonSocial,contacto,telefono,correo,usuario,pass,tipo,habilitado,vendorID,vendorSite,tipoProveedor,privacidad,fechaAceptacion,status,fechaSolicitud) 
                                        values (@rfcDD,@rzocD,@conAct,@telefno,@coreoD,@usuArr,@psWord,@tipPp,@hbTTT,@ViDDD,@VsIdD,@tprOvv,@proveedorD,@fechaA,@stAtSS,@fhAcc)");
                                    BD.AsignarParametroCadena("@rfcDD", Trfc.Text.ToUpper());
                                    BD.AsignarParametroCadena("@rzocD", Trz.Text.ToUpper().Replace(",", "").Replace(".", ""));
                                    BD.AsignarParametroCadena("@conAct", Tct.Text);
                                    BD.AsignarParametroCadena("@telefno", Ttel.Text);
                                    BD.AsignarParametroCadena("@coreoD", Tcor.Text);
                                    BD.AsignarParametroCadena("@usuArr", Tus.Text);
                                    BD.AsignarParametroCadena("@psWord", cla);
                                    BD.AsignarParametroEntero("@tipPp", 2);
                                    BD.AsignarParametroCadena("@hbTTT", "si");
                                    BD.AsignarParametroCadena("@ViDDD", ArraPr[1]);
                                    BD.AsignarParametroCadena("@VsIdD", ArraPr[2]);
                                    BD.AsignarParametroCadena("@tprOvv", ArraPr[0]);
                                    BD.AsignarParametroCadena("@proveedorD", Session["identificador"].ToString());
                                    BD.AsignarParametroCadena("@fechaA", System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
                                    BD.AsignarParametroCadena("@stAtSS", "aprobado");
                                    BD.AsignarParametroCadena("@fhAcc", System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
                                    //string consulta = BD.comando.CommandText;
                                    BD.EjecutarConsulta();
                                    BD.Desconectar();

                                    try
                                    {
                                        string rutLog = AppDomain.CurrentDomain.BaseDirectory + @"log\logPr.txt";
                                        //esto inserta texto en un archivo existente, si el archivo no existe lo crea
                                        StreamWriter writer = File.AppendText(rutLog);
                                        writer.WriteLine("|" + Trfc.Text + "|" + Trz.Text + "|" + ArraPr[0] + "|" + System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss") + "|");
                                        writer.Close();
                                    }
                                    catch (Exception u)
                                    {
                                        //Console.WriteLine("Error: " + u.ToString());
                                    }
                                }
                                catch (Exception t)
                                {
                                    String archivo = System.AppDomain.CurrentDomain.BaseDirectory + @"ErrorBD.txt";
                                    //Label2.Text = archivo;
                                    using (System.IO.StreamWriter escritor = new System.IO.StreamWriter(archivo))
                                    {
                                        escritor.WriteLine(t.ToString());
                                    }

                                }

                                BD.Conectar();
                                BD.CrearComando("INSERT INTO Modulos(RFC, MODULO) values (@rf,@mod)");
                                BD.AsignarParametroCadena("@rf", Trfc.Text);
                                BD.AsignarParametroCadena("@mod", Trz.Text);
                                BD.EjecutarConsulta();
                                BD.Desconectar();

                                mail.servidorSTMP(servidor, puerto, ssl, emailCredencial, passCredencial);

                                string mensaje = "Estimado proveedor:<br><br>";
                                mensaje += "<br>Su solicitud de registro en el portal de recepción DHL ha sido a aprobada";
                                mensaje += "<br>Para ingresar al sistema dirijase a la página<br>";
                                mensaje += "<br>http://www.facturasdscm.com/";
                                mensaje += "<br>Ingrese su RFC y los siguientes datos:<br>";
                                mensaje += "<br>Usuario: " + Tus.Text + "<br>";
                                mensaje += "<br>Contraseña: " + cla + "<br><br>";
                                mensaje += "<br>La primera vez que ingrese al sistema deberá cambiar su contraseña<br><br>";
                                mensaje += "<br>NO CONTESTE ESTE CORREO, HA SIDO ENVIADO DESDE UNA CUENTA DESATENDIDA";

                                mail.llenarEmail(emailEnviar, Tcor.Text, "", "", "Acceso-Recepcion-DHL", mensaje);


                                mail.enviarEmail();


                            }


                            Trfc.Text = "";
                            Tus.Text = "";
                            Trz.Text = "";
                            Tct.Text = "";
                            Ttel.Text = "";
                            Tcor.Text = "";
                            if (Session["adSub"].ToString() != "Admin")
                            {
                                Session["confirmacion"] = 2;
                                Session["mensajeCon"] = "Su solicitud se esta procesando, en breve recibirá un correo a la cuenta antes designada";
                                Session["redi"] = 2;
                                Session["adSub"] = "";
                                Response.Redirect("notificacion.aspx", false);
                            }
                            else
                            {

                                Session["confirmacion"] = 2;
                                Session["mensajeCon"] = "Su solicitud se esta procesando, en breve recibirá un correo a la cuenta antes designada";
                                Session["redi"] = 2;
                                Response.Redirect("notificacion.aspx", false);
                            }
                            //Ppriv.Visible = true;
                            //Ppriv.Width = 585;
                            //Ppriv.Height = 380;
                        }
                        else
                        {
                            Session["estNot"] = false;
                            Session["msjNoti"] = "EL RFC CONTIENE CARACTERES INVÁLIDOS";
                            Session["estPan"] = true;
                        }
                    }
                    else
                    {
                        Session["estNot"] = false;
                        Session["msjNoti"] = "YA EXISTE UN PROVEEDOR CON EL MISMO RFC";
                        Session["estPan"] = true;
                    }
                }
                else {
                    Session["estNot"] = false;
                    Session["msjNoti"] = "CORREO INVÁLIDO";
                    Session["estPan"] = true;
                }
            }
            else {
                Session["estNot"] = false;
                Session["msjNoti"] = "NO PUEDEN IR CAMPOS VACIOS";
                Session["estPan"] = true;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //try
            //{
            

            // Response.Redirect("~/cuenta/Login.aspx");
            //}
            //catch (Exception ex) 
            //{ 

            //}

        }

        protected bool valRfc(string rfc)
        {
            bool aux = true;
            foreach (var c in rfc)
            {
                if (!((c >= '0' && c <= '9') || (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z')))
                {
                    aux = false;
                }
            }

            if (aux)
            {
                return true;
            }
            else
            {
                if (!(rfc.IndexOf('&') < 0) && (rfc.IndexOf('-') < 0) && (rfc.IndexOf('.') < 0) && (rfc.IndexOf(',') < 0))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        protected bool verRfc(string rfc)
        {
            bool st = false;
            string estatus = "";
            BD.Conectar();
            BD.CrearComando("select rfc,status from Proveedores where rfc=@rfc");
            BD.AsignarParametroCadena("@rfc", rfc);
            DbDataReader RD = BD.EjecutarConsulta();
            if (RD.Read())
            {
                st = true;
                estatus = RD[1].ToString();
            }
            BD.Desconectar();

            if (st)
            {
                if (estatus == "rechazado")
                {
                    BD.Conectar();
                    BD.CrearComando("delete from Proveedores where rfc=@rfc and status='rechazado'");
                    BD.AsignarParametroCadena("@rfc", rfc);
                    BD.EjecutarConsulta();
                    BD.Desconectar();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        protected string DatosProv(string RFC)
        {
            //string ruta = ruta.Replace("XdService\\Interfaz\\bin\\Debug\\datos.txt", "Datos\\datos.txt");
            try
            {
                string respDat = "";
                string ruta = System.AppDomain.CurrentDomain.BaseDirectory + @"catalogos\Proveedores.txt";
                string[] valores = new string[5];
                StreamReader sr = new StreamReader(ruta);
                var linea = "";
                linea = sr.ReadLine();

                while ((linea = sr.ReadLine()) != null)
                {
                    //linea = sr.ReadLine();
                    if (!String.IsNullOrEmpty(linea))
                    {
                        valores = linea.Split('|');
                        if (valores[0].Trim().Equals(RFC))
                        {
                            if (valores[2] != "" && valores[3] != "" && valores[4] != "")
                            {
                                respDat = valores[2] + "|" + valores[3] + "|" + valores[4];
                            }
                        }
                    }

                }
                sr.Dispose();
                sr.Close();

                return respDat;
            }
            catch (Exception t)
            {
                return "";
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Ppriv.Visible = false;
            Ppriv.Width = 20;
            Ppriv.Height = 20;
        }
    }
}