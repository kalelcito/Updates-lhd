using Control;
using Datos;
using SAT;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web.Services;
using System.Xml;

namespace DataExpressWeb.ws
{
    /// <summary>
    /// Descripción breve de Retenciones
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Retenciones : System.Web.Services.WebService
    {
        private BasesDatos DB = new BasesDatos();
        private static string mensajeError = "";

        #region Metodos Publicos

        [WebMethod]
        public XmlDocument retencionFactura(string idFactura, string correo)
        {
            XmlDocument result = null;
            int id;
            if (!int.TryParse(idFactura, out id))
            {
                return null;
            }
            object[] factura = obtenerFactura(id);
            if (factura == null || factura.Length <= 0)
            {
                return null;
            }
            List<object[]> impRetenidos = obtenerImpuestosRetenidos(id);
            Dictionary<string, string> catImpuestos = new Dictionary<string, string>
            {
                { "ISR", "01" },
                { "IVA", "02" },
                { "IEPS", "03" }
            };
            var tbRfcEmi = factura[0].ToString();
            var tbNomEmi = factura[1].ToString();
            var tbCURPE = factura[2].ToString();
            var nacionalidad = factura[3].ToString();
            var tbRfcRec = factura[4].ToString();
            var tbNomRec = factura[5].ToString();
            var tbCURPR = factura[6].ToString();
            var tbIdFiscal = factura[7].ToString();
            var mesIni = factura[8].ToString();
            var mesFin = factura[9].ToString();
            var anio = factura[10].ToString();
            var tbmontoTotOperacion = cerosNull(factura[11].ToString());
            var tbmontoTotGrav = cerosNull(factura[12].ToString());
            var tbmontoTotExent = cerosNull(factura[13].ToString());
            var tbmontoTotRet = cerosNull(factura[14].ToString());
            var ddlPaisExt = factura[15].ToString();
            var sFecha = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz");
            var TXT = "";
            var desc = "04|Servicios prestados por comisionistas|";
            //var desc = (!nacionalidad.Equals("Nacional"))
            //        ? "18|Pagos realizados a favor de residentes en el extranjero|"
            //        : "04|Servicios prestados por comisionistas|";
            TXT = "Retenciones|||" + sFecha + "|" + desc;
            TXT += Environment.NewLine + "Emisor||" + tbRfcEmi + "|" + tbNomEmi + "|" + tbCURPE + "|";
            var recep = (!nacionalidad.Equals("Nacional"))
                ? "|||EXT|" + "XEXX010101000" + " |" + tbNomRec
                : tbRfcRec + "|" + tbNomRec + "|" + tbCURPR + "|||";
            TXT += Environment.NewLine + "Receptor||" + nacionalidad + "|" + recep + "|";
            TXT += Environment.NewLine + "Periodo||" + mesIni + "|" + mesFin + "|" + anio + "|";
            TXT += Environment.NewLine + "Totales||" + tbmontoTotOperacion + "|" + tbmontoTotGrav + "|" + tbmontoTotExent + "|" + tbmontoTotRet + "|";
            foreach (var impuesto in impRetenidos)
            {
                var imp = impuesto[0].ToString().ToUpper();
                var importe = cerosNull(impuesto[1].ToString());
                TXT += Environment.NewLine + "ImpRetenidos|||" + (catImpuestos.ContainsKey(imp) ? catImpuestos[imp] : "01") + "|" + importe + "|" +
            "Pago definitivo" + "|";
            }
            //if (!nacionalidad.Equals("Nacional"))
            //{
            //    TXT += Environment.NewLine + "Complemento|Pagosaextranjeros||SI|";
            //    TXT += Environment.NewLine + "Complemento|Pagosaextranjeros|NoBeneficiario||" + ddlPaisExt + "|2|Otras personas f\u00EDsicas|";
            //    TXT += Environment.NewLine + "Complemento|Pagosaextranjeros|Beneficiario||" + tbRfcRec + "|" + tbCURPR + "|" + tbNomRec + "|2|Otras personas f\u00EDsicas|";
            //}
            result = procesarRetencionTXT(TXT, correo);
            if (result != null)
            {
                DB.Conectar();
                DB.CrearComando(@"UPDATE GENERAL SET estadoRetencion=1 WHERE idFactura=@IDEFAC");
                DB.AsignarParametroEntero("@IDEFAC", id);
                DB.EjecutarConsulta1();
                DB.Desconectar();
                var uuid = AtributoXML(result, "tfd:TimbreFiscalDigital", "UUID");
                DB.Conectar();
                DB.CrearComando(@"INSERT INTO RetencionFactura (idFactura, UUID, rfcEmi, estado) VALUES (@IDEFAC, @UUID, @RFC, @EDO)");
                DB.AsignarParametroEntero("@IDEFAC", id);
                DB.AsignarParametroCadena("@UUID", uuid);
                DB.AsignarParametroCadena("@RFC", tbRfcEmi);
                DB.AsignarParametroEntero("@EDO", 1);
                DB.EjecutarConsulta1();
                DB.Desconectar();
            }
            return result;
        }
        [WebMethod]
        public XmlDocument procesarRetencionTXT(string txt, string correo)
        {
            var fileName = Server.MapPath("retencion.tmp");
            using (var sw = new StreamWriter(fileName))
            {
                sw.Write(txt);
            }
            return procesarRetencionArchivo(fileName, correo);
        }
        [WebMethod]
        public XmlDocument procesarRetencionArchivo(string fileName, string correo)
        {
            var retencion = new Control.Retencion(fileName);
            Transformar transformar = new Transformar(retencion);
            File.Delete(fileName);
            XmlDocument result = transformar.XML();
            if (result != null)
            {
                var pdf = "";
                Log("result != null");
                DB.Conectar();
                DB.CrearComando(@"select dirdocs from ParametrosSistema");
                var DR = DB.EjecutarConsulta();
                if (DR.Read()) { pdf = DR[0].ToString(); }
                DB.Desconectar();
                Log("docus = " + pdf);
                var subcarpeta = "docus/retencionesRecepcion/";
                Log("subcarpeta = " + subcarpeta);
                var rutaFisica = pdf + (subcarpeta.Replace("docus", ""));
                Log("rutaFisica = " + rutaFisica);
                var UUID = AtributoXML(result, "tfd:TimbreFiscalDigital", "UUID");
                var fileName1 = (!string.IsNullOrEmpty(UUID) ? UUID : CreateMD5(result.OuterXml)) + ".xml";
                Log("fileName = " + fileName1);
                Directory.CreateDirectory(rutaFisica);
                rutaFisica = rutaFisica + fileName1;
                result.Save(rutaFisica);
                if (File.Exists(rutaFisica))
                {
                    mensajeError = null;
                    if (transformar.ambiente)
                    {
                        Ftp ftp = new Ftp();
                        ftp.UploadFTP(rutaFisica, "ftp://50.97.147.202/RetencionesDHL", "ftpDeCameron", "Cameron2015");
                        //                  EnviarXMLMail(rutaFisica, correo, result);
                    }
                }
                else
                {
                    mensajeError = "La retención se timbró, pero no se pudo guardar en el servidor";
                }
            }
            else
            {
                mensajeError = transformar.MensajeError;
            }
            return result;
        }
        [WebMethod]
        public bool cancelarRetencion(string idFactura, string correo)
        {
            var uuid = "";
            var rfcEmi = "";
            var numCert = "";
            var cerRut = "";
            var prvRut = "";
            var claveCer = "";
            var idRetencion = "";
            DB.Conectar();
            DB.CrearComando(@"SELECT
                                rf.idRetencion, rf.UUID, rf.rfcEmi, cf.CERNUM, cf.CERRUT, cf.PRVRUT, cf.CLAVE
                            FROM
                                RetencionFactura rf INNER JOIN
                                Configuracion cf ON rf.rfcEmi = cf.RFC
                            WHERE rf.idFactura = @ID;");
            DB.AsignarParametroCadena("@ID", idFactura);
            var dr = DB.EjecutarConsulta();
            if (dr.HasRows && dr.Read())
            {
                idRetencion = dr["idRetencion"].ToString();
                uuid = dr["UUID"].ToString();
                rfcEmi = dr["rfcEmi"].ToString();
                numCert = dr["CERNUM"].ToString();
                cerRut = dr["CERRUT"].ToString();
                prvRut = dr["PRVRUT"].ToString();
                claveCer = dr["CLAVE"].ToString();
                DB.Desconectar();
                Transformar transformar = new Transformar();
                var _pac = new Timbrado(DB);
                object oJSON = new { tipo = "JSON", datos = new { rfcEmisor = rfcEmi, noCertificado = numCert, UUID = uuid } };
                var ret = _pac.CancelarComprobante(cerRut, prvRut, claveCer, numCert, oJSON, transformar.ambiente, idRetencion); //<- true = prod; false = pruebas
                if (ret != null)
                {
                    DB.Conectar();
                    DB.CrearComando("DELETE FROM RetencionFactura WHERE idRetencion = @ID");
                    DB.AsignarParametroCadena("@ID", idRetencion);
                    DB.EjecutarConsulta1();
                    DB.Desconectar();
                    DB.Conectar();
                    DB.CrearComando("UPDATE GENERAL SET estadoRetencion = NULL WHERE idFactura = @ID");
                    DB.AsignarParametroCadena("@ID", idFactura);
                    DB.EjecutarConsulta1();
                    DB.Desconectar();
                    var pdf = "";
                    Log("result != null");
                    DB.Conectar();
                    DB.CrearComando(@"select dirdocs from ParametrosSistema");
                    var DR = DB.EjecutarConsulta();
                    if (DR.Read()) { pdf = DR[0].ToString(); }
                    DB.Desconectar();
                    Log("docus = " + pdf);
                    var subcarpeta = "docus/retencionesRecepcion/";
                    Log("subcarpeta = " + subcarpeta);
                    var rutaFisica = pdf + (subcarpeta.Replace("docus", ""));
                    var fileName1 = "CANCELACION_" + uuid + ".can";
                    Directory.CreateDirectory(rutaFisica);
                    rutaFisica = rutaFisica + fileName1;
                    using (var sw = new StreamWriter(rutaFisica))
                    {
                        sw.Write("Cancelacion||" + uuid);
                    }
                    if (File.Exists(rutaFisica))
                    {
                        if (transformar.ambiente)
                        {
                            Ftp ftp = new Ftp();
                            ftp.UploadFTP(rutaFisica, "ftp://50.97.147.202/RetencionesDHL", "ftpDeCameron", "Cameron2015");
                            EnviarMailCanc(correo, uuid);
                        }
                        return true;
                    }
                    else
                    {
                        mensajeError = "La retención se canceló, pero no se pudo guardar en el servidor";
                        return false;
                    }
                }
                else
                {
                    mensajeError = _pac.LastError;
                    return false;
                }
            }
            else
            {
                mensajeError = "No existe retención para a factura " + idFactura;
                DB.Desconectar();
                return false;
            }
        }
        [WebMethod]
        public string obtenerMensajeError()
        {
            return mensajeError;
        }

        #endregion

        #region Metodos Privados

        private List<object[]> obtenerImpuestosRetenidos(int idFactura)
        {
            List<object[]> rows = new List<object[]>();
            DB.Conectar();
            DB.CrearComando(@"SELECT impuesto, importe FROM Impuestos WHERE id_Factura = @IDFAC AND tipo = 'R'");
            DB.AsignarParametroEntero("@IDFAC", idFactura);
            DbDataReader DR = DB.EjecutarConsulta();
            if (DR.HasRows)
            {
                while (DR.Read())
                {
                    object[] row = new object[DR.FieldCount];
                    DR.GetValues(row);
                    rows.Add(row);
                }
            }
            DB.Desconectar();
            return rows;
        }
        private bool EnviarXMLMail(string xmlPath, string correo, XmlDocument xDoc)
        {
            try
            {
                if (string.IsNullOrEmpty(correo))
                {
                    return false;
                }
                var EM = new EnviarMail();
                var servidor = "";
                var puerto = 0;
                var ssl = false;
                var emailCredencial = "";
                var passCredencial = "";
                var emailEnviar = "";
                DB.Conectar();
                DB.CrearComando("select servidorSMTP,puertoSMTP,sslSMTP,userSMTP,passSMTP,emailEnvio from ParametrosSistema");
                DbDataReader DR1 = DB.EjecutarConsulta();
                while (DR1.Read())
                {
                    servidor = DR1[0].ToString();
                    puerto = Convert.ToInt32(DR1[1].ToString());
                    ssl = Convert.ToBoolean(DR1[2].ToString());
                    emailCredencial = DR1[3].ToString();
                    passCredencial = DR1[4].ToString();
                    emailEnviar = DR1[5].ToString();
                }
                DB.Desconectar();
                var asunto = "Retencion DHL";
                var uuid = AtributoXML(xDoc, "tfd:TimbreFiscalDigital", "UUID");
                var desc = AtributoXML(xDoc, "retenciones:Retenciones", "DescRetenc");
                var mensaje = "Saludos Cordiales! <br>Se acaba de recibir un comprobante de retención de " + desc + " con UUID \"" + uuid + "\"";
                mensaje += "<br><br>No responder a este correo, es solo informativo";
                EM.servidorSTMP(servidor, puerto, ssl, emailCredencial, passCredencial);
                EM.llenarEmail(emailEnviar, correo, "gabriel.ruiz@dhl.com", "", asunto, mensaje);
                //EM.llenarEmail(emailEnviar, "sehernandez@dataexpressintmx.com", "", "", asunto, mensaje);
                if (!string.IsNullOrEmpty(xmlPath)) { EM.adjuntar(xmlPath); }
                return EM.enviarEmail();
            }
            catch { return false; }
        }
        private object[] obtenerFactura(int idFactura)
        {
            object[] row = null;
            DB.Conectar();
            DB.CrearComando(@"SELECT
    r.rfc, r.razonSoc, '' AS CURPR,
    'Nacional' AS Nacionalidad, e.RFCEMI, e.NOMEMI, '' AS CURPR, '' AS IdFiscal,
    RIGHT(RTRIM(MONTH(g.fecha)), 2) AS MesIni, RIGHT(RTRIM(MONTH(g.fecha)), 2) AS MesFin, YEAR(g.fecha) AS Ejerc,
    g.total AS montoTotOperacion, g.subtotal AS montoTotGrav, '0' AS montoTotExent,
    g.totalImpuestosRetenidos AS montoTotRet, 'MX' AS PAIS
FROM GENERAL g
    INNER JOIN EMISOR e ON g.id_Emisor = e.IDEEMI
    INNER JOIN receptorCFDI r ON g.id_Receptor = r.idreceptorCFDI
WHERE g.tipoDeComprobante <> 'retencion' AND g.totalImpuestosRetenidos > 0 AND (g.estadoRetencion IS NULL OR g.estadoRetencion = 0) AND g.idFactura = @IDFAC");
            DB.AsignarParametroEntero("@IDFAC", idFactura);
            DbDataReader DR = DB.EjecutarConsulta();
            if (DR.HasRows)
            {
                while (DR.Read())
                {
                    row = new object[DR.FieldCount];
                    DR.GetValues(row);
                }
            }
            DB.Desconectar();
            return row;
        }
        private List<object[]> obtenerFacturas(string RFCREC)
        {
            List<object[]> rows = new List<object[]>();
            DB.Conectar();
            DB.CrearComando(@"SELECT
    r.rfc, r.razonSoc, '' AS CURPR,
    'Nacional' AS Nacionalidad, e.RFCEMI, e.NOMEMI, '' AS CURPR, '' AS IdFiscal,
    RIGHT(RTRIM(MONTH(g.fecha)), 2) AS MesIni, RIGHT(RTRIM(MONTH(g.fecha)), 2) AS MesFin, YEAR(g.fecha) AS Ejerc,
    g.total AS montoTotOperacion, g.subtotal AS montoTotGrav, '0' AS montoTotExent,
    g.totalImpuestosRetenidos AS montoTotRet, 'MX' AS PAIS
FROM GENERAL g
    INNER JOIN EMISOR e ON g.id_Emisor = e.IDEEMI
    INNER JOIN receptorCFDI r ON g.id_Receptor = r.idreceptorCFDI
WHERE g.tipoDeComprobante <> 'retencion' AND g.totalImpuestosRetenidos > 0 AND (g.estadoRetencion IS NULL OR g.estadoRetencion = 0) AND r.rfc = @RFC");
            DB.AsignarParametroCadena("@RFC", RFCREC);
            DbDataReader DR = DB.EjecutarConsulta();
            if (DR.HasRows)
            {
                while (DR.Read())
                {
                    object[] row = new object[DR.FieldCount];
                    DR.GetValues(row);
                    rows.Add(row);
                }
            }
            DB.Desconectar();
            return rows;
        }
        private String cerosNull(string a)
        {
            if (a == "")
                return "0.00";

            if (a == null)
                return "0.00";

            if (a == "0")
                return "0.00";

            if (a == "0.00")
                return "0.00";
            else
                return a;
        }
        private static string CreateMD5(string input)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }
        private string AtributoXML(XmlDocument xDoc, string nombreNodo, string nombreAtributo)
        {
            string result = "";
            if (xDoc != null)
            {
                XmlNodeList nodos = xDoc.GetElementsByTagName(nombreNodo);
                foreach (XmlElement nodo in nodos)
                {
                    if (nodo.HasAttributes && nodo.HasAttribute(nombreAtributo))
                    {
                        result = nodo.GetAttribute(nombreAtributo);
                        break;
                    }
                }
            }
            return result;
        }
        private void Log(string logMessage)
        {
            var DBLog = new BasesDatos();
            DBLog.Conectar();
            try
            {
                DBLog.CrearComando(@"INSERT INTO PruebasLog VALUES (@pagina, @fechaHora, @mensaje)");
                DBLog.AsignarParametroCadena("@pagina", "Retenciones.asmx.cs");
                DBLog.AsignarParametroCadena("@fechaHora", DateTime.Now.ToString("s"));
                DBLog.AsignarParametroCadena("@mensaje", logMessage.Replace("'", "''"));
                DBLog.EjecutarConsulta1();
            }
            catch { }
            finally
            {
                DBLog.Desconectar();
            }
        }
        private bool EnviarMailCanc(string correo, string uuid)
        {
            try
            {
                if (string.IsNullOrEmpty(correo))
                {
                    return false;
                }
                var EM = new EnviarMail();
                var servidor = "";
                var puerto = 0;
                var ssl = false;
                var emailCredencial = "";
                var passCredencial = "";
                var emailEnviar = "";
                DB.Conectar();
                DB.CrearComando("select servidorSMTP,puertoSMTP,sslSMTP,userSMTP,passSMTP,emailEnvio from ParametrosSistema");
                DbDataReader DR1 = DB.EjecutarConsulta();
                while (DR1.Read())
                {
                    servidor = DR1[0].ToString();
                    puerto = Convert.ToInt32(DR1[1].ToString());
                    ssl = Convert.ToBoolean(DR1[2].ToString());
                    emailCredencial = DR1[3].ToString();
                    passCredencial = DR1[4].ToString();
                    emailEnviar = DR1[5].ToString();
                }
                DB.Desconectar();
                var asunto = "Retencion DHL";
                var mensaje = "Saludos Cordiales! <br>Se acaba de cancelar el comprobante de retención \"" + uuid + "\"";
                mensaje += "<br><br>No responder a este correo, es solo informativo";
                EM.servidorSTMP(servidor, puerto, ssl, emailCredencial, passCredencial);
                EM.llenarEmail(emailEnviar, correo, "gabriel.ruiz@dhl.com", "", asunto, mensaje);
                //EM.llenarEmail(emailEnviar, "sehernandez@dataexpressintmx.com", "", "", asunto, mensaje);
                return EM.enviarEmail();
            }
            catch { return false; }
        }

        #endregion
    }
}
