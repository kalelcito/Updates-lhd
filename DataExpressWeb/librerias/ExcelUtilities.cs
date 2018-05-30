using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Reflection;

namespace DataExpressWeb.librerias
{
    public class ExcelUtilities
    {

        public static void GeneraExcel(List<object> lista)
        {
            StreamWriter w;
            String nombre = System.DateTime.Now.ToString("ddMMyyyy_HHmmss");
            if (lista != null && lista.Count > 0)
            {
                FileStream fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + @"reportes/docs/"+nombre+".xls", FileMode.Create, FileAccess.ReadWrite);
                w = new StreamWriter(fs);

                PropertyInfo[] p = lista[0].GetType().GetProperties();

                EscribeHeader(w, p);

                foreach (object obj in lista)
                {
                    EscribeLinea(w, p, obj);
                }

                EscribeFooter(w);
                w.Close();
                w.Dispose();

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "application/ms-excel";
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + nombre + ".xls");
                HttpContext.Current.Response.WriteFile(AppDomain.CurrentDomain.BaseDirectory + "reportes/docs/" + nombre + ".xls");
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.Close();

                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "reportes/docs/" + nombre + ".xls"))
                    File.Delete(AppDomain.CurrentDomain.BaseDirectory + "reportes/docs/" + nombre + ".xls");
            }
        }



        private static void EscribeHeader(StreamWriter w, PropertyInfo[] p)
        {
            StringBuilder html = new StringBuilder();
            html.Append("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">");
            html.Append("<html>");
            html.Append("  <head>");
            html.Append("<title>www.devjoker.com</title>");
            html.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />");
            html.Append("  </head>");
            html.Append("<body>");
            html.Append("<p>");
            html.Append("<table>");
         /*   html.Append("<tr style=\"font-weight:  bold;font-size: 12px;color: white;\">");

            foreach (PropertyInfo pro in p)
            {
                html.Append("<td bgcolor=\"Blue\">" + pro.Name + "</td>");
            }

            html.Append("</tr>");
            */
            w.Write(html.ToString());
        }



        private static void EscribeLinea(StreamWriter w, PropertyInfo[] p, object o)
        {
            string linea = "<tr>";

            foreach (PropertyInfo prop in p)
            {
                linea += "<td>" + (prop.GetValue(o, null) != null ? prop.GetValue(o, null).ToString() : string.Empty) + "</td>";
            }

            linea += "</tr>";

            w.Write(linea);
        }

        private static void EscribeFooter(StreamWriter w)
        {
            StringBuilder html = new StringBuilder();
            html.Append("  </table>");
            html.Append("</p>");
            html.Append(" </body>");
            html.Append("</html>");
            w.Write(html.ToString());
        }
    }
}
