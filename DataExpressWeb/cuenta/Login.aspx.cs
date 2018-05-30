using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using System.Drawing;
using System.Data.Common;
namespace DataExpressWeb
{
    public partial class Login : System.Web.UI.Page
    {
        private BasesDatos DB = new BasesDatos();
        private String msj;
        private string Usuario = "", RazonSoc = "", rfcProv = "", pass = "";
        bool auxuser = false;
        private string habi = "";
        private string categoria;
        private int rol, perV;
        private string tipo;
        private bool band;
        private bool bandPanelMensaje = true;
        int bandtip;
        string soporte = "";
        string minutossoporte = "-";
        //DataRecepcionWeb wb = new DataRecepcionWeb();

        protected void Page_Load(object sender, EventArgs e)
        {

            DB.Conectar();
            DB.CrearComando("select soporte, minutosSoporte from ParametrosSistema");
            DbDataReader DRS = DB.EjecutarConsulta();
            if (DRS.Read())
            {
                soporte = DRS[0].ToString();
                minutossoporte = DRS[1].ToString();
            }
            DB.Desconectar();

            if (soporte == "no")
            {
                //Response.Redirect("~/Soporte.aspx", false); Context.ApplicationInstance.CompleteRequest();
                if (Session["usuario"] == null)
                {
                    if (Convert.ToBoolean(Session["ini"]))
                    {

                        bool banmen = false;
                        string mn = "", tit = "", colLe = "", colPan = "", tam = "", coltit = "";
                        msj = "";
                        categoria = "Login";
                        rol = 0;
                        //---------------------panel mensajes--------------------------
                        DB.Conectar();
                        DB.CrearComando("select * from confiMensaje where idMensaje=@id and habilitado=@habi");
                        DB.AsignarParametroCadena("@id", "1");
                        DB.AsignarParametroCadena("@habi", "si");
                        DbDataReader DR = DB.EjecutarConsulta();
                        if (DR.Read())
                        {
                            banmen = true;
                            mn = DR[1].ToString();
                            tit = DR[2].ToString();
                            colLe = DR[3].ToString();
                            colPan = DR[4].ToString();
                            tam = DR[7].ToString();
                            coltit = DR[9].ToString();
                        }
                        DB.Desconectar();

                        if (banmen)
                        {
                            Color color = System.Drawing.ColorTranslator.FromHtml(colPan);
                            Color color2 = System.Drawing.ColorTranslator.FromHtml(colLe);
                            Color color3 = System.Drawing.ColorTranslator.FromHtml(coltit);
                            //Ltit.ForeColor = color3;
                            titulo.ForeColor = color3;
                            //Lmsj.ForeColor = color2;
                            mensaje.ForeColor = color2;
                            // Pmsj.BackColor = color;
                            pMensaje.BackColor = color;

                            string[] tm = tam.Split('-');
                            //Pmsj.Width = Convert.ToInt32(tm[0]);
                            //Pmsj.Height = Convert.ToInt32(tm[1]);

                            //Lmsj.Text = mn;
                            //Ltit.Text = tit;
                            //Pmsj.Visible = true;
                            mensaje.Text = mn;
                            titulo.Text = tit;

                            if (DropDownList1.SelectedValue.Equals("Selecciona ingreso") && tbRfcuser.Text.Equals("") && tbPass.Text.Equals(""))
                            {
                                //this.Page.Response.Write("<script language='JavaScript'>window.alert(" + error + ");</script>");
                                //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('\\t\\t"+tit+"\\n\\n" + mn.Replace("\n", "\\n").Replace("\r", "").Replace("'", "\\'").Replace("<br/>","\\n") + "');", true);
                                mostrarPanelMensaje();

                            }
                        }
                        //-------------------------------------------------------------
                    }
                    else { Response.Redirect("~/Default.aspx"); }
                }
                //else
                //{
                //    Response.Redirect("~/Documentos.aspx");
                //}

                else if (Convert.ToBoolean(Session["adm"]))
                {
                    if (Convert.ToBoolean(Session["Bandera"]))
                    {
                        Response.Redirect("~/menuReceDHL/ComprobantesFiscales.aspx");
                    }
                }
                else
                {
                    if (Convert.ToBoolean(Session["Bandera"]))
                    {
                        Response.Redirect("~/Documentos.aspx");
                    }
                }
            }
            else
            {
                Response.Redirect("~/Soporte.aspx", false); Context.ApplicationInstance.CompleteRequest();
            }
        }

