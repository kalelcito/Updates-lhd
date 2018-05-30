using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataExpressWeb
{
    public partial class Cerrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session.RemoveAll();
            Session["ini"] = false;
            Session["permisos"] = null;
            Session["usuario"] = null;
            Session["Bandera"] = false;
            Session["rfcUser"] = null;
            Session["rolUser"] = null;
            Session["rfcCliente"] = null;
            Session["crCliPermisos"] = null;
            Session["crAdminPermiso"] = null;
            Session["coFactPropias"] = null;
            Session["coFactTodas"] = null;
            Session["repSucursales"] = null;
            Session["repGlobales"] = null;
            Session["moEmpleado"] = null;
            Session["asRoles"] = null;
            Session["enFacturasEmail"] = null;
            Session["crDocumento"] = null;
            Session["tbRfcRectemp"] = null;
            Session["tbNomRectemp"] = null;
            Session["tbDomRectemp"] = null;
            Session["tbColRectemp"] = null;
            Session["tbMunRectemp"] = null;
            Session["tbCpRectemp"] = null;
            Session["tbEstRectemp"] = null;
            Session["tbPaiRectemp"] = null;
            Session["tbLocRectemp"] = null;
            Session["Menu"] = false;
            Session["Menu2"] = false;
            Session["Menu3"] = false;
            Session["adSub"] = null;
            Session["proveedorTipe"] = null;
            Session["men"] = null;
            Session["otra"] = null;
            Session["grupo"] = null;

            Response.Redirect("~/Default.aspx");
        }
    }
}