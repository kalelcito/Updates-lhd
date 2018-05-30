using CodeQR;
using Datos;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Xsl;

namespace Control
{
    public class Retencion
    {
        #region Propiedades de la retencion

        public string Archivo { get; } = "";
        public string cadenaCFDI { get; set; } = "";
        public string cadenaOriginal { get; set; } = "";
        public string certificadoEmi { get; set; } = "";
        public string certificadoSAT { get; set; } = "";
        public byte[] codigoQR { get; set; } = new byte[0];
        public string conceptoPago { get; set; } = "";
        public string ConceptoPago { get; set; } = "";
        public string CURP { get; set; } = "";
        public string CURPE { get; set; } = "";
        public string CURPR { get; set; } = "";
        public string CveRetenc { get; set; } = "";
        public string DescRetenc { get; set; } = "";
        public string descripcionConcepto { get; set; } = "";
        public string DescripcionConcepto { get; set; } = "";
        public string dirPDF { get; set; } = "";
        public string dirXML { get; set; } = "";
        public string edoFac { get; set; } = "0";
        public string Ejerc { get; set; } = "";
        public string EsBenefEfectDelCobro { get; set; } = "";
        public string EXT { get; set; } = "";
        public string FechaExp { get; set; } = "";
        public string fechaTimbrado { get; set; } = "";
        public string FolioInt { get; set; } = "";
        public int id { get; set; } = -1;
        public List<ImpuestosRetenidos> ImpRetenidos { get; set; } = new List<ImpuestosRetenidos>();
        public string MesFin { get; set; } = "";
        public string MesIni { get; set; } = "";
        public string montoTotExent { get; set; } = "";
        public string montoTotGrav { get; set; } = "";
        public string montoTotOperacion { get; set; } = "";
        public string montoTotRet { get; set; } = "";
        public string Nacionalidad { get; set; } = "";
        public string noCertificadoEmi { get; set; } = "";
        public string noCertificadoSAT { get; set; } = "";
        public string NomDenRazSocB { get; set; } = "";
        public string NomDenRazSocE { get; set; } = "";
        public string NomDenRazSocR { get; set; } = "";
        public string NumRegIdTrib { get; set; } = "";
        public string PaisDeResidParaEfecFisc { get; set; } = "";
        public string RFC { get; set; } = "";
        public string RFCEmisor { get; set; } = "";
        public string RFCRecep { get; set; } = "";
        public string selloCFD { get; set; } = "";
        public string selloEmi { get; set; } = "";
        public string selloSAT { get; set; } = "";
        public string serie { get; set; } = "";
        public string tipoDeComprobante { get; set; } = "retencion";
        public string tipoDoc { get; set; } = "7";
        public string UUID { get; set; } = "";
        public string CveTipDivOUtil { get; set; } = "";
        public string MontISRAcredRetMexico { get; set; } = "";
        public string MontISRAcredRetExtranjero { get; set; } = "";
        public string MontRetExtDivExt { get; set; } = "";
        public string TipoSocDistrDiv { get; set; } = "";
        public string MontISRAcredNal { get; set; } = "";
        public string MontDivAcumNal { get; set; } = "";
        public string MontDivAcumExt { get; set; } = "";
        public string ProporcionRem { get; set; } = "";

        #region Campos CFDI

        public bool banCFDI { get; set; } = false;
        public string CadenaCodigo { get; set; } = "";
        public string version_tim { get; set; } = "";
        public string xmlns_tfd_cfdi { get; set; } = "";
        public string xmlns_xsi_cfdi { get; set; } = "";
        public string xsi_schemaLocation_cfdi { get; set; } = "";

        #endregion Campos CFDI

        #endregion Propiedades de la retencion

        #region Propiedades de utilidad

        public Dictionary<string, string> CatalogoImpuestos { get; } = new Dictionary<string, string>()
        {
            {"01", "ISR"},
            {"02", "IVA"},
            {"03", "IEPS"}
        };

        public Dictionary<string, string> CatalogoRetenciones { get; } = new Dictionary<string, string>()
        {
            {"01", "Servicios profesionales"},
            {"02", "Regalías por derechos de autor"},
            {"03", "Autotransporte terrestre de carga"},
            {"04", "Servicios prestados por comisionistas"},
            {"05", "Arrendamiento"},
            {"06", "Enajenación de acciones"},
            {"07", "Enajenación de bienes objeto de la LIEPS, a través de mediadores, agentes, representantes, corredores, consignatarios o distribuidores"},
            {"08", "Enajenación de bienes inmuebles consignada en escritura publica"},
            {"09", "Enajenación de otros bienes, no consignada en escritura publica"},
            {"10", "Adquisición de desperdicios industriales"},
            {"11", "Adquisición de bienes consignada en escritura publica"},
            {"12", "Adquisición de otros bienes, no consignada a escritura publica"},
            {"13", "Otros retiros de AFORE"},
            {"14", "Dividendos o utilidades distribuidas"},
            {"15", "Remanente distribuible"},
            {"16", "Intereses"},
            {"17", "Arrendamiento en fideicomiso"},
            {"18", "Pagos realizados a favor de residentes en el extranjero"},
            {"19", "Enajenación de acciones u operaciones en bolsa de valores"},
            {"20", "Obtención de premios"},
            {"21", "Fideicomisos que no realizan actividades empresariales"},
            {"22", "Planes personales de retiro"},
            {"23", "Intereses reales deducibles por crédito hipotecarios"},
            {"24", "Operaciones Financieras Derivadas de Capital"},
            {"25", "Otro tipo de retenciones"}
        };

        public bool isPagoExtranjero { get; set; } = false;

        public bool isDividendos { get; set; } = false;

        public List<KeyValuePair<string, List<KeyValuePair<string, string>>>> secciones { get; set; }

        private Dictionary<string, List<string>> Mapeo { get; } = new Dictionary<string, List<string>>()
{
            {"Retenciones", new List<string>{"FolioInt", "FechaExp", "CveRetenc", "DescRetenc"}},
            {"Emisor", new List<string>{"RFCEmisor", "NomDenRazSocE", "CURPE"}},
            {"Receptor", new List<string>{"Nacionalidad", "RFCRecep", "NomDenRazSocR", "CURPR", "EXT", "NumRegIdTrib", "NomDenRazSocR"}},
            {"Periodo", new List<string>{"MesIni", "MesFin", "Ejerc"}},
            {"Totales", new List<string>{"montoTotOperacion", "montoTotGrav", "montoTotExent", "montoTotRet"}},
            {"ImpRetenidos", new List<string>{"BaseRet", "Impuesto", "montoRet", "TipoPagoRet"}},
            {"Complemento|Pagosaextranjeros", new List<string>{"EsBenefEfectDelCobro" }},
            {"Complemento|Pagosaextranjeros|NoBeneficiario", new List<string>{"PaisDeResidParaEfecFisc", "ConceptoPago", "DescripcionConcepto"}},
            {"Complemento|Pagosaextranjeros|Beneficiario", new List<string>{"RFC", "CURP", "NomDenRazSocB", "ConceptoPago", "DescripcionConcepto"}},
            {"Complemento|Dividendos", new List<string> { } },
            {"Complemento|Dividendos|DividOUtil", new List<string> {"CveTipDivOUtil","MontISRAcredRetMexico","MontISRAcredRetExtranjero","MontRetExtDivExt","TipoSocDistrDiv","MontISRAcredNal","MontDivAcumNal","MontDivAcumExt"}},
            {"Complemento|Dividendos|Remanente", new List<string> {"ProporcionRem"}}
};