        protected void mostrarPanelMensaje()
        {
            //bandPanelMensaje = false;
            DropDownList1.Enabled = false;
            LinkButton1.Enabled = false;
            LinkButton2.Enabled = false;
            bSesion.Enabled = false;
            Pmsj.Visible = false;
            Image5.Visible = false;
            pMensaje.Visible = true;
            PanelMensaje.Visible = true;
        }

        protected void bSesion_Click(object sender, EventArgs e)
        {
            try
            {
                if (DropDownList1.SelectedValue == "Administrador")
                {
                    DB.Conectar();
                    DB.CrearComando(@"Select usuarios.idUsuario,usuarios.nombre,usuarios.login, usuarios.proveedor, usuarios.activo, grupos.permiso, 
                                             usuarios.empresas , usuarios.grupo, usuarios.correo, grupos.nivelRol
                                       From usuarios inner join grupos on grupos.nivelRol=usuarios.nivel where login=@us and pass=@ps");
                    DB.AsignarParametroCadena("@us", tbRfcuser.Text);
                    DB.AsignarParametroCadena("@ps", tbPass.Text);
                    DbDataReader DR2 = DB.EjecutarConsulta();
                    string aux = "";
                    if (DR2.Read())
                    {
                        auxuser = true;
                        band = true;
                        habi = DR2[4].ToString();
                        Session["id_usuario"] = DR2[0].ToString();
                        Session["identificador"] = DR2[0].ToString();
                        Session["rfcUser"] = DR2[1].ToString();
                        Session["usuario"] = DR2[2].ToString();
                        Session["razon"] = DR2[3].ToString();
                        Session["permisos"] = DR2[5].ToString();
                        Session["empresas"] = DR2[6].ToString().Replace("DHL METROPOLITAN LOGISTICS SC DE MEXICO", "DHL METROPOLITAN LOGISTICS SC MEXICO SA DE CV").Replace("DHL SUPPLY  CHAIN AUTOMOTIVE MEXICO SA DE CV", "DHL SUPPLY CHAIN AUTOMOTIVE MEXICO SA DE CV");
                        Session["grupo"] = DR2[7].ToString();
                        Session["correo"] = DR2[8].ToString();
                        Session["nivelRol"] = DR2[9].ToString();
                        Session["adm"] = true;
                        bandtip = 1;
                    }
                    else { band = false; }
                    DB.Desconectar();
                }

                if (DropDownList1.SelectedValue == "Proveedor")
                {
                    DB.Conectar();
                    DB.CrearComando("Select * From Proveedores where rfc=@rfc and usuario=@us and pass=@ps");
                    DB.AsignarParametroCadena("@rfc", tbrfc.Text);
                    DB.AsignarParametroCadena("@us", tbRfcuser.Text);
                    DB.AsignarParametroCadena("@ps", tbPass.Text);
                    DbDataReader DR = DB.EjecutarConsulta();
                    string aux = "";
                    if (DR.Read())
                    {
                        rfcProv = DR[1].ToString();
                        RazonSoc = DR[2].ToString();
                        Usuario = DR[6].ToString();
                        pass = DR[7].ToString();
                        habi = DR[9].ToString();
                        bandtip = Convert.ToInt32(DR[8]);
                        Session["id_usuario"] = DR[0].ToString();
                        Session["identificador"] = DR[0].ToString();
                        Session["proveedorTipe"] = DR[12];
                        Session["rfcUser"] = rfcProv;
                        Session["usuario"] = Usuario;
                        Session["razon"] = RazonSoc;
                        Session["correo"] = DR["correo"].ToString();
                        band = true;
                    }
                    else
                    {
                        band = false;
                    }
                }
                if (tbRfcuser.Text != "" && tbPass.Text != "" && band == true)
                {
                    if (habi == "si")
                    {
                        if (!(pass.Contains("CLA")))
                        {
                            if (bandtip == 1)
                            {
                                Session["Bandera"] = true;
                                Session["Menu"] = true;
                                Session["Menu2"] = true;
                                Session["men"] = true;
                                Session["otra"] = null;
                                if (soporte == "si") { Response.Redirect("~/Soporte.aspx", false); Context.ApplicationInstance.CompleteRequest(); }
                                else { Response.Redirect("~/menuReceDHL/inicio.aspx", false); Context.ApplicationInstance.CompleteRequest(); }
                            }
                            else if (bandtip == 2)
                            {
                                Session["Bandera"] = true;
                                Session["adm"] = false;
                                Session["adSub"] = "";
                                Session["men"] = false;

                                if (soporte == "si") { Response.Redirect("~/Soporte.aspx", false); Context.ApplicationInstance.CompleteRequest(); }
                                else { Response.Redirect("~/Documentos.aspx", false); Context.ApplicationInstance.CompleteRequest(); }
                            }
                            else if (bandtip == 3)
                            {

                                not.Text = "ACCESO EN PROCESO DE AUTORIZACIÓN";

                            }
                            else if (bandtip == 4)
                            {

                                not.Text = "SU SOLICITUD FUE RECHAZADA,<br> FAVOR DE PONERSE EN CONTACTO CON UN <br> ADMINISTRADOR";

                            }
                        }
                        else
                        {
                            Session["confirmacion"] = 1;
                            Session["mensajeCon"] = "La contraseña ha expirado, \n Favor de renovarla";
                            Session["redi"] = 1;
                            Session["adSub"] = "";
                            Session["men"] = false;


                            Session["identificador"] = null;
                            Session["rfcUser"] = null;
                            Session["usuario"] = null;
                            Session["razon"] = null;
                            Session["permisos"] = null;
                            Session["adm"] = null;

                            Response.Redirect("~/notificacion.aspx");
                            //Response.Redirect("~/RenovarContra.aspx");
                        }
                    }
                    else
                    {
                        if (Convert.ToBoolean(Session["adm"]))
                        {
                            Session["identificador"] = null;
                            Session["rfcUser"] = null;
                            Session["usuario"] = null;
                            Session["razon"] = null;
                            Session["permisos"] = null;
                            Session["adm"] = null;


                            not.Text = "Empleado deshabilitado";


                        }
                        else
                        {
                            Session["identificador"] = null;
                            Session["rfcUser"] = null;
                            Session["permisos"] = null;
                            Session["usuario"] = null;
                            Session["razon"] = null;
                            Session["adm"] = null;


                            not.Text = "Proveedor deshabilitado";

                        }
                    }
                }
                else
                {

                    not.Text = "DATOS INCORRECTOS";

                }
            }
            catch (System.Threading.ThreadAbortException)
            {

            }
            catch (Exception ma)
            {

                not.Text = "PROBLEMAS AL BUSCAR EL PROVEEDOR";

            }
        }

        protected void bRegistrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/agregarProveedor.aspx");
        }

