using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataExpressWeb
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // this.Form.Target = "_blank";
            //if (Session["rfcUser"] != null)
            //{

            //   // lSesion.Text = (string)(Session["rfcUser"]);
            //}
        }

        protected void bSesion_Click(object sender, EventArgs e)
        {
            Session["rfcUser"] = null;
            Session["usuario"] = null;
            Session["razon"] = null;
            Session["permisos"] = null;
            Session["ini"] = true;
            Response.Redirect("~/cuenta/Login.aspx");
            
        }
    }
}
