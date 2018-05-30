using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataExpressWeb
{
    public partial class notificacionElim : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int aux = Convert.ToInt32(Session["confirmacion"]);

            if (aux == 1)
            {
                string col = "#ffcc00";
                Color color = System.Drawing.ColorTranslator.FromHtml(col);
                P11.BackColor = color;
                mso.Text = Session["mensajeCon"].ToString();
                Im.ImageUrl = "~/Imagenes-dhl/warning.png";
            }

            if (aux == 2)
            {
                string col2 = "#d1d1d1";
                Color color2 = System.Drawing.ColorTranslator.FromHtml(col2);
                P11.BackColor = color2;
                mso.Text = Session["mensajeCon"].ToString();
                Im.ImageUrl = "~/Imagenes-dhl/paloma.png";
            }
        }

        protected void ok_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/menuReceDHL/ComprobantesFiscales.aspx");
        }
    }
}