        protected void bLimpiar_Click(object sender, EventArgs e)
        {
            tbrfc.Text = "";
            tbPass.Text = "";
            tbRfcuser.Text = "";
        }

        protected void bOlvide_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/OlvideContra.aspx");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "Proveedor")
            {
                Label1.Visible = true;
                tbrfc.Visible = true;
                Label2.Visible = true;
                tbRfcuser.Visible = true;
                Label3.Visible = true;
                tbPass.Visible = true;
            }
            else if (DropDownList1.SelectedValue == "Administrador")
            {
                Label1.Visible = false;
                tbrfc.Visible = false;
                Label2.Visible = true;
                tbRfcuser.Visible = true;
                Label3.Visible = true;
                tbPass.Visible = true;
            }
        }

        protected void DropDownList1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["otro"] = true;
            Session["adSub"] = "";
            Response.Redirect("~/Privacidad.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Session["otro"] = true;
            Session["adSub"] = "";
            Response.Redirect("~/OlvideContra.aspx");

        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            DropDownList1.Enabled = true;
            LinkButton1.Enabled = true;
            LinkButton2.Enabled = true;
            bSesion.Enabled = true;
            Pmsj.Visible = true;
            Image5.Visible = true;
            pMensaje.Visible = false;
            PanelMensaje.Visible = false;
        }
    }
}