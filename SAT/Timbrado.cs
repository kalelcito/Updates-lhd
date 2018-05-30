using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml;
using Datos;
using System.Reflection;

namespace SAT
{
    /// <summary>
    ///     Clase de timbrado para usar el PAC MasNegocio v4 r. 201. Revisar la documentación para saber cómo deben de enviarse
    ///     los comprobantes (ya sea XmlDocument o object de JSON)
    /// </summary>
    public class Timbrado
    {
        private readonly BasesDatos _db;
        private readonly string _rutaArchivo = AppDomain.CurrentDomain.BaseDirectory + "PACv4.log";

        /// <summary>
        ///     Inicializa el Timbrado con los valores que se van a agregar en la base de datos
        /// </summary>
        /// <param name="db"></param>
        /// <param name="serie">Serie del emisor</param>
        /// <param name="rfcEmisor">RFC del emisor</param>
        /// <param name="rfcReceptor">RFC del receptor</param>
        public Timbrado(BasesDatos db, string serie, string rfcEmisor, string rfcReceptor)
        {
            _db = db;
            _serie = serie;
            _rfcEmisor = rfcEmisor;
            _rfcReceptor = rfcReceptor;
            Log("Se inicializo con serie=" + serie + ",rfcEmisor=" + _rfcEmisor + ",rfcReceptor=" + _rfcReceptor);
        }

        /// <summary>
        ///     Inicializa el Timbrado
        /// </summary>
        public Timbrado(BasesDatos db)
        {
            _db = db;
            Log("Se inicializo con BD");
        }

        /// <summary>
        ///     Inicializa el Timbrado
        /// </summary>
        public Timbrado()
        {
            Log("Se inicializo vacio");
        }

        #region Propiedades

        public string LastError { get; set; }

        #endregion

        public void Log(string logMessage)
        {
            using (var w = File.AppendText(_rutaArchivo))
            {
                w.Write("\r\nLog Entry : ");
                w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                w.WriteLine("  :");
                w.WriteLine("  :{0}", logMessage);
                w.WriteLine("-------------------------------");
            }
        }

        #region Base de Datos

        /// <summary>
        ///     Si el timbrado fue exitoso, guarda automáticamente el registro en la tabla [RegistroTimbrado]
        /// </summary>
        /// <param name="comprobanteTimbrado">El comprobante timbrado a guardar</param>
        /// <returns>true si se guardo correctamente el registro, false de lo contrario</returns>
        private void GuardarBd(ComprobanteTimbrado comprobanteTimbrado)
        {
            try
            {
                _db.Conectar();
                _db.CrearComando(@"INSERT INTO RegistroTimbrado (RFC_EMISOR, RFC_RECEPTOR, SERIE, UUID, FECHATIMBRADO, XML_BASE64) VALUES (@rfcEmisor, @rfcReceptor, @serie, @uuid, @fecha, @xml)");
                _db.AsignarParametroCadena("@rfcEmisor", _rfcEmisor);
                _db.AsignarParametroCadena("@rfcReceptor", _rfcReceptor);
                _db.AsignarParametroCadena("@serie", _serie);
                _db.AsignarParametroCadena("@uuid", comprobanteTimbrado.Uuid);
                _db.AsignarParametroCadena("@fecha", comprobanteTimbrado.FechaTimbrado);
                _db.AsignarParametroCadena("@xml", comprobanteTimbrado.XmlTimbradoBase64);
                Log("GuardarBD-Timbrado-Consulta=" + _db.comando.CommandText);
                _db.EjecutarConsulta1();
                Log("GuardarBD-Timbrado-OK");
            }
            catch
            {
                // ignored
                Log("GuardarBD-Timbrado-ERROR");
            }
            finally
            {
                if (_db != null)
                {
                    _db.Desconectar();
                }
            }
        }

        #endregion

        #region Variables

