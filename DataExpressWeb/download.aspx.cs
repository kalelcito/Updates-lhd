using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace DataExpressWeb
{
    public partial class Formulario_web11 : System.Web.UI.Page
    {
        //String sRuta = "";
        String filename = "";
        String LOG_AditionaFILES = AppDomain.CurrentDomain.BaseDirectory + @"log\Error " + System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss").Replace("T", "_").Replace("-", "_").Substring(0, 10) + ".txt";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // filename = Request.RawUrl.Replace("/download.aspx?file=","");
                filename = Request.QueryString["file"];
                var pagina = Request.UrlReferrer.ToString().ToLower();
                // filename = filename.Replace("file=", "").Replace("%5c", "/");
                if (!String.IsNullOrEmpty(filename))
                {
                    String dlDir = "";//@"docus/";
                    String path = Server.MapPath(dlDir + filename);
                    Label1.Text = path;
                    System.IO.FileInfo toDownload =
                                 new System.IO.FileInfo(path);
                    var isCsv = pagina.Contains("interfazoracle.aspx") && filename.EndsWith(".csv", StringComparison.OrdinalIgnoreCase);
                    if (toDownload.Exists)
                    {
                        Response.Clear();
                        Response.AddHeader("Content-Disposition",
                                   "attachment; filename=" + (isCsv ? "XXGL_MX_APINVOICES_EXT_DOC.csv" : toDownload.Name));
                        Response.AddHeader("Content-Length",
                                   toDownload.Length.ToString());
                        Response.ContentType = "application/octet-stream";
                        Response.WriteFile(dlDir + filename);
                        Response.End();
                    }
                }
                else
                {
                    Label1.Text = "No contiene Documento";
                }
            }
            catch (Exception ex) {
                anade_linea_archivo(LOG_AditionaFILES, "Error " + ex.ToString() + "|" +filename);
            }
        }

        public static void anade_linea_archivo(string archivo, string linea)
        {
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + @"log"))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"log");
            }
            using (StreamWriter w = File.AppendText(archivo))
            {
                w.WriteLine(linea.Replace(Environment.NewLine, ""));
                w.Flush();
                w.Close();
            }
        }
    }
}