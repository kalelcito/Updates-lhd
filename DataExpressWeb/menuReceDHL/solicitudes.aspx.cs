using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using System.Data.Common;
using System.Data;
using Control;
using System.Text;
using System.IO;
using System.Data.SqlClient;

namespace DataExpressWeb
{
    public partial class Formulario_web116 : System.Web.UI.Page
    {
        BasesDatos BD = new BasesDatos();
        EnviarMail mail = new EnviarMail();
        private DataTable DT = new DataTable();
        string modulo = "";
        string rfcEmisor = "";
        static string idres = "";
        private String separador = "|";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null || Session["adm"] == null || Session["permisos"] == null)
            {
                Response.Redirect("~/Cerrar.aspx");
            }
            else if (Convert.ToBoolean(Session["adm"]) == false)
            {
                Response.Redirect("~/Documentos.aspx");
            }
        }

        protected void Button30_Click(object sender, EventArgs e)
        {

        }

        protected void Button24_Click(object sender, EventArgs e)
        {
            //---------panel rechazar solicitud----------------
            bool si = false;
            foreach (GridViewRow row in GridView8.Rows)
            {
                CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                if (chk_Seleccionar.Checked)
                { si = true; }
            }

            if (si == true)
            {
                foreach (GridViewRow row in GridView8.Rows)
                {
                    CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                    HiddenField hd_Seleccionafol = (HiddenField)row.FindControl("checkFol");
                    if (chk_Seleccionar.Checked)
                    {
                        idres = hd_Seleccionafol.Value;
                        BD.Conectar();
                        BD.CrearComando("select rfc,razonSocial from Proveedores where idProveedor=@idp");
                        BD.AsignarParametroCadena("@idp", idres);
                        DbDataReader DR = BD.EjecutarConsulta();
                        if (DR.Read())
                        {
                            Trfcrec.Text = DR[0].ToString();
                            Trzrec.Text = DR[1].ToString();

                            Prechazar.Width = 435;
                            Prechazar.Height = 230;
                            Prechazar.Visible = true;
                        }
                        BD.Desconectar();
                    }
                }
            }
            else
            {
                Session["estNot"] = false;
                Session["msjNoti"] = "DEBES SELECIONAR UN PROVEEDOR";
                Session["estPan"] = true;
            }
        }

        protected void Button17_Click(object sender, EventArgs e)
        {
            //------------------cancelar rechazar solicitud-----------
            Prechazar.Width = 20;
            Prechazar.Height = 20;
            Prechazar.Visible = false;
            idres = "";
            Response.Redirect("~/menuReceDHL/solicitudes.aspx");
        }

        protected void Button18_Click(object sender, EventArgs e)
        {
            //-----------------------rechazar solicitud---------------
            BD.Conectar();
            BD.CrearComando("update Proveedores set tipo=@ti, causaRechazo=@cau, status=@st  where idProveedor=@idp ");
            BD.AsignarParametroEntero("@ti", 4);
            BD.AsignarParametroCadena("@cau", Tcaurec.Text);
            BD.AsignarParametroCadena("@st", "rechazado");
            BD.AsignarParametroCadena("@idp", idres);
            BD.EjecutarConsulta();
            BD.Desconectar();
            enviarMail(idres, false, Tcaurec.Text);
            Prechazar.Width = 20;
            Prechazar.Height = 20;
            Prechazar.Visible = false;
            idres = "";
            Response.Redirect("~/menuReceDHL/proveedoresDhl.aspx");
        }

        protected void Button25_Click(object sender, EventArgs e)
        {
            //---------------abrir panel aprobar----------
            bool si = false;
            foreach (GridViewRow row in GridView8.Rows)
            {
                CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                if (chk_Seleccionar.Checked)
                { si = true; }
            }

            if (si == true)
            {
                foreach (GridViewRow row in GridView8.Rows)
                {
                    CheckBox chk_Seleccionar = (CheckBox)row.FindControl("check");
                    HiddenField hd_Seleccionafol = (HiddenField)row.FindControl("checkFol");
                    if (chk_Seleccionar.Checked)
                    {
                        
                        idres = hd_Seleccionafol.Value;
                        BD.Conectar();
                        BD.CrearComando("select rfc,razonSocial from Proveedores where idProveedor=@idp");
                        BD.AsignarParametroCadena("@idp", idres);
                        DbDataReader DR = BD.EjecutarConsulta();
                        if (DR.Read())
                        {
                            Trfcap.Text = DR[0].ToString().Trim();
                            Trzap.Text = DR[1].ToString();

                            Paprov.Width = 450;
                            Paprov.Height = 280;
                            string datosPr = DatosProv(DR[0].ToString());
                            if (datosPr != "")
                            {
                                string[] ArraPr = datosPr.Split('|');

                                if (ArraPr[1] != "" && ArraPr[2] != "")
                                {
                                    Tvendap.Text = ArraPr[1];
                                    Tsiteap.Text = ArraPr[2];
                                    Drotipap.SelectedValue = ArraPr[0];
                                }
                                else
                                {
                                    msjAp.Text = "El proveedor no contiene Vendor ID o " + "<br/>" + "Vendor Site en el archivo Proveedores.txt";
                                    Button20.Visible = false;

                                    Session["estNot"] = false;
                                    Session["msjNoti"] = "Ingresa a la Administración de Catálogos y registra al proveedor";
                                    Session["estPan"] = true;
                                }
                            }
                            else {
                               
                                msjAp.Text = "El proveedor no se encuentra en el archivo Proveedores.txt";
                                Button20.Visible = false;

                                Session["estNot"] = false;
                                Session["msjNoti"] = "Ingresa a la Administración de Catálogos y registra al proveedor";
                                Session["estPan"] = true;
                            }
                            Paprov.Visible = true;
                        }

                        
                        BD.Desconectar();
                    }
                }
            }
            else
            {
                Session["estNot"] = false;
                Session["msjNoti"] = "DEBES SELECIONAR UN PROVEEDOR";
                Session["estPan"] = true;
            }

        }

        protected void Button19_Click(object sender, EventArgs e)
        {
            //------------cancelar aprobar------------
            Paprov.Width = 20;
            Paprov.Height = 20;
            Paprov.Visible = false;
            idres = "";
            Response.Redirect("~/menuReceDHL/solicitudes.aspx");
        }

        protected void Button20_Click(object sender, EventArgs e)
        {
             //--------------aprobar solicitud----------------
            try
            {
                BD.Conectar();
                BD.CrearComando("update Proveedores set tipo=@ti, vendorID=@ven, vendorSite=@site,tipoProveedor=@prov, status=@st, habilitado=@habi  where idProveedor=@idp ");
                BD.AsignarParametroEntero("@ti", 2);
                BD.AsignarParametroEntero("@ven", Convert.ToInt32(Tvendap.Text));
                BD.AsignarParametroEntero("@site", Convert.ToInt32(Tsiteap.Text));
                BD.AsignarParametroCadena("@prov", Drotipap.SelectedValue);
                BD.AsignarParametroCadena("@st", "aprobado");
                BD.AsignarParametroCadena("@habi", "si");
                BD.AsignarParametroCadena("@idp", idres);
                BD.EjecutarConsulta();
                BD.Desconectar();

                enviarMail(idres, true, "");
                Paprov.Width = 20;
                Paprov.Height = 20;
                Paprov.Visible = false;
                idres = "";
                Response.Redirect("~/menuReceDHL/proveedoresDhl.aspx");
            }
            catch (Exception a)
            {
                
                String archivo = System.AppDomain.CurrentDomain.BaseDirectory + @"ErrorAprobar.txt";
                //Label2.Text = archivo;
                using (System.IO.StreamWriter escritor = new System.IO.StreamWriter(archivo))
                {
                    escritor.WriteLine(a.ToString());
                }
                msjAp.Text = "Error al aprobar";
            }
        }

        protected void Button27_Click(object sender, EventArgs e)
        {
            //-----------------ver pendientes----------------------
            SqlDataSource9.SelectParameters["STATUS"].DefaultValue = "pendiente|";
            SqlDataSource9.SelectParameters["RFC"].DefaultValue = " ";
            SqlDataSource9.DataBind();
            GridView8.DataBind();
        }

        protected void Button28_Click(object sender, EventArgs e)
        {
            //-----------------ver rechazados----------------------
            SqlDataSource9.SelectParameters["STATUS"].DefaultValue = "rechazado|";
            SqlDataSource9.SelectParameters["RFC"].DefaultValue = " ";
            SqlDataSource9.DataBind();
            GridView8.DataBind();
        }

        protected void Button29_Click(object sender, EventArgs e)
        {
            //-----------------ver aprobados----------------------
            SqlDataSource9.SelectParameters["STATUS"].DefaultValue = "aprobado|";
            SqlDataSource9.SelectParameters["RFC"].DefaultValue = " ";
            SqlDataSource9.DataBind();
            GridView8.DataBind();
        }

        protected void Button26_Click(object sender, EventArgs e)
        {
            //-----------------ver todos----------------------
            Response.Redirect("~/menuReceDHL/solicitudes.aspx");
        }


        protected string DatosProv(string RFC)
        {
            //string ruta = ruta.Replace("XdService\\Interfaz\\bin\\Debug\\datos.txt", "Datos\\datos.txt");
            string respDat = "";
            string ruta = System.AppDomain.CurrentDomain.BaseDirectory + @"catalogos\Proveedores.txt";
            string[] valores = new string[5];
            StreamReader sr = new StreamReader(ruta);
            var linea = "";
            linea = sr.ReadLine();
            while ((linea = sr.ReadLine()) != null)
            //while (!String.IsNullOrEmpty(linea))
            {
                //linea = sr.ReadLine();
                if (!String.IsNullOrEmpty(linea))
                {
                    valores = linea.Split('|');
                    if (valores[0].Trim().Equals(RFC))
                    {
                        respDat = valores[2]+"|"+valores[3]+"|"+valores[4]; 
                    }
                }

            }
            sr.Dispose();
            sr.Close();
            return respDat;
           
        }

        protected void enviarMail(string idr, bool bnd, string caus)
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

            string us = "", ps = "", cr = "" ;

            BD.Conectar();
            BD.CrearComando("select usuario, pass, correo from Proveedores where idProveedor=@id");
            BD.AsignarParametroCadena("@id", idr);
            DbDataReader DR = BD.EjecutarConsulta();
            if (DR.Read()) {
                us = DR[0].ToString();
                ps = DR[1].ToString();
                cr = DR[2].ToString();
            }
            BD.Desconectar();

            if (us != "" && ps != "")
            {
                if (bnd)
                {
                    mail.servidorSTMP(servidor, puerto, ssl, emailCredencial, passCredencial);

                    string mensaje = "Estimado proveedor:<br><br>";
                    mensaje += "<br>Su solicitud de registro en el portal de recepción DHL ha sido a aprobada";
                    mensaje += "<br>Para ingresar al sistema dirijase a la página<br>";
                    mensaje += "<br>http://www.facturasdscm.com/";
                    mensaje += "<br>Ingrese su RFC y los siguientes datos:<br>";
                    mensaje += "<br>Usuario: " + us + "<br>";
                    mensaje += "<br>Contraseña: " + ps + "<br><br>";
                    mensaje += "<br>La primera vez que ingrese al sistema deberá cambiar su contraseña<br><br>";
                    mensaje += "<br>NO CONTESTE ESTE CORREO, HA SIDO ENVIADO DESDE UNA CUENTA DESATENDIDA";

                    mail.llenarEmail(emailEnviar, cr, "", "", "Acceso-Recepcion-DHL", mensaje);


                    mail.enviarEmail();
                }
                else {
                    mail.servidorSTMP(servidor, puerto, ssl, emailCredencial, passCredencial);

                    string mensaje = "Estimado proveedor:<br><br>";
                    mensaje += "<br>Su solicitud de registro en el portal de recepción DHL ha sido a rechazada";
                    mensaje += "<br>La causa del rechazo es el siguiente:<br>";
                    mensaje += "<br>-" + caus + "<br><br>";
                    mensaje += "<br>Para mayor información favor de comunicarse con DHL<br><br>";
                    mensaje += "<br>NO CONTESTE ESTE CORREO, HA SIDO ENVIADO DESDE UNA CUENTA DESATENDIDA";

                    mail.llenarEmail(emailEnviar, cr, "", "", "Acceso-Recepcion-DHL", mensaje);
                    mail.enviarEmail();
                }
            }


        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Panelbusc.Height=90;
            Panelbusc.Width = 360;
            Panelbusc.Visible = true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Panelbusc.Width = 20;
            Panelbusc.Height = 20;
            Panelbusc.Visible = false;
            Response.Redirect("~/menuReceDHL/solicitudes.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            
            SqlDataSource9.SelectParameters["STATUS"].DefaultValue = "aprobado|pendiente|rechazado";
            SqlDataSource9.SelectParameters["RFC"].DefaultValue = TextBusc.Text;
            SqlDataSource9.DataBind();
            GridView8.DataBind();
            Panelbusc.Width = 20;
            Panelbusc.Height = 20;
            Panelbusc.Visible = false;
        }
    }
}