        private const string UrlBasePruebas = "http://qa.pacmasnegocio.com:2376";
        private const string UrlBaseProduccion = "https://api.pacmasnegocio.com";
        private const string TokenPruebas = "eyAidHlwIjogIkpXVCIsICJhbGciOiAiSFMyNTYiIH0=.eyAic3ViIiA6ICJEQVRBRVhQUkVTU19BUEkiLCAiaWF0IiA6ICIyMDE1MDkyNjA5NTAzMCIsICJrZXkiIDogIjYzdE15eUM0eU1Dekh2Q1ZZbEhJL1E9PSIgfQ==./R+aDTdBdeTkO6qFkXR99dX1EZYCGpj8uePFR5VxZDU=";
        private const string TokenProduccion = "eyAidHlwIjogIkpXVCIsICJhbGciOiAiSFMyNTYiIH0=.eyAic3ViIiA6ICJEQVRBRVhQUkVTU19BUEkiLCAiaWF0IiA6ICIyMDE1MDkyNjA5NTEwMiIsICJrZXkiIDogImQyTFZodm1hQ2xSUHVXOFRmYVBlUEE9PSIgfQ==.fjnZJll94zA48BJFSNDKSYxv27RmRpgaRu3G1UiZkyE=";
        private readonly string _serie;
        private readonly string _rfcEmisor;
        private readonly string _rfcReceptor;

        #endregion

        #region Certificados

        /// <summary>
        ///     Sube el certificado al servidor del PAC
        /// </summary>
        /// <param name="rutaCer">Ruta del certificado del emisor (archivo .cer)</param>
        /// <param name="rutaKey">Ruta de la llave del emisor (archivo .key)</param>
        /// <param name="keyCer">Clave de la llave del emisor</param>
        /// <param name="urlMaster">URL del PAC (produccion o pruebas)</param>
        /// <param name="token">Token definido para la empresa (produccion o pruebas)</param>
        /// <returns>true si se subio correctamente el certificado, false de lo contrario</returns>
        private async Task<bool> SubirCertificado(string rutaCer, string rutaKey, string keyCer, string urlMaster, string token)
        {
            var result = false;
            var cer = EncodeFileToBase64(rutaCer);
            Log("SubirCertificado-cer=" + cer);
            var key = EncodeFileToBase64(rutaKey);
            Log("SubirCertificado-key=" + key);
            Log("SubirCertificado-clave=" + keyCer);
            Log("SubirCertificado-url=" + urlMaster);
            var httpClient = new HttpClient();
            try
            {
                var postBody = new JavaScriptSerializer().Serialize(new
                {
                    certificadoBase64 = cer,
                    llaveBase64 = key,
                    password = keyCer
                });
                Log("SubirCertificado-postBody=" + postBody);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Add("Token", token);
                var wcfResponse = await httpClient.PostAsync(urlMaster + "/certificados", new StringContent(postBody, Encoding.UTF8, "application/json")).ConfigureAwait(false);
                var response = await wcfResponse.Content.ReadAsStringAsync();
                Log("SubirCertificado-response=" + response);
                if (wcfResponse.IsSuccessStatusCode)
                {
                    var rresult = (Dictionary<string, object>)new JavaScriptSerializer().DeserializeObject(response);
                    var msg = rresult["mensaje"].ToString();
                    if (msg.Equals("Certificado cargado exitosamente", StringComparison.OrdinalIgnoreCase) || msg.Equals("El certificado que intenta cargar ya existe en el sistema", StringComparison.OrdinalIgnoreCase))
                    {
                        Log("SubirCertificado-status=OK");
                        result = true;
                    }
                }
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                httpClient.Dispose();
            }
            return result;
        }

