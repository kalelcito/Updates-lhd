using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Diagnostics;

namespace DataExpressWeb
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta al iniciarse la aplicación

        }

        void Application_End(object sender, EventArgs e)
        {
            //  Código que se ejecuta cuando se cierra la aplicación
        }

        void Application_Error(object sender, EventArgs e)
        {
            Exception objErr = Server.GetLastError().GetBaseException();
            string err = "Error Caught in Application_Error event <br>" +
                    "Error in: " + Request.Url.ToString() +
                    "<br><br>Error Message:" + objErr.Message.ToString();
            // +            "<br><br>Stack Trace:" + objErr.StackTrace.ToString()
            Session["ErrorTec"] = err;
            //Response.Redirect("~/Error.aspx");



            var errorMessage = Server.GetLastError().Message;
            var errorString = Server.GetLastError().ToString();
            var errorStack = Server.GetLastError().StackTrace;
            var urlSource = Request.Url.LocalPath;
            var detallesError = "<p><strong>Error (String Format):</strong></p><blockquote>" + errorString + "</blockquote><p><strong>Error (Stack Trace):</strong></p><blockquote>" + errorStack + "</blockquote><br/>";
            try
            {
                if (HttpContext.Current != null && HttpContext.Current.Session != null)
                {
                    if (Session == null)
                    {
                        if (Request.Path.IndexOf("/consultarCodigo.aspx") != -1 || Request.Path.IndexOf("/download.aspx") != -1 || Request.Path.IndexOf("/descargarPDF.aspx") != -1 || Request.Path.IndexOf("/cuenta/Login.aspx") != -1)
                        {
                            Response.Redirect("~/cuenta/Login.aspx", false);
                            return;
                        }
                    }

                }
                else
                {
                    if (Request.Path.IndexOf("/download.aspx") != -1 || Request.Path.IndexOf("/descargarPDF.aspx") != -1 || Request.Path.IndexOf("/cuenta/Login.aspx") != -1)
                    {
                        Response.Redirect("~/cuenta/Login.aspx", false);
                        return;
                    }
                }
            }
            catch (Exception)
            {
            }


        }

        void Session_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta cuando se inicia una nueva sesión

        }

        void Session_End(object sender, EventArgs e)
        {
            // Código que se ejecuta cuando finaliza una sesión.
            // Nota: el evento Session_End se desencadena sólo cuando el modo sessionstate
            // se establece como InProc en el archivo Web.config. Si el modo de sesión se establece como StateServer 
            // o SQLServer, el evento no se genera.

        }

        protected void But2_Click(object sender, EventArgs e)
        {
        }
    }
}
