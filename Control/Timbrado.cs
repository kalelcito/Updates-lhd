using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;
using System.Xml;

namespace Control
{
    public class timbrado
    {
        String requestor;
        String username;
        String rfc;
        String xml;
        XmlDocument factura;
        MYSUITE3.FactWSFrontSoap servicio;
        public timbrado(String xml)
        {
            this.xml = xml;
            requestor = "12211111-1111-1111-1111-111111111111";
            username = "techsite7";
            rfc = "AAA010101AAA";
            factura = new XmlDocument();

           

            //CREAMOS UNA INSTANCIA DEL PROXY DEL WEBSERVICE. 
            //servicio = new MYSUITE1.FactWSFrontSoapClient();
            System.Net.ServicePointManager.ServerCertificateValidationCallback +=
           delegate(object sender1, System.Security.Cryptography.X509Certificates.X509Certificate certificate,
           System.Security.Cryptography.X509Certificates.X509Chain chain,
           System.Net.Security.SslPolicyErrors sslPolicyErrors)
           {
               return true;
           };

           servicio = new MYSUITE3.FactWSFrontSoapClient();

        }
        #region PRIVATE
        private static string ByteArray_Base64String(byte[] b)
        {
            return Convert.ToBase64String(b);
        }

        private static byte[] String_ByteArray(string s)
        {
            return System.Text.Encoding.UTF8.GetBytes(s);
        }

        private static string String_Base64String(string s)
        {
            return ByteArray_Base64String(String_ByteArray(s));
        }//String_Base64String 

        private static string Base64String_String(string b64)
        {
            try
            {
                return ByteArray_String(Base64String_ByteArray(b64));
            }
            catch
            {
                return b64;
            }

        }//Base64String_String 

        private static byte[] Base64String_ByteArray(string s)
        {
            return Convert.FromBase64String(s);
        }//Base64String_ByteArray 



        private static string ByteArray_String(byte[] b)
        {
            return new string(System.Text.Encoding.UTF8.GetChars(b));
        }//ByteArray_String 
        #endregion

        public String generar(string des)
        {
            String mensaje = "";
            factura.Load(xml);

            MYSUITE3.TransactionTag tag = servicio.RequestTransaction(
            requestor, "TIMBRAR", "MX", rfc,
            requestor, "MX." + rfc + "." + username,
            factura.InnerXml, "PDF HTML XML", "");

            if (!tag.Response.Result)
            {
                mensaje = tag.Response.Hint + "\n";
                mensaje = mensaje + tag.Response.Description + "\n";
                mensaje = mensaje + tag.Response.Data + "\n";
            }
            else //SI ES EXITOSA LA TRANSACCION PODEMOS RECUPERAR VARIOS DATOS A PARTIR DEL OBJETO IDENTIFIER.
            {
                mensaje = "OK!!!!" + "\n";
                mensaje = mensaje + "Se creo la factura con serie:" + tag.Response.Identifier.Batch
                + " y folio " + tag.Response.Identifier.Serial;
            }

            FileInfo f1 = new FileInfo(des);
            StreamWriter w1 = f1.CreateText();
            w1.Write(Base64String_String(tag.ResponseData.ResponseData2));
            w1.Close();
            /*ResponseData3: DEVUELVE EL CONTENIDO DEL COMPROBANTE FISCAL DIGITAL EN FORMATO 
            PDF CODIFICADO EN BASE64 */
            System.IO.FileStream oFileStream = new FileStream(des,
            System.IO.FileMode.Create);
            oFileStream.Write(Base64String_ByteArray(tag.ResponseData.ResponseData3), 0,
            Base64String_ByteArray(tag.ResponseData.ResponseData3).Length);
            oFileStream.Close();
            FileInfo f = new FileInfo(des);
            StreamWriter w = f.CreateText();
            w.Write(Base64String_String(tag.ResponseData.ResponseData1));
            w.Close();


            return mensaje;
        }