        /// <summary>
        ///     Verifica que el certificado existe en el servidor del PAC (para evitar duplicados y errores)
        /// </summary>
        /// <param name="numCert">Numero del certificado del emisor</param>
        /// <param name="urlMaster">URL del PAC (produccion o pruebas)</param>
        /// <param name="token">Token definido para la empresa (produccion o pruebas)</param>
        /// <returns>true si el certificado ya existe, false de lo contrario</returns>
        private async Task<bool> ExisteCertificadoServer(string numCert, string urlMaster, string token)
        {
            Log("ExisteCertificadoServer-numCert=" + numCert);
            Log("ExisteCertificadoServer-url=" + urlMaster);
            var httpClient = new HttpClient();
            try
            {
                //Console.WriteLine("Comprobar certficado " + numCert);
                httpClient.DefaultRequestHeaders.Add("Token", token);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var wcfResponse = await httpClient.GetAsync(urlMaster + "/certificados").ConfigureAwait(false);
                var response = await wcfResponse.Content.ReadAsStringAsync();
                Log("ExisteCertificadoServer-response=" + response);
                if (wcfResponse.IsSuccessStatusCode)
                {
                    var rresult = (Dictionary<string, object>)new JavaScriptSerializer().DeserializeObject(response);
                    var certifcadosExistetes = (object[])rresult["certificados"];
                    if ((from Dictionary<string, object> certificado in certifcadosExistetes select certificado["noCertificado"].ToString()).Any(num => num.Equals(numCert)))
                    {
                        Log("ExisteCertificadoServer-status=EXISTE");
                        return true;
                    }
                }
            }
            catch
            {
                // ignored
            }
            finally
            {
                httpClient.Dispose();
            }
            Log("ExisteCertificadoServer-status=NO_EXISTE");
            return false;
        }

        #endregion

        #region Comprobantes

        /// <summary>
        ///     Timbra un comprobante electrónico fiscal mediante el PAC de MasNegocio v4
        /// </summary>
        /// <param name="rutaCer">Ruta del certificado del emisor (archivo .cer)</param>
        /// <param name="rutaKey">Ruta de la llave del emisor (archivo .key)</param>
        /// <param name="keyCer">Clave de la llave del emisor</param>
        /// <param name="numCert">Numero de certificado del emisor</param>
        /// <param name="aTimbrar">Objeto a timbrar (XmlDocument u object (JSON))</param>
        /// <param name="produccion">Ambiente de producción (true) o de pruebas (false)</param>
        /// <param name="tipoDoc">Tipo de documento a timbrar: ( "cfdi32" (default) | "retencion" )</param>
        /// <returns>El objeto coteniendo los valores de timbrado</returns>
        public ComprobanteTimbrado Timbrar(string rutaCer, string rutaKey, string keyCer, string numCert, object aTimbrar, bool produccion, string tipoDoc = "cfdi32")
        {
            Log("Timbrar-aTimbrar=" + aTimbrar);
            Log("Timbrar-ambiente=" + produccion);
            Log("Timbrar-tipodoc=" + tipoDoc);
            var urlMaster = produccion ? UrlBaseProduccion : UrlBasePruebas;
            var token = produccion ? TokenProduccion : TokenPruebas;
            var existe = ExisteCertificadoServer(numCert, urlMaster, token).Result;
            if (!existe)
            {
                //Console.WriteLine("Certificado NO existe");
                var subida = SubirCertificado(rutaCer, rutaKey, keyCer, urlMaster, token).Result;
                if (!subida)
                {
                    return null;
                }
                //Console.WriteLine("Subida de certificado OK");
            }
            switch (tipoDoc)
            {
                case "cfdi32":
                    return TimbrarCfdi32(urlMaster, token, aTimbrar);
                case "retencion":
                    return TimbrarRetencion(urlMaster, token, aTimbrar);
                default:
                    return null;
            }
        }

