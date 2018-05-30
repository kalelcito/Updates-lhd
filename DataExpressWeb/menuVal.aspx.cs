using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataExpressWeb
{
    public partial class Formulario_web13 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            error.Visible = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt16(Session["permisoVali"]) == 1 || Convert.ToInt16(Session["permisoVali"]) == 3)
            {
                Response.Redirect("Autorizar.aspx");
            }
            else {
                error.Text = "NO TIENES PERMISOS PARA VALIDAR FACTURAS";
                error.Visible = true;

            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt16(Session["permisoVali"]) == 2 || Convert.ToInt16(Session["permisoVali"]) == 3)
            {
                Response.Redirect("Autorizar2.aspx");
            }
            else
            {
                error.Text = "NO TIENES PERMISOS PARA VALIDAR FACTURAS POR PAGAR";
                error.Visible = true;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}