        public string cancelar(string serie, string folio, string des)
        {
            String mensaje = "";
            MYSUITE3.TransactionTag tag = servicio.RequestTransaction(
            requestor, "CANCEL_XML", "MX", rfc,
            requestor, "MX." + rfc + "." + username, serie, folio, "");
            if (!tag.Response.Result)
            {
                mensaje = tag.Response.Hint + "\n";
                mensaje = mensaje + tag.Response.Description + "\n";
                mensaje = mensaje + tag.Response.Data + "\n";
            }
            else //SI ES EXITOSA LA TRANSACCION PODEMOS RECUPERAR VARIOS DATOS A PARTIR DEL OBJETO IDENTIFIER.
            {
                mensaje = "CANCELADO OK!!!!";
            }

            FileInfo f1 = new FileInfo(des);
            StreamWriter w1 = f1.CreateText();
            w1.Write(Base64String_String(tag.ResponseData.ResponseData2));
            w1.Close();
            /*ResponseData3: DEVUELVE EL CONTENIDO DEL COMPROBANTE FISCAL DIGITAL EN FORMATO 
            PDF CODIFICADO EN BASE64 */
            System.IO.FileStream oFileStream = new FileStream(des,
            System.IO.FileMode.Create);
            oFileStream.Write(Base64String_ByteArray(tag.ResponseData.ResponseData3), 0,
            Base64String_ByteArray(tag.ResponseData.ResponseData3).Length);
            oFileStream.Close();
            FileInfo f = new FileInfo(des);
            StreamWriter w = f.CreateText();
            w.Write(Base64String_String(tag.ResponseData.ResponseData1));
            w.Close();
            return mensaje;
        }

        public string pagado(string serie, string folio, string fecha, string des)
        {
            String mensaje = "";

            MYSUITE3.TransactionTag tag = servicio.RequestTransaction(
            requestor, "MARK_XML_AS_PAID", "MX", rfc,
            requestor, "MX." + rfc + "." + username,
            serie, folio, fecha);

            if (!tag.Response.Result)
            {
                mensaje = tag.Response.Hint + "\n";
                mensaje = mensaje + tag.Response.Description + "\n";
                mensaje = mensaje + tag.Response.Data + "\n";
            }
            else //SI ES EXITOSA LA TRANSACCION PODEMOS RECUPERAR VARIOS DATOS A PARTIR DEL OBJETO IDENTIFIER.
            {
                mensaje = "OK!!!!" + "\n";
                mensaje = "Marcado como Pagado";
            }

            FileInfo f1 = new FileInfo(des);
            StreamWriter w1 = f1.CreateText();
            w1.Write(Base64String_String(tag.ResponseData.ResponseData2));
            w1.Close();
            /*ResponseData3: DEVUELVE EL CONTENIDO DEL COMPROBANTE FISCAL DIGITAL EN FORMATO 
            PDF CODIFICADO EN BASE64 */
            System.IO.FileStream oFileStream = new FileStream(des,
            System.IO.FileMode.Create);
            oFileStream.Write(Base64String_ByteArray(tag.ResponseData.ResponseData3), 0,
            Base64String_ByteArray(tag.ResponseData.ResponseData3).Length);
            oFileStream.Close();
            FileInfo f = new FileInfo(des);
            StreamWriter w = f.CreateText();
            w.Write(Base64String_String(tag.ResponseData.ResponseData1));
            w.Close();
            return mensaje;
        }
        public string obtenerDoc(string serie, string folio, string des)
        {
            String mensaje = "";

            MYSUITE3.TransactionTag tag = servicio.RequestTransaction(
            requestor, "GET_DOCUMENT", "MX", rfc,
            requestor, "MX." + rfc + "." + username,
            serie, folio, "PDF XML HTML");

            if (!tag.Response.Result)
            {
                mensaje = tag.Response.Hint + "\n";
                mensaje = mensaje + tag.Response.Description + "\n";
                mensaje = mensaje + tag.Response.Data + "\n";
            }
            else //SI ES EXITOSA LA TRANSACCION PODEMOS RECUPERAR VARIOS DATOS A PARTIR DEL OBJETO IDENTIFIER.
            {
                mensaje = "OK!!!!";
            }

            FileInfo f1 = new FileInfo(des);
            StreamWriter w1 = f1.CreateText();
            w1.Write(Base64String_String(tag.ResponseData.ResponseData2));
            w1.Close();
            /*ResponseData3: DEVUELVE EL CONTENIDO DEL COMPROBANTE FISCAL DIGITAL EN FORMATO 
            PDF CODIFICADO EN BASE64 */
            System.IO.FileStream oFileStream = new FileStream(des,
            System.IO.FileMode.Create);
            oFileStream.Write(Base64String_ByteArray(tag.ResponseData.ResponseData3), 0,
            Base64String_ByteArray(tag.ResponseData.ResponseData3).Length);
            oFileStream.Close();
            FileInfo f = new FileInfo(des);
            StreamWriter w = f.CreateText();
            w.Write(Base64String_String(tag.ResponseData.ResponseData1));
            w.Close();
            return mensaje;

        }
    }
}