        /// <summary>
        ///     Timbra un comprobante de retencion con el PAC
        /// </summary>
        /// <param name="urlMaster">URL del PAC (produccion o pruebas)</param>
        /// <param name="token">Token definido para la empresa (produccion o pruebas)</param>
        /// <param name="aTimbrar">Objeto a timbrar (XmlDocument u object (JSON))</param>
        /// <returns>El objeto coteniendo los valores de timbrado</returns>
        private ComprobanteTimbrado TimbrarRetencion(string urlMaster, string token, object aTimbrar)
        {
            string postBody;
            if (aTimbrar.GetType() == typeof(XmlDocument))
            {
                Log("TimbrarRetencion-obj=" + "XML");
                var xmlB64 = EncodeStringToBase64(Utilidades.ReplaceAccents(((XmlDocument)aTimbrar).OuterXml));
                postBody = new JavaScriptSerializer().Serialize(new
                {
                    tipo = "XML",
                    retencionXMLBase64 = xmlB64
                });
            }
            else
            {
                Log("TimbrarRetencion-obj=" + "JSON");
                postBody = Regex.Replace(new JavaScriptSerializer().Serialize(aTimbrar), "[\"][a-zA-Z0-9_]*[\"]:[\"][\"][ ]*[,]?", "");
            }
            postBody = Utilidades.ReplaceAccents(postBody);
            Log("TimbrarRetencion-postBody=" + postBody);
            var task = ProcesarComprobante(urlMaster + "/retenciones/emision", token, postBody);
            var result = task.Result;
            return result;
        }

        /// <summary>
        ///     Timbra un comprobante CFDI32 con el PAC
        /// </summary>
        /// <param name="urlMaster">URL del PAC (produccion o pruebas)</param>
        /// <param name="token">Token definido para la empresa (produccion o pruebas)</param>
        /// <param name="aTimbrar">Objeto a timbrar (XmlDocument u object (JSON))</param>
        /// <returns>El objeto coteniendo los valores de timbrado</returns>
        private ComprobanteTimbrado TimbrarCfdi32(string urlMaster, string token, object aTimbrar)
        {
            string postBody;
            if (aTimbrar.GetType() == typeof(XmlDocument))
            {
                Log("TimbrarCfdi32-obj=" + "XML");
                var xmlB64 = EncodeStringToBase64(Utilidades.ReplaceAccents(((XmlDocument)aTimbrar).OuterXml));
                postBody = new JavaScriptSerializer().Serialize(new
                {
                    tipo = "XML",
                    comprobanteXMLBase64 = xmlB64
                });
            }
            else
            {
                Log("TimbrarRetencion-obj=" + "JSON");
                var serializer = new JavaScriptSerializer();
                serializer.RegisterConverters(new JavaScriptConverter[] { new NullPropertiesConverter() });
                postBody = Regex.Replace(serializer.Serialize(aTimbrar), "[\"][a-zA-Z0-9_]*[\"]:[\"][\"][ ]*[,]?", "");
                //postBody = Regex.Replace(new JavaScriptSerializer().Serialize(aTimbrar), "[\"][a-zA-Z0-9_]*[\"]:[\"][\"][ ]*[,]?", "");
            }
            postBody = Utilidades.ReplaceAccents(postBody);
            Log("TimbrarRetencion-postBody=" + postBody);
            var task = ProcesarComprobante(urlMaster + "/facturas/emision", token, postBody);
            var result = task.Result;
            return result;
        }

