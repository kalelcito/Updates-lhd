using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Xml.Schema;
using System.Xml;
using System.IO;
using Crypto;
using Datos;

namespace ValSign
{
    public class Validacion
    {
        public string cadenaOriginal { get; set; }
        private string selloDigital;
        private string hashData;
        public string version { get; set; }
        public string fecha { get; set; }
        public string msj { get; set; }
        public string msjT { get; set; }
        private SelloDigital Sello;
        private XslTransform xslt1 = null;
        public Validacion()
        {
            cadenaOriginal = "";
            Sello = new SelloDigital();
            xslt1 = new XslTransform();

        }

        public string generaCadena(string plantilla, XmlDocument xmlDoc)
        {
            try
            {
                if (version.Equals("2.2"))
                {
                    plantilla += "cadenaoriginal_2_2.xslt";
                }
                else if (version.Equals("2.0"))
                {
                    plantilla += "cadenaoriginal_2_0.xslt";
                }
                else if (version.Equals("3.2"))
                {
                    plantilla += "cadenaoriginal_3_2.xslt";
                }
                else if (version.Equals("3.3"))
                {
                    plantilla += "cadenaoriginal_3_3.xslt";
                }
                else if (version.Equals("tfd1.0"))
                {
                    plantilla += "cadenaoriginal_TFD_1_0.xslt";
                }
                UTF8Encoding utf8 = new UTF8Encoding();
                xslt1.Load(plantilla);
                //XPathDocument myXML = new XPathDocument(xmlDoc);
                // XmlWriter writer = new XmlTextWriter("UTF8.txt".ToString(), UTF8Encoding.UTF8);
                MemoryStream ms = new MemoryStream();
                xslt1.Transform(xmlDoc, null, ms);
                ms.Position = 0;
                StreamReader sr = new StreamReader(ms, UTF8Encoding.UTF8);
                cadenaOriginal = sr.ReadToEnd();
                byte[] utf8Bytes = System.Text.Encoding.UTF8.GetBytes(cadenaOriginal);
                cadenaOriginal = System.Text.Encoding.UTF8.GetString(utf8Bytes);


            }
            catch (Exception es)
            {
                using (StreamWriter outfile = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"\errorGeneraCadena.txt"))
                {
                    outfile.Write(es.ToString());
                }
            }


            return cadenaOriginal;
        }

        public Boolean validarXML(string strSello, string strCertificado, string band)
        {
            string strHash;
            DateTime fechaXML;
            //  try
            //  {
            var verSellado = "";
            fechaXML = Convert.ToDateTime(fecha);
            if (!version.Equals("3.3")) { verSellado = "Sha1"; }
            else { verSellado = "Sha256"; }
            if (fechaXML.Year <= 2010)
            {
                Sello.setHash("Md5");
            }
            else
            {
                Sello.setHash(verSellado);
            }



            strHash = Sello.Mex_ExtractDigestFromSignature(strSello, strCertificado.Trim());
            // strHash = "si";
            hashData = Sello.Mex_CreateDigestFromString(cadenaOriginal);
            //hashData = "si";



            if (hashData == strHash)
            {
                msj += "El Sello es Válido" + Environment.NewLine;
                return true;
            }
            else
            {
                //if (band == "SI") {
                //    msj += "El Sello es Válido" + Environment.NewLine;
                //    return true;
                //}
                //else
                //{
                msj += "El Sello no es Válido" + Environment.NewLine;
                return false;
                //}
            }

        }



        private string acentos(string strCa)
        {
            strCa = strCa.Replace("á", "a");
            strCa = strCa.Replace("é", "e");
            strCa = strCa.Replace("í", "i");
            strCa = strCa.Replace("ó", "o");
            strCa = strCa.Replace("ú", "u");

            strCa = strCa.Replace("Á", "A");
            strCa = strCa.Replace("É", "E");
            strCa = strCa.Replace("Í", "I");
            strCa = strCa.Replace("Ó", "O");
            strCa = strCa.Replace("Ú", "U");
            return strCa;
        }

        public string espacios(string strCa)
        {
            strCa = strCa.Replace("       ", " ");
            strCa = strCa.Replace("      ", " ");
            strCa = strCa.Replace("     ", " ");
            strCa = strCa.Replace("    ", " ");
            strCa = strCa.Replace("   ", " ");
            strCa = strCa.Replace("  ", " ");
            return strCa;
        }
        private string saltosDeLinea(string strCa)
        {
            strCa = strCa.Replace("\r\n", " ");
            strCa = strCa.Replace("\n", "");
            strCa = strCa.Replace("\r", "");
            return strCa;
        }

        public string extraerCertificado(String certificado)
        {
            return Sello.Mex_CertToBase64String(certificado);
        }
        public string extraerNoCertificado(String certificado)
        {
            return Sello.Mex_SAT_SerialNumber(certificado);
        }

        public Boolean certificadoValido(String rutacertificado)
        {
            return Sello.certificadoValido(rutacertificado);
        }
    }
}