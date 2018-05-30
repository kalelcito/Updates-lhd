using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Printing;

namespace DataExpressWeb
{
    public partial class Formulario_web17 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           int aux= Convert.ToInt32(Session["confirmacion"]);

           if (aux == 1) {
               string col = "#ffcc00";
                   Color color = System.Drawing.ColorTranslator.FromHtml(col);
               P1.BackColor = color;
               mso.Text = Session["mensajeCon"].ToString();
               Im.ImageUrl = "~/Imagenes-dhl/warning.png";
           }

           if (aux == 2) {
               string col2 = "#d1d1d1";
               Color color2 = System.Drawing.ColorTranslator.FromHtml(col2);
               P1.BackColor = color2;
               mso.Text = Session["mensajeCon"].ToString();
               Im.ImageUrl = "~/Imagenes-dhl/paloma.png";
           }
        }

        protected void ok_Click(object sender, EventArgs e)
        {
            int rd = Convert.ToInt32(Session["redi"]);
            if (Session["adSub"].ToString() != "Admin")
            {
                if (rd == 1)
                {
                    Session["otra"] = null;
                    Response.Redirect("RenovarContra.aspx", false);
                }
                if (rd == 2)
                {
                    Session["rfcUser"] = null;
                    Session["usuario"] = null;
                    Session["permisos"] = null;
                    Session["razon"] = null;
                    Session["otra"] = null;
                    Session["identificador"] = null;
                    Response.Redirect("~/Default.aspx", false);
                }
            }
            else {
                Session["adSub"] = null;
                Response.Redirect("~/menuReceDHL/proveedoresDhl.aspx");
            }
        }
    }
}