        /// <summary>
        ///     Cancela un comprobante mediante el PAC
        /// </summary>
        /// <param name="numCert"></param>
        /// <param name="aTimbrar">Objeto a timbrar (XmlDocument u object (JSON))</param>
        /// <param name="produccion">Ambiente de producción (true) o de pruebas (false)</param>
        /// <param name="idefac">Id de la factura a cancelar</param>
        /// <param name="fechaTimbreEmision">(Opcional) Fecha de timbrado original del comprobante en formato yyyy-mm-ddThh:mm:ss</param>
        /// <param name="rutaCer"></param>
        /// <param name="rutaKey"></param>
        /// <param name="keyCer"></param>
        /// <returns>El UUID del comprobante cancelado</returns>
        public Cancelacion CancelarComprobante(string rutaCer, string rutaKey, string keyCer, string numCert, object aTimbrar, bool produccion, string idefac, string fechaTimbreEmision = null)
        {
            Log("CancelarComprobante-aTimbrar=" + aTimbrar);
            Log("CancelarComprobante-ambiente=" + produccion);
            Log("CancelarComprobante-idefac=" + idefac);
            Log("CancelarComprobante-fechaTimbreEmision=" + fechaTimbreEmision);
            var urlMaster = produccion ? UrlBaseProduccion : UrlBasePruebas;
            var token = produccion ? TokenProduccion : TokenPruebas;
            var existe = ExisteCertificadoServer(numCert, urlMaster, token).Result;
            if (!existe)
            {
                //Console.WriteLine("Certificado NO existe");
                var subida = SubirCertificado(rutaCer, rutaKey, keyCer, urlMaster, token).Result;
                if (!subida)
                {
                    return null;
                }
                //Console.WriteLine("Subida de certificado OK");
            }
            string postBody;
            if (aTimbrar.GetType() == typeof(XmlDocument))
            {
                Log("CancelarComprobante-obj=" + "XML");
                var xmlB64 = EncodeStringToBase64(Utilidades.ReplaceAccents(((XmlDocument)aTimbrar).OuterXml));
                postBody = !string.IsNullOrEmpty(fechaTimbreEmision) ? new JavaScriptSerializer().Serialize(new { tipo = "XML", cancelacionXMLBase64 = xmlB64, datos = new { fechaTimbrado = fechaTimbreEmision } }) : new JavaScriptSerializer().Serialize(new { tipo = "XML", cancelacionXMLBase64 = xmlB64 });
            }
            else
            {
                Log("CancelarComprobante-obj=" + "JSON");
                var serializer = new JavaScriptSerializer();
                serializer.RegisterConverters(new JavaScriptConverter[] { new NullPropertiesConverter() });
                postBody = Regex.Replace(serializer.Serialize(aTimbrar), "[\"][a-zA-Z0-9_]*[\"]:[\"][\"][ ]*[,]?", "");
                //postBody = Regex.Replace(new JavaScriptSerializer().Serialize(aTimbrar), "[\"][a-zA-Z0-9_]*[\"]:[\"][\"][ ]*[,]?", "");
            }
            postBody = Utilidades.ReplaceAccents(postBody);
            Log("TimbrarRetencion-postBody=" + postBody);
            var task = ProcesarCancelacion(urlMaster + "/facturas/cancelacion", token, postBody, produccion, idefac);
            var result = task.Result;
            return result;
        }

        #endregion

        #region Proceso

        /// <summary>
        ///     Cancela un comprobante con el PAC
        /// </summary>
        /// <param name="url">URL del PAC (produccion o pruebas)</param>
        /// <param name="token">Token definido para la empresa (produccion o pruebas)</param>
        /// <param name="postBody">Información en JSON a emitir al PAC</param>
        /// <param name="produccion">Ambiente de producción (true) o de pruebas (false)</param>
        /// <param name="idefac">Id de la factura a cancelar</param>
        /// <returns>El objeto coteniendo los valores de cancelacion</returns>
        private async Task<Cancelacion> ProcesarCancelacion(string url, string token, string postBody, bool produccion, string idefac)
        {
            var httpClient = new HttpClient();
            Cancelacion cancelacion = null;
            var response = "";
            try
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Add("Token", token);
                var wcfResponse = await httpClient.PostAsync(url, new StringContent(postBody, Encoding.UTF8, "application/json")).ConfigureAwait(false);
                response = await wcfResponse.Content.ReadAsStringAsync();
                Log("ProcesarCancelacion-response=" + response);
                var result = (Dictionary<string, object>)new JavaScriptSerializer().DeserializeObject(response);
                if (wcfResponse.IsSuccessStatusCode)
                {
                    cancelacion = new Cancelacion
                    {
                        Uuid = result["uuid"].ToString(),
                        AnioMes = result["anioMes"].ToString(),
                        Ambiente = produccion,
                        IdFactura = idefac
                    };
                    Log("ProcesarCancelacion-comprobante-Uuid=" + cancelacion.Uuid);
                    Log("ProcesarCancelacion-comprobante-AnioMes=" + cancelacion.AnioMes);
                    cancelacion.MonitoreaStatus();
                }
                else
                {
                    LastError = result["mensaje"].ToString();
                    Log("ProcesarCancelacion-LastError=" + LastError);
                }
            }
            catch
            {
                var result = (object[])new JavaScriptSerializer().DeserializeObject(response);
                LastError = ((Dictionary<string, object>)result.First())["mensaje"].ToString();
                Log("ProcesarCancelacion-LastError=" + LastError);
            }
            finally
            {
                httpClient.Dispose();
            }
            return cancelacion;
        }

