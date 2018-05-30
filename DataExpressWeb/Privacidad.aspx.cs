using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataExpressWeb
{
    public partial class Formulario_web129 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button25_Click(object sender, EventArgs e)
        {
            Session["otra"] = null;
            Response.Redirect("~/cuenta/Login.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["identificador"] = "Fecha: " + System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
            Response.Redirect("~/agregarProveedor.aspx");
        }
    }
}