        #endregion Propiedades de utilidad

        private BasesDatos DB;

        public Retencion(string archivo)
        {
            this.Archivo = archivo;
            this.secciones = new List<KeyValuePair<string, List<KeyValuePair<string, string>>>>();
            DB = new BasesDatos();
            procesarInformacion();
            if (isPagoExtranjero)
            {
                RFCRecep = RFC;
                CURPR = CURP;
            }
        }

        public Retencion()
        {
            this.secciones = new List<KeyValuePair<string, List<KeyValuePair<string, string>>>>();
            DB = new BasesDatos();
        }

        public Retencion(List<List<string>> listaDatos)
        {
            setDatos(listaDatos);
        }

        public void setDatos(List<List<string>> listaDatos)
        {
            this.secciones = new List<KeyValuePair<string, List<KeyValuePair<string, string>>>>();
            DB = new BasesDatos();
            for (int i = 0; i < listaDatos.Count; i++)
            {
                List<string> datos = listaDatos.ElementAt(i);
                string nodo = datos.ElementAt(0);
                datos.RemoveAt(0);
                this.secciones.Add(new KeyValuePair<string, List<KeyValuePair<string, string>>>(nodo, colocaAtributos(datos, nodo)));
            }
        }

        private string calculaFolio()
        {
            string sFolio = "1";
            DB.Conectar();
            //DB.CrearComando(@"SELECT
            //                    TOP 1 (g.folio + 1) AS folio
            //                FROM
            //                    GENERAL g
            //                    INNER JOIN Emisor e
            //                    ON g.id_Emisor = e.IDEEMI AND g.serie = e.SERIE
            //                WHERE e.RFCEMI = @RFC
            //                ORDER BY folio DESC");
            DB.CrearComando(@"SELECT
                                TOP 1 (g.folio + 1) AS folio
                            FROM
                                GENERAL g
                                INNER JOIN Emisor e
                                   ON g.id_Emisor = e.IDEEMI
                            WHERE e.RFCEMI = @RFC
                            ORDER BY folio DESC");
            DB.AsignarParametroCadena("@RFC", this.RFCEmisor);
            DbDataReader dr = DB.EjecutarConsulta();
            if (dr.HasRows)
            {
                dr.Read();
                sFolio = dr["folio"].ToString();
            }
            DB.Desconectar();
            return sFolio;
        }

        private List<KeyValuePair<string, string>> colocaAtributos(List<string> datos, string nodo)
        {
            string atributo;
            string valor;
            List<KeyValuePair<string, string>> datos_tmp = new List<KeyValuePair<string, string>>();
            ImpuestosRetenidos imp = new ImpuestosRetenidos();
            bool esImp = (nodo.Equals("ImpRetenidos", StringComparison.OrdinalIgnoreCase));
            for (int i = 0; i < datos.Count; i++)
            {
                atributo = (this.Mapeo[nodo])[i];
                valor = datos[i];
                if (!String.IsNullOrEmpty(valor))
                {
                    if (esImp)
                    {
                        imp.GetType().GetProperty(atributo).SetValue(imp, valor, null);
                    }
                    else
                    {
                        this.GetType().GetProperty(atributo).SetValue(this, valor, null);
                    }
                    datos_tmp.Add(new KeyValuePair<string, string>(atributo, valor));
                }
            }
            if (esImp)
            {
                imp.descripcion = CatalogoImpuestos[imp.Impuesto];
                this.ImpRetenidos.Add(imp);
            }
            return datos_tmp;
        }

        private void procesarInformacion()
        {
            string linea;
            this.secciones = new List<KeyValuePair<string, List<KeyValuePair<string, string>>>>();
            System.IO.StreamReader file = new System.IO.StreamReader(this.Archivo);
            while ((linea = file.ReadLine()) != null)
            {
                var nodoDatos = linea.Split(new[] { "||" }, 2, StringSplitOptions.None);
                var nodo = nodoDatos[0];
                if (nodo.Equals("Complemento|PagosaExtranjeros", StringComparison.OrdinalIgnoreCase))
                {
                    this.isPagoExtranjero = true;
                }
                if (nodo.Equals("Complemento|Dividendos", StringComparison.OrdinalIgnoreCase))
                {
                    this.isDividendos = true;
                }
                var datos = nodoDatos[1].Split('|').ToList();
                if (linea.EndsWith("|"))
                {
                    datos.RemoveAt(datos.Count - 1);
                }
                this.secciones.Add(new KeyValuePair<string, List<KeyValuePair<string, string>>>(nodo, colocaAtributos(datos, nodo)));
            }
            file.Close();
            //this.FolioInt = (this.FolioInt.Equals("")) ? calculaFolio() : this.FolioInt;
            this.serie = "";
            //this.FolioInt = calculaFolio();
            string subcarpeta = Convert.ToDateTime(this.FechaExp).ToString("yyyy/MM/dd").Replace("/", @"\") + @"\" + this.RFCEmisor + @"\";
            this.dirXML = subcarpeta + "XML" + @"\0" + this.tipoDoc + "_" + this.RFCEmisor + "_" + this.FolioInt + "_" + this.serie + ".xml";
            this.dirPDF = subcarpeta + "PDF" + @"\0" + this.tipoDoc + "_" + this.RFCEmisor + "_" + this.FolioInt + "_" + this.serie + ".pdf";
            // mensajeColor("XML = " + this.dirXML, ConsoleColor.Red);
        }

        private void recortarNodoDatos(ref string nodo, ref List<string> datos)
        {
            string localNodo = datos.ElementAt(0);
            while ((localNodo.Equals("PagosaExtranjeros", StringComparison.OrdinalIgnoreCase) || localNodo.Equals("NoBeneficiario", StringComparison.OrdinalIgnoreCase) || localNodo.Equals("Beneficiario", StringComparison.OrdinalIgnoreCase)))
            {
                nodo += "|" + localNodo;
                datos.RemoveAt(0);
                localNodo = datos.ElementAt(0);
            }
        }
    }
    public class ImpuestosRetenidos
    {
        public string BaseRet { get; set; } = "";
        public string descripcion { get; set; } = "";
        public string Impuesto { get; set; } = "";
        public string montoRet { get; set; } = "";
        public string TipoPagoRet { get; set; } = "";
    }
    public class StringWriterWithEncoding : StringWriter
    {
        private Encoding myEncoding;

        public StringWriterWithEncoding(Encoding encoding)
            : base()
        {
            myEncoding = encoding;
        }

        public override Encoding Encoding
        {
            get
            {
                return myEncoding;
            }
        }
    }
    public class Transformar
    {
        private void Log(string logMessage)
        {
            var _dbLog = new BasesDatos();
            _dbLog.Conectar();
            try
            {
                _dbLog.CrearComando(@"INSERT INTO PruebasLog VALUES (@pagina, @fechaHora, @mensaje)");
                _dbLog.AsignarParametroCadena("@pagina", "Transformar.cs");
                _dbLog.AsignarParametroCadena("@fechaHora", DateTime.Now.ToString("s"));
                _dbLog.AsignarParametroCadena("@mensaje", logMessage.Replace("'", "''"));
                _dbLog.EjecutarConsulta1();
            }
            catch { }
            finally
            {
                _dbLog.Desconectar();
            }
        }

        #region Variables

        private BasesDatos DB;
        private Retencion retencion;
        private XslCompiledTransform xsltRET;
        private string calleEmisor;
        private string calleEmisorExp;
        private string calleReceptor;
        private string codigoPostalEmisor;
        private string codigoPostalEmisorExp;
        private string codigoPostalReceptor;
        private GeneraQR codigoQR;
        private string coloniaEmisor;
        private string coloniaEmisorExp;
        private string coloniaReceptor;
        private string curpe;
        private string curpEmi;
        private string curpRec;
        private string estadoEmisor;
        private string estadoEmisorExp;
        private string estadoReceptor;
        private string id_Empleado;
        private string IDEDOMEMIEXP;
        private string IDEDOMRECCON;
        private string IDEEMI;
        private string IDEFAC;
        private string IDEREC;
        private string imssReceptor;
        private DateTime inicio, fin;
        private string localidadEmisor;
        private string localidadEmisorExp;
        private string localidadReceptor;
        private string municipioEmisor;
        private string municipioEmisorExp;
        private string municipioReceptor;
        private string noExteriorEmisor;
        private string noExteriorEmisorExp;
        private string noExteriorReceptor;
        private string noInteriorEmisor;
        private string noInteriorEmisorExp;
        private string noInteriorReceptor;
        private string nombreEmisor;
        private string nombreReceptor;
        private string paisEmisor;
        private string paisEmisorExp;
        private string paisReceptor;
        private string referenciaEmisor;
        private string referenciaEmisorExp;
        private string referenciaReceptor;
        private string Regimen;
        private string rfcEmisor;
        private string rfcReceptor;
        private List<KeyValuePair<string, List<KeyValuePair<string, string>>>> secciones;
        private string serie;
        private string subcarpeta;
        private string telefonoRec;
        private string telefonoReceptor;
        public bool ambiente { get { return true; } } //false= pruebas & true =produccion

        #region Campos Configuracion

        private string ANIOAPROB = "";
        private string CERNUM = "";
        private string CERRUT = "";
        private string CLAVE = "";
        private string IDECNF = "";
        private string NUMAPROB = "";
        private string PRVRUT = "";
        private string SERIE = "";

        #endregion Campos Configuracion

        #region Lista Paises

        private Dictionary<string, string> listaPaises = new Dictionary<string, string>()
            {
                {"AF", "AFGANISTAN (EMIRATO ISLAMICO DE)"},
                {"AL", "ALBANIA (REPUBLICA DE)"},
                {"DE", "ALEMANIA (REPUBLICA FEDERAL DE)"},
                {"AD", "ANDORRA (PRINCIPADO DE)"},
                {"AO", "ANGOLA (REPUBLICA DE)"},
                {"AI", "ANGUILA"},
                {"AQ", "ANTARTIDA"},
                {"AG", "ANTIGUA Y BARBUDA (COMUNIDAD BRITANICA DE NACIONES)"},
                {"AN", "ANTILLAS NEERLANDESAS (TERRITORIO HOLANDES DE ULTRAMAR)"},
                {"SA", "ARABIA SAUDITA (REINO DE)"},
                {"DZ", "ARGELIA (REPUBLICA DEMOCRATICA Y POPULAR DE)"},
                {"AR", "ARGENTINA (REPUBLICA)"},
                {"AM", "ARMENIA (REPUBLICA DE)"},
                {"AW", "ARUBA (TERRITORIO HOLANDES DE ULTRAMAR)"},
                {"AU", "AUSTRALIA (COMUNIDAD DE)"},
                {"AT", "AUSTRIA (REPUBLICA DE)"},
                {"AZ", "AZERBAIJAN (REPUBLICA AZERBAIJANI)"},
                {"BS", "BAHAMAS (COMUNIDAD DE LAS)"},
                {"BH", "BAHREIN (ESTADO DE)"},
                {"BD", "BANGLADESH (REPUBLICA POPULAR DE)"},
                {"BB", "BARBADOS (COMUNIDAD BRITANICA DE NACIONES)"},
                {"BE", "BELGICA (REINO DE)"},
                {"BZ", "BELICE"},
                {"BJ", "BENIN (REPUBLICA DE)"},
                {"BM", "BERMUDAS"},
                {"BY", "BIELORRUSIA (REPUBLICA DE)"},
                {"BO", "BOLIVIA (REPUBLICA DE)"},
                {"BA", "BOSNIA Y HERZEGOVINA"},
                {"BW", "BOTSWANA (REPUBLICA DE)"},
                {"BR", "BRASIL (REPUBLICA FEDERATIVA DE)"},
                {"BN", "BRUNEI (ESTADO DE) (RESIDENCIA DE PAZ)"},
                {"BG", "BULGARIA (REPUBLICA DE)"},
                {"BF", "BURKINA FASO"},
                {"BI", "BURUNDI (REPUBLICA DE)"},
                {"BT", "BUTAN (REINO DE)"},
                {"CV", "CABO VERDE (REPUBLICA DE)"},
                {"TD", "CHAD (REPUBLICA DEL)"},
                {"KY", "CAIMAN (ISLAS)"},
                {"KH", "CAMBOYA (REINO DE)"},
                {"CM", "CAMERUN (REPUBLICA DEL)"},
                {"CA", "CANADA"},
                {"CL", "CHILE (REPUBLICA DE)"},
                {"CN", "CHINA (REPUBLICA POPULAR)"},
                {"CY", "CHIPRE (REPUBLICA DE)"},
                {"VA", "CIUDAD DEL VATICANO (ESTADO DE LA)"},
                {"CC", "COCOS (KEELING, ISLAS AUSTRALIANAS)"},
                {"CO", "COLOMBIA (REPUBLICA DE)"},
                {"KM", "COMORAS (ISLAS)"},
                {"CG", "CONGO (REPUBLICA DEL)"},
                {"CK", "COOK (ISLAS)"},
                {"KP", "COREA (REPUBLICA POPULAR DEMOCRATICA DE) (COREA DEL NORTE)"},
                {"KR", "COREA (REPUBLICA DE) (COREA DEL SUR)"},
                {"CI", "COSTA DE MARFIL (REPUBLICA DE LA)"},
                {"CR", "COSTA RICA (REPUBLICA DE)"},
                {"HR", "CROACIA (REPUBLICA DE)"},
                {"CU", "CUBA (REPUBLICA DE)"},
                {"DK", "DINAMARCA (REINO DE)"},
                {"DJ", "DJIBOUTI (REPUBLICA DE)"},
                {"DM", "DOMINICA (COMUNIDAD DE)"},
                {"EC", "ECUADOR (REPUBLICA DEL)"},
                {"EG", "EGIPTO (REPUBLICA ARABE DE)"},
                {"SV", "EL SALVADOR (REPUBLICA DE)"},
                {"AE", "EMIRATOS ARABES UNIDOS"},
                {"ER", "ERITREA (ESTADO DE)"},
                {"SI", "ESLOVENIA(REPUBLICA DE)"},
                {"ES", "ESPAÑA (REINO DE)"},
                {"FM", "ESTADO FEDERADO DE MICRONESIA"},
                {"US", "ESTADOS UNIDOS DE AMERICA"},
                {"EE", "ESTONIA (REPUBLICA DE)"},
                {"ET", "ETIOPIA (REPUBLICA DEMOCRATICA FEDERAL)"},
                {"FJ", "FIDJI (REPUBLICA DE)"},
                {"PH", "FILIPINAS (REPUBLICA DE LAS)"},
                {"FI", "FINLANDIA (REPUBLICA DE)"},
                {"FR", "FRANCIA (REPUBLICA FRANCESA)"},
                {"GA", "GABONESA (REPUBLICA)"},
                {"GM", "GAMBIA (REPUBLICA DE LA)"},
                {"GE", "GEORGIA (REPUBLICA DE)"},
                {"GH", "GHANA (REPUBLICA DE)"},
                {"GI", "GIBRALTAR (R.U.)"},
                {"GD", "GRANADA"},
                {"GR", "GRECIA (REPUBLICA HELENICA)"},
                {"GL", "GROENLANDIA (DINAMARCA)"},
                {"GP", "GUADALUPE (DEPARTAMENTO DE)"},
                {"GU", "GUAM (E.U.A.)"},
                {"GT", "GUATEMALA (REPUBLICA DE)"},
                {"GG", "GUERNSEY"},
                {"GW", "GUINEA-BISSAU (REPUBLICA DE)"},
                {"GQ", "GUINEA ECUATORIAL (REPUBLICA DE)"},
                {"GN", "GUINEA (REPUBLICA DE)"},
                {"GF", "GUYANA FRANCESA"},
                {"GY", "GUYANA (REPUBLICA COOPERATIVA DE)"},
                {"HT", "HAITI (REPUBLICA DE)"},
                {"HN", "HONDURAS (REPUBLICA DE)"},
                {"HK", "HONG KONG (REGION ADMINISTRATIVA ESPECIAL DE LA REPUBLICA)"},
                {"HU", "HUNGRIA (REPUBLICA DE)"},
                {"IN", "INDIA (REPUBLICA DE)"},
                {"ID", "INDONESIA (REPUBLICA DE)"},
                {"IQ", "IRAK (REPUBLICA DE)"},
                {"IR", "IRAN (REPUBLICA ISLAMICA DEL)"},
                {"IE", "IRLANDA (REPUBLICA DE)"},
                {"IS", "ISLANDIA (REPUBLICA DE)"},
                {"BV", "ISLA BOUVET"},
                {"IM", "ISLA DE MAN"},
                {"AX", "ISLAS ALAND"},
                {"FO", "ISLAS FEROE"},
                {"GS", "ISLAS GEORGIA Y SANDWICH DEL SUR"},
                {"HM", "ISLAS HEARD Y MCDONALD"},
                {"FK", "ISLAS MALVINAS (R.U.)"},
                {"MP", "ISLAS MARIANAS SEPTENTRIONALES"},
                {"MH", "ISLAS MARSHALL"},
                {"UM", "ISLAS MENORES DE ULTRAMAR DE ESTADOS UNIDOS DE AMERICA"},
                {"SB", "ISLAS SALOMON (COMUNIDAD BRITANICA DE NACIONES)"},
                {"SJ", "ISLAS SVALBARD Y JAN MAYEN (NORUEGA)"},
                {"TK", "ISLAS TOKELAU"},
                {"WF", "ISLAS WALLIS Y FUTUNA"},
                {"IL", "ISRAEL (ESTADO DE)"},
                {"IT", "ITALIA (REPUBLICA ITALIANA)"},
                {"JM", "JAMAICA"},
                {"JP", "JAPON"},
                {"JE", "JERSEY"},
                {"JO", "JORDANIA (REINO HACHEMITA DE)"},
                {"KZ", "KAZAKHSTAN (REPUBLICA DE) "},
                {"KE", "KENYA (REPUBLICA DE)"},
                {"KI", "KIRIBATI (REPUBLICA DE)"},
                {"KW", "KUWAIT (ESTADO DE)"},
                {"KG", "KYRGYZSTAN (REPUBLICA KIRGYZIA)"},
                {"LS", "LESOTHO (REINO DE)"},
                {"LV", "LETONIA (REPUBLICA DE)"},
                {"LB", "LIBANO (REPUBLICA DE)"},
                {"LR", "LIBERIA (REPUBLICA DE)"},
                {"LY", "LIBIA (JAMAHIRIYA LIBIA ARABE POPULAR SOCIALISTA)"},
                {"LI", "LIECHTENSTEIN (PRINCIPADO DE)"},
                {"LT", "LITUANIA (REPUBLICA DE)"},
                {"LU", "LUXEMBURGO (GRAN DUCADO DE)"},
                {"MO", "MACAO"},
                {"MK", "MACEDONIA (ANTIGUA REPUBLICA YUGOSLAVA DE)"},
                {"MG", "MADAGASCAR (REPUBLICA DE)"},
                {"MY", "MALASIA"},
                {"MW", "MALAWI (REPUBLICA DE)"},
                {"MV", "MALDIVAS (REPUBLICA DE)"},
                {"ML", "MALI (REPUBLICA DE)"},
                {"MT", "MALTA (REPUBLICA DE)"},
                {"MA", "MARRUECOS (REINO DE)"},
                {"MQ", "MARTINICA (DEPARTAMENTO DE) (FRANCIA)"},
                {"MU", "MAURICIO (REPUBLICA DE)"},
                {"MR", "MAURITANIA (REPUBLICA ISLAMICA DE)"},
                {"YT", "MAYOTTE"},
                {"MX", "MEXICO (ESTADOS UNIDOS MEXICANOS)"},
                {"MD", "MOLDAVIA (REPUBLICA DE)"},
                {"MC", "MONACO (PRINCIPADO DE)"},
                {"MN", "MONGOLIA"},
                {"MS", "MONSERRAT (ISLA)"},
                {"ME", "MONTENEGRO"},
                {"MZ", "MOZAMBIQUE (REPUBLICA DE)"},
                {"MM", "MYANMAR (UNION DE)"},
                {"NA", "NAMIBIA (REPUBLICA DE)"},
                {"NR", "NAURU"},
                {"CX", "NAVIDAD (CHRISTMAS) (ISLAS)"},
                {"NP", "NEPAL (REINO DE)"},
                {"NI", "NICARAGUA (REPUBLICA DE)"},
                {"NE", "NIGER (REPUBLICA DE)"},
                {"NG", "NIGERIA (REPUBLICA FEDERAL DE)"},
                {"NU", "NIVE (ISLA)"},
                {"NF", "NORFOLK (ISLA)"},
                {"NO", "NORUEGA (REINO DE)"},
                {"NC", "NUEVA CALEDONIA (TERRITORIO FRANCES DE, ULTRAMAR)"},
                {"NZ", "NUEVA ZELANDIA"},
                {"OM", "OMAN (SULTANATO DE)"},
                {"PIK", "PACIFICO, ISLAS DEL (ADMON. E.U.A.)"},
                {"NL", "PAISES BAJOS (REINO DE LOS) (HOLANDA)"},
                {"PK", "PAKISTAN (REPUBLICA ISLAMICA DE)"},
                {"PW", "PALAU (REPUBLICA DE)"},
                {"PS", "PALESTINA"},
                {"PA", "PANAMA (REPUBLICA DE)"},
                {"PG", "PAPUA NUEVA GUINEA (ESTADO INDEPENDIENTE DE)"},
                {"PY", "PARAGUAY (REPUBLICA DEL)"},
                {"PE", "PERU (REPUBLICA DEL)"},
                {"PN", "PITCAIRNS (ISLAS DEPENDENCIA BRITANICA)"},
                {"PF", "POLINESIA FRANCESA"},
                {"PL", "POLONIA (REPUBLICA DE)"},
                {"PT", "PORTUGAL (REPUBLICA PORTUGUESA)"},
                {"PR", "PUERTO RICO (ESTADO LIBRE ASOCIADO DE LA COMUNIDAD DE)"},
                {"QA", "QATAR (ESTADO DE)"},
                {"GB", "REINO UNIDO DE LA GRAN BRETAÑA E IRLANDA DEL NORTE"},
                {"CZ", "REPUBLICA CHECA"},
                {"CF", "REPUBLICA CENTROAFRICANA"},
                {"LA", "REPUBLICA DEMOCRATICA POPULAR LAOS"},
                {"RS", "REPUBLICA DE SERBIA"},
                {"DO", "REPUBLICA DOMINICANA"},
                {"SK", "REPUBLICA ESLOVACA"},
                {"CD", "REPUBLICA POPULAR DEL CONGO"},
                {"RW", "REPUBLICA RUANDESA"},
                {"RE", "REUNION (DEPARTAMENTO DE LA) (FRANCIA)"},
                {"RO", "RUMANIA"},
                {"RU", "RUSIA (FEDERACION RUSA)"},
                {"EH", "SAHARA OCCIDENTAL (REPUBLICA ARABE SAHARAVI DEMOCRATICA)"},
                {"WS", "SAMOA (ESTADO INDEPENDIENTE DE)"},
                {"AS", "SAMOA AMERICANA"},
                {"BL", "SAN BARTOLOME"},
                {"KN", "SAN CRISTOBAL Y NIEVES (FEDERACION DE) (SAN KITTS - NEVIS)"},
                {"SM", "SAN MARINO (SERENISIMA REPUBLICA DE)"},
                {"MF", "SAN MARTIN"},
                {"PM", "SAN PEDRO Y MIQUELON"},
                {"VC", "SAN VICENTE Y LAS GRANADINAS"},
                {"SH", "SANTA ELENA"},
                {"LC", "SANTA LUCIA"},
                {"ST", "SANTO TOME Y PRINCIPE (REPUBLICA DEMOCRATICA DE)"},
                {"SN", "SENEGAL (REPUBLICA DEL)"},
                {"SC", "SEYCHELLES (REPUBLICA DE LAS)"},
                {"SL", "SIERRA LEONA (REPUBLICA DE)"},
                {"SG", "SINGAPUR (REPUBLICA DE)"},
                {"SY", "SIRIA (REPUBLICA ARABE)"},
                {"SO", "SOMALIA"},
                {"LK", "SRI LANKA (REPUBLICA DEMOCRATICA SOCIALISTA DE)"},
                {"ZA", "SUDAFRICA (REPUBLICA DE)"},
                {"SD", "SUDAN (REPUBLICA DEL)"},
                {"SE", "SUECIA (REINO DE)"},
                {"CH", "SUIZA (CONFEDERACION)"},
                {"SR", "SURINAME (REPUBLICA DE)"},
                {"SZ", "SWAZILANDIA (REINO DE)"},
                {"TJ", "TADJIKISTAN (REPUBLICA DE)"},
                {"TH", "TAILANDIA (REINO DE)"},
                {"TW", "TAIWAN (REPUBLICA DE CHINA)"},
                {"TZ", "TANZANIA (REPUBLICA UNIDA DE)"},
                {"IO", "TERRITORIOS BRITANICOS DEL OCEANO INDICO"},
                {"TF", "TERRITORIOS FRANCESES, AUSTRALES Y ANTARTICOS"},
                {"TL", "TIMOR ORIENTAL"},
                {"TG", "TOGO (REPUBLICA TOGOLESA)"},
                {"TO", "TONGA (REINO DE)"},
                {"TT", "TRINIDAD Y TOBAGO (REPUBLICA DE)"},
                {"TN", "TUNEZ (REPUBLICA DE)"},
                {"TC", "TURCAS Y CAICOS(ISLAS)"},
                {"TM", "TURKMENISTAN (REPUBLICA DE)"},
                {"TR", "TURQUIA (REPUBLICA DE)"},
                {"TV", "TUVALU (COMUNIDAD BRITANICA DE NACIONES)"},
                {"UA", "UCRANIA"},
                {"UG", "UGANDA (REPUBLICA DE)"},
                {"UY", "URUGUAY (REPUBLICA ORIENTAL DEL)"},
                {"UZ", "UZBEJISTAN (REPUBLICA DE)"},
                {"VU", "VANUATU"},
                {"VE", "VENEZUELA (REPUBLICA DE)"},
                {"VN", "VIETNAM (REPUBLICA SOCIALISTA DE)"},
                {"VG", "VIRGENES. ISLAS (BRITANICAS)"},
                {"VI", "VIRGENES. ISLAS (NORTEAMERICANAS)"},
                {"YE", "YEMEN (REPUBLICA DE)"},
                {"ZM", "ZAMBIA (REPUBLICA DE)"}
            };

        #endregion Lista Paises

        public string MensajeError { get; set; }

        #endregion Variables

        public Transformar(Retencion retencion)
        {
            DB = new BasesDatos();
            this.retencion = retencion;
            ObtenerConf(retencion.RFCEmisor);
            this.retencion.serie = SERIE;
        }

        public Transformar()
        {
        }

        private bool loadXSLT()
        {
            xsltRET = new XslCompiledTransform();
            string dirXsltRet = AppDomain.CurrentDomain.BaseDirectory + @"xslt\retenciones.xslt";
            try
            {
                xsltRET.Load(dirXsltRet);
                return true;
            }
            catch (Exception e)
            {
                // ignored
                return false;
            }
        }

        public XmlDocument XML()
        {
            if (!loadXSLT())
            {
                throw new Exception("No se cargó el XSLT de retenciones...");
            }
            retencion.noCertificadoEmi = CERNUM;
            secciones = retencion.secciones;
            generarNamespacesAdicionales();
            var documentoXML = XML(secciones);

            object oJSON = JSON();
            try
            {
                retencion.cadenaOriginal = generarCadenaOriginal(documentoXML, xsltRET);
                if (generarSello()) { documentoXML = XML(secciones); }
                documentoXML = EnviarATimbrado(documentoXML, oJSON);
                if (documentoXML != null)
                {
                    Log("XML() => " + "Cuando se envia a timbrado documentoXML != null");
                    asignarValoresTimbrado(documentoXML);
                    Log("XML() => " + "Se asignaron valores de timbrado");
                    fin = DateTime.Now;
                }
                else
                {
                    Log("XML() => " + "Cuando se envia a timbrado documentoXML == null");
                }
            }
            catch (Exception ex)
            {
                Log("XML() => " + ex.ToString());
                documentoXML = null;
            }
            return documentoXML;
        }

        private void asignarValoresTimbrado(XmlDocument estado)
        {
            try
            {
                XmlElement root = estado.DocumentElement;
                string selloEmi = root.Attributes["Sello"].Value;
                string certificadoEmi = root.Attributes["Cert"].Value;
                retencion.selloEmi = selloEmi;
                retencion.certificadoEmi = certificadoEmi;

                var TimbreFiscalDigital = estado.GetElementsByTagName("tfd:TimbreFiscalDigital");
                foreach (XmlElement nodoTimbrado in TimbreFiscalDigital)
                {
                    retencion.xsi_schemaLocation_cfdi = nodoTimbrado.GetAttribute("xsi:schemaLocation");
                    retencion.version_tim = nodoTimbrado.GetAttribute("version").Replace("\n", " ");
                    retencion.UUID = nodoTimbrado.GetAttribute("UUID").Replace("\n", " ");
                    retencion.fechaTimbrado = nodoTimbrado.GetAttribute("FechaTimbrado").Replace("\n", " ");
                    retencion.selloCFD = nodoTimbrado.GetAttribute("selloCFD").Replace("\n", " ");
                    retencion.noCertificadoSAT = nodoTimbrado.GetAttribute("noCertificadoSAT").Replace("\n", " ");
                    retencion.selloSAT = nodoTimbrado.GetAttribute("selloSAT").Replace("\n", " ");
                    retencion.xmlns_tfd_cfdi = nodoTimbrado.GetAttribute("xmlns:tfd").Replace("\n", " ");
                }
            }
            catch (Exception exNodo1)
            {
                // // mensajeColor("TI001, " + "NODO1 " + exNodo1);
                Log("XML() => exNodo1: " + exNodo1.ToString());
            }
            try
            {
                var Comprobante = estado.GetElementsByTagName("cfdi:Comprobante");

                foreach (XmlElement nodoTimbrado in Comprobante)
                {
                    retencion.xmlns_xsi_cfdi = nodoTimbrado.GetAttribute("xmlns:xsi").Replace("\n", " ");
                }
                retencion.CadenaCodigo = "?re=" + retencion.RFCEmisor + "&rr=" + retencion.RFCRecep + "&tt=" + retencion.montoTotGrav + "&id=" + retencion.UUID;
            }
            catch (Exception exNodo2)
            {
                // // mensajeColor("TI001, " + "NODO2 " + exNodo2);
                Log("XML() => exNodo2: " + exNodo2.ToString());
            }
            try
            {
                codigoQR = new GeneraQR(retencion.CadenaCodigo);
                codigoQR.createCodigoQR();
                retencion.codigoQR = codigoQR.getImgCodigo();
            }
            catch (Exception exQR)
            {
                // // mensajeColor("TI001, " + "QR " + exQR);
                Log("XML() => exQR: " + exQR.ToString());
            }
            try
            {
                retencion.cadenaCFDI = "||" + retencion.version_tim + "|" + retencion.UUID + "|" + retencion.fechaTimbrado + "|" + retencion.selloCFD + "|" + retencion.noCertificadoSAT + "||";
                retencion.edoFac = "1";
            }
            catch (Exception exUlt)
            {
                // // mensajeColor("TI001, " + "Ultimo " + exUlt);
                Log("XML() => exUlt: " + exUlt.ToString());
            }
        }

        private KeyValuePair<string, List<KeyValuePair<string, string>>> buscarSeccion(string nodo)
        {
            KeyValuePair<string, List<KeyValuePair<string, string>>> _item = new KeyValuePair<string, List<KeyValuePair<string, string>>>();
            foreach (var item in secciones)
            {
                if (item.Key.Equals(nodo))
                {
                    _item = item;
                    break;
                }
            }
            return _item;
        }

        private XmlDocument EnviarATimbrado(XmlDocument xmlTimbrar, object json = null)
        {
            XmlDocument estado = null;
            SAT.Timbrado timbre = new SAT.Timbrado(DB, retencion.serie, retencion.RFCEmisor, retencion.RFCRecep);
            inicio = DateTime.Now;
            ComprobanteTimbrado ret = null;
            ret = timbre.Timbrar(CERRUT, PRVRUT, CLAVE, CERNUM, xmlTimbrar, ambiente, "retencion"); //EDOTIMBRADO.Equals("PRODUCCION", StringComparison.OrdinalIgnoreCase), "retencion"
            if (ret == null && json != null)
            {
                ret = timbre.Timbrar(CERRUT, PRVRUT, CLAVE, CERNUM, json, ambiente, "retencion"); //EDOTIMBRADO.Equals("PRODUCCION", StringComparison.OrdinalIgnoreCase), "retencion"
            }
            if (ret != null)
            {
                estado = ret.XmlTimbrado;
            }
            else
            {
                fin = DateTime.Now;
                MensajeError = timbre.LastError;
            }
            return estado;
        }

        private bool existeSeccion(string nodo)
        {
            foreach (var item in secciones)
            {
                if (item.Key.Equals(nodo))
                {
                    return true;
                }
            }
            return false;
        }

        private string generarCadenaOriginal(XmlDocument xtr, XslCompiledTransform xslt)
        {
            string CO;
            try
            {
                var ms = new MemoryStream();
                xslt.Transform(xtr, null, ms);
                ms.Position = 0;
                var sr = new StreamReader(ms, Encoding.UTF8);
                CO = sr.ReadToEnd();
                var utf8Bytes = Encoding.UTF8.GetBytes(CO);
                CO = Encoding.UTF8.GetString(utf8Bytes);
                return CO;
            }
            catch (Exception e)
            {
                // // mensajeColor("EM004, " + e.Message);
                //System.Diagnostics.// // mensajeColor("EM004", "", e.Message, "");
                return null;
            }
        }

        private void generarNamespacesAdicionales()
        {
            List<KeyValuePair<string, string>> datos_tmp;
            for (var i = 0; i < secciones.Count; i++)
            {
                var pair = secciones.ElementAt(i);
                datos_tmp = new List<KeyValuePair<string, string>>();
                switch (pair.Key)
                {
                    case "Retenciones":
                        KeyValuePair<string, string> folio = new KeyValuePair<string, string>("FolioInt", retencion.FolioInt);
                        pair.Value.Remove(folio);
                        datos_tmp.Add(new KeyValuePair<string, string>("Version", "1.0"));
                        if (!string.IsNullOrEmpty(retencion.FolioInt)) { datos_tmp.Add(folio); }
                        datos_tmp.Add(new KeyValuePair<string, string>("Sello", retencion.selloEmi));
                        datos_tmp.Add(new KeyValuePair<string, string>("NumCert", retencion.noCertificadoEmi));
                        datos_tmp.Add(new KeyValuePair<string, string>("Cert", retencion.certificadoEmi));
                        datos_tmp.AddRange(pair.Value);
                        datos_tmp.Add(new KeyValuePair<string, string>("xmlns:retenciones",
                            "http://www.sat.gob.mx/esquemas/retencionpago/1"));
                        datos_tmp.Add(new KeyValuePair<string, string>("xmlns:xsi",
                            "http://www.w3.org/2001/XMLSchema-instance"));
                        datos_tmp.Add(new KeyValuePair<string, string>("xsi:schemaLocation",
                            "http://www.sat.gob.mx/esquemas/retencionpago/1 http://www.sat.gob.mx/esquemas/retencionpago/1/retencionpagov1.xsd" + (retencion.isPagoExtranjero ? " http://www.sat.gob.mx/esquemas/retencionpago/1/pagosaextranjeros http://www.sat.gob.mx/esquemas/retencionpago/1/pagosaextranjeros/pagosaextranjeros.xsd" : "") + (retencion.isDividendos ? " http://www.sat.gob.mx/esquemas/retencionpago/1/dividendos http://www.sat.gob.mx/esquemas/retencionpago/1/dividendos/dividendos.xsd" : "")));
                        if (retencion.isPagoExtranjero)
                        {
                            datos_tmp.Add(new KeyValuePair<string, string>("xmlns:pagosaextranjeros",
                            "http://www.sat.gob.mx/esquemas/retencionpago/1/pagosaextranjeros"));
                        }
                        if (retencion.isDividendos)
                        {
                            datos_tmp.Add(new KeyValuePair<string, string>("xmlns:dividendos", "http://www.sat.gob.mx/esquemas/retencionpago/1/dividendos"));
                        }
                        secciones[secciones.IndexOf(buscarSeccion(pair.Key))] =
                            new KeyValuePair<string, List<KeyValuePair<string, string>>>(pair.Key, datos_tmp);
                        break;
                    case "Complemento|Dividendos":
                        datos_tmp.Add(new KeyValuePair<string, string>("Version", "1.0"));
                        datos_tmp.AddRange(pair.Value);
                        secciones[secciones.IndexOf(buscarSeccion(pair.Key))] =
                            new KeyValuePair<string, List<KeyValuePair<string, string>>>(pair.Key, datos_tmp);
                        break;
                    case "Complemento|Pagosaextranjeros":
                        datos_tmp.Add(new KeyValuePair<string, string>("Version", "1.0"));
                        datos_tmp.AddRange(pair.Value);
                        secciones[secciones.IndexOf(buscarSeccion(pair.Key))] =
                            new KeyValuePair<string, List<KeyValuePair<string, string>>>(pair.Key, datos_tmp);
                        break;
                }
            }
        }

        private bool generarSello()
        {
            var Sello = new SAT.Sellado();
            try
            {
                var indexext = 0;
                var index = 0;
                /* =========== COLOCAR BREACKPOINT AQUI =========== */
                string certificado;
                string noCertificado;
                Sello.CertificateData(CERRUT, out certificado, out noCertificado);
                retencion.selloEmi = Sello.SignString(PRVRUT, CLAVE, retencion.cadenaOriginal);
                retencion.certificadoEmi = certificado;
                retencion.noCertificadoEmi = noCertificado;
                var retenciones = buscarSeccion("Retenciones");
                indexext = secciones.IndexOf(retenciones);
                index = retenciones.Value.IndexOf(new KeyValuePair<string, string>("Sello", ""));
                retenciones.Value[index] = new KeyValuePair<string, string>("Sello", retencion.selloEmi);
                index = retenciones.Value.IndexOf(new KeyValuePair<string, string>("Cert", ""));
                retenciones.Value[index] = new KeyValuePair<string, string>("Cert", retencion.certificadoEmi);
                //    index = retenciones.Value.IndexOf(new KeyValuePair<string, string>("NumCert", ""));
                //   retenciones.Value[index] = new KeyValuePair<string, string>("NumCert", retencion.noCertificadoEmi);
                secciones[indexext] = retenciones;
                return true;
            }
            catch (Exception e)
            {
                // // mensajeColor("EM005, " + e.Message + Sello.strMsg);
                //System.Diagnostics.// // mensajeColor("EM005", "", e.Message + Sello.strMsg, "");
                return false;
            }
        }

        private object JSON()
        {
            object nodoEmisor;
            object receptorNacional;
            if (!string.IsNullOrEmpty(retencion.CURPE))
            {
                nodoEmisor = new
                {
                    rfc = retencion.RFCEmisor,
                    nombre = retencion.NomDenRazSocE,
                    curp = retencion.CURPE
                };
            }
            else
            {
                nodoEmisor = new
                {
                    rfc = retencion.RFCEmisor,
                    nombre = retencion.NomDenRazSocE
                };
            }
            if (!string.IsNullOrEmpty(retencion.CURPR))
            {
                receptorNacional = new
                {
                    objectType = "RetencionesReceptorNacional",
                    rfc = retencion.RFCRecep,
                    nombre = retencion.NomDenRazSocR,
                    curp = retencion.CURPR
                };
            }
            else
            {
                receptorNacional = new
                {
                    objectType = "RetencionesReceptorNacional",
                    rfc = retencion.RFCRecep,
                    nombre = retencion.NomDenRazSocR
                };
            }
            object receptorExtranjero = new
            {
                objectType = "RetencionesReceptorExtranjero",
                numeroRegistroFiscal = retencion.NumRegIdTrib,
                nombre = retencion.NomDenRazSocR
            };
            bool esNacional = retencion.Nacionalidad.Equals("Nacional", StringComparison.OrdinalIgnoreCase);
            object nodoReceptor = new
            {
                nacionalidad = retencion.Nacionalidad,
                item = esNacional ? receptorNacional : receptorExtranjero
            };
            object nodoPeriodo = new
            {
                mesIni = retencion.MesIni,
                mesFin = retencion.MesFin,
                ejerc = retencion.Ejerc
            };
            List<object> impuestosRetenidos = new List<object>();
            foreach (ImpuestosRetenidos impuesto in retencion.ImpRetenidos)
            {
                bool baseRet = !string.IsNullOrEmpty(impuesto.BaseRet);
                object oImpuesto;
                if (baseRet)
                {
                    oImpuesto = new
                    {
                        tipoPagoRet = impuesto.TipoPagoRet,
                        baseRetSpecified = baseRet.ToString().ToLower(),
                        baseRet = impuesto.BaseRet,
                        impuestoSpecified = "true",
                        impuesto = impuesto.Impuesto,
                        montoRet = impuesto.montoRet
                    };
                }
                else
                {
                    oImpuesto = new
                    {
                        tipoPagoRet = impuesto.TipoPagoRet,
                        baseRetSpecified = baseRet.ToString().ToLower(),
                        impuestoSpecified = "true",
                        impuesto = impuesto.Impuesto,
                        montoRet = impuesto.montoRet
                    };
                }
                impuestosRetenidos.Add(oImpuesto);
            }
            object nodoTotales = new
            {
                montoTotOperacion = retencion.montoTotOperacion,
                montoTotGrav = retencion.montoTotGrav,
                montoTotExent = retencion.montoTotExent,
                montoTotRet = retencion.montoTotRet,
                impRetenidos = impuestosRetenidos.ToArray()
            };
            object nodoNoBeneficiario = new
            {
                paisDeResidParaEfecFisc = retencion.PaisDeResidParaEfecFisc,
                conceptoPago = retencion.ConceptoPago,
                descripcionConcepto = retencion.DescripcionConcepto
            };
            object nodoBeneficiario = new
            {
                rfc = retencion.RFC,
                curp = retencion.CURP,
                nombre = retencion.NomDenRazSocB,
                conceptoPago = retencion.ConceptoPago,
                descripcionConcepto = retencion.DescripcionConcepto,
            };
            object nodoPagosaextranjeros = new
            {
                objectType = "Pagosaextranjeros",
                version = "1.0",
                noBeneficiario = (existeSeccion("Complemento|Pagosaextranjeros|NoBeneficiario")) ? nodoNoBeneficiario : "",
                beneficiario = (existeSeccion("Complemento|Pagosaextranjeros|Beneficiario")) ? nodoBeneficiario : "",
                esBenefEfectDelCobro = retencion.EsBenefEfectDelCobro
            };
            object nododividOUtil = new
            {
                cveTipDivOUtil = retencion.CveTipDivOUtil,
                montISRAcredRetMexico = retencion.MontISRAcredRetMexico,
                montISRAcredRetExtranjero = retencion.MontISRAcredRetExtranjero,
                montRetExtDivExtSpecified = !string.IsNullOrEmpty(retencion.MontRetExtDivExt),
                montRetExtDivExt = retencion.MontRetExtDivExt,
                tipoSocDistrDiv = retencion.TipoSocDistrDiv,
                montISRAcredNalSpecified = !string.IsNullOrEmpty(retencion.MontISRAcredNal),
                montISRAcredNal = retencion.MontISRAcredNal,
                montDivAcumNalSpecified = !string.IsNullOrEmpty(retencion.MontDivAcumNal),
                montDivAcumNal = retencion.MontDivAcumNal,
                montDivAcumExtSpecified = !string.IsNullOrEmpty(retencion.MontDivAcumExt),
                montDivAcumExt = retencion.MontDivAcumExt
            };
            object nodoremanente = new
            {
                proporcionRemSpecified = !string.IsNullOrEmpty(retencion.ProporcionRem),
                proporcionRem = retencion.ProporcionRem
            };
            object nodoDividendos = new
            {
                objectType = "Dividendos",
                version = "1.0",
                dividOUtil = (existeSeccion("Complemento|Dividendos|DividOUtil")) ? nododividOUtil : "",
                remanente = (existeSeccion("Complemento|Dividendos|Remanente")) ? nodoremanente : ""
            };
            List<object> complementos = new List<object>();
            if (retencion.isPagoExtranjero)
            {
                complementos.Add(nodoPagosaextranjeros);
            }
            if (retencion.isDividendos)
            {
                complementos.Add(nodoDividendos);
            }
            object nodoComplemento = new
            {
                items = complementos.ToArray()
            };
            object nodoRetencion;
            if (complementos.Count > 0)
            {
                nodoRetencion = new
                {
                    version = "1.0",
                    folioInt = retencion.FolioInt,
                    numCert = retencion.noCertificadoEmi,
                    fechaExp = retencion.FechaExp,
                    cveRetenc = retencion.CveRetenc,
                    descRetenc = retencion.DescRetenc,
                    emisor = nodoEmisor,
                    receptor = nodoReceptor,
                    periodo = nodoPeriodo,
                    totales = nodoTotales,
                    complemento = nodoComplemento
                };
            }
            else
            {
                nodoRetencion = new
                {
                    version = "1.0",
                    folioInt = retencion.FolioInt,
                    numCert = retencion.noCertificadoEmi,
                    fechaExp = retencion.FechaExp,
                    cveRetenc = retencion.CveRetenc,
                    descRetenc = retencion.DescRetenc,
                    emisor = nodoEmisor,
                    receptor = nodoReceptor,
                    periodo = nodoPeriodo,
                    totales = nodoTotales
                };
            }
            object result = new
            {
                tipo = "JSON",
                retencion = nodoRetencion,
            };
            return result;
        }

        private void ObtenerConf(string RFC)
        {
            try
            {
                DB.Conectar();
                DB.CrearComando("select * from Configuracion where RFC=@rfc");
                DB.AsignarParametroCadena("@rfc", RFC);
                var DR = DB.EjecutarConsulta();
                if (DR.Read())
                {
                    IDECNF = DR[0].ToString();
                    CERRUT = DR[1].ToString();
                    PRVRUT = DR[2].ToString();
                    CLAVE = DR[3].ToString();
                    CERNUM = DR[4].ToString();
                    SERIE = DR[6].ToString();
                    NUMAPROB = DR[7].ToString();
                    ANIOAPROB = DR[8].ToString();
                }
                else
                {
                }
            }
            catch (Exception e)
            {
            }
            finally
            {
                DB.Desconectar();
            }
        }

        private XmlDocument XML(List<KeyValuePair<string, List<KeyValuePair<string, string>>>> secciones)
        {
            XmlDocument documentoXML = null;
            try
            {
                documentoXML = new XmlDocument();
                var existeTagComplementos = false;
                var complementosFinalizados = true;
                var prefijoNodo = "";
                var buffer = new StringWriterWithEncoding(Encoding.UTF8);
                var codigoXML = new XmlTextWriter(buffer);
                codigoXML.Formatting = Formatting.Indented;
                codigoXML.WriteStartDocument();
                KeyValuePair<string, List<KeyValuePair<string, string>>> seccionplus1;
                for (var i = 0; i < secciones.Count; i++)
                {
                    var seccion = secciones.ElementAt(i);
                    seccionplus1 = ((i + 1) < secciones.Count)
                        ? secciones.ElementAt(i + 1)
                        : new KeyValuePair<string, List<KeyValuePair<string, string>>>("", null);
                    if (seccion.Key.StartsWith("Complemento|", StringComparison.OrdinalIgnoreCase) &&
                        !existeTagComplementos)
                    {
                        codigoXML.WriteStartElement("retenciones:Complemento");
                        existeTagComplementos = true;
                        complementosFinalizados = false;
                    }
                    prefijoNodo = seccion.Key.StartsWith("Complemento|Pagosaextranjeros",
                        StringComparison.OrdinalIgnoreCase)
                        ? "pagosaextranjeros"
                        : (seccion.Key.StartsWith("Complemento|Dividendos",
                        StringComparison.OrdinalIgnoreCase)
                        ? "dividendos"
                        : "retenciones");
                    codigoXML.WriteStartElement(prefijoNodo + ":" + seccion.Key.Split('|').Last());
                    if (seccion.Key.Equals("Receptor", StringComparison.OrdinalIgnoreCase))
                    {
                        codigoXML.WriteAttributeString("Nacionalidad", retencion.Nacionalidad);
                        codigoXML.WriteStartElement(prefijoNodo + ":" + retencion.Nacionalidad);
                        seccion.Value.Remove(new KeyValuePair<string, string>("EXT", "EXT"));
                        seccion.Value.Remove(new KeyValuePair<string, string>("Nacionalidad", retencion.Nacionalidad));
                    }
                    foreach (var atributo in seccion.Value)
                    {
                        codigoXML.WriteAttributeString(atributo.Key, atributo.Value);
                    }
                    if (seccion.Key.Equals("ImpRetenidos", StringComparison.OrdinalIgnoreCase) ||
                        (seccion.Key.Equals("Receptor", StringComparison.OrdinalIgnoreCase)))
                    {
                        codigoXML.WriteEndElement();
                    }
                    if (seccion.Key.Equals("Retenciones", StringComparison.OrdinalIgnoreCase) ||
                        seccion.Key.Equals("Totales", StringComparison.OrdinalIgnoreCase) ||
                        seccionplus1.Key.Equals("ImpRetenidos") ||
                        seccion.Key.Equals("Complemento|Pagosaextranjeros", StringComparison.OrdinalIgnoreCase) ||
                        seccion.Key.Equals("Complemento|Dividendos", StringComparison.OrdinalIgnoreCase))
                    {
                        //El TAG permanece abierto
                    }
                    else
                    {
                        codigoXML.WriteEndElement();
                    }
                }
                if (existeTagComplementos && !complementosFinalizados)
                {
                    codigoXML.WriteEndElement();
                }
                codigoXML.WriteEndDocument();
                documentoXML.InnerXml = buffer.ToString();
            }
            catch (Exception ex)
            {
            }
            return documentoXML;
        }
    }
}
