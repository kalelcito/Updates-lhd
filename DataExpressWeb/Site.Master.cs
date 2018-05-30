using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Control;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Security.Cryptography;

namespace DataExpressWeb
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {


            if (Convert.ToBoolean(Session["estPan"]))
            {
                Session["estPan"] = false;
            }
            if (Session["otro"] != null)
            {
                m1.Visible = false;
                m2.Visible = false;
            }

            if (Session["rfcUser"] != null && Session["usuario"] != null
                && Session["razon"] != null)
            {

                if (Convert.ToBoolean(Session["estPan"]) == false)
                {
                    //noti.Visible = false;
                }

                if (Convert.ToBoolean(Session["Bandera"]))
                {
                    string fechaHoy = System.DateTime.Now.ToString("yyyy-MM-dd");
                    lRfc.Text = fechaHoy + "  " + "<br>" + "Bienvenido | " + Session["usuario"].ToString() + "  " + "<br>";
                    if (!Convert.ToBoolean(Session["men"]))
                    {
                        m1.Visible = false;
                        m2.Visible = false;
                    }
                    else
                    {
                        revisarPer();
                    }
                }
            }
            else if (Session["rfcUser"] == null && Session["usuario"] == null
                && Session["razon"] == null && Session["otra"] != null)
            {
                Response.Redirect("~/Default.aspx");
            }

            if (Session["permisos"] != null && Session["permisos"].ToString().Contains("OraGenIt|"))
            {
                m2.Visible = true;
                HyperLink9.Visible = true;
            }
        }

        protected void NavigationMenu_MenuItemClick(object sender, MenuEventArgs e)
        {

        }

        public void Tmsj_Tick(object sender, EventArgs e)
        {
            this.noti.Visible = false;
            Tmsj.Enabled = false;
        }

        protected void menu_MenuItemClick(object sender, MenuEventArgs e)
        {
            int index = Int32.Parse(e.Item.Value);
            if (index == 1)
            {
                Session["Menu3"] = true;
                Session["Menu2"] = false;
                Response.Redirect("~/menuReceDHL/UsuariosDhl.aspx");
            }
            else if (index == 0)
            {
                Session["Menu3"] = false;
                Session["Menu2"] = true;
                Response.Redirect("~/menuReceDHL/ComprobantesFiscales.aspx");
            }


        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (Session["adm"] != null)
            {
                if (Convert.ToBoolean(Session["adm"]))
                {
                    Response.Redirect("~/menuReceDHL/perfilEmple.aspx");
                }
                else
                {
                    Response.Redirect("~/menuReceDHL/perfilProv.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        protected void revisarPer()
        {
            if (!(Session["permisos"].ToString().IndexOf("PorConsultas") < 0))
            {
                m2.Visible = true;
            }
            if (!(Session["permisos"].ToString().IndexOf("Administracion") < 0))
            {
                m1.Visible = true;
            }

            //if (m2.Visible) {
            //    if (!(Session["permisos"].ToString().IndexOf("CompFis") < 0))
            //    {
            //        HyperLink2.Visible = true;
            //    }
            //    if (!(Session["permisos"].ToString().IndexOf("Interfaz") < 0))
            //    {
            //        HyperLink3.Visible = true;
            //    }
            //}

            //if (m1.Visible)
            //{
            //    if (!(Session["permisos"].ToString().IndexOf("AdmUsuarios") < 0))
            //    {
            //        HyperLink4.Visible = true;
            //    }
            //    if (!(Session["permisos"].ToString().IndexOf("AdmProveedores") < 0))
            //    {
            //        HyperLink11.Visible = true;
            //    }
            //    if (!(Session["permisos"].ToString().IndexOf("AdmReceptores") < 0))
            //    {
            //        HyperLink13.Visible = true;
            //    }
            //    if (!(Session["permisos"].ToString().IndexOf("AdmConfiguracion") < 0))
            //    {
            //        HyperLink15.Visible = true;
            //    }
            //    if (!(Session["permisos"].ToString().IndexOf("AdmMensajes") < 0))
            //    {
            //        HyperLink6.Visible = true;
            //    }
            //    if (!(Session["permisos"].ToString().IndexOf("Reportes") < 0))
            //    {
            //        HyperLink5.Visible = true;
            //    }

            //}
        }

        public void MostrarAlerta(Page page, string mensaje, int messageLevel = 0, string size = null, string jsCallBack = null, string jsAlong = null)
        {
            var js = !string.IsNullOrEmpty(jsAlong) ? jsAlong : "";
            js += "alertBootBox('" + mensaje.Replace(Environment.NewLine, "<br />").Replace("'", "\"") + "'";
            //js += "," + messageLevel;
            //js += ",'" + (!string.IsNullOrEmpty(jsCallBack) ? jsCallBack.Replace("'", "\"") : "") + "'";
            //js += ",'" + (!string.IsNullOrEmpty(size) ? size : "") + "'";
            //js += ");";
            ScriptManager.RegisterStartupScript(page, page.GetType(), "_key" + Md5Alert(), js, true);
        }

        public static string Md5Alert()
        {
            var sb = new StringBuilder();
            using (var sha1 = MD5.Create())
            {
                var fecha = DateTime.Now.ToString("s");
                var inputBytes = Encoding.ASCII.GetBytes(fecha);
                var hashBytes = sha1.ComputeHash(inputBytes);
                foreach (var t in hashBytes)
                {
                    sb.Append(t.ToString("X2"));
                }
            }
            return sb.ToString();

        }

    }
}
