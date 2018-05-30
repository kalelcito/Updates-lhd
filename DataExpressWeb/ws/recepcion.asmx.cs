using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Datos;
using ValSign;
using Control;
using System.IO;
using System.Data.Common;
namespace DataExpressWeb.ws
{
    /// <summary>
    /// Descripción breve de recepcion
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
        
    public class recepcion : System.Web.Services.WebService
    {
        Facturas FAC;

        BasesDatos DB = new BasesDatos();
        Validacion val;
        string dirArc, dirPdf, dirBck;
         string msj;

        [WebMethod]

        public string recibirFactura(byte[] xml, byte[] pdf, string email, string nombre, string dst)
        {
            try
            {
               
                DB.Conectar();
                DB.CrearComando(@"SELECT dirtxt,dirdocs,dirrespaldo from ParametrosSistema");
                DbDataReader DR = DB.EjecutarConsulta();
                if (DR.Read())
                {
                    dirArc = DR[0].ToString();
                    dirPdf = DR[1].ToString();
                    dirBck = DR[2].ToString();
                }
                DB.Desconectar();

                if (xml != null)
                {
                    //StreamWriter swXml = new StreamWriter(dirArc + nombre + ".xml");
                    //swXml.Write(xml);
                    //swXml.Close();
                    //swXml.Dispose();
                    System.IO.File.WriteAllBytes(dirArc + nombre + ".xml", xml);
                }
                if (pdf != null)
                {
                    
                    //StreamWriter swPdf = new StreamWriter(dirArc + nombre + ".pdf");
                    //swPdf.Write(xml);
                    //swPdf.Close();
                    //swPdf.Dispose();
                    System.IO.File.WriteAllBytes(dirArc + nombre + ".pdf", pdf);
                }
                String[] files = Directory.GetFiles(dirArc);

                FAC = new Facturas(files, dirBck, dirPdf, dirArc, "", Session["identificador"].ToString());
                FAC.emails = email;
                FAC.msj = "";
                FAC.TIPOORDEN = dst;

                FAC.leerIndividual(dirArc + nombre + ".xml");

                //Estatus general
                //msj = FAC.getmsgarrayLog();
                return msj;
            }
            catch (Exception e)
            {
                return e.ToString();

            }
        }
       
        public void Escribe_Arch(string datos, string nombre)
        {
            //string datos = "Hola..  ";
            string nombre_hoy;
            if (String.IsNullOrEmpty(nombre))
            {
                nombre_hoy = "Log_" + DateTime.Now.ToString("ddMMyyyy") + ".txt";
            }
            else
            {
                nombre_hoy = nombre + ".txt";
            }
            //System.AppDomain.CurrentDomain.BaseDirectory
            string ruta = AppDomain.CurrentDomain.BaseDirectory + nombre_hoy;
            if (File.Exists(ruta))
            {
                using (StreamWriter w = File.AppendText(ruta))
                {
                    Log(datos, w);
                    w.Close(); // Close the writer and underlying file.
                }
            }
            else
            {
                FileStream fs1 = new FileStream(ruta, FileMode.CreateNew);
                BinaryWriter c1 = new BinaryWriter(fs1);
                c1.Close();
                fs1.Close();
                using (StreamWriter w = File.AppendText(ruta))
                {
                    Log(datos, w);
                    w.Close(); // Close the writer and underlying file.


                }
            }
        }
        public void Log(String logMessage, TextWriter w)//Archivo Log
        {
            w.WriteLine(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + " " + logMessage);
            w.Flush();
        }
    }
}