        /// <summary>
        ///     Timbra un comprobante con el PAC
        /// </summary>
        /// <param name="url">URL del PAC (produccion o pruebas)</param>
        /// <param name="token">Token definido para la empresa (produccion o pruebas)</param>
        /// <param name="postBody">Información en JSON a emitir al PAC</param>
        /// <returns>El objeto coteniendo los valores de timbrado</returns>
        private async Task<ComprobanteTimbrado> ProcesarComprobante(string url, string token, string postBody)
        {
            var httpClient = new HttpClient();
            ComprobanteTimbrado comprobante = null;
            var response = "";
            try
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Add("Token", token);
                var wcfResponse = await httpClient.PostAsync(url, new StringContent(postBody, Encoding.UTF8, "application/json")).ConfigureAwait(false);
                response = await wcfResponse.Content.ReadAsStringAsync();
                Log("ProcesarComprobante-response=" + response);
                var result = (Dictionary<string, object>)new JavaScriptSerializer().DeserializeObject(response);
                if (wcfResponse.IsSuccessStatusCode)
                {
                    comprobante = new ComprobanteTimbrado
                    {
                        Uuid = result["uuid"].ToString(),
                        FechaTimbrado = result["fechaTimbrado"].ToString(),
                        XmlTimbradoBase64 = result[GetField(url)].ToString()
                    };
                    Log("ProcesarComprobante-comprobante-Uuid=" + comprobante.Uuid);
                    Log("ProcesarComprobante-comprobante-fechaTimbrado=" + comprobante.FechaTimbrado);
                    Log("ProcesarComprobante-comprobante-XmlTimbradoBase64=" + comprobante.XmlTimbradoBase64);
                    GuardarBd(comprobante);
                }
                else
                {
                    LastError = result["mensaje"].ToString();
                    Log("ProcesarComprobante-LastError=" + LastError);
                }
            }
            catch
            {
                var result = (object[])new JavaScriptSerializer().DeserializeObject(response);
                LastError = ((Dictionary<string, object>)result.First())["mensaje"].ToString();
                Log("ProcesarComprobante-LastError=" + LastError);
                comprobante = null;
            }
            finally
            {
                httpClient.Dispose();
            }
            return comprobante;
        }

        #endregion

        #region Helpers

        /// <summary>
        ///     Obtiene el nombre del campo retornado por el PAC
        /// </summary>
        /// <param name="url">URL del PAC (produccion o pruebas)</param>
        /// <returns>Nombre del campo retornado por el PAC</returns>
        private string GetField(string url)
        {
            var field = "";
            if (url.EndsWith("/facturas/emision", StringComparison.OrdinalIgnoreCase))
            {
                field = "facturaTimbradaBase64";
            }
            else if (url.EndsWith("/retenciones/emision", StringComparison.OrdinalIgnoreCase))
            {
                field = "retencionTimbradaBase64";
            }
            return field;
        }

        /// <summary>
        ///     Codifica un archivo en Base64/UTF-8
        /// </summary>
        /// <param name="fileToEncode">La ruta del archivo a codificar</param>
        /// <returns>Cadena de texto en formato Base64/UTF-8</returns>
        private string EncodeFileToBase64(string fileToEncode)
        {
            var bytes = File.ReadAllBytes(fileToEncode);
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        ///     Codifica una cadenad etexto plano en Base64/UTF-8
        /// </summary>
        /// <param name="stringToEncode">El texto plao a codificar</param>
        /// <returns>Cadena de texto en formato Base64/UTF-8</returns>
        private string EncodeStringToBase64(string stringToEncode)
        {
            return Convert.ToBase64String(Encoding.Default.GetBytes(stringToEncode));
        }

        private class NullPropertiesConverter : JavaScriptConverter
        {
            public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
            {
                throw new NotImplementedException();
            }

            public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
            {
                var jsonExample = new Dictionary<string, object>();
                foreach (var prop in obj.GetType().GetProperties())
                {
                    //check if decorated with ScriptIgnore attribute
                    bool ignoreProp = prop.IsDefined(typeof(ScriptIgnoreAttribute), true);

                    var value = prop.GetValue(obj, BindingFlags.Public, null, null, null);
                    if (value != null && !ignoreProp)
                        jsonExample.Add(prop.Name, value);
                }

                return jsonExample;
            }

            public override IEnumerable<Type> SupportedTypes
            {
                get { return GetType().Assembly.GetTypes(); }
            }
        }

        #endregion
    }
}

