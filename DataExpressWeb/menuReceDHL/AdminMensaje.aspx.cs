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
    public partial class Formulario_web126 : System.Web.UI.Page
    {
        private BasesDatos DB = new BasesDatos();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["usuario"] != null || Session["adm"] != null || Session["permisos"] != null)
                {
                    //revisarPer();
                    if (Convert.ToBoolean(Session["adm"]))
                    {

                        DB.Conectar();
                        DB.CrearComando("select * from confiMensaje where idMensaje=@id");
                        DB.AsignarParametroCadena("@id", "1");
                        DbDataReader DR = DB.EjecutarConsulta();
                        if (DR.Read())
                        {
                            Ttama.Text = DR[7].ToString();
                            TcolPan.Text = DR[4].ToString();
                            Ttitulo.Text = DR[2].ToString();
                            TcolTit.Text = DR[9].ToString();
                            Tcuerpo.Text = DR[1].ToString().Replace("<br/>", "&");
                            TcolorCuer.Text = DR[3].ToString();
                            Lfecha.Text = DR[10].ToString();
                            if (DR[8].ToString() == "si")
                            {
                                Check.Checked = true;
                            }
                            else
                            {
                                Check.Checked = false;
                            }
                        }
                        DB.Desconectar();
                    }
                    else
                    {
                        Response.Redirect("~/Documentos.aspx");
                    }
                }
                else
                {
                    Response.Redirect("~/Cerrar.aspx");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            bool banHex = true;
            if (TcolPan.Text != "")
            {
                if (TcolPan.Text.IndexOf("#") >= 0 && TcolPan.Text.Length == 7 && TcolPan.Text.Substring(0,1)=="#")
                {
                    string aux= TcolPan.Text.Replace("#","");
                    foreach(var c in aux){
                        if (!((c >= '0' && c <= '9') || (c >= 'a' && c <= 'f') || (c >= 'A' && c <= 'F'))) {
                            banHex = false;
                        }
                    }
                    if (banHex)
                    {
                        Color color = System.Drawing.ColorTranslator.FromHtml(TcolPan.Text);
                        P1.BackColor = color;
                        m.Text = "Válido";
                        m.Visible = true;
                    }
                    else {
                        m.Text = "formato incorrecto";
                        m.Visible = true;
                        mensaje.Text = "El hexadecimal solo acepta números (0-9) y letras de (A-F)";
                    }
                    
                }
                else
                {
                    Color color = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    P1.BackColor = color;
                    m.Text = "formato incorrecto";
                    m.Visible = true;
                }
            }
            else {
                Color color = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                P1.BackColor = color;
                m.Text = "campo vacio";
                m.Visible = true;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            bool banHex = true;
            if (TcolTit.Text != "")
            {
                if (TcolTit.Text.IndexOf("#") >= 0 && TcolTit.Text.Length == 7 && TcolTit.Text.Substring(0, 1) == "#")
                {
                    string aux = TcolTit.Text.Replace("#", "");
                    foreach (var c in aux)
                    {
                        if (!((c >= '0' && c <= '9') || (c >= 'a' && c <= 'f') || (c >= 'A' && c <= 'F')))
                        {
                            banHex = false;
                        }
                    }
                    if (banHex)
                    {
                        Color color = System.Drawing.ColorTranslator.FromHtml(TcolTit.Text);
                        P2.BackColor = color;
                        m2.Text = "Válido";
                        m2.Visible = true;
                    }
                    else
                    {
                        m.Text = "formato incorrecto";
                        m.Visible = true;
                        mensaje.Text = "El hexadecimal solo acepta números (0-9) y letras de (A-F)";
                    }
                }
                else
                {
                    Color color = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    P2.BackColor = color;
                    m2.Text = "formato incorrecto";
                    m2.Visible = true;
                }
            }
            else
            {
                Color color = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                P2.BackColor = color;
                m2.Text = "campo vacio";
                m2.Visible = true;
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            bool banHex = true;
            if (TcolorCuer.Text != "")
            {
                if (TcolorCuer.Text.IndexOf("#") >= 0 && TcolorCuer.Text.Length == 7 && TcolorCuer.Text.Substring(0, 1) == "#")
                {
                    string aux = TcolorCuer.Text.Replace("#", "");
                    foreach (var c in aux)
                    {
                        if (!((c >= '0' && c <= '9') || (c >= 'a' && c <= 'f') || (c >= 'A' && c <= 'F')))
                        {
                            banHex = false;
                        }
                    }
                    if (banHex)
                    {
                        Color color = System.Drawing.ColorTranslator.FromHtml(TcolorCuer.Text);
                        P3.BackColor = color;
                        m3.Text = "Válido";
                        m3.Visible = true;
                    }
                    else
                    {
                        m.Text = "formato incorrecto";
                        m.Visible = true;
                        mensaje.Text = "El hexadecimal solo acepta números (0-9) y letras de (A-F)";
                    }
                }
                else
                {
                    Color color = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    P3.BackColor = color;
                    m3.Text = "formato incorrecto";
                    m3.Visible = true;
                }
            }
            else
            {
                Color color = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                P3.BackColor = color;
                m3.Text = "campo vacio";
                m3.Visible = true;
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            bool banHex = true, banHex2 = true, banHex3 = true , bantama=true;
            if(Ttama.Text != "" && TcolPan.Text !="" && Ttitulo.Text != "" && TcolTit.Text != "" && Tcuerpo.Text != "" && TcolorCuer.Text != ""){
                if ((TcolorCuer.Text.IndexOf("#") >= 0 && TcolorCuer.Text.Length == 7 && TcolorCuer.Text.Substring(0, 1) == "#")
                    && (TcolTit.Text.IndexOf("#") >= 0 && TcolTit.Text.Length == 7 && TcolTit.Text.Substring(0, 1) == "#")
                    && (TcolPan.Text.IndexOf("#") >= 0 && TcolPan.Text.Length == 7 && TcolPan.Text.Substring(0, 1) == "#"))
                {
                    if (Ttama.Text.IndexOf("-") >= 0 && (Ttama.Text.Substring(3, 1) == "-" || Ttama.Text.Substring(2, 1) == "-" || Ttama.Text.Substring(1, 1) == "-")
                        && (Ttama.Text.Length >= 3 && Ttama.Text.Length <= 7))
                    {
                        string aux = TcolPan.Text.Replace("#", "");
                        foreach (var c in aux)
                        {
                            if (!((c >= '0' && c <= '9') || (c >= 'a' && c <= 'f') || (c >= 'A' && c <= 'F')))
                            {
                                banHex = false;
                            }
                        }

                        string aux2 = TcolTit.Text.Replace("#", "");
                        foreach (var c in aux2)
                        {
                            if (!((c >= '0' && c <= '9') || (c >= 'a' && c <= 'f') || (c >= 'A' && c <= 'F')))
                            {
                                banHex2 = false;
                            }
                        }

                        string aux3 = TcolorCuer.Text.Replace("#", "");
                        foreach (var c in aux3)
                        {
                            if (!((c >= '0' && c <= '9') || (c >= 'a' && c <= 'f') || (c >= 'A' && c <= 'F')))
                            {
                                banHex3 = false;
                            }
                        }
                        if (banHex && banHex2 && banHex3)
                        {
                            string aux4 = Ttama.Text.Replace("-", "");
                            foreach (var c in aux4)
                            {
                                if (!(c >= '0' && c <= '9'))
                                {
                                    bantama = false;
                                }
                            }
                            if (bantama)
                            {
                                DB.Conectar();
                                DB.CrearComando(@"update confiMensaje set mensaje=@men, tituloMensaje=@tit, colorLetra=@col, colorPanel=@colP, tamPanel=@tp, habilitado=@habi, colorTitLet=@colT, fecMod=@fec
                                        where idMensaje=@id");
                                DB.AsignarParametroCadena("@men", Tcuerpo.Text.Replace("&", "<br/>"));
                                DB.AsignarParametroCadena("@tit", Ttitulo.Text);
                                DB.AsignarParametroCadena("@col", TcolorCuer.Text);
                                DB.AsignarParametroCadena("@colP", TcolPan.Text);
                                DB.AsignarParametroCadena("@tp", Ttama.Text);
                                if (Check.Checked)
                                {
                                    DB.AsignarParametroCadena("@habi", "si");
                                }
                                else
                                {
                                    DB.AsignarParametroCadena("@habi", "no");
                                }
                                DB.AsignarParametroCadena("@colT", TcolTit.Text);
                                DB.AsignarParametroCadena("@fec", System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
                                DB.AsignarParametroCadena("@id", "1");
                                DB.EjecutarConsulta();
                                DB.Desconectar();

                                Response.Redirect("~/menuReceDHL/AdminMensaje.aspx");
                            }
                            else {
                                mensaje.Text = "Error: el formato del tamaño no puede contener letras u otros signos";
                            }
                        }
                        else {
                            mensaje.Text = "Error: el formata hexadecimal solo acepta numeros (0-9) y letras (A-F)";
                        }

                    }else{
                        mensaje.Text = "Formato incorrecto del tamaño";
                    }
                }
               else{
                   mensaje.Text = "Existe un formato de color incorrecto";
               }
            }else{
                mensaje.Text = "Existen campos vacios";
            }
        }

        //protected void revisarPer()
        //{
        //    if (!(Session["permisos"].ToString().IndexOf("AdmUsuarios") < 0))
        //    {
        //        HyperLink5.Visible = true;
        //    }
        //    if (!(Session["permisos"].ToString().IndexOf("AdmProveedores") < 0))
        //    {
        //        HyperLink1.Visible = true;
        //    }
        //    if (!(Session["permisos"].ToString().IndexOf("AdmReceptores") < 0))
        //    {
        //        HyperLink3.Visible = true;
        //    }
        //    if (!(Session["permisos"].ToString().IndexOf("AdmConfiguracion") < 0))
        //    {
        //        HyperLink4.Visible = true;
        //    }
        //    if (!(Session["permisos"].ToString().IndexOf("Reportes") < 0))
        //    {
        //        HyperLink2.Visible = true;
        //    }
        //}
    }
}