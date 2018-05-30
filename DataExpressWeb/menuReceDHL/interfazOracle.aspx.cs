using System;

namespace DataExpressWeb
{
    public partial class Formulario_webOracle : System.Web.UI.Page
    {
        #region Variables

        #endregion

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

            HyperLink1.Visible = true;

            if (Session["permisos"] != null && Session["permisos"].ToString().Contains("Valdif|"))
            {
                li1.Visible = true;
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/subirXLS.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/RegistrosXLS.aspx");
        }


    }
}