public class Cancelacion
{
    private const string UrlBasePruebas = "http://qa.pacmasnegocio.com:2376";
    private const string UrlBaseProduccion = "https://api.pacmasnegocio.com";
    private const string TokenPruebas = "eyAidHlwIjogIkpXVCIsICJhbGciOiAiSFMyNTYiIH0=.eyAic3ViIiA6ICJEQVRBRVhQUkVTU19BUEkiLCAiaWF0IiA6ICIyMDE1MDkyNjA5NTAzMCIsICJrZXkiIDogIjYzdE15eUM0eU1Dekh2Q1ZZbEhJL1E9PSIgfQ==./R+aDTdBdeTkO6qFkXR99dX1EZYCGpj8uePFR5VxZDU=";
    private const string TokenProduccion = "eyAidHlwIjogIkpXVCIsICJhbGciOiAiSFMyNTYiIH0=.eyAic3ViIiA6ICJEQVRBRVhQUkVTU19BUEkiLCAiaWF0IiA6ICIyMDE1MDkyNjA5NTEwMiIsICJrZXkiIDogImQyTFZodm1hQ2xSUHVXOFRmYVBlUEE9PSIgfQ==.fjnZJll94zA48BJFSNDKSYxv27RmRpgaRu3G1UiZkyE=";

    /// <summary>
    ///     UUID del comprobante cancelado
    /// </summary>
    public string Uuid { get; set; }

    /// <summary>
    ///     Ambiente de producción (true) o de pruebas (false)
    /// </summary>
    public bool Ambiente { get; set; }

    /// <summary>
    ///     ID de la factura a cancelar
    /// </summary>
    public string IdFactura { get; set; }

    public string AnioMes { get; set; }

    public string FechaSolicitud { get; private set; } = "";

    public string FechaCancelacion { get; private set; } = "";

    public string Estatus { get; private set; } = "";

    /// <summary>
    ///     Status de la cancelación ( -1=No UUID | 0=Desconocido | 1=Pendiente | 2=Encolada | 3=Exitosa | 4=Datos Erroneos |
    ///     5=Error en solicitud )
    /// </summary>
    public int Status { get; private set; }

    public void MonitoreaStatus()
    {
        new Thread(() =>
        {
            do
            {
                if (!string.IsNullOrEmpty(Uuid))
                {
                    for (var i = 1; i <= 5; i++)
                    {
                        var status = CheckStatus(i).Result;
                        if (status)
                        {
                            Status = i;
                            GuardarBd();
                            break;
                        }
                    }
                    Status = 0;
                }
                else
                {
                    Status = -1;
                }
                Thread.Sleep(1000 * 30);
            } while (Status < 3 && Status >= 0);
        }).Start();
    }

    #region Base de Datos

    private void GuardarBd()
    {
        BasesDatos bd = null;
        var fueExistosa = Status == 3 && !string.IsNullOrEmpty(IdFactura);
        try
        {
            if (fueExistosa)
            {
                bd = new BasesDatos();
                bd.Conectar();
                bd.CrearComando(@"UPDATE RetencionFactura SET estado = @estado WHERE idRetencion = @ID");
                bd.AsignarParametroEntero("@estado", Status);
                bd.AsignarParametroCadena("@ID", IdFactura);
                bd.EjecutarConsulta1();
            }
        }
        catch
        {
            // ignored
        }
        finally
        {
            if (bd != null)
            {
                bd.Desconectar();
            }
        }
    }

    #endregion

    private async Task<bool> CheckStatus(int status)
    {
        var httpClient = new HttpClient();
        try
        {
            httpClient.DefaultRequestHeaders.Add("Token", Ambiente ? TokenProduccion : TokenPruebas);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var aniomes = !string.IsNullOrEmpty(AnioMes) ? AnioMes : DateTime.Now.ToString("yyyyMM");
            var url = Ambiente ? UrlBaseProduccion : UrlBasePruebas + "/reportes/detalle/Cancelacion_CFDI32/" + aniomes + "/1/1/1/" + status + "/1/" + Uuid;
            var wcfResponse = await httpClient.GetAsync(url).ConfigureAwait(false);
            var response = await wcfResponse.Content.ReadAsStringAsync();
            if (wcfResponse.IsSuccessStatusCode)
            {
                var result = (Dictionary<string, object>)new JavaScriptSerializer().DeserializeObject(response);
                var registros = (object[])result["registros"];
                foreach (Dictionary<string, object> registro in registros)
                {
                    try
                    {
                        FechaSolicitud = registro["fechaSolicitud"].ToString();
                    }
                    catch
                    {
                        // ignored
                    }
                    try
                    {
                        FechaCancelacion = registro["fechaCancelacion"].ToString();
                    }
                    catch
                    {
                        // ignored
                    }
                    try
                    {
                        Estatus = registro["estatus"].ToString();
                    }
                    catch
                    {
                        // ignored
                    }
                }
                httpClient.Dispose();
                return true;
            }
        }
        catch
        {
            // ignored
        }
        finally
        {
            httpClient.Dispose();
        }
        return false;
    }
}

public class ComprobanteTimbrado
{
    /// <summary>
    ///     UUID del comprobante timbrado
    /// </summary>
    public string Uuid { get; set; }

    /// <summary>
    ///     Fecha y hora en el que el comprobante fue timbrado en formato yyyy-mm-ddThh:mm:ss
    /// </summary>
    public string FechaTimbrado { get; set; }

    /// <summary>
    ///     XmlTimbrado en formato Base64/UTF-8 que regresa el PAC
    /// </summary>
    public string XmlTimbradoBase64 { get; set; }

    /// <summary>
    ///     El XmlDocument resultado del XmlTimbrado que regresa el PAC
    /// </summary>
    public XmlDocument XmlTimbrado
    {
        get
        {
            XmlDocument xmlTimbrado = null;
            try
            {
                xmlTimbrado = new XmlDocument();
                xmlTimbrado.LoadXml(DecodeStringFromBase64(XmlTimbradoBase64));
            }
            catch
            {
                // ignored
            }
            return xmlTimbrado;
        }
    }

    /// <summary>
    ///     Decodifica una cadena en texto Base64/UTF-8 a texto plano
    /// </summary>
    /// <param name="stringToDecode">La cadena en formato Base64/UTF-8 a decodificar</param>
    /// <returns>El texto plano decodificado</returns>
    private string DecodeStringFromBase64(string stringToDecode)
    {
        return Encoding.Default.GetString(Convert.FromBase64String(stringToDecode));
    }

    public string GetAtributte(string name, string node)
    {
        string result = null;
        if (XmlTimbrado != null)
        {
            XmlNodeList listaNodos = XmlTimbrado.GetElementsByTagName(node);
            foreach (XmlElement nodo in listaNodos)
            {
                if (nodo.HasAttributes && nodo.HasAttribute(name))
                {
                    result = nodo.GetAttribute(name);
                    break;
                }
            }
        }
        return result;
    }

}