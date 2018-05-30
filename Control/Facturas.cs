using Control.ConsultaCFDIService;
using Datos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;
using ValSign;



namespace Control
{
    public class Facturas
    {
        #region VARIABLES GLOBAL
        ValidacionCert VC = new ValidacionCert();
        ValidacionFolios VF = new ValidacionFolios();
        ValidacionEstructura VE = new ValidacionEstructura();
        BasesDatos DB = new BasesDatos();
        int auxContCer = 0;
        bool ban = false;
        string[] rutaFAC;
        string rutaBCK;
        string rutaDOC;
        string rutaORG;
        string nombre;
        string extension;
        string nombreSE;
        string IDPROVEMI = "";
        string servidor = "mail.dataexpress.com.mx";
        Int32 puerto = 587;
        Boolean ssl = false;
        string emailCredencial = "soporte@dataexpress.com.mx";
        string passCredencial = "123456";

        private string nameXMLp = "";
        private string namePDFp = "";
        private string extensionXMLp = "";
        private string extensionPDFp = "";
        private string nameFINALxml = "";
        private string nameFINALpdf = "";
        private bool ValidarXML1 = false;
        private bool ValidarXML2 = false;
        private bool ValidarXML3 = false;
        private bool ValidarXML4 = false;
        private bool ValidarXML5 = false;
        private bool ValidarXML6 = false;
        private bool ValidarXML7 = false;
        private bool ValidarXML_ctaPredial = false;
        private string archivo_log = AppDomain.CurrentDomain.BaseDirectory + "logErrorNEW\\Error DHL " + DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss").Replace("T", "_").Replace("-", "_").Substring(0, 10) + ".txt";
        private string archivo_logXSD = AppDomain.CurrentDomain.BaseDirectory + "logErrorNEW\\ErrorREADXML.txt";
        private string archivo_logCOM = AppDomain.CurrentDomain.BaseDirectory + "logErrorNEW\\ErrorCOM.txt";
        private string _metodoActual = "";
        private string MPaymentBD = "";
        string tMPaymentBD = "";

        string emailEnviar;
        string emailNoti;
        EnviarMail em;
        public String emails;
        string emailsReceptor = "";
        String asunto;
        string mensaje;
        string cadRes = "";
        string IDEREC;
        string IDEEMI;
        public string IDEFAC;
        string IDEDOMEMIEXP;
        public string TIPOORDEN;
        #region VARIABLES CFDI XML
        //comprobante
        string xmlns, xmlns_xsi, xmlns_xsd, xsi_schemaLocation, folio, fecha2;
        string version;
        string serie;
        public string sello;
        string noAprobacion;
        string anoAprobacion;
        string codContable;
        string moneda;
        string NumSabana;
        string siteOri;
        string correosFin;
        string nomFin;
        private string RefBancaria;
        string formaDePago, subTotal, total, tipoDeComprobante, LugarExpedicion;
        string descuento, Moneda, NumCtaPago, TipoCambio, condicionesDePago, MotivoDescuento;
        string noCertificado;
        string certificado;
        private string confirmacion;
        private string CFDIrelacion;
        private string UUIDrelacion;
        //Emisor
        string rfcEmisor, nombreEmisor;
        string calleEmisor, noExteriorEmisor, noInteriorEmisor, coloniaEmisor, municipioEmisor, estadoEmisor, paisEmisor, codigoPostalEmisor;
        string localidadEmisor, referenciaEmisor;
        string calleEmisorExp, noExteriorEmisorExp, noInteriorEmisorExp, coloniaEmisorExp, municipioEmisorExp, estadoEmisorExp, paisEmisorExp, codigoPostalEmisorExp;
        string localidadEmisorExp, referenciaEmisorExp;
        //Receptor
        string rfcReceptor, nombreReceptor;
        string calleReceptor, noExteriorReceptor, noInteriorReceptor, coloniaReceptor, municipioReceptor, estadoReceptor, paisReceptor, codigoPostalReceptor;
        string localidadReceptor, referenciaReceptor;
        private string ResidenciaFiscal;
        private string NumRegIdTrib;
        private string UsoCFDI;
        //Conceptos
        string cantidad, unidad, noIdentificacion, descripcion, valorUnitario, importe;
        private string ClaveProdServ;
        private string ClaveUnidad;
        private string Descuento;
        //Impuestos
        string impuesto, tasa, importeImpuesto;
        string totalImpuestosTrasladados, totalImpuestosRetenidos;
        private string TipoFactor;
        //Informacion aduanera
        string numero, fechaAduana, aduana;
        private string NumeroPedimento;
        //Cuenta predial 
        string numeroCuentaPredial;
        //Campos Version 2.2
        string Regimen, metodoDePago;
        //Campos Aux Conceptos
        string[] arrayConceptos;
        ArrayList arrayListConceptos;
        //Campos Aduana
        string[] arrayAduana;
        ArrayList arrayListAduana;
        //Campos Aux Impuestos
        string[] arrayImpuestosT, arrayImpuestosR;
        ArrayList arrayListImpuestosT, arrayListImpuestosR;
        private ArrayList arrayListImpuestosTC;
        private ArrayList arrayListImpuestosRC;
        private string[] arrayComPago;
        private ArrayList arrayListComPago;
        #endregion

        int timFact;
        #region COMPLEMENT PAYMENT
        private string rfcEmisorP;
        private string rfcReceptorP;
        private string versionP10;
        private string FechaPagoP;
        private string FormaDePagoP;
        private string MonedaP;
        private string TipoCambioP;
        private string MontoP;
        private string NumOperacionP;
        private string RfcEmisorCtaOrdP;
        private string NomBancoOrdExtP;
        private string CtaOrdenanteP;
        private string RfcEmisorCtaBenP;
        private string CtaBeneficiarioP;
        private string TipoCadPagoP;
        private string CertPagoP;
        private string CadPagoP;
        private string SelloPagoP;
        private string IdDocumentoP;
        private string SerieP;
        private string FolioP;
        private string MonedaDRP;
        private string TipoCambioDRP;
        private string MetodoDePagoDRP;
        private string NumParcialidadP;
        private string ImpSaldoAntP;
        private string ImpPagadoP;
        private string ImpSaldoInsolutoP;
        private string versionP;
        private string UUIDP;
        private string FechaTimbradoP;
        private string selloCFDP;
        private string noCertificadoSATP;
        private string selloSATP;
        private string schemaLocationP;
        private string tfdP;
        private string VregFiscal;
        private string VusoCFDI;
        private string Vimpuestos;
        private string VtipoFactor;
        private string VtasaCuota;
        private string menCFDI33;
        #endregion


        List<string> DetGen;
        List<string> DetPago;
        List<string> DetBanco;
        List<List<string>> General;
        List<List<string>> txtPago;
        List<List<string>> Bancos;
        List<string> gPago;
        List<string> gBanco;


        string xsi_schemaLocation_cfdi;
        string version_tim;
        string UUID;
        string FechTimbrado;
        string selloCFD;
        string noCertificadoSAT;
        string selloSAT;
        string xmlns_xsi_cfdi, xmlns_tfd_cfdi;
        string cadenaCFDI;
        string certificadoSAT;
        decimal totalMas;
        decimal totalCFE_Fin;
        String banXc = "";
        string resSello = "";
        string resExistCer = "";
        string resFolser = "";
        string resultadoVal = "";
        string resCO = "";
        string estadoValfs = "";
        Boolean valida_numNegativos = true;
        Boolean validacion_importe = true;
        Boolean validacion_formaDePago = true;
        Boolean validacion_metodoDePago = true;
        Boolean validacion_numDeCta = true;
        Boolean validacion_numDeCtaTieneNum = false;
        Boolean valida_IVA = false;
        Boolean valida_domicilioReceptor = false;
        Boolean validaDomReceptor = false;
        Boolean valida_fleteDesc = false;
        Boolean valida_Desc_motDes = false;
        Boolean val_totalT = true;
        Boolean val_totalR = true;
        Boolean sesionAdmin = false;
        Boolean valida_moneda = false;
        Boolean continuar = false;
        Boolean val_FaD_d_Re = false;
        Boolean val_FaD_d_Total = false;
        Boolean banCFDI;
        Boolean MENSAJE_ISR = false;


        Double totalRetenciones = 0;
        Double totalTraslados = 0;
        Decimal sumaT = 0;
        public string CO;
        Validacion Val;
        string fecharec;
        string impISR2;



        string mensenger = "";

        private List<string> _xsdList;
        public string getVersion() { return version; }
        public string getSerie() { return serie; }
        public string getSello() { return sello; }
        public string getNoAprobacion() { return noAprobacion; }
        public string getAnoAprobacion() { return anoAprobacion; }
        public string getNoCertificado() { return noCertificado; }
        public string getCertificado() { return certificado; }
        public void setCertificado(string cert) { certificado = cert; }
        public void getCadCont(string ccon) { codContable = ccon.ToUpper(); }
        public void getSesionAdm(Boolean sesionAdm) { sesionAdmin = sesionAdm; }
        public void getMon(string tmon) { Moneda = tmon; }
        public void getTimFac(string tm) { timFact = Convert.ToInt32(tm); }
        public string msj { get; set; }
        public string msjT { get; set; }
        public void getUsuarioFac(string usFac) { usuarioFac = usFac; }
        public void getTipoProveedor(string tProv) { TipoProveedor = tProv; }
        public void getPropi(double pr) { propinas = pr; }
        public void getParentInv(string PI) { pInvoice = PI; }
        public void getLAdi(string ad) { LisAdi.Add(ad); }
        public void getNomOrden(string ord) { ordenCompra = ord; }
        public void getSabana(string sb) { NumSabana = sb; }
        public void getSiteOr(string st) { siteOri = st; }
        public void getFinancieros(string corr, string noms) { correosFin = corr; nomFin = noms; }
        public string getmsgEstructura() { return msgEstructura; }
        public string getRFCEMISOR() { return rfcEmisor; }
        public string getFolio() { return folio; }
        public string getestadovalf() { return estadoValfs; }
        public string getmsgarrayLog() { return msgarrayLog; }
        public string getFechaRec() { return fecharec; }
        public void getRefBancaria(string RefB) { this.RefBancaria = RefB; }
        public string getCO() { return CO; }
        public string getSelloSAT() { return selloSAT; }
        public string getCadenaCFDI() { return cadenaCFDI; }
        //Variables para guardar respuesta de las validaciones
        string msgarrayLog = "";
        string msgEstructura = "";
        string msgCadenaOriginal = "";
        string msgCertidicado = "";
        string msgVesiondoc = "";
        Boolean banValCadena = false;
        Boolean banexistenciaCer = false;
        Boolean banstatusCer = false;
        Boolean banfolser = false;
        Boolean banRangofol = false;
        Boolean banNoAprob = false;
        Boolean banValRetencion = false;
        public Boolean getbanValCadena() { return banValCadena; }
        public Boolean getbanexistenciaCer() { return banexistenciaCer; }
        //public Boolean getbanstatusCer() { return banstatusCer; }
        public Boolean getbanfolser() { return banfolser; }
        //public Boolean getbanRangofol() { return banRangofol; }
        //public Boolean getbanNoAprob() { return banNoAprob; }
        public Boolean getbanValRetencion() { return banValRetencion; }
        public Boolean getbanCFDI() { return banCFDI; }
        public Boolean getbanVigCer() { return banstatusCer; }


        bool BanBD = false;
        int id_usuario = 0;
        string usuarioFac = "";
        string TipoProveedor = "";
        double propinas = 0.0;
        string pInvoice = "";
        string ordenCompra = "";
        string[] eval;
        string nomTemp;
        ArrayList LisAdi = new ArrayList();
        #endregion

        bool impuestosRetLocal = false;
        bool impuestosTrasLocal = false;
        private string IMPSALDOANTDR = "";
        private string IMPPAGADODR = "";
        private string IMPSALDOINSOLUTODR = "";
        string filesPagos = "";
        string banDate = ConfigurationManager.AppSettings.Get("banDate");

        bool GeneralComple = false;
        bool TxtComple = false;
        bool BancosComple = false;
        bool bantotal = true;
        bool banMoneda = true;
        bool banParcialidades = true;
        bool banUUID = true;
        bool banSumaTotal = false;
        bool banUUIDexistBD = false;

        bool banNumOPI = false;
        bool banFechaI = true;
        bool banMonedaI = true;
        bool banMontoI = true;
        bool banRFCordenanteI = true;
        bool banCtaOrdenanteI = true;
        bool banRFCbenefI = true;
        bool banCtaBenefI = true;

        bool banNumOPB = false;
        bool banFechaB = true;
        bool banMonedaB = true;
        bool banMontoB = true;
        bool banRFCordenanteB = true;
        bool banCtaOrdenanteB = true;
        bool banRFCbenefB = true;
        bool banCtaBenefB = true;

        bool banImpuestosLocales = false;

        public Facturas(String[] fac, string bck, string doc, string origen, string mail, string id_usuario)
        {
            rutaFAC = fac;
            rutaBCK = bck;
            rutaDOC = doc;
            rutaORG = origen;
            emails = mail;
            try
            {
                this.id_usuario = Convert.ToInt16(id_usuario);
            }
            catch (Exception ex)
            {

            }
            DB.Conectar();
            DB.CrearComando("select servidorSMTP,puertoSMTP,sslSMTP,userSMTP,passSMTP,dirdocs,emailEnvio,emailNotificacion from ParametrosSistema");
            DbDataReader DR1 = DB.EjecutarConsulta();

            while (DR1.Read())
            {
                servidor = DR1[0].ToString();
                puerto = Convert.ToInt32(DR1[1].ToString());
                ssl = Convert.ToBoolean(DR1[2].ToString());
                emailCredencial = DR1[3].ToString();
                passCredencial = DR1[4].ToString();
                rutaDOC = DR1[5].ToString();
                emailEnviar = DR1[6].ToString();
                emailNoti = DR1[7].ToString();
            }
            DB.Desconectar();
        }

        private String consultarIDEFACT(string valor1, string valor2, string valor3, string campo1, string campo2, string campo3, string consulta)
        {

            String ide;
            DB.Conectar();
            DB.CrearComando(consulta + " " + campo1 + "=@a and " + campo2 + "=@b and " + campo3 + "=@c  and idFactura=(SELECT  MAX(idFactura) FROM GENERAL where folio=@a and serie=@b and noCertificado=@c )");
            DB.AsignarParametroCadena("@a", valor1);
            DB.AsignarParametroCadena("@b", valor2);
            DB.AsignarParametroCadena("@c", valor3);

            DB.AsignarParametroCadena("@a", valor1);
            DB.AsignarParametroCadena("@b", valor2);
            DB.AsignarParametroCadena("@c", valor3);

            DbDataReader DR = DB.EjecutarConsulta();

            while (DR.Read())
            {
                ide = DR[0].ToString();
                DB.Desconectar();
                return ide;
            }
            DB.Desconectar();
            return null;


        }

        public void leer()
        {
            foreach (string file in rutaFAC)
            {
                FileInfo InfoFile = new FileInfo(file);
                XmlDocument xDoc = new XmlDocument();
                nombre = InfoFile.Name;
                extension = InfoFile.Extension;
                nombreSE = nombre.Replace(extension, "");
                nomTemp = InfoFile.DirectoryName + @"\";
                if ((System.IO.File.Exists(file.Replace(extension, ".PDF")) || System.IO.File.Exists(file.Replace(extension, ".pdf"))) &&
                    (System.IO.File.Exists(file.Replace(extension, ".XML")) || System.IO.File.Exists(file.Replace(extension, ".xml"))))
                {
                    if (extension.Equals(".xml") || extension.Equals(".XML"))
                    {
                        leerXML(file);
                    }
                }
                else
                {
                    System.IO.File.Delete(file);
                    mensajeEmailAdjuntar("ES002", "", emails);
                    mensajesLog("ES002", msj, "", emails, "");
                }
            }
        }

        public void leerIndividual(string file)
        {
            FileInfo InfoFile = new FileInfo(file);
            XmlDocument xDoc = new XmlDocument();
            nombre = InfoFile.Name;
            extension = InfoFile.Extension;
            nombreSE = nombre.Replace(extension, "");
            nomTemp = InfoFile.DirectoryName + @"\";
            leerXML(file);
        }

        private void leerXML(string file)
        {
            #region READ XML VARIABLE
            XmlDocument xtr = new XmlDocument();
            XmlTextReader xtrReader = null;
            asunto = "";
            mensaje = "";
            Val = new Validacion();
            //comprobante
            xmlns = ""; xmlns_xsi = ""; xmlns_xsd = ""; xsi_schemaLocation = ""; version = ""; serie = "";
            folio = ""; fecha2 = ""; sello = ""; noAprobacion = ""; anoAprobacion = "";
            formaDePago = ""; noCertificado = ""; certificado = ""; subTotal = ""; total = ""; tipoDeComprobante = ""; LugarExpedicion = "";
            descuento = ""; MotivoDescuento = ""; NumCtaPago = ""; TipoCambio = ""; condicionesDePago = "";
            this.confirmacion = "";
            this.CFDIrelacion = "";
            this.UUIDrelacion = "";
            //Emisor
            rfcEmisor = ""; nombreEmisor = "";
            calleEmisor = ""; noExteriorEmisor = ""; noInteriorEmisor = ""; coloniaEmisor = ""; municipioEmisor = "";
            estadoEmisor = ""; paisEmisor = ""; codigoPostalEmisor = "";
            localidadEmisor = ""; referenciaEmisor = "";
            calleEmisorExp = ""; noExteriorEmisorExp = ""; noInteriorEmisorExp = ""; coloniaEmisorExp = "";
            municipioEmisorExp = ""; estadoEmisorExp = ""; paisEmisorExp = ""; codigoPostalEmisorExp = "";
            localidadEmisorExp = ""; referenciaEmisorExp = "";
            //Receptor
            rfcReceptor = ""; nombreReceptor = "";
            calleReceptor = ""; noExteriorReceptor = ""; noInteriorReceptor = ""; coloniaReceptor = ""; municipioReceptor = "";
            estadoReceptor = ""; paisReceptor = ""; codigoPostalReceptor = "";
            localidadReceptor = ""; referenciaEmisor = "";
            this.ResidenciaFiscal = "";
            this.NumRegIdTrib = "";
            this.UsoCFDI = "";
            CO = "";
            Regimen = ""; metodoDePago = "";
            msj = "";
            msjT = "";

            banCFDI = true;
            xsi_schemaLocation_cfdi = "";
            version_tim = "";
            UUID = "";
            FechTimbrado = "";
            selloCFD = "";
            noCertificadoSAT = "";
            selloSAT = "";
            xmlns_xsi_cfdi = "";
            xmlns_tfd_cfdi = "";
            cadenaCFDI = "";
            certificadoSAT = "";
            FileInfo InfoFile = new FileInfo(file);
            XmlDocument xDoc = new XmlDocument();
            nombre = InfoFile.Name;
            eval = nombre.Split('.');
            nomTemp = file.Replace(nombre, "");
            string cfdi = "cfdi:";
            #endregion
            try
            {

                var tipoPRO = "";
                xDoc.Load(file);

                //Lectura de nodo  --> nodohi --> nodohi2 --> nodohi3
                XmlNodeList existe = null;
                XmlNodeList comprobante = null;
                //comprobante = xDoc.GetElementsByTagName("Comprobante");
                xtrReader = new XmlTextReader(new StringReader(xDoc.OuterXml));
                existe = xDoc.GetElementsByTagName(cfdi + "Comprobante");
                if (existe.Count != 0)
                {
                    cfdi = "cfdi:";
                    comprobante = xDoc.GetElementsByTagName(cfdi + "Comprobante");
                    banCFDI = true;
                }
                else
                {
                    cfdi = "";
                    comprobante = xDoc.GetElementsByTagName("Comprobante");
                    banCFDI = false;
                }
                foreach (XmlElement xmlElement in comprobante)
                    this.version = xmlElement.GetAttribute("Version").Trim();
                if (this.version == "3.3")
                {
                    #region CFDI 33
                    string path = AppDomain.CurrentDomain.BaseDirectory + "logErrorNEW\\ErrorREADXML.txt";
                    try
                    {
                        System.IO.File.Delete(path);
                    }
                    catch
                    {
                    }
                    xtr.Load(file);
                    XmlNodeList xmlNodeList = (XmlNodeList)null;
                    XmlTextReader xmlTextReader2 = new XmlTextReader((TextReader)new StringReader(xtr.OuterXml));
                    string str3;
                    XmlNodeList elementsByTagName2;
                    xtrReader = new XmlTextReader(new StringReader(xDoc.OuterXml));
                    existe = xDoc.GetElementsByTagName(cfdi + "Comprobante");
                    if (existe.Count != 0)
                    {
                        str3 = "cfdi:";
                        comprobante = xtr.GetElementsByTagName(str3 + "Comprobante");
                        this.banCFDI = true;
                    }
                    else
                    {
                        str3 = "";
                        comprobante = xtr.GetElementsByTagName("Comprobante");
                        this.banCFDI = false;
                    }
                    string str4 = "";
                    XPathNavigator navigator = new XPathDocument((XmlReader)xmlTextReader2).CreateNavigator();
                    navigator.MoveToFollowing(XPathNodeType.Element);
                    foreach (string key in (IEnumerable<string>)navigator.GetNamespacesInScope(XmlNamespaceScope.All).Keys)
                        str4 = key;
                    foreach (XmlElement xmlElement1 in comprobante)
                    {
                        #region Comprobante
                        try
                        {
                            this.xmlns = xmlElement1.GetAttribute("xmlns");
                            this.xmlns_xsi = xmlElement1.GetAttribute("xmlns:xsi");
                            this.xmlns_xsd = xmlElement1.GetAttribute("xmlns:xsd");
                            this.xsi_schemaLocation = xmlElement1.GetAttribute("xsi:schemaLocation");
                            this.version = xmlElement1.GetAttribute("Version").Trim();
                            this.serie = xmlElement1.GetAttribute("Serie");
                            this.folio = xmlElement1.GetAttribute("Folio");
                            this.fecha2 = xmlElement1.GetAttribute("Fecha");
                            this.sello = xmlElement1.GetAttribute("Sello");
                            this.formaDePago = xmlElement1.GetAttribute("FormaPago");
                            this.noCertificado = xmlElement1.GetAttribute("NoCertificado");
                            this.certificado = xmlElement1.GetAttribute("Certificado");
                            this.condicionesDePago = xmlElement1.GetAttribute("CondicionesDePago");
                            this.subTotal = xmlElement1.GetAttribute("SubTotal");
                            this.descuento = xmlElement1.GetAttribute("Descuento");
                            this.moneda = xmlElement1.GetAttribute("Moneda");
                            this.TipoCambio = xmlElement1.GetAttribute("TipoCambio");
                            this.total = xmlElement1.GetAttribute("Total");
                            this.tipoDeComprobante = xmlElement1.GetAttribute("TipoDeComprobante");
                            this.metodoDePago = xmlElement1.GetAttribute("MetodoPago");
                            this.LugarExpedicion = xmlElement1.GetAttribute("LugarExpedicion");
                            this.confirmacion = xmlElement1.GetAttribute("Confirmacion");
                        }
                        catch (Exception ex)
                        {
                            this.ValidarXML1 = true;
                            Facturas.anade_linea_archivo(this.archivo_logXSD, "La estructura del Nodo Comprobante es invalida,");
                        }
                        #endregion
                        #region VALIDACIONES  COMPROBANTE
                        if (this.moneda.Contains("M"))
                            this.moneda = "MXN";
                        if (this.moneda == "MXN" || this.moneda == "USD" || this.moneda == "" && this.sesionAdmin || (this.moneda != "MXN" || this.moneda != "USD") && this.sesionAdmin)
                        {
                            this.moneda = this.moneda == "" || this.moneda != "MXN" && this.moneda != "USD" ? this.Moneda : this.moneda;
                            this.valida_moneda = true;
                        }
                        else
                        {
                            this.valida_moneda = false;
                            Facturas.anade_linea_archivo(this.archivo_logXSD, "Formato de moneda invalido" + this.moneda + ",");
                        }
                        XmlAttribute attributeNode1 = xmlElement1.GetAttributeNode("Descuento");
                        XmlAttribute attributeNode2 = xmlElement1.GetAttributeNode("MotivoDescuento");
                        try
                        {
                            if (attributeNode1 == null && attributeNode2 == null || Convert.ToDecimal(this.descuento.Trim()) == Decimal.Zero && attributeNode2 == null)
                                this.valida_Desc_motDes = true;
                        }
                        catch (Exception ex)
                        {
                        }
                        if (Convert.ToDecimal(this.subTotal) < Decimal.Zero || Convert.ToDecimal(this.total) < Decimal.Zero)
                        {
                            this.valida_numNegativos = false;
                            Facturas.anade_linea_archivo(this.archivo_logXSD, "El campo descuento es invalido" + (object)attributeNode1 + ",");
                        }
                        string str5 = this.formaDePago.ToUpper().Replace("Ó", "O");
                        string str6 = this.metodoDePago.ToUpper().Replace("Ó", "O");
                        if (!str5.Contains("EXHIBICION") && !str5.Contains("EXIBICION"))
                            this.validacion_formaDePago = false;
                        this.validacion_metodoDePago = str6.Equals("03") || str6.Equals("17") || (str6.Equals("NA") || str6.Equals("TRANSFERENCIA")) || (str6.Equals("TRANSFERENCIA ELECTRONICA DE FONDOS") || str6.Equals("COMPENSACION")) || str6.Equals("NO IDENTIFICADO");
                        if (this.metodoDePago.ToUpper().Contains("TRANSFERENCIA") || this.metodoDePago.ToUpper().Contains("CHEQUE") || this.metodoDePago.Equals(""))
                            this.validacion_metodoDePago = false;
                        foreach (XmlElement xmlElement2 in xmlElement1.GetElementsByTagName(str3 + "Emisor"))
                            this.rfcEmisor = xmlElement2.GetAttribute("Rfc");
                        foreach (XmlElement xmlElement2 in xmlElement1.GetElementsByTagName(str3 + "Receptor"))
                            this.rfcReceptor = xmlElement2.GetAttribute("Rfc").Trim();
                        this.DB.Conectar();
                        this.DB.CrearComando("select emailsRegla from EmailsReglas  where rfc=@rfcrec and estadoRegla=1");
                        this.DB.AsignarParametroCadena("@rfcrec", this.rfcEmisor);
                        DbDataReader dbDataReader = this.DB.EjecutarConsulta();
                        if (dbDataReader.Read())
                            this.emails = this.emails.Trim(',') + "," + dbDataReader[0].ToString().Trim(',') ?? "";
                        this.DB.Desconectar();
                        #endregion
                    }
                    this.emails = (this.emails.Trim(',') + "," + this.correoProveedor(this.rfcEmisor)).Trim(',');
                    if (this.rfcReceptor == this.validaRFC(this.rfcReceptor))
                    {
                        foreach (XmlElement xmlElement1 in comprobante)
                        {
                            #region CFDi Relacion
                            try
                            {
                                existe = xDoc.GetElementsByTagName(str3 + "CfdiRelacionados");
                                if (existe.Count != 0)
                                {
                                    foreach (XmlElement xmlElement2 in xmlElement1.GetElementsByTagName(str3 + "CfdiRelacionados"))
                                    {
                                        this.CFDIrelacion = xmlElement2.GetAttribute("TipoRelacion");
                                        foreach (XmlElement xmlElement3 in xmlElement2.GetElementsByTagName(str3 + "CfdiRelacionado"))
                                            this.UUIDrelacion = xmlElement3.GetAttribute("UUID");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                this.ValidarXML2 = true;
                                Facturas.anade_linea_archivo(this.archivo_logXSD, "La estructura del Nodo CFDIRelacionados es invalida,");
                            }
                            #endregion
                            #region emisor
                            try
                            {
                                foreach (XmlElement xmlElement2 in xmlElement1.GetElementsByTagName(str3 + "Emisor"))
                                {
                                    this.nombreEmisor = xmlElement2.GetAttribute("Nombre");
                                    this.rfcEmisor = xmlElement2.GetAttribute("Rfc");
                                    this.Regimen = xmlElement2.GetAttribute("RegimenFiscal");
                                }
                            }
                            catch (Exception ex)
                            {
                                this.ValidarXML3 = true;
                                Facturas.anade_linea_archivo(this.archivo_logXSD, "La estructura del Nodo Emisor es invalida,");
                            }
                            #endregion
                            #region RECEPTOR
                            try
                            {
                                foreach (XmlElement xmlElement2 in xmlElement1.GetElementsByTagName(str3 + "Receptor"))
                                {
                                    this.nombreReceptor = xmlElement2.GetAttribute("Nombre");
                                    this.rfcReceptor = xmlElement2.GetAttribute("Rfc");
                                    this.ResidenciaFiscal = xmlElement2.GetAttribute("ResidenciaFiscal");
                                    this.NumRegIdTrib = xmlElement2.GetAttribute("NumRegIdTrib");
                                    this.UsoCFDI = xmlElement2.GetAttribute("UsoCFDI");
                                }
                            }
                            catch (Exception ex)
                            {
                                this.ValidarXML4 = true;
                                Facturas.anade_linea_archivo(this.archivo_logXSD, "La estructura del Nodo Receptor es invalida,");
                            }
                            #endregion
                            #region OBTENER DATOS TIPO PROVEEDOR

                            DB.Conectar();
                            DB.CrearComando("select tipoProveedor from proveedores where rfc=@rfc");
                            DB.AsignarParametroCadena("@rfc", rfcEmisor);
                            DbDataReader DRP = DB.EjecutarConsulta();
                            if (DRP.Read())
                                tipoPRO = DRP[0].ToString();
                            DB.Desconectar();
                            #endregion
                            #region NODO CONCEPTOS
                            try
                            {
                                this.cantidad = "";
                                this.unidad = "";
                                this.noIdentificacion = "";
                                this.descripcion = "";
                                this.valorUnitario = "";
                                this.importe = "";
                                this.ClaveProdServ = "";
                                this.ClaveUnidad = "";
                                this.Descuento = "";
                                this.arrayListConceptos = new ArrayList();
                                #region ARREGLOS DE IMPUESTOS POR CONCEPTO
                                this.arrayListImpuestosRC = new ArrayList();
                                this.arrayListImpuestosTC = new ArrayList();
                                #endregion

                                this.arrayListAduana = new ArrayList();
                                XmlNodeList elementsByTagName3 = ((XmlElement)xmlElement1.GetElementsByTagName(str3 + "Conceptos")[0]).GetElementsByTagName(str3 + "Concepto");
                                int num1 = 0;
                                foreach (XmlElement xmlElement2 in elementsByTagName3)
                                {
                                    this.importe = "";
                                    this.ClaveProdServ = xmlElement2.GetAttribute("ClaveProdServ");
                                    this.noIdentificacion = xmlElement2.GetAttribute("NoIdentificacion");
                                    this.cantidad = xmlElement2.GetAttribute("Cantidad");
                                    this.ClaveUnidad = xmlElement2.GetAttribute("ClaveUnidad");
                                    this.unidad = xmlElement2.GetAttribute("Unidad");
                                    this.descripcion = xmlElement2.GetAttribute("Descripcion");
                                    this.valorUnitario = xmlElement2.GetAttribute("ValorUnitario");
                                    this.importe = xmlElement2.GetAttribute("Importe");
                                    this.Descuento = xmlElement2.GetAttribute("Descuento");
                                    this.arrayConceptos = new string[6];
                                    this.arrayConceptos[0] = this.cantidad;
                                    this.arrayConceptos[1] = this.unidad;
                                    this.arrayConceptos[2] = this.noIdentificacion;
                                    this.arrayConceptos[3] = this.descripcion;
                                    this.arrayConceptos[4] = this.valorUnitario;
                                    this.arrayConceptos[5] = this.importe;
                                    this.sumaT = this.sumaT + Convert.ToDecimal(this.importe);
                                    this.arrayListConceptos.Add((object)this.arrayConceptos);
                                    if (this.descripcion.ToUpper().Contains("FLETE") || this.unidad.ToUpper().Contains("FLETE") || this.descripcion.ToUpper().Contains("TRANSPORTE") || this.unidad.ToUpper().Contains("TRANSPORTE"))
                                        this.valida_fleteDesc = true;
                                    if (this.descripcion.ToUpper() != "FLETE" || this.unidad.ToUpper() != "FLETE" || this.descripcion.ToUpper() != "TRANSPORTE" || this.unidad.ToUpper() != "TRANSPORTE")
                                        this.val_FaD_d_Re = true;
                                    if (Convert.ToDecimal(this.cantidad) < Decimal.Zero || Convert.ToDecimal(this.valorUnitario) < Decimal.Zero || Convert.ToDecimal(this.importe) < Decimal.Zero)
                                    {
                                        string str5 = "";
                                        string str6 = "";
                                        string str7 = "";
                                        if (this.cantidad.Contains("-"))
                                            str5 = this.cantidad;
                                        if (this.valorUnitario.Contains("-"))
                                            str6 = this.valorUnitario;
                                        if (this.importe.Contains("-"))
                                            str7 = this.importe;
                                        this.valida_numNegativos = false;
                                        Facturas.anade_linea_archivo(this.archivo_logXSD, "Hay numeros negativos en los importe de conceptos" + str5 + str6 + str7 + ",");
                                    }
                                    double num2 = Convert.ToDouble(this.cantidad) * Convert.ToDouble(this.valorUnitario);
                                    if (num2 + 0.01 < Convert.ToDouble(this.importe) || num2 - 0.01 > Convert.ToDouble(this.importe))
                                    {
                                        this.validacion_importe = false;
                                        Facturas.anade_linea_archivo(this.archivo_logXSD, "La suma de los conceptos" + this.cantidad + "*" + this.valorUnitario + "no es igual a" + this.importe + ",");
                                    }
                                    #region NODO INFORMACION ADUANERA
                                    this.numero = "";
                                    this.fechaAduana = "";
                                    this.aduana = "";
                                    this.NumeroPedimento = "";
                                    xmlElement2.GetElementsByTagName(str3 + "Concepto");
                                    if ((uint)xmlElement2.GetElementsByTagName(str3 + "InformacionAduanera").Count > 0U)
                                    {
                                        try
                                        {
                                            foreach (XmlElement xmlElement3 in xmlElement2.GetElementsByTagName(str3 + "InformacionAduanera"))
                                            {
                                                this.NumeroPedimento = "";
                                                this.NumeroPedimento = xmlElement3.GetAttribute("NumeroPedimento");
                                                this.arrayAduana = new string[2];
                                                this.arrayAduana[0] = this.NumeroPedimento;
                                                this.arrayListAduana.Add((object)this.arrayAduana);
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            Facturas.anade_linea_archivo(this.archivo_logXSD, "La estructura del Nodo InformacionAduanera es invalida,");
                                        }
                                    }
                                    #endregion
                                    ++num1;
                                    #region NODO CONCEPTOS IMPUESTOS
                                    existe = xmlElement2.GetElementsByTagName(str3 + "Impuestos");
                                    foreach (XmlElement xmlElement3 in xmlElement2.GetElementsByTagName(str3 + "Impuestos"))
                                    {
                                        if (xmlElement3.ParentNode.Name == "cfdi:Concepto")
                                        {
                                            #region NODO CONCEPTOS RETENCIONES
                                            try
                                            {
                                                //       this.arrayListImpuestosRC = new ArrayList();
                                                XmlNodeList elementsByTagName4 = xmlElement3.GetElementsByTagName(str3 + "Retenciones");
                                                if ((uint)xtr.GetElementsByTagName(str3 + "Retencion").Count > 0U)
                                                {
                                                    foreach (XmlElement xmlElement4 in ((XmlElement)elementsByTagName4[0]).GetElementsByTagName(str3 + "Retencion"))
                                                    {
                                                        this.impuesto = "";
                                                        this.tasa = "0.00";
                                                        this.importeImpuesto = "";
                                                        this.TipoFactor = "";
                                                        this.impuesto = xmlElement4.GetAttribute("Impuesto");
                                                        this.TipoFactor = xmlElement4.GetAttribute("TipoFactor");
                                                        this.tasa = xmlElement4.GetAttribute("TasaOCuota");
                                                        this.importeImpuesto = xmlElement4.GetAttribute("Importe");
                                                        this.sumaT = this.sumaT + Convert.ToDecimal(this.importeImpuesto);
                                                        this.totalTraslados = this.totalTraslados + Convert.ToDouble(this.importeImpuesto);
                                                        this.arrayImpuestosR = new string[4];
                                                        if (this.impuesto.Equals("IVA") && (Convert.ToDecimal(this.importeImpuesto) > Decimal.Zero && Convert.ToDecimal(this.tasa) == new Decimal(16) || Convert.ToString(this.tasa) == "0.16" || Convert.ToDecimal(this.importeImpuesto) == Decimal.Zero && Convert.ToDecimal(this.tasa) == Decimal.Zero))
                                                            this.valida_IVA = true;
                                                        this.arrayImpuestosR[0] = this.impuesto;
                                                        this.arrayImpuestosR[1] = this.TipoFactor;
                                                        this.arrayImpuestosR[2] = this.tasa;
                                                        this.arrayImpuestosR[3] = this.importeImpuesto;
                                                        this.arrayListImpuestosRC.Add((object)this.arrayImpuestosR);
                                                    }
                                                    xmlNodeList = (XmlNodeList)null;
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                //   this.ValidarXML5 = true;
                                            }
                                            #endregion
                                            #region NODO CONCEPTOS TRASLADOS
                                            try
                                            {
                                                //            this.arrayListImpuestosTC = new ArrayList();
                                                XmlNodeList elementsByTagName4 = xmlElement2.GetElementsByTagName(str3 + "Traslados");
                                                if ((uint)xtr.GetElementsByTagName(str3 + "Traslados").Count > 0U)
                                                {
                                                    foreach (XmlElement xmlElement4 in ((XmlElement)elementsByTagName4[0]).GetElementsByTagName(str3 + "Traslado"))
                                                    {
                                                        this.impuesto = "";
                                                        this.tasa = "0.00";
                                                        this.importeImpuesto = "";
                                                        this.TipoFactor = "";
                                                        this.impuesto = xmlElement4.GetAttribute("Impuesto");
                                                        this.TipoFactor = xmlElement4.GetAttribute("TipoFactor");
                                                        this.tasa = xmlElement4.GetAttribute("TasaOCuota");
                                                        this.importeImpuesto = xmlElement4.GetAttribute("Importe");
                                                        this.sumaT = this.sumaT + Convert.ToDecimal(this.importeImpuesto);
                                                        this.totalTraslados = this.totalTraslados + Convert.ToDouble(this.importeImpuesto);
                                                        this.arrayImpuestosT = new string[4];
                                                        if (this.impuesto.Equals("IVA") && (Convert.ToDecimal(this.importeImpuesto) > Decimal.Zero && Convert.ToDecimal(this.tasa) == new Decimal(16) || Convert.ToString(this.tasa) == "0.16" || Convert.ToDecimal(this.importeImpuesto) == Decimal.Zero && Convert.ToDecimal(this.tasa) == Decimal.Zero))
                                                            this.valida_IVA = true;
                                                        this.arrayImpuestosT[0] = this.impuesto;
                                                        this.arrayImpuestosT[1] = this.TipoFactor;
                                                        this.arrayImpuestosT[2] = this.tasa;
                                                        this.arrayImpuestosT[3] = this.importeImpuesto;
                                                        this.arrayListImpuestosTC.Add((object)this.arrayImpuestosT);
                                                    }
                                                    xmlNodeList = (XmlNodeList)null;
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                //   this.ValidarXML6 = true;
                                            }
                                            #endregion
                                        }
                                    }
                                    #endregion
                                    #region NODO CONCEPTOS CUENTA PREDIAL
                                    string str8 = "";
                                    this.DB.Conectar();
                                    this.DB.CrearComando("select tipoProveedor from proveedores where rfc=@rfc");
                                    this.DB.AsignarParametroCadena("@rfc", this.rfcEmisor);
                                    DbDataReader DR = this.DB.EjecutarConsulta();
                                    if (DR.Read())
                                        str8 = DR[0].ToString();
                                    this.DB.Desconectar();
                                    if (str8.Equals("RENTA CON RETENCION") || str8.Equals("RENTA"))
                                    {
                                        XmlNodeList elementsByTagName4 = xmlElement2.GetElementsByTagName(str3 + "CuentaPredial");
                                        if ((uint)xmlElement2.GetElementsByTagName(str3 + "CuentaPredial").Count > 0U)
                                        {
                                            foreach (XmlElement xmlElement3 in elementsByTagName4)
                                            {
                                                try
                                                {
                                                    this.numeroCuentaPredial = xmlElement3.GetAttribute("Numero");
                                                }
                                                catch (Exception ex)
                                                {
                                                    this.ValidarXML_ctaPredial = true;
                                                    Facturas.anade_linea_archivo(this.archivo_logXSD, "La estructura del Nodo Cuenta Predial es invalida,");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            this.ValidarXML_ctaPredial = true;
                                            Facturas.anade_linea_archivo(this.archivo_logXSD, "La estructura del Nodo Cuenta Predial es invalida,");
                                        }
                                    }
                                    #endregion
                                }
                            }
                            catch (Exception ex)
                            {
                                this.ValidarXML5 = true;
                                Facturas.anade_linea_archivo(this.archivo_logXSD, "La estructura del Nodo Conceptos es invalida,");
                            }
                            #endregion
                            #region NODO IMPUESTOS
                            this.totalImpuestosTrasladados = "";
                            this.totalImpuestosRetenidos = "";
                            this.arrayListImpuestosR = new ArrayList();
                            this.arrayListImpuestosT = new ArrayList();
                            foreach (XmlElement xmlElement2 in xmlElement1.GetElementsByTagName(str3 + "Impuestos"))
                            {
                                if (xmlElement2.ParentNode.Name == "cfdi:Comprobante")
                                {
                                    this.totalImpuestosRetenidos = xmlElement2.GetAttribute("TotalImpuestosRetenidos");
                                    if (this.totalImpuestosRetenidos == "0.00")
                                        this.val_FaD_d_Total = true;
                                    this.totalImpuestosTrasladados = xmlElement2.GetAttribute("TotalImpuestosTrasladados");
                                    if (this.totalImpuestosTrasladados != "" && Convert.ToDecimal(this.totalImpuestosTrasladados) < Decimal.Zero)
                                        this.valida_numNegativos = false;
                                    if (this.totalImpuestosRetenidos != "" && Convert.ToDecimal(this.totalImpuestosRetenidos) < Decimal.Zero)
                                        this.valida_numNegativos = false;
                                    this.ValidarXML7 = false;
                                    #region NODO TRASLADOS
                                    try
                                    {
                                        this.arrayListImpuestosT = new ArrayList();
                                        XmlNodeList elementsByTagName3 = xmlElement2.GetElementsByTagName(str3 + "Traslados");
                                        if ((uint)xtr.GetElementsByTagName(str3 + "Traslados").Count > 0U)
                                        {
                                            foreach (XmlElement xmlElement3 in ((XmlElement)elementsByTagName3[0]).GetElementsByTagName(str3 + "Traslado"))
                                            {
                                                this.impuesto = "";
                                                this.tasa = "0.00";
                                                this.importeImpuesto = "";
                                                this.TipoFactor = "";
                                                this.impuesto = xmlElement3.GetAttribute("Impuesto");
                                                this.TipoFactor = xmlElement3.GetAttribute("TipoFactor");
                                                this.tasa = xmlElement3.GetAttribute("TasaOCuota");
                                                this.importeImpuesto = xmlElement3.GetAttribute("Importe");
                                                this.sumaT = this.sumaT + Convert.ToDecimal(this.importeImpuesto);
                                                this.totalTraslados = this.totalTraslados + Convert.ToDouble(this.importeImpuesto);
                                                this.arrayImpuestosT = new string[4];
                                                if (this.impuesto.Equals("IVA") && (Convert.ToDecimal(this.importeImpuesto) > Decimal.Zero && Convert.ToDecimal(this.tasa) == new Decimal(16) || Convert.ToString(this.tasa) == "0.16" || Convert.ToDecimal(this.importeImpuesto) == Decimal.Zero && Convert.ToDecimal(this.tasa) == Decimal.Zero))
                                                    this.valida_IVA = true;
                                                this.arrayImpuestosT[0] = this.impuesto;
                                                this.arrayImpuestosT[1] = this.TipoFactor;
                                                this.arrayImpuestosT[2] = this.tasa;
                                                this.arrayImpuestosT[3] = this.importeImpuesto;
                                                this.arrayListImpuestosT.Add((object)this.arrayImpuestosT);
                                            }
                                            xmlNodeList = (XmlNodeList)null;
                                        }
                                        if (this.totalTraslados > 0.0 && this.totalImpuestosTrasladados == "")
                                        {
                                            this.val_totalT = false;
                                            Facturas.anade_linea_archivo(this.archivo_logXSD, "La suma del totalTraslados es diferente a totalImpuestosTrasladados,");
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        impuestosTrasLocal = true;

                                    }
                                    #endregion
                                    #region NODO RETENCIONES
                                    try
                                    {
                                        this.arrayListImpuestosR = new ArrayList();
                                        XmlNodeList elementsByTagName3 = xmlElement2.GetElementsByTagName(str3 + "Retenciones");
                                        if ((uint)xtr.GetElementsByTagName(str3 + "Retencion").Count > 0U)
                                        {
                                            foreach (XmlElement xmlElement3 in ((XmlElement)elementsByTagName3[0]).GetElementsByTagName(str3 + "Retencion"))
                                            {
                                                this.impuesto = "";
                                                this.tasa = "0.00";
                                                this.importeImpuesto = "";
                                                this.impuesto = xmlElement3.GetAttribute("Impuesto");
                                                this.importeImpuesto = xmlElement3.GetAttribute("Importe");
                                                this.totalRetenciones = this.totalRetenciones + Convert.ToDouble(this.importeImpuesto);
                                                this.sumaT = this.sumaT - Convert.ToDecimal(this.importeImpuesto);
                                                this.arrayImpuestosR = new string[3];
                                                this.arrayImpuestosR[0] = this.impuesto;
                                                this.arrayImpuestosR[1] = this.tasa;
                                                this.arrayImpuestosR[2] = this.importeImpuesto;
                                                this.arrayListImpuestosR.Add((object)this.arrayImpuestosR);
                                            }
                                            xmlNodeList = (XmlNodeList)null;
                                        }
                                        if (this.totalRetenciones > 0.0 && this.totalImpuestosRetenidos == "")
                                        {
                                            this.val_totalR = false;
                                            Facturas.anade_linea_archivo(this.archivo_logXSD, "La suma del totalRetenciones es diferente a totalImpuestosRetenidos,");
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        impuestosRetLocal = true;
                                    }
                                    #endregion
                                }
                                //valida existencia de nodo correcto
                                else if (arrayListImpuestosRC.Count > 0 || arrayListImpuestosTC.Count > 0 || rfcEmisor.Equals("GEM850101BJ3"))
                                {
                                    if (!tipoPRO.Equals("BIENES Y SERVICIOS SIN IVA"))
                                    {
                                        this.ValidarXML7 = true;
                                        //        Facturas.anade_linea_archivo(archivo_logXSD, "-El nodo de impuestos no contiene estructura valida,");
                                    }
                                }
                            }

                            if (this.totalImpuestosTrasladados.Equals("") && this.totalTraslados > 0.0)
                                this.totalImpuestosTrasladados = this.totalTraslados.ToString();
                            if (this.totalImpuestosRetenidos.Equals("") && this.totalRetenciones > 0.0)
                                this.totalImpuestosRetenidos = this.totalRetenciones.ToString();

                            #endregion
                            #region VALIDACION CFE
                            if (this.rfcEmisor == "CFE370814QI0")
                            {
                                Decimal sumaT = this.sumaT;
                                if (Convert.ToDecimal(this.total) != sumaT)
                                {
                                    this.totalMas = Convert.ToDecimal(this.total) - sumaT;
                                    this.totalCFE_Fin = Convert.ToDecimal(this.totalMas.ToString().Replace("-", "")) + Convert.ToDecimal(this.importe);
                                }
                                else
                                    this.totalCFE_Fin = Convert.ToDecimal(this.total);
                            }
                            #endregion
                            #region NODO COMPLEMENTOS
                            if (this.banCFDI)
                            {
                                XmlNodeList elementsByTagName3 = xmlElement1.GetElementsByTagName(str3 + "Complemento");
                                if ((uint)xtr.GetElementsByTagName(str3 + "Complemento").Count > 0U)
                                {
                                    xmlNodeList = (XmlNodeList)null;

                                    foreach (XmlElement xmlElement2 in elementsByTagName3)
                                    {

                                        XmlNodeList elementsByTagName4 = xmlElement2.GetElementsByTagName("implocal:ImpuestosLocales");
                                        if ((uint)xtr.GetElementsByTagName("implocal:ImpuestosLocales").Count > 0U)
                                        {
                                            xmlNodeList = (XmlNodeList)null;
                                            foreach (XmlElement xmlElement3 in elementsByTagName4)
                                            {
                                                #region IMPUESTOS TRALADOS LOCALES
                                                XmlNodeList elementsByTagName5 = xmlElement3.GetElementsByTagName("implocal:TrasladosLocales");
                                                try
                                                {
                                                    if (impuestosTrasLocal)
                                                    {
                                                        if ((uint)xtr.GetElementsByTagName("implocal:TrasladosLocales").Count > 0U)
                                                        {
                                                            xmlNodeList = (XmlNodeList)null;
                                                            foreach (XmlElement xmlElement4 in elementsByTagName5)
                                                            {
                                                                this.impuesto = "";
                                                                this.tasa = "";
                                                                this.importeImpuesto = "";
                                                                this.impuesto = xmlElement4.GetAttribute("ImpLocTrasladado");
                                                                this.tasa = xmlElement4.GetAttribute("TasadeTraslado");
                                                                this.importeImpuesto = xmlElement4.GetAttribute("Importe");
                                                                this.sumaT = this.sumaT + Convert.ToDecimal(this.importeImpuesto);
                                                                this.arrayImpuestosT = new string[4];
                                                                this.arrayImpuestosT[0] = this.impuesto;
                                                                this.arrayImpuestosT[1] = "-";
                                                                this.arrayImpuestosT[2] = this.tasa;
                                                                this.arrayImpuestosT[3] = this.importeImpuesto;
                                                                this.arrayListImpuestosT.Add((object)this.arrayImpuestosT);
                                                            }
                                                        }
                                                    }
                                                }
                                                catch (Exception es)
                                                {
                                                    this.ValidarXML6 = true;
                                                    Facturas.anade_linea_archivo(this.archivo_logXSD, "La estructura del Nodo ImpuestosTraslados es invalida,");
                                                }
                                                #endregion
                                                #region NODO RETENCIONES LOCALES
                                                try
                                                {
                                                    if (impuestosTrasLocal)
                                                    {
                                                        XmlNodeList elementsByTagName6 = xmlElement3.GetElementsByTagName("implocal:RetencionesLocales");
                                                        if ((uint)xtr.GetElementsByTagName("implocal:RetencionesLocales").Count > 0U)
                                                        {
                                                            xmlNodeList = (XmlNodeList)null;
                                                            foreach (XmlElement xmlElement4 in elementsByTagName6)
                                                            {
                                                                this.impuesto = "";
                                                                this.tasa = "";
                                                                this.importeImpuesto = "";
                                                                this.tasa = xmlElement4.GetAttribute("TasadeRetencion");
                                                                this.impuesto = xmlElement4.GetAttribute("ImpLocRetenido");
                                                                this.importeImpuesto = xmlElement4.GetAttribute("Importe");
                                                                this.sumaT = this.sumaT - Convert.ToDecimal(this.importeImpuesto);
                                                                this.arrayImpuestosR = new string[4];
                                                                this.arrayImpuestosR[0] = this.impuesto;
                                                                this.arrayImpuestosR[1] = "-";
                                                                this.arrayImpuestosR[2] = this.tasa;
                                                                this.arrayImpuestosR[3] = this.importeImpuesto;
                                                                this.arrayListImpuestosR.Add((object)this.arrayImpuestosR);
                                                            }
                                                        }
                                                    }
                                                }
                                                catch (Exception es)
                                                {
                                                    this.ValidarXML7 = true;
                                                    Facturas.anade_linea_archivo(this.archivo_logXSD, "La estructura del Nodo ImpuestosRetenidos es invalida,");
                                                }
                                                #endregion
                                            }
                                        }

                                        #region NODO VALES DE DESPENSA
                                        XmlNodeList elementsByTagName7 = xmlElement2.GetElementsByTagName("valesdedespensa:ValesDeDespensa");
                                        if ((uint)xtr.GetElementsByTagName("valesdedespensa:ValesDeDespensa").Count > 0U)
                                        {
                                            xmlNodeList = (XmlNodeList)null;
                                            foreach (XmlElement xmlElement3 in elementsByTagName7)
                                            {
                                                XmlNodeList elementsByTagName5 = xmlElement2.GetElementsByTagName("valesdedespensa:Conceptos");
                                                if ((uint)xtr.GetElementsByTagName("valesdedespensa:Conceptos").Count > 0U)
                                                {
                                                    xmlNodeList = (XmlNodeList)null;
                                                    foreach (XmlElement xmlElement4 in elementsByTagName5)
                                                    {
                                                        XmlNodeList elementsByTagName6 = xmlElement2.GetElementsByTagName("valesdedespensa:Concepto");
                                                        if ((uint)xtr.GetElementsByTagName("valesdedespensa:Concepto").Count > 0U)
                                                        {
                                                            xmlNodeList = (XmlNodeList)null;
                                                            foreach (XmlElement xmlElement5 in elementsByTagName6)
                                                            {
                                                                this.importe = "";
                                                                this.cantidad = "1";
                                                                this.unidad = "NO APLICA";
                                                                this.noIdentificacion = xmlElement5.GetAttribute("identificador");
                                                                this.descripcion = xmlElement5.GetAttribute("nombre") + "-" + xmlElement5.GetAttribute("rfc");
                                                                this.valorUnitario = xmlElement5.GetAttribute("importe");
                                                                this.importe = xmlElement5.GetAttribute("importe");
                                                                this.arrayConceptos = new string[6];
                                                                this.arrayConceptos[0] = this.cantidad;
                                                                this.arrayConceptos[1] = this.unidad;
                                                                this.arrayConceptos[2] = this.noIdentificacion;
                                                                this.arrayConceptos[3] = this.descripcion;
                                                                this.arrayConceptos[4] = this.valorUnitario;
                                                                this.arrayConceptos[5] = this.importe;
                                                                this.sumaT = this.sumaT + Convert.ToDecimal(this.importe);
                                                                //       this.arrayListConceptos.Add((object)this.arrayConceptos);
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        #endregion

                                        #region NODO TIMBRE FISCAL
                                        XmlNodeList elementsByTagName8 = xmlElement2.GetElementsByTagName("tfd:TimbreFiscalDigital");
                                        if ((uint)xtr.GetElementsByTagName("tfd:TimbreFiscalDigital").Count > 0U)
                                        {
                                            xmlNodeList = (XmlNodeList)null;
                                            foreach (XmlElement xmlElement3 in elementsByTagName8)
                                            {
                                                this.xsi_schemaLocation_cfdi = xmlElement3.GetAttribute("xsi:schemaLocation");
                                                this.version_tim = xmlElement3.GetAttribute("version");
                                                this.UUID = xmlElement3.GetAttribute("UUID");
                                                this.FechTimbrado = xmlElement3.GetAttribute("FechaTimbrado");
                                                this.selloCFD = xmlElement3.GetAttribute("selloCFD");
                                                this.noCertificadoSAT = xmlElement3.GetAttribute("noCertificadoSAT");
                                                this.selloSAT = xmlElement3.GetAttribute("selloSAT");
                                                this.xmlns_xsi_cfdi = xmlElement3.GetAttribute("xmlns:tfd");
                                                this.xmlns_tfd_cfdi = xmlElement3.GetAttribute("xmlns:xsi");
                                                this.cadenaCFDI = "";
                                                this.impuesto = xmlElement3.GetAttribute("impuesto");
                                                this.importeImpuesto = xmlElement3.GetAttribute("importe");
                                            }
                                        }
                                        #endregion
                                    }
                                }
                            }
                            #endregion
                        }
                        this.evaluar(xtr);
                        #region WRITE GENERAL LOG
                        if (!sesionAdmin)
                        {
                            string mpproveedores = "";
                            if (!tipoDeComprobante.ToUpper().Equals("I"))
                            {
                                if (!tipoDeComprobante.ToUpper().Equals("E"))
                                {
                                    if (!tipoDeComprobante.ToUpper().Equals("P"))
                                    {
                                        anade_linea_archivo(archivo_logXSD, "-Tipo de comprobante invalido");
                                    }
                                }
                            }
                            if (!this.metodoDePago.Equals("PPD"))
                            {
                                //if (!metodoDePago.Equals("PUE"))
                                //{
                                if (!RFCPrivilegiado33(rfcEmisor))
                                {
                                    if (!tipoPRO.Equals("IMSS SAR INFONAVIT ENE-JUN"))
                                    {
                                        if (!tipoPRO.Equals("IMPUESTOS ENE-JUN"))
                                        {
                                            anade_linea_archivo(this.archivo_logXSD, "-Metodo de pago invalido,");
                                        }
                                    }
                                    //  }
                                }
                            }
                            if (!this.validation33(this.rfcEmisor) || rfcEmisor.Equals("ASE930924SS7"))
                                mpproveedores = this.ObtainMPproveedores(this.rfcEmisor);
                            if (!mpproveedores.Equals(this.formaDePago) && !string.IsNullOrEmpty(mpproveedores) || rfcEmisor.Equals("GEM850101BJ3"))
                                this.formaDePago = mpproveedores;
                            if (!this.formaDePago.Equals("99"))
                                if (!RFCPrivilegiado33(rfcEmisor))
                                {
                                    if (!tipoPRO.Equals("IMSS SAR INFONAVIT ENE-JUN"))
                                    {
                                        if (!tipoPRO.Equals("IMPUESTOS ENE-JUN"))
                                        {
                                            Facturas.anade_linea_archivo(this.archivo_logXSD, "-Forma de pago invalida,");
                                        }
                                    }
                                }
                        }
                        #endregion

                        string str9 = ConsultaWSSAT(rfcEmisor.Replace("&", "&amp;"), rfcReceptor.Replace("&", "&amp;"), total, UUID);
                        if (str9 == "Vigente")
                        {
                            #region VALIDACIONES CFDI 3.3

                            if (!this.ValidarXML1 || rfcEmisor.Equals("GEM850101BJ3"))
                            {
                                if (!this.ValidarXML2 || rfcEmisor.Equals("GEM850101BJ3"))
                                {
                                    if (!this.ValidarXML3 || rfcEmisor.Equals("GEM850101BJ3"))
                                    {
                                        if (!this.ValidarXML4 || rfcEmisor.Equals("GEM850101BJ3"))
                                        {
                                            if (!this.ValidarXML5 || rfcEmisor.Equals("GEM850101BJ3"))
                                            {
                                                if (!this.ValidarXML6 || rfcEmisor.Equals("GEM850101BJ3"))
                                                {
                                                    if (!this.ValidarXML7 || rfcEmisor.Equals("GEM850101BJ3"))
                                                    {
                                                        if (!this.ValidarXML_ctaPredial)
                                                        {
                                                            if (this.formaDePago.Equals("99") || tipoPRO.Equals("IMSS SAR INFONAVIT ENE-JUN") || tipoPRO.Equals("IMPUESTOS ENE-JUN") || RFCPrivilegiado33(rfcEmisor))
                                                            {
                                                                if ((this.metodoDePago.Equals("PPD")) || tipoPRO.Equals("IMSS SAR INFONAVIT ENE-JUN") || tipoPRO.Equals("IMPUESTOS ENE-JUN") || RFCPrivilegiado33(rfcEmisor))
                                                                {
                                                                    if (this.tipoDeComprobante.Equals("I") || this.tipoDeComprobante.Equals("E") || this.tipoDeComprobante.Equals("P"))
                                                                    {
                                                                        if (this.valida_moneda)
                                                                        {
                                                                            if (this.validation33(this.rfcEmisor) || rfcEmisor.Equals("GEM850101BJ3") || rfcEmisor.Equals("ASE930924SS7"))
                                                                            {
                                                                                if (this.operaciones33() || arrayListImpuestosRC.Count > 0 || arrayListImpuestosTC.Count > 0)
                                                                                {

                                                                                    if (sesionAdmin || rfcEmisor.Equals("GEM850101BJ3"))
                                                                                    {
                                                                                        continuar = true;
                                                                                        goto evitarValidaciones;
                                                                                    }

                                                                                    if (this.nombreEmisor != "")
                                                                                    {
                                                                                        if (!this.nombreReceptor.Equals("") || this.validaDomReceptor)
                                                                                        {
                                                                                            if (this.validaDomReceptor && this.valida_domicilioReceptor && this.valida_PaisRecep(this.rfcReceptor) || (this.valida_domicilioReceptor && this.RFCPrivilegiado(this.rfcEmisor) || this.valida_domicilioReceptor && this.validar_domicilioReceptor(this.rfcReceptor)) || this.version == "3.3")
                                                                                            {
                                                                                                if (this.valida_numNegativos)
                                                                                                {
                                                                                                    if (this.validacion_importe)
                                                                                                    {
                                                                                                        if (/*this.valida_IVA ||*/ this.version == "3.3")
                                                                                                        {
                                                                                                            if (/*valTiProv())*/this.version == "3.3")
                                                                                                            {
                                                                                                                if (this.val_totalR && this.val_totalT)
                                                                                                                {
                                                                                                                    this.continuar = true;
                                                                                                                    goto evitarValidaciones;
                                                                                                                }
                                                                                                                else
                                                                                                                {
                                                                                                                    this.copiarArc(this.nomTemp, this.rutaBCK, this.nombreSE, this.rfcEmisor, this.ordenCompra);
                                                                                                                    this.mensajeEmailError("RE044", "", this.emails);
                                                                                                                    this.mensajesLog("RE044", "", "", this.emails, "");
                                                                                                                }
                                                                                                            }
                                                                                                        }
                                                                                                        else
                                                                                                        {
                                                                                                            this.copiarArc(this.nomTemp, this.rutaBCK, this.nombreSE, this.rfcEmisor, this.ordenCompra);
                                                                                                            this.mensajeEmailError("RE032", "", this.emails);
                                                                                                            this.mensajesLog("RE032", "", "", this.emails, "");
                                                                                                        }
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        this.copiarArc(this.nomTemp, this.rutaBCK, this.nombreSE, this.rfcEmisor, this.ordenCompra);
                                                                                                        this.mensajeEmailError("RE036", "", this.emails);
                                                                                                        this.mensajesLog("RE036", "", "", this.emails, "");
                                                                                                    }
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    this.copiarArc(this.nomTemp, this.rutaBCK, this.nombreSE, this.rfcEmisor, this.ordenCompra);
                                                                                                    this.mensajeEmailError("RE040", "", this.emails);
                                                                                                    this.mensajesLog("RE040", "", "", this.emails, "");
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            this.copiarArc(this.nomTemp, this.rutaBCK, this.nombreSE, this.rfcEmisor, this.ordenCompra);
                                                                                            this.mensajeEmailError("RE038", "", this.emails);
                                                                                            this.mensajesLog("RE038", "", "", this.emails, "");
                                                                                        }
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        this.copiarArc(this.nomTemp, this.rutaBCK, this.nombreSE, this.rfcEmisor, this.ordenCompra);
                                                                                        this.mensajeEmailError("RE037", "", this.emails);
                                                                                        this.mensajesLog("RE037", "", "", this.emails, "");
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    this.copiarArc(this.nomTemp, this.rutaBCK, this.nombreSE, this.rfcEmisor, this.ordenCompra);
                                                                                    this.mensajeEmailError("RE020", "", this.emails);
                                                                                    this.mensajesLog("RE020", "", "", this.emails, "");
                                                                                    Facturas.anade_linea_archivo(this.archivo_logXSD, "Error en diferencias con el total y los impuestos,");
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                this.copiarArc(this.nomTemp, this.rutaBCK, this.nombreSE, this.rfcEmisor, this.ordenCompra);
                                                                                this.mensajeEmailError("RE032", "", this.emails);
                                                                                this.mensajesLog("RE032", "", "", this.emails, "");
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            this.copiarArc(this.nomTemp, this.rutaBCK, this.nombreSE, this.rfcEmisor, this.ordenCompra);
                                                                            this.mensajeEmailError("RE050", "", this.emails);
                                                                            this.mensajesLog("RE050", "", "", this.emails, "");
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        this.copiarArc(this.nomTemp, this.rutaBCK, this.nombreSE, this.rfcEmisor, this.ordenCompra);
                                                                        this.mensajeEmailError("RE027", "", this.emails);
                                                                        this.mensajesLog("RE027", "", "", this.emails, "");
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    this.copiarArc(this.nomTemp, this.rutaBCK, this.nombreSE, this.rfcEmisor, this.ordenCompra);
                                                                    this.mensajeEmailError("RE030", "", this.emails);
                                                                    this.mensajesLog("RE030", "", "", this.emails, "");
                                                                }
                                                            }
                                                            else
                                                            {
                                                                this.copiarArc(this.nomTemp, this.rutaBCK, this.nombreSE, this.rfcEmisor, this.ordenCompra);
                                                                this.mensajeEmailError("RE031", "", this.emails);
                                                                this.mensajesLog("RE031", "", "", this.emails, "");
                                                            }
                                                        }
                                                        else
                                                        {
                                                            this.copiarArc(this.nomTemp, this.rutaBCK, this.nombreSE, this.rfcEmisor, this.ordenCompra);
                                                            this.mensajeEmailError("RE338", "", this.emails);
                                                            this.mensajesLog("RE338", "", "", this.emails, "");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        this.copiarArc(this.nomTemp, this.rutaBCK, this.nombreSE, this.rfcEmisor, this.ordenCompra);
                                                        this.mensajeEmailError("RE337", "", this.emails);
                                                        this.mensajesLog("RE337", "", "", this.emails, "");
                                                    }
                                                }
                                                else
                                                {
                                                    this.copiarArc(this.nomTemp, this.rutaBCK, this.nombreSE, this.rfcEmisor, this.ordenCompra);
                                                    this.mensajeEmailError("RE336", "", this.emails);
                                                    this.mensajesLog("RE336", "", "", this.emails, "");
                                                }
                                            }
                                            else
                                            {
                                                this.copiarArc(this.nomTemp, this.rutaBCK, this.nombreSE, this.rfcEmisor, this.ordenCompra);
                                                this.mensajeEmailError("RE335", "", this.emails);
                                                this.mensajesLog("RE335", "", "", this.emails, "");
                                            }
                                        }
                                        else
                                        {
                                            this.copiarArc(this.nomTemp, this.rutaBCK, this.nombreSE, this.rfcEmisor, this.ordenCompra);
                                            this.mensajeEmailError("RE334", "", this.emails);
                                            this.mensajesLog("RE334", this.msj, "", this.emails, "");
                                        }
                                    }
                                    else
                                    {
                                        this.copiarArc(this.nomTemp, this.rutaBCK, this.nombreSE, this.rfcEmisor, this.ordenCompra);
                                        this.mensajeEmailError("RE333", "", this.emails);
                                        this.mensajesLog("RE333", this.msj, "", this.emails, "");
                                    }
                                }
                                else
                                {
                                    this.copiarArc(this.nomTemp, this.rutaBCK, this.nombreSE, this.rfcEmisor, this.ordenCompra);
                                    this.mensajeEmailError("RE332", "", this.emails);
                                    this.mensajesLog("RE332", this.msj, "", this.emails, "");
                                }
                            }
                            else
                            {
                                this.copiarArc(this.nomTemp, this.rutaBCK, this.nombreSE, this.rfcEmisor, this.ordenCompra);
                                this.mensajeEmailError("RE331", "", this.emails);
                                this.mensajesLog("RE331", this.msj, "", this.emails, "");
                            }
                            #endregion
                        }
                        else
                        #region ESTATUS CANCELADO
                            if (str9 == "Cancelado")
                        {
                            this.copiarArc(this.nomTemp, this.rutaBCK, this.nombreSE, this.rfcEmisor, this.ordenCompra);
                            this.mensajeEmailError("RE048", "", this.emails);
                            this.mensajesLog("RE048", "", "", this.emails, "");
                        }
                        else if (str9 == "No Encontrado")
                        {
                            this.copiarArc(this.nomTemp, this.rutaBCK, this.nombreSE, this.rfcEmisor, this.ordenCompra);
                            this.mensajeEmailError("RE046", "", this.emails);
                            this.mensajesLog("RE046", "", "", this.emails, "");
                        }
                        else
                        {
                            this.copiarArc(this.nomTemp, this.rutaBCK, this.nombreSE, this.rfcEmisor, this.ordenCompra);
                            this.mensajeEmailError("RE049", "", this.emails);
                            this.mensajesLog("RE049", "", "", this.emails, "");
                        }
                        #endregion
                    }
                    else
                    {
                        this.msj = this.msj + this.VF.msj;
                        this.msj = this.msj + this.VF.msjT;
                        this.copiarArc(this.nomTemp, this.rutaBCK, this.nombreSE, this.rfcEmisor, this.ordenCompra);
                        this.mensajeEmailError("RE007", "", this.emails);
                        this.mensajesLog("RE007", this.msj, this.msjT, this.emails, "");
                        Facturas.anade_linea_archivo(this.archivo_logXSD, "RFC de receptor invalido " + this.rfcReceptor + ",");
                    }

                    evitarValidaciones:
                    if (this.validarExistenciaAdicionales())
                    {
                        if (!this.continuar || !this.banValCadena && !(this.version == "3.3"))
                            return;
                        if (!this.banCFDI || this.version == "3.3")
                        {
                            if (this.banfolser || this.version == "3.3")
                                this.guardarBD();
                        }
                        else
                            this.guardarBD();
                    }
                    else
                        this.mensajesLog("RE051", "", "", this.emails, "");
                    #endregion
                }
                else
                {
                    #region CFDI 32
                    xDoc.Load(file);
                    xtrReader = new XmlTextReader(new StringReader(xDoc.OuterXml));
                    existe = xDoc.GetElementsByTagName(cfdi + "Comprobante");
                    if (existe.Count != 0)
                    {
                        cfdi = "cfdi:";
                        comprobante = xDoc.GetElementsByTagName(cfdi + "Comprobante");
                        banCFDI = true;
                    }
                    else
                    {
                        cfdi = "";
                        comprobante = xDoc.GetElementsByTagName("Comprobante");
                        banCFDI = false;
                    }

                    string az = "";
                    XPathDocument x = new XPathDocument(xtrReader);
                    XPathNavigator foo = x.CreateNavigator();
                    foo.MoveToFollowing(XPathNodeType.Element);
                    IDictionary<string, string> whatever = foo.GetNamespacesInScope(XmlNamespaceScope.All);
                    foreach (String a in whatever.Keys)
                    {
                        az = a;

                    }
                    foreach (XmlElement nodo in comprobante)
                    {
                        #region Nodo Comprobante
                        xmlns = nodo.GetAttribute("xmlns"); xmlns_xsi = nodo.GetAttribute("xmlns:xsi");
                        xmlns_xsd = nodo.GetAttribute("xmlns:xsd"); xsi_schemaLocation = nodo.GetAttribute("xsi:schemaLocation");
                        version = nodo.GetAttribute("version").Trim(); serie = nodo.GetAttribute("serie");
                        folio = nodo.GetAttribute("folio"); fecha2 = nodo.GetAttribute("fecha");
                        sello = nodo.GetAttribute("sello"); noAprobacion = nodo.GetAttribute("noAprobacion");
                        anoAprobacion = nodo.GetAttribute("anoAprobacion"); formaDePago = nodo.GetAttribute("formaDePago");
                        noCertificado = nodo.GetAttribute("noCertificado"); certificado = nodo.GetAttribute("certificado");
                        subTotal = nodo.GetAttribute("subTotal"); total = nodo.GetAttribute("total");
                        tipoDeComprobante = nodo.GetAttribute("tipoDeComprobante"); LugarExpedicion = nodo.GetAttribute("LugarExpedicion");
                        descuento = nodo.GetAttribute("descuento");
                        MotivoDescuento = nodo.GetAttribute("motivoDescuento"); //Moneda = nodo.GetAttribute("Moneda");
                        NumCtaPago = nodo.GetAttribute("NumCtaPago"); TipoCambio = nodo.GetAttribute("TipoCambio");
                        condicionesDePago = nodo.GetAttribute("condicionesDePago");
                        //  fecha = Convert.ToDateTime(fecha).ToString("dd/MM/yyyy HH:mm:ss");
                        metodoDePago = nodo.GetAttribute("metodoDePago");
                        moneda = nodo.GetAttribute("Moneda");
                        if (moneda.Contains("M"))
                        {
                            moneda = "MXN";
                        }


                        if (moneda == "MXN" || moneda == "USD" || (moneda == "" && sesionAdmin) || ((moneda != "MXN" || moneda != "USD") && sesionAdmin))
                        {
                            moneda = moneda == "" || (moneda != "MXN" && moneda != "USD") ? Moneda : moneda;
                            valida_moneda = true;
                        }
                        else
                        {
                            valida_moneda = false;
                        }
                        //validar descuento y motivo de descuento para fletes
                        XmlAttribute descuentoA = nodo.GetAttributeNode("descuento");
                        XmlAttribute MotivoDescuentoA = nodo.GetAttributeNode("motivoDescuento");
                        try
                        {
                            if ((descuentoA == null && MotivoDescuentoA == null) || (Convert.ToDecimal(descuento.Trim()) == 0 && MotivoDescuentoA == null))
                            {
                                valida_Desc_motDes = true;
                            }
                        }
                        catch (Exception e)
                        {

                        }

                        if (Convert.ToDecimal(subTotal) < 0 || Convert.ToDecimal(total) < 0)
                        {
                            valida_numNegativos = false;
                        }

                        String tempformaPago = formaDePago.ToUpper().Replace("Ó", "O");
                        string tempmetodoPago = metodoDePago.ToUpper().Replace("Ó", "O");

                        if (!tempformaPago.Contains("EXHIBICION") && !tempformaPago.Contains("EXIBICION")) { validacion_formaDePago = false; }

                        if (tempmetodoPago.Equals("03") || tempmetodoPago.Equals("17") || tempmetodoPago.Equals("NA")
                            || tempmetodoPago.Equals("TRANSFERENCIA") || tempmetodoPago.Equals("TRANSFERENCIA ELECTRONICA DE FONDOS")
                            || tempmetodoPago.Equals("COMPENSACION") || tempmetodoPago.Equals("NO IDENTIFICADO")) { validacion_metodoDePago = true; }
                        else { validacion_metodoDePago = false; }

                        if (metodoDePago.ToUpper().Contains("TRANSFERENCIA") || metodoDePago.ToUpper().Contains("CHEQUE") || metodoDePago.Equals("")) { validacion_metodoDePago = false; }
                        XmlAttribute numCta = nodo.GetAttributeNode("NumCtaPago");
                        if ((NumCtaPago.Equals("") && numCta == null) || (!NumCtaPago.Equals("") && System.Text.RegularExpressions.Regex.IsMatch(NumCtaPago, @"^[a-zA-Z_áéíóúñ\s]*$"))) // @"^[a-zA-Z_áéíóúñ\s\D]*$" excepto numeros
                        {

                            validacion_numDeCta = true;
                        }
                        else
                        {
                            validacion_numDeCta = false;
                        }
                        #endregion
                        #region VALIDACION EMISOR AND RECEPTOR
                        XmlNodeList emisor = nodo.GetElementsByTagName(cfdi + "Emisor");
                        foreach (XmlElement nodohi in emisor)
                        {
                            rfcEmisor = nodohi.GetAttribute("rfc");
                        }
                        XmlNodeList receptor = nodo.GetElementsByTagName(cfdi + "Receptor");
                        foreach (XmlElement nodohi in receptor)
                        {
                            rfcReceptor = nodohi.GetAttribute("rfc").Trim();
                        }
                        DB.Conectar();
                        DB.CrearComando("select emailsRegla from EmailsReglas  where rfc=@rfcrec and estadoRegla=1");
                        DB.AsignarParametroCadena("@rfcrec", rfcEmisor);
                        DbDataReader DR3 = DB.EjecutarConsulta();
                        if (DR3.Read())
                        {
                            emails = emails.Trim(',') + "," + DR3[0].ToString().Trim(',') + "";
                        }
                        DB.Desconectar();
                        #endregion
                    }
                    emails = (emails.Trim(',') + "," + correoProveedor(rfcEmisor)).Trim(',');
                    string valRFC = "";
                    valRFC = validaRFC(rfcReceptor);

                    if (rfcReceptor == valRFC)
                    {
                        if (version.Equals("2.2") || version.Equals("2.0") || version.Equals("3.2"))
                        {
                            foreach (XmlElement nodo in comprobante)
                            {
                                #region Nodo Emisor
                                XmlNodeList emisor = nodo.GetElementsByTagName(cfdi + "Emisor");
                                foreach (XmlElement nodohi in emisor)
                                {
                                    nombreEmisor = nodohi.GetAttribute("nombre");
                                    rfcEmisor = nodohi.GetAttribute("rfc");

                                    XmlNodeList DomicilioFiscal = nodohi.GetElementsByTagName(cfdi + "DomicilioFiscal");
                                    foreach (XmlElement nodohi2 in DomicilioFiscal)
                                    {

                                        calleEmisor = nodohi2.GetAttribute("calle"); noExteriorEmisor = nodohi2.GetAttribute("noExterior");
                                        noInteriorEmisor = nodohi2.GetAttribute("noInterior"); coloniaEmisor = nodohi2.GetAttribute("colonia");
                                        municipioEmisor = nodohi2.GetAttribute("municipio"); estadoEmisor = nodohi2.GetAttribute("estado");
                                        paisEmisor = nodohi2.GetAttribute("pais"); codigoPostalEmisor = nodohi2.GetAttribute("codigoPostal");
                                        localidadEmisor = nodohi2.GetAttribute("localidad"); referenciaEmisor = nodohi2.GetAttribute("referencia");
                                    }

                                    XmlNodeList ExpedidoEn = nodohi.GetElementsByTagName(cfdi + "ExpedidoEn");
                                    foreach (XmlElement nodohi2 in ExpedidoEn)
                                    {
                                        calleEmisorExp = nodohi2.GetAttribute("calle"); noExteriorEmisorExp = nodohi2.GetAttribute("noExterior");
                                        noInteriorEmisorExp = nodohi2.GetAttribute("noInterior"); coloniaEmisorExp = nodohi2.GetAttribute("colonia");
                                        municipioEmisorExp = nodohi2.GetAttribute("municipio"); estadoEmisorExp = nodohi2.GetAttribute("estado");
                                        paisEmisorExp = nodohi2.GetAttribute("pais"); codigoPostalEmisorExp = nodohi2.GetAttribute("codigoPostal");
                                        localidadEmisorExp = nodohi2.GetAttribute("localidad"); referenciaEmisorExp = nodohi2.GetAttribute("referencia");
                                    }

                                    XmlNodeList RegimenFiscal = nodohi.GetElementsByTagName(cfdi + "RegimenFiscal");
                                    foreach (XmlElement nodohi2 in RegimenFiscal)
                                    {
                                        Regimen = nodohi2.GetAttribute("Regimen");
                                    }
                                }
                                #endregion
                                #region Nodo Receptor
                                XmlNodeList receptor = nodo.GetElementsByTagName(cfdi + "Receptor");
                                foreach (XmlElement nodohi in receptor)
                                {
                                    nombreReceptor = nodohi.GetAttribute("nombre");
                                    rfcReceptor = nodohi.GetAttribute("rfc");

                                    XmlNodeList DomicilioFiscal = nodohi.GetElementsByTagName(cfdi + "Domicilio");
                                    if (DomicilioFiscal != null && DomicilioFiscal.Count != 0)
                                    {
                                        valida_domicilioReceptor = true;
                                    }
                                    foreach (XmlElement nodohi2 in DomicilioFiscal)
                                    {
                                        calleReceptor = nodohi2.GetAttribute("calle"); noExteriorReceptor = nodohi2.GetAttribute("noExterior");
                                        noInteriorReceptor = nodohi2.GetAttribute("noInterior"); coloniaReceptor = nodohi2.GetAttribute("colonia");
                                        municipioReceptor = nodohi2.GetAttribute("municipio"); estadoReceptor = nodohi2.GetAttribute("estado");
                                        paisReceptor = nodohi2.GetAttribute("pais"); codigoPostalReceptor = nodohi2.GetAttribute("codigoPostal");
                                        localidadReceptor = nodohi2.GetAttribute("localidad"); referenciaReceptor = nodohi2.GetAttribute("referencia");
                                    }
                                    //--------------Valida domicilio del receptor-------------
                                    //if (calleReceptor == "" && noInteriorReceptor == "" && municipioReceptor == "" && paisReceptor != "" && localidadReceptor == "" &&
                                    //    noExteriorReceptor == "" && coloniaReceptor == "" && estadoReceptor == "" && codigoPostalReceptor == "" && referenciaReceptor == "" && rfcReceptor != "")
                                    //{
                                    //    validaDomReceptor = true;
                                    //}
                                    //else
                                    //{
                                    //    validaDomReceptor = false;
                                    //}
                                    //-------------------------------------------------------
                                }
                                #endregion
                                #region Nodo Conceptos
                                cantidad = ""; unidad = ""; noIdentificacion = "";
                                descripcion = ""; valorUnitario = ""; importe = "";
                                arrayListConceptos = new ArrayList();
                                arrayListAduana = new ArrayList();
                                XmlNodeList Conceptos = nodo.GetElementsByTagName(cfdi + "Conceptos");
                                XmlNodeList listaConcepto = ((XmlElement)Conceptos[0]).GetElementsByTagName(cfdi + "Concepto");
                                int cont = 0;
                                foreach (XmlElement nodohi2 in listaConcepto)
                                {
                                    importe = "";
                                    cantidad = nodohi2.GetAttribute("cantidad"); unidad = nodohi2.GetAttribute("unidad");
                                    noIdentificacion = nodohi2.GetAttribute("noIdentificacion"); descripcion = nodohi2.GetAttribute("descripcion");
                                    valorUnitario = nodohi2.GetAttribute("valorUnitario");
                                    //                importe = Math.Round(Convert.ToDecimal(nodohi2.GetAttribute("importe")), 2).ToString();/////redondea cocneptos a 2 digitos
                                    importe = nodohi2.GetAttribute("importe");         ///original
                                    arrayConceptos = new String[6];
                                    arrayConceptos[0] = cantidad; arrayConceptos[1] = unidad; arrayConceptos[2] = noIdentificacion;
                                    arrayConceptos[3] = descripcion; arrayConceptos[4] = valorUnitario; arrayConceptos[5] = importe;
                                    sumaT = sumaT + Convert.ToDecimal(importe);
                                    arrayListConceptos.Add(arrayConceptos);
                                    if (descripcion.ToUpper().Contains("FLETE") || unidad.ToUpper().Contains("FLETE")
                                        || descripcion.ToUpper().Contains("TRANSPORTE") || unidad.ToUpper().Contains("TRANSPORTE"))
                                    {
                                        valida_fleteDesc = true;
                                    }

                                    if (descripcion.ToUpper() != "FLETE" || unidad.ToUpper() != "FLETE"
                                        || descripcion.ToUpper() != "TRANSPORTE" || unidad.ToUpper() != "TRANSPORTE")
                                    {
                                        val_FaD_d_Re = true;
                                    }


                                    if (Convert.ToDecimal(cantidad) < 0 || Convert.ToDecimal(valorUnitario) < 0 || Convert.ToDecimal(importe) < 0)
                                    {
                                        valida_numNegativos = false;
                                    }
                                    double impor = Convert.ToDouble(cantidad) * Convert.ToDouble(valorUnitario);
                                    if ((impor + 0.01) >= Convert.ToDouble(importe) && (impor - 0.01) <= Convert.ToDouble(importe))
                                    {

                                    }
                                    else
                                    {
                                        validacion_importe = false;
                                    }
                                    //if (Math.Round(impor,1) != (Math.Round(Convert.ToDecimal(importe),1)))
                                    // { validacion_importe = false; }

                                    numero = ""; fechaAduana = ""; aduana = "";

                                    XmlNodeList Concepto = nodohi2.GetElementsByTagName(cfdi + "Concepto");
                                    existe = nodohi2.GetElementsByTagName(cfdi + "InformacionAduanera");
                                    if (existe.Count != 0)
                                    {

                                        XmlNodeList ListaAduana = ((XmlElement)nodohi2).GetElementsByTagName(cfdi + "InformacionAduanera");

                                        foreach (XmlElement nodohi3 in ListaAduana)
                                        {
                                            numero = ""; fechaAduana = ""; aduana = "";
                                            numero = nodohi3.GetAttribute("numero"); fechaAduana = nodohi3.GetAttribute("fecha");
                                            aduana = nodohi3.GetAttribute("aduana");

                                            arrayAduana = new String[4];
                                            arrayAduana[0] = numero; arrayAduana[1] = fechaAduana; arrayAduana[2] = aduana;
                                            arrayAduana[3] = cont.ToString();
                                            arrayListAduana.Add(arrayAduana);

                                        }
                                    }
                                    cont++;
                                }
                                #endregion
                                #region Nodo impuestos
                                totalImpuestosTrasladados = ""; totalImpuestosRetenidos = "";
                                arrayListImpuestosR = new ArrayList();
                                arrayListImpuestosT = new ArrayList();
                                XmlNodeList Impuestos = nodo.GetElementsByTagName(cfdi + "Impuestos");
                                foreach (XmlElement nodohi in Impuestos)
                                {
                                    totalImpuestosRetenidos = nodohi.GetAttribute("totalImpuestosRetenidos");
                                    if (totalImpuestosRetenidos == "0.00")
                                    {
                                        val_FaD_d_Total = true;
                                    }

                                    totalImpuestosTrasladados = nodohi.GetAttribute("totalImpuestosTrasladados");
                                    if (totalImpuestosTrasladados != "" && Convert.ToDecimal(totalImpuestosTrasladados) < 0)
                                    {
                                        valida_numNegativos = false;
                                    }

                                    if (totalImpuestosRetenidos != "" && Convert.ToDecimal(totalImpuestosRetenidos) < 0)
                                    {
                                        valida_numNegativos = false;
                                    }
                                    #region Nodo Traslados
                                    XmlNodeList Traslados = nodohi.GetElementsByTagName(cfdi + "Traslados");
                                    existe = xDoc.GetElementsByTagName(cfdi + "Traslado");
                                    if (existe.Count != 0)
                                    {
                                        XmlNodeList listaTraslado = ((XmlElement)Traslados[0]).GetElementsByTagName(cfdi + "Traslado");
                                        foreach (XmlElement nodohi2 in listaTraslado)
                                        {
                                            impuesto = ""; tasa = ""; importeImpuesto = "";

                                            impuesto = nodohi2.GetAttribute("impuesto"); tasa = nodohi2.GetAttribute("tasa");
                                            importeImpuesto = nodohi2.GetAttribute("importe");
                                            sumaT = sumaT + Convert.ToDecimal(importeImpuesto);
                                            totalTraslados = totalTraslados + Convert.ToDouble(importeImpuesto);
                                            arrayImpuestosT = new String[3];
                                            if (impuesto.Equals("IVA") && ((Convert.ToDecimal(importeImpuesto) > 0 && (Convert.ToDecimal(tasa) == 16) || Convert.ToString(tasa) == "0.16") ||
                                                (Convert.ToDecimal(importeImpuesto) == 0 && Convert.ToDecimal(tasa) == 0))) { valida_IVA = true; }
                                            arrayImpuestosT[0] = impuesto; arrayImpuestosT[1] = tasa; arrayImpuestosT[2] = importeImpuesto;
                                            arrayListImpuestosT.Add(arrayImpuestosT);
                                        }
                                        existe = null;
                                    }
                                    if (totalTraslados > 0 && totalImpuestosTrasladados == "")
                                    {
                                        val_totalT = false;
                                    }
                                    #endregion
                                    #region nodo Retenciones
                                    XmlNodeList Retenciones = nodohi.GetElementsByTagName(cfdi + "Retenciones");
                                    existe = xDoc.GetElementsByTagName(cfdi + "Retencion");
                                    if (existe.Count != 0)
                                    {
                                        XmlNodeList listaRetencion = ((XmlElement)Retenciones[0]).GetElementsByTagName(cfdi + "Retencion");
                                        foreach (XmlElement nodohi2 in listaRetencion)
                                        {
                                            impuesto = ""; tasa = "0.00"; importeImpuesto = "";
                                            impuesto = nodohi2.GetAttribute("impuesto");
                                            importeImpuesto = nodohi2.GetAttribute("importe");
                                            totalRetenciones = totalRetenciones + Convert.ToDouble(importeImpuesto);
                                            sumaT = sumaT - Convert.ToDecimal(importeImpuesto);
                                            arrayImpuestosR = new String[3];
                                            arrayImpuestosR[0] = impuesto; arrayImpuestosR[1] = tasa; arrayImpuestosR[2] = importeImpuesto;
                                            arrayListImpuestosR.Add(arrayImpuestosR);
                                        }
                                        existe = null;
                                    }
                                    if (totalRetenciones > 0 && totalImpuestosRetenidos == "")
                                    {
                                        val_totalR = false;
                                    }
                                    #endregion
                                }
                                #endregion
                                if (totalImpuestosTrasladados.Equals("") && totalTraslados > 0)
                                {
                                    totalImpuestosTrasladados = totalTraslados.ToString();
                                }
                                if (totalImpuestosRetenidos.Equals("") && totalRetenciones > 0)
                                {
                                    totalImpuestosRetenidos = totalRetenciones.ToString();
                                }
                                #region VALIDACION CFE
                                if (rfcEmisor == "CFE370814QI0")
                                {
                                    decimal totalCFE = sumaT;
                                    if (Convert.ToDecimal(total) != totalCFE)
                                    {
                                        totalMas = Convert.ToDecimal(total) - totalCFE;
                                        var totalMas2 = totalMas.ToString().Replace("-", "");
                                        totalCFE_Fin = Convert.ToDecimal(totalMas2) + Convert.ToDecimal(importe);
                                    }
                                    else
                                    {
                                        totalCFE_Fin = Convert.ToDecimal(total);
                                    }
                                }
                                #endregion
                                #region Nodo Complemento CFDI
                                if (banCFDI)
                                {

                                    XmlNodeList Complementos = nodo.GetElementsByTagName(cfdi + "Complemento");
                                    existe = xDoc.GetElementsByTagName(cfdi + "Complemento");
                                    if (existe.Count != 0)
                                    {
                                        existe = null;
                                        foreach (XmlElement nodohi in Complementos)
                                        {
                                            #region IMPUESTOS LOCALES
                                            XmlNodeList impuestosLocales = nodohi.GetElementsByTagName("implocal:ImpuestosLocales");
                                            existe = xDoc.GetElementsByTagName("implocal:ImpuestosLocales");
                                            if (existe.Count != 0)
                                            {
                                                existe = null;
                                                foreach (XmlElement nodohi3 in impuestosLocales)
                                                {
                                                    XmlNodeList trasladosLocales = nodohi3.GetElementsByTagName("implocal:TrasladosLocales");
                                                    existe = xDoc.GetElementsByTagName("implocal:TrasladosLocales");
                                                    if (existe.Count != 0)
                                                    {
                                                        existe = null;
                                                        foreach (XmlElement nodohiL in trasladosLocales)
                                                        {
                                                            impuesto = ""; tasa = ""; importeImpuesto = "";

                                                            impuesto = nodohiL.GetAttribute("ImpLocTrasladado"); tasa = nodohiL.GetAttribute("TasadeTraslado");
                                                            importeImpuesto = nodohiL.GetAttribute("Importe");
                                                            //totalTraslados = totalTraslados + Convert.ToDouble(importeImpuesto);
                                                            sumaT = sumaT + Convert.ToDecimal(importeImpuesto);
                                                            arrayImpuestosT = new String[3];
                                                            arrayImpuestosT[0] = impuesto; arrayImpuestosT[1] = tasa; arrayImpuestosT[2] = importeImpuesto;
                                                            arrayListImpuestosT.Add(arrayImpuestosT);
                                                        }

                                                    }

                                                    XmlNodeList retencionesLocales = nodohi3.GetElementsByTagName("implocal:RetencionesLocales");
                                                    existe = xDoc.GetElementsByTagName("implocal:RetencionesLocales");
                                                    if (existe.Count != 0)
                                                    {
                                                        existe = null;
                                                        foreach (XmlElement nodohiR in retencionesLocales)
                                                        {
                                                            impuesto = ""; tasa = ""; importeImpuesto = ""; tasa = nodohiR.GetAttribute("TasadeRetencion");
                                                            impuesto = nodohiR.GetAttribute("ImpLocRetenido");
                                                            importeImpuesto = nodohiR.GetAttribute("Importe");
                                                            //totalRetenciones = totalRetenciones + Convert.ToDouble(importeImpuesto);
                                                            sumaT = sumaT - Convert.ToDecimal(importeImpuesto);
                                                            arrayImpuestosR = new String[3];
                                                            arrayImpuestosR[0] = impuesto; arrayImpuestosR[1] = tasa; arrayImpuestosR[2] = importeImpuesto;
                                                            arrayListImpuestosR.Add(arrayImpuestosR);
                                                        }
                                                    }
                                                }
                                            }
                                            #endregion
                                            #region VALES DE DESPENSA
                                            XmlNodeList ValesDeDespensa = nodohi.GetElementsByTagName("valesdedespensa:ValesDeDespensa");
                                            existe = xDoc.GetElementsByTagName("valesdedespensa:ValesDeDespensa");
                                            if (existe.Count != 0)
                                            {
                                                existe = null;
                                                foreach (XmlElement nodohi3 in ValesDeDespensa)
                                                {
                                                    XmlNodeList ValesDeDespensaConceptos = nodohi.GetElementsByTagName("valesdedespensa:Conceptos");
                                                    existe = xDoc.GetElementsByTagName("valesdedespensa:Conceptos");
                                                    if (existe.Count != 0)
                                                    {
                                                        existe = null;
                                                        foreach (XmlElement nodohi4 in ValesDeDespensaConceptos)
                                                        {
                                                            XmlNodeList ValesDeDespensaConcepto = nodohi.GetElementsByTagName("valesdedespensa:Concepto");
                                                            existe = xDoc.GetElementsByTagName("valesdedespensa:Concepto");
                                                            if (existe.Count != 0)
                                                            {
                                                                existe = null;
                                                                foreach (XmlElement nodohi5 in ValesDeDespensaConcepto)
                                                                {
                                                                    importe = "";
                                                                    cantidad = "1"; unidad = "NO APLICA";
                                                                    noIdentificacion = nodohi5.GetAttribute("identificador"); descripcion = nodohi5.GetAttribute("nombre") + "-" + nodohi5.GetAttribute("rfc");
                                                                    valorUnitario = nodohi5.GetAttribute("importe"); importe = nodohi5.GetAttribute("importe");
                                                                    arrayConceptos = new String[6];
                                                                    arrayConceptos[0] = cantidad; arrayConceptos[1] = unidad; arrayConceptos[2] = noIdentificacion;
                                                                    arrayConceptos[3] = descripcion; arrayConceptos[4] = valorUnitario; arrayConceptos[5] = importe;
                                                                    sumaT = sumaT + Convert.ToDecimal(importe);
                                                                    //        arrayListConceptos.Add(arrayConceptos);
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            #endregion
                                            #region TIMBRE FISCAL
                                            XmlNodeList TimbreFiscalDigital = nodohi.GetElementsByTagName("tfd:TimbreFiscalDigital");
                                            existe = xDoc.GetElementsByTagName("tfd:TimbreFiscalDigital");
                                            if (existe.Count != 0)
                                            {
                                                existe = null;
                                                foreach (XmlElement nodohi2 in TimbreFiscalDigital)
                                                {
                                                    xsi_schemaLocation_cfdi = nodohi2.GetAttribute("xsi:schemaLocation");
                                                    version_tim = nodohi2.GetAttribute("version");
                                                    UUID = nodohi2.GetAttribute("UUID");
                                                    FechTimbrado = nodohi2.GetAttribute("FechaTimbrado");
                                                    selloCFD = nodohi2.GetAttribute("selloCFD");
                                                    noCertificadoSAT = nodohi2.GetAttribute("noCertificadoSAT");
                                                    selloSAT = nodohi2.GetAttribute("selloSAT");
                                                    xmlns_xsi_cfdi = nodohi2.GetAttribute("xmlns:tfd");
                                                    xmlns_tfd_cfdi = nodohi2.GetAttribute("xmlns:xsi");
                                                    cadenaCFDI = "";
                                                    impuesto = nodohi2.GetAttribute("impuesto");
                                                    importeImpuesto = nodohi2.GetAttribute("importe");
                                                }
                                            }
                                            #endregion
                                        }
                                    }
                                }
                                #endregion
                            }

                            evaluar(xDoc);
                            String estado = ConsultaWSSAT(rfcEmisor.Replace("&", "&amp;"), rfcReceptor.Replace("&", "&amp;"), total, UUID);
                            if (estado == "Vigente")
                            {
                                #region VALIDACIONES 3.2
                                if (valida_moneda)
                                {
                                    if (sesionAdmin)
                                    {
                                        continuar = true;
                                        goto evitarValidaciones;
                                    }

                                    if (validacion_formaDePago || RFCPrivilegiado(rfcEmisor))
                                    {
                                        if (validacion_metodoDePago || RFCPrivilegiado(rfcEmisor))
                                        {
                                            if (validacion_numDeCta)
                                            {
                                                if (operaciones())
                                                {
                                                    //if (tipoDeComprobante.ToLower().Equals("ingreso") || tipoDeComprobante.ToLower().Equals("egreso"))
                                                    //{
                                                    if (nombreEmisor != "")
                                                    {
                                                        if (!nombreReceptor.Equals("") || validaDomReceptor)
                                                        {
                                                            if ((validaDomReceptor && valida_domicilioReceptor && valida_PaisRecep(rfcReceptor)) || (valida_domicilioReceptor && RFCPrivilegiado(rfcEmisor)) || (valida_domicilioReceptor && validar_domicilioReceptor(rfcReceptor)))
                                                            {

                                                                if (valida_numNegativos)
                                                                {
                                                                    if (validacion_importe)
                                                                    {

                                                                        if (valida_IVA)
                                                                        {
                                                                            if (valTiProv())
                                                                            {
                                                                                if (val_totalR && val_totalT)
                                                                                {
                                                                                    continuar = true;
                                                                                    goto evitarValidaciones;
                                                                                }
                                                                                else
                                                                                {
                                                                                    //falta de totalImpuestosTrasladados o otalImpuestosRetenidos
                                                                                    copiarArc(nomTemp, rutaBCK, nombreSE, rfcEmisor, ordenCompra);
                                                                                    mensajeEmailError("RE044", "", emails);
                                                                                    mensajesLog("RE044", "", "", emails, "");
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                //faltan atributos segun el tipo de proveedor
                                                                            }
                                                                        }
                                                                        //else//////////////////////////7validacion NC
                                                                        //{
                                                                        //}
                                                                        //   }
                                                                        else
                                                                        {
                                                                            //falta IVA
                                                                            copiarArc(nomTemp, rutaBCK, nombreSE, rfcEmisor, ordenCompra);
                                                                            mensajeEmailError("RE032", "", emails);
                                                                            mensajesLog("RE032", "", "", emails, "");
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        //importe incorrecto
                                                                        copiarArc(nomTemp, rutaBCK, nombreSE, rfcEmisor, ordenCompra);
                                                                        mensajeEmailError("RE036", "", emails);
                                                                        mensajesLog("RE036", "", "", emails, "");
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    //Hay numeros negativos en cantidad, valor unitario o importe
                                                                    copiarArc(nomTemp, rutaBCK, nombreSE, rfcEmisor, ordenCompra);
                                                                    mensajeEmailError("RE040", "", emails);
                                                                    mensajesLog("RE040", "", "", emails, "");
                                                                }
                                                            }
                                                            else
                                                            {
                                                                Facturas.anade_linea_archivo(this.archivo_logXSD, "El Domicilio del receptor falta o es incorrecto");
                                                                //copiarArc(nomTemp, rutaBCK, nombreSE, rfcEmisor, ordenCompra);
                                                                //mensajeEmailAdjuntar("RE040", "", emails);
                                                                //mensajesLog("RE053", "", "", emails, "");
                                                            }
                                                        }
                                                        else
                                                        {
                                                            //falta nombre receptor
                                                            copiarArc(nomTemp, rutaBCK, nombreSE, rfcEmisor, ordenCompra);
                                                            mensajeEmailError("RE038", "", emails);
                                                            mensajesLog("RE038", "", "", emails, "");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        //falta nombre del emisor
                                                        copiarArc(nomTemp, rutaBCK, nombreSE, rfcEmisor, ordenCompra);
                                                        mensajeEmailError("RE037", "", emails);
                                                        mensajesLog("RE037", "", "", emails, "");
                                                    }
                                                    /*}
                                                    else
                                                    {
                                                        //tipoDeCoprobante invalido
                                                        copiarArc(nomTemp, rutaBCK, nombreSE, rfcEmisor, ordenCompra);
                                                        mensajeEmailAdjuntar("RE027", "", emails);
                                                        mensajesLog("RE027", "", "", "", "");
                                                    }*/
                                                }
                                                else
                                                {
                                                    //Error en Total
                                                    copiarArc(nomTemp, rutaBCK, nombreSE, rfcEmisor, ordenCompra);
                                                    mensajeEmailError("RE020", "", emails);
                                                    mensajesLog("RE020", "", "", emails, "");
                                                }

                                            }
                                            else
                                            {
                                                //falta numDeCta o contiene numeros
                                                copiarArc(nomTemp, rutaBCK, nombreSE, rfcEmisor, ordenCompra);
                                                mensajeEmailError("RE029", "", emails);
                                                mensajesLog("RE029", "", "", emails, "");
                                            }

                                        }
                                        else
                                        {
                                            //falta metodoDePago o es trasferencia o cheque
                                            copiarArc(nomTemp, rutaBCK, nombreSE, rfcEmisor, ordenCompra);
                                            mensajeEmailError("RE030", "", emails);
                                            mensajesLog("RE030", "", "", emails, "");
                                        }
                                    }
                                    else
                                    {
                                        //falta formaDePago o es incorrecto
                                        copiarArc(nomTemp, rutaBCK, nombreSE, rfcEmisor, ordenCompra);
                                        mensajeEmailError("RE031", "", emails);
                                        mensajesLog("RE031", "", "", emails, "");
                                    }
                                }
                                else
                                {
                                    //formato de moneda erroneo
                                    copiarArc(nomTemp, rutaBCK, nombreSE, rfcEmisor, ordenCompra);
                                    mensajeEmailError("RE050", "", emails);
                                    mensajesLog("RE050", "", "", emails, "");
                                }
                                #endregion
                            }
                            else
                            {
                                #region ESTADO CANCELADO
                                if (estado == "Cancelado")
                                {
                                    //CFDI esta cancelado
                                    copiarArc(nomTemp, rutaBCK, nombreSE, rfcEmisor, ordenCompra);
                                    mensajeEmailError("RE048", "", emails);
                                    mensajesLog("RE048", "", "", emails, "");
                                }
                                else
                                {
                                    if (estado == "No Encontrado")
                                    {
                                        //CFDI no encontrado en el SAT
                                        copiarArc(nomTemp, rutaBCK, nombreSE, rfcEmisor, ordenCompra);
                                        mensajeEmailError("RE046", "", emails);
                                        mensajesLog("RE046", "", "", emails, "");
                                    }
                                    else
                                    {
                                        //Sat no contesto reintentar mas tarde
                                        copiarArc(nomTemp, rutaBCK, nombreSE, rfcEmisor, ordenCompra);
                                        mensajeEmailError("RE049", "", emails);
                                        mensajesLog("RE049", "", "", emails, "");
                                    }
                                }
                            }
                            #endregion
                        }
                        else
                        {
                            copiarArc(nomTemp, rutaBCK, nombreSE, rfcEmisor, ordenCompra);
                            mensajeEmailError("RE014", "", emails);
                            mensajesLog("RE014", "", "", emails, "");
                        }
                    }
                    else
                    {
                        //en caso de que no sea una factura de la empresa
                        msj += VF.msj;
                        msj += VF.msjT;
                        copiarArc(nomTemp, rutaBCK, nombreSE, rfcEmisor, ordenCompra);
                        mensajeEmailError("RE007", "", emails);
                        mensajesLog("RE007", msj, msjT, emails, "");
                    }

                    evitarValidaciones:
                    if (validarExistenciaAdicionales())
                    {
                        if (continuar)
                        {
                            if (banValCadena)
                            {
                                if (!banCFDI)
                                {
                                    if (banfolser)
                                    {
                                        if (!(version.Equals("3.2")) || sesionAdmin)
                                        {
                                            guardarBD();
                                        }
                                        else
                                        {
                                            copiarArc(nomTemp, rutaBCK, nombreSE, rfcEmisor, ordenCompra);
                                            mensajeEmailError("RE339", "", emails);
                                            mensajesLog("RE339", "", "", emails, "");
                                        }

                                    }
                                }
                                else
                                {
                                    if (!(version.Equals("3.2")) || sesionAdmin)
                                    {
                                        guardarBD();
                                    }
                                    else
                                    {
                                        copiarArc(nomTemp, rutaBCK, nombreSE, rfcEmisor, ordenCompra);
                                        mensajeEmailError("RE339", "", emails);
                                        mensajesLog("RE339", "", "", emails, "");
                                    }

                                }
                            }
                        }
                    }
                    else
                    {
                        mensajesLog("RE051", "", "", emails, "");
                    }

                }
                #endregion
            }
            catch (Exception e)
            {
                DB.Desconectar();
                copiarArc(nomTemp, rutaBCK, nombreSE, rfcEmisor, ordenCompra);
                String archivo2 = System.AppDomain.CurrentDomain.BaseDirectory + @"ErrorCorru.txt";
                using (System.IO.StreamWriter escritor = new System.IO.StreamWriter(archivo2))
                {
                    escritor.WriteLine(e.ToString() + "Adi:" + msj);
                }
                mensajesLog("RE009", msj, e.ToString(), emails, e.Message);
            }
        }

        protected string ConsultaWSSAT(string re, string rr, string tt, string id)
        {
            try
            {
                ConsultaCFDIServiceClient consulta = new ConsultaCFDIServiceClient();
                Acuse recibo = new Acuse();
                consulta.Open();
                recibo = consulta.Consulta("?re=" + re + "&rr=" + rr + "&tt=" + tt + "&id=" + id);
                consulta.Close();

                return recibo.Estado;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        private bool RFCPrivilegiado33(String rfc)
        {
            if (rfc == "GEM850101BJ3")
            {
                return true;
            }
            if (rfc == "KME591225JY1")
            {
                return true;
            }
            if (rfc == "ASE930924SS7")
            {
                return true;
            }
            if (rfc == "VME640813HF6")
            {
                return true;
            }
            return false;
        }


        private bool RFCPrivilegiado(String rfc)
        {
            if (rfc == "ACG1208232X5")
            {
                return true;
            }
            if (rfc == "TEP7409025J9")
            {
                return true;
            }
            if (rfc == "GVA7209049N6")
            {
                return true;
            }
            if (rfc == "SWI5210141J5")
            {
                return true;
            }
            if (rfc == "BME940711FR5")
            {
                return true;
            }
            if (rfc == "TEM670628A19")
            {
                return true;
            }
            if (rfc == "KME591225JY1")
            {
                return true;
            }
            if (rfc == "TRA800423S25")
            {
                return true;
            }
            if (rfc == "TCF840607DS9")
            {
                return true;
            }
            if (rfc == "CME720930GM9")
            {
                return true;
            }
            if (rfc == "LFO540716E98")
            {
                return true;
            }
            if (rfc == "ASE930924SS7")
            {
                return true;
            }
            if (rfc == "VME640813HF6")
            {
                return true;
            }
            if (rfc == "DME9204099R6")
            {
                return true;
            }
            if (rfc == "CSE070227GD3")
            {
                return true;
            }
            if (rfc == "SMI990401JS4")
            {
                return true;
            }
            if (rfc == "FFX121005C6A")
            {
                return true;
            }
            if (rfc == "FHO121005EFA")
            {
                return true;
            }
            if (rfc == "ASO0408178B2")
            {
                return true;
            }
            if (rfc == "P&G4803059U8")
            {
                return true;
            }
            if (rfc == "MIN980623CFA")
            {
                return true;
            }
            if (rfc == "VER870629GN3")
            {
                return true;
            }
            if (rfc == "CSS160330CP7")//recien agregado
            {
                return true;
            }
            return false;
        }

        private void evaluar(XmlDocument xtr)
        {
            string[] mensajes, mensajesT;
            mensajes = new String[10];
            mensajesT = new string[10];
            String impISR;
            String impuesISR = "0";
            if (validarCadena(xtr))
            {
                banValCadena = true;
                mensajes[0] = "Sello válido";
            }
            else
            {
                banValCadena = false;
                mensajes[0] = "Sello inválido";
                mensajesT[0] = msjT;
            }
            if (VC.existenciaCertificado(rfcEmisor, noCertificado))
            {
                banexistenciaCer = true;
                banstatusCer = true;
                mensajes[1] = "Existencia de certificado:Correcto";
            }
            else
            {
                banexistenciaCer = true;
                banstatusCer = true;
                mensajes[1] = "No existe el Certificado";
                mensajesT[1] = msjT;
            }
            //////////////////////////////////////////////////////////////
            if ((TipoProveedor == "FLETES") && !(tipoDeComprobante.ToUpper().Equals("EGRESO") || tipoDeComprobante.ToUpper().Equals("E")))
            {
                #region VALIDATE RETENTIONS
                XmlNode xmlNode = null;
                XmlDocument xtrtfd = new XmlDocument();
                xmlNode = xtr.GetElementsByTagName("cfdi:Retenciones")[0];
                if (xmlNode != null)
                {
                    foreach (XmlElement nodohi in xmlNode)
                    {
                        impISR = nodohi.GetAttribute("impuesto");
                        if (impISR == "ISR")
                        {
                            impISR2 = impISR;
                        }
                    }
                    if (impISR2 != "ISR" || (rfcEmisor == "VER870629GN3" && Convert.ToDecimal(impuesISR) == 0))
                    {
                        banValRetencion = true;
                        mensajes[4] = "Factura sin retenciones ISR";
                    }
                    else
                    {
                        banValRetencion = false;
                        mensajes[4] = "La factura contiene retenciones ISR";
                        mensajesT[4] = msjT;
                        MENSAJE_ISR = true;
                    }
                }
                else
                {
                    banValRetencion = true;
                    mensajes[4] = "Factura sin retenciones ISR";
                }
                #endregion
            }
            else
            {
                banValRetencion = true;
                mensajes[4] = "Factura sin retenciones ISR";
            }
            if (!banCFDI)
            {
                if (VF.folioyserie(rfcEmisor, serie, folio, anoAprobacion, noAprobacion))
                {
                    banfolser = true;
                    mensajes[3] = "Folio y Serie validos";
                }
                else
                {
                    banfolser = false;
                    estadoValfs = VF.estado;
                    if (VF.estado == "3")
                    { mensajes[3] = "El número de aprobación es invalido."; }

                    else if (VF.estado == "1")
                    {
                        mensajes[3] = "El número de folio no esta dentro del rango, o no esta autorizado por el SAT.";
                    }

                    mensajesT[3] = msjT;
                }
            }
            if (!banValCadena)
            {
                resSello = mensajes[0].ToString() + Environment.NewLine;
                resExistCer = mensajes[1].ToString() + Environment.NewLine;
                msgVesiondoc = "Versión del comprobante" + version + Environment.NewLine;
                msgCadenaOriginal = getCO();

                resCO = "Cadena Original: " + Environment.NewLine + getCO() + Environment.NewLine;
                msgCertidicado = "No de certificado" + Environment.NewLine + noCertificado;
                resultadoVal = msj + resSello + resExistCer; //resVigCer + 
                resultadoVal += resFolser + msgVesiondoc + resCO + msgCertidicado;

                copiarArc(nomTemp, rutaBCK, nombreSE, rfcEmisor, ordenCompra);
                mensajeEmailError("RE002", "", emails);
                mensajesLog("RE002", mensajes[0], mensajesT[0], emails, resultadoVal);

            }
            else if (!banexistenciaCer)
            {
                resSello = mensajes[0].ToString() + Environment.NewLine;
                resExistCer = mensajes[1].ToString() + Environment.NewLine;
                // resVigCer = mensajes[2].ToString() + Environment.NewLine;
                msgVesiondoc = "Versión del comprobante" + version + Environment.NewLine;
                msgCadenaOriginal = getCO();

                resCO = "Cadena Original: " + Environment.NewLine + getCO() + Environment.NewLine;
                msgCertidicado = "No de certificado" + Environment.NewLine + noCertificado;
                resultadoVal = msj + resSello + resExistCer; //resVigCer + 
                resultadoVal += resFolser + msgVesiondoc + resCO + msgCertidicado;

                mensajesLog("RE005", mensajes[1], mensajesT[1], emails, resultadoVal);

            }
            if (!banValRetencion)
            {   //error de sello Digital
                resSello = mensajes[0].ToString() + Environment.NewLine;
                resExistCer = mensajes[1].ToString() + Environment.NewLine;
                //resVigCer = mensajes[2].ToString() + Environment.NewLine;
                msgVesiondoc = "Versión del comprobante" + version + Environment.NewLine;
                msgCadenaOriginal = getCO();

                resCO = "Cadena Original: " + Environment.NewLine + getCO() + Environment.NewLine;
                msgCertidicado = "No de certificado" + Environment.NewLine + noCertificado;
                resultadoVal = msj + resSello + resExistCer; //resVigCer + 
                resultadoVal += resFolser + msgVesiondoc + resCO + msgCertidicado;

                copiarArc(nomTemp, rutaBCK, nombreSE, rfcEmisor, ordenCompra);
                mensajeEmailError("RE002", "", emails);
                mensajesLog("RE002", mensajes[4], mensajesT[4], emails, resultadoVal);
            }
            else if (!banCFDI)
            {
                if (!banfolser)
                {
                    copiarArc(nomTemp, rutaBCK, nombreSE, rfcEmisor, ordenCompra);

                    resSello = mensajes[0].ToString() + Environment.NewLine;
                    resExistCer = mensajes[1].ToString() + Environment.NewLine;
                    // resVigCer = mensajes[2].ToString() + Environment.NewLine;
                    msgVesiondoc = "Versión del comprobante" + version + Environment.NewLine;
                    msgCadenaOriginal = getCO();

                    resCO = "Cadena Original: " + Environment.NewLine + getCO() + Environment.NewLine;
                    msgCertidicado = "No de certificado" + Environment.NewLine + noCertificado;
                    resultadoVal = msj + resSello + resExistCer; //resVigCer + 
                    resultadoVal += resFolser + msgVesiondoc + resCO + msgCertidicado;

                    if (VF.estado == "3")
                    {  //No esta en el rango de folios
                        mensajeEmailError("RE004", "", emails);
                        mensajesLog("RE004", mensajes[3], mensajesT[3], emails, resultadoVal);
                        banRangofol = true;
                    }
                    else if (VF.estado == "1")
                    { //El numero de Aprobación es invalido
                        mensajeEmailError("RE003", "", emails);
                        mensajesLog("RE003", mensajes[3], mensajesT[3], emails, resultadoVal);
                        banNoAprob = true;
                    }
                }
            }
            else if (banValCadena && banexistenciaCer && banstatusCer && banValRetencion)//Si la factrura es válida 
            {
                resSello = mensajes[0].ToString() + Environment.NewLine;
                resExistCer = mensajes[1].ToString() + Environment.NewLine;
                //     resVigCer = mensajes[2].ToString() + Environment.NewLine;
                msgVesiondoc = "Versión del comprobante" + version + Environment.NewLine;
                msgCadenaOriginal = getCO();

                resCO = "Cadena Original: " + Environment.NewLine + getCO() + Environment.NewLine;
                msgCertidicado = "No de certificado" + Environment.NewLine + noCertificado;
                resultadoVal = msj + resSello + resExistCer; //resVigCer + 
                resultadoVal += resFolser + msgVesiondoc + resCO + msgCertidicado;
            }
        }

        private void AgregarXsd(string xsdFileName)
        {
            if (this._xsdList.Exists((Predicate<string>)(i => i.Equals(xsdFileName))))
                return;
            this._xsdList.Add(xsdFileName);
        }

        private bool Validar(XmlDocument xDoc)
        {
            int num1 = 5;
            int num2 = 0;
            bool flag;
            do
            {
                ++num2;
                try
                {
                    XmlSchemaSet xmlSchemaSet = new XmlSchemaSet();
                    string inputUri = AppDomain.CurrentDomain.BaseDirectory + "xsd\\cfdv33.xsd";
                    xmlSchemaSet.Add(XmlSchema.Read(XmlReader.Create(inputUri), new ValidationEventHandler(this.ValidationCallback)));
                    xDoc.Schemas = xmlSchemaSet;
                    xDoc.Validate((ValidationEventHandler)((o, e) =>
                    {
                        throw new Exception("CUSTOM_EXCEPTION:" + e.Message);
                    }));
                    flag = true;
                }
                catch (Exception ex)
                {
                    this.menCFDI33 = "";
                    flag = false;
                    if (num2 >= num1)
                    {
                        this._metodoActual = MethodBase.GetCurrentMethod().Name;
                        this.menCFDI33 = ex.ToString();
                    }
                }
            }
            while (!flag && num2 <= num1);
            return flag;
        }

        private void ValidationCallback(object sender, ValidationEventArgs args)
        {
            switch (args.Severity)
            {
                case XmlSeverityType.Error:
                    throw new Exception("CUSTOM_EXCEPTION:ERROR: " + args.Message);
                case XmlSeverityType.Warning:
                    throw new Exception("CUSTOM_EXCEPTION:ADVERTENCIA: " + args.Message);
            }
        }

        private void estructura(XmlTextReader xmlTR)
        {
            String[] esquemas;
            esquemas = (xsi_schemaLocation + " " + xsi_schemaLocation_cfdi).Split();
            foreach (string esq in esquemas)
            {
                if (esq.IndexOf(".xsd") > 0)
                {
                    WebClient webClient = new WebClient();
                    VE.agregarSchemas(webClient.DownloadData(esq));
                }
            }
            VE.Validar(xmlTR);
            msj += VE.msj;
            msjT += VE.msjT;
            msgEstructura = msj.Replace('\r', ' ').Replace('\n', ' ');
        }

        private Boolean validarCadena(XmlDocument xtr)
        {
            string fileCer = "", urlCer = "", timbre = "";
            string certificadoCFD = "";
            // StringWriter sw = new StringWriter() ;
            try
            {
                string dir = AppDomain.CurrentDomain.BaseDirectory + @"xslt\";
                Val.version = version;
                Val.fecha = fecha2;
                CO = Val.generaCadena(dir, xtr);

                if (String.IsNullOrEmpty(certificado))
                {
                    certificadoCFD = obtenerCertificado(noCertificado);
                }
                else
                {
                    certificadoCFD = certificado;

                }

                if (!(xsi_schemaLocation.IndexOf("ventavehiculos11") < 0) || !(xsi_schemaLocation.IndexOf("cfdv32") < 0))
                {
                    banXc = "SI";
                }

                if (Val.validarXML(sello, certificadoCFD, banXc))
                {
                    xmlns_xsd = "";
                    xsi_schemaLocation = "";
                    if (banCFDI)
                    {
                        WebClient webClient = new WebClient();
                        XmlNode xmlNode = null;
                        XmlDocument xtrtfd = new XmlDocument();
                        xmlNode = xtr.GetElementsByTagName("tfd:TimbreFiscalDigital")[0];
                        timbre = xmlNode.OuterXml;
                        xtrtfd.LoadXml(timbre);

                        Val.version = "tfd1.0";
                        Val.fecha = fecha2;
                        fileCer = AppDomain.CurrentDomain.BaseDirectory + @"certificados\" + noCertificado + ".cer";

                        Val.generaCadena(dir, xtrtfd);
                        certificadoSAT = obtenerCertificado(noCertificadoSAT);

                        return true;
                    }
                    else
                    {//Este es para cuando es un CFD
                        return true;
                    }
                }
                else
                {
                    //MessageBox.Show("errror de sello");
                    return false;
                }

            }
            catch (Exception e)
            {
                msj = e.ToString();
                using (StreamWriter outfile = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"\errror.txt"))
                {
                    outfile.Write(e.ToString());
                }
                return false;

            }
        }

        public string obtenerCertificado(string CertificadoSAT)
        {
            string fileCer = "", urlCer = "", valor = "", valor2 = "";
            try
            {
                fileCer = AppDomain.CurrentDomain.BaseDirectory + @"certificados\" + CertificadoSAT + ".cer";
                String arc = AppDomain.CurrentDomain.BaseDirectory;
                //string serverPath = "ftp://ftp2.sat.gob.mx/Certificados/FEA/000010/000002/01/02/04/00001000000201020449.cer";

                if (!System.IO.File.Exists(fileCer))
                {
                    urlCer = "ftp://ftp2.sat.gob.mx/Certificados/FEA/" + "/" + CertificadoSAT.Substring(0, 6) + "/";
                    urlCer += CertificadoSAT.Substring(6, 6) + "/" + CertificadoSAT.Substring(12, 2) + "/";
                    urlCer += CertificadoSAT.Substring(14, 2) + "/" + CertificadoSAT.Substring(16, 2) + "/" + CertificadoSAT + ".cer";
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(urlCer);
                    request.KeepAlive = true;
                    request.UsePassive = true;
                    request.UseBinary = true;
                    request.Method = WebRequestMethods.Ftp.DownloadFile;
                    request.Credentials = new NetworkCredential();

                    using (var response = (FtpWebResponse)request.GetResponse())
                    {
                        using (var fileStream = File.Create(arc + @"certificados\" + CertificadoSAT + ".cer"))
                        {
                            response.GetResponseStream().CopyTo(fileStream);
                            ban = true;
                        }
                    }
                }
                valor = Val.extraerCertificado(fileCer);
                return valor;
            }
            catch (Exception t)
            {
                if (ban == false)
                {
                    if (auxContCer < 10)
                    {
                        auxContCer++;
                        this.obtenerCertificado(CertificadoSAT);
                    }
                }
                return valor;
            }
        }

        private bool operaciones()
        {
            decimal suma = 0;
            bool ax = true;
            foreach (String[] obj in arrayListConceptos)
            {
                suma = suma + Convert.ToDecimal(obj[5]);
            }

            foreach (string[] val in arrayListImpuestosT)
            {
                suma = suma + Convert.ToDecimal(val[2]);
            }

            if (descuento != "")
            {
                if (Convert.ToDecimal(descuento) > 0)
                {
                    suma = suma - Convert.ToDecimal(descuento);
                }
            }

            foreach (string[] val in arrayListImpuestosR)
            {
                suma = suma - Convert.ToDecimal(val[2]);
            }


            if (suma == Convert.ToDecimal(total))
            {
                return true;
            }
            else
            {
                string totAux = "";
                suma = Truncate(Convert.ToDecimal(suma), 1);
                totAux = Truncate(Convert.ToDecimal(total), 1).ToString();

                string[] redon = suma.ToString().Split('.');
                if (Convert.ToInt32(redon[1]) == 9)
                {
                    if (suma != Convert.ToDecimal(totAux))
                    {
                        suma = Convert.ToDecimal(Convert.ToDouble(suma) + 0.1);
                    }
                }
                Decimal diferencia = suma - Convert.ToDecimal(totAux);
                if (Math.Abs(diferencia) <= Convert.ToDecimal("0.90"))
                {
                    suma = Convert.ToDecimal(totAux);
                }

                if (suma == Convert.ToDecimal(totAux))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private bool operaciones33()
        {
            try
            {
                Decimal num1 = new Decimal();
                foreach (string[] arrayListConcepto in arrayListConceptos)
                    num1 += Convert.ToDecimal(arrayListConcepto[5]);
                if (arrayListImpuestosT.Count > 0)
                {
                    foreach (string[] strArray in arrayListImpuestosT)
                        num1 += Convert.ToDecimal(strArray[3]);
                }

                if (this.descuento != "" && Convert.ToDecimal(descuento) > Decimal.Zero)
                    num1 -= Convert.ToDecimal(descuento);
                if (arrayListImpuestosR.Count > 0)
                {
                    foreach (string[] strArray in arrayListImpuestosR)
                        num1 -= Convert.ToDecimal(strArray[2]);
                }
                if (num1 == Convert.ToDecimal(total))
                    return true;
                Decimal num2 = Truncate(Convert.ToDecimal(num1), 1);
                string str = Truncate(Convert.ToDecimal(total), 1).ToString();
                if (Convert.ToInt32(num2.ToString().Split('.')[1]) == 9 && num2 != Convert.ToDecimal(str))
                    num2 = Convert.ToDecimal(Convert.ToDouble(num2) + 0.1);
                if (Math.Abs(num2 - Convert.ToDecimal(str)) <= Convert.ToDecimal("0.90"))
                    num2 = Convert.ToDecimal(str);
                return num2 == Convert.ToDecimal(str);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool valTasa()
        {
            bool auxTa = true; ;
            if (arrayImpuestosT != null)
            {
                if (arrayImpuestosT.Count() > 0)
                {
                    foreach (string[] val in arrayListImpuestosT)
                    {
                        if (!(val[1].IndexOf(".") < 0))
                        {
                            string[] auxT = val[1].Split('.');
                            decimal valor = Convert.ToDecimal(auxT[1].ToString());
                            if (valor > 0)
                            {
                                //auxTa = false;
                                auxTa = true;
                            }

                        }
                    }
                }
            }
            if (auxTa)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool varRetFletes()
        {
            if (TipoProveedor == "FLETES" && tipoDeComprobante.ToLower() != "egreso" || (tipoDeComprobante.Equals("E")))
            {
                if (totalImpuestosRetenidos != "" || (tipoDeComprobante.Equals("E")) || (tipoDeComprobante.Equals("I")))
                {

                    if ((tipoDeComprobante.Equals("E")) || (tipoDeComprobante.Equals("I")))
                    {
                        return true;
                    }
                    else if (Convert.ToDecimal(totalImpuestosRetenidos) > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        private bool valTiProv() //Valida campos obligatorios segun tipo de proveedor
        {
            bool val_Risr = false;
            bool val_Riva = false;
            switch (TipoProveedor.ToUpper())
            {
                case "FLETES":
                    foreach (string[] val in arrayListImpuestosR)
                    {
                        if (!version.Equals("3.3"))
                        {
                            if ((val[0].ToString() == "IVA" && Convert.ToDecimal(val[2].ToString()) >= 0))
                            {
                                val_Riva = true;
                            }
                        }
                        else
                        {
                            if ((val[0].ToString() == "002" && Convert.ToDecimal(val[2].ToString()) >= 0))
                            {
                                val_Riva = true;
                            }
                        }

                    }
                    if ((tipoDeComprobante.ToLower().Equals("ingreso") || (tipoDeComprobante.ToLower().Equals("egreso") && valida_fleteDesc)) || (tipoDeComprobante.ToUpper().Equals("I") || (tipoDeComprobante.ToUpper().Equals("E") && valida_fleteDesc)))
                    {
                        if (val_Riva)
                        {
                            if (valida_Desc_motDes)
                            {
                                return true;
                            }

                            else
                            {
                                copiarArc(nomTemp, rutaBCK, nombreSE, rfcEmisor, ordenCompra);
                                mensajeEmailError("RE045", "", emails);
                                mensajesLog("RE045", "", "", emails, "");
                                return false;
                            }
                        }
                        else
                        {
                            copiarArc(nomTemp, rutaBCK, nombreSE, rfcEmisor, ordenCompra);
                            mensajeEmailError("RE033", "", emails);
                            mensajesLog("RE033", "", "", emails, "");
                            return false;
                        }
                    }
                    else
                    {
                        if ((tipoDeComprobante.ToLower().Equals("egreso") && valida_fleteDesc == false) || (tipoDeComprobante.ToUpper().Equals("E") && valida_fleteDesc == false))
                        {
                            if (val_Riva == false)
                            {
                                if (valida_Desc_motDes)
                                {
                                    return true;
                                }
                                else
                                {
                                    copiarArc(nomTemp, rutaBCK, nombreSE, rfcEmisor, ordenCompra);
                                    mensajeEmailError("RE045", "", emails);
                                    mensajesLog("RE045", "", "", emails, "");
                                    return false;
                                }
                            }
                            else
                            {
                                copiarArc(nomTemp, rutaBCK, nombreSE, rfcEmisor, ordenCompra);
                                mensajeEmailError("RE042", "", emails);
                                mensajesLog("RE042", "", "", emails, "");
                                return false;


                            }

                        }
                        copiarArc(nomTemp, rutaBCK, nombreSE, rfcEmisor, ordenCompra);
                        mensajeEmailError("RE027", "", emails);
                        mensajesLog("RE027", "", "", emails, "");
                        return false;
                    }
                case "BIENES Y SERVICIOS":
                    foreach (string[] val in arrayListImpuestosT)
                    {
                        if (!version.Equals("3.3"))
                        {
                            if ((val[0].ToString() == "IEPS" && Convert.ToDecimal(val[2].ToString()) < 0))
                            {
                                copiarArc(nomTemp, rutaBCK, nombreSE, rfcEmisor, ordenCompra);
                                mensajeEmailError("RE041", "", emails);
                                mensajesLog("RE041", "", "", emails, "");
                                return false;
                            }
                        }
                        else
                        {
                            if ((val[0].ToString() == "003" && Convert.ToDecimal(val[2].ToString()) < 0))
                            {
                                copiarArc(nomTemp, rutaBCK, nombreSE, rfcEmisor, ordenCompra);
                                mensajeEmailError("RE041", "", emails);
                                mensajesLog("RE041", "", "", emails, "");
                                return false;
                            }
                        }

                    }
                    return true;
                case "HOSPEDAJES Y CONVENCIONES":
                    foreach (string[] val in arrayListImpuestosR)
                    {
                        if ((val[0].ToString() == "OTROS" && Convert.ToDecimal(val[2].ToString()) < 0))
                        {
                            copiarArc(nomTemp, rutaBCK, nombreSE, rfcEmisor, ordenCompra);
                            mensajeEmailError("RE035", "", emails);
                            mensajesLog("RE035", "", "", emails, "");
                            return false;
                        }

                    }
                    return true;
                case "HONORARIOS":
                    foreach (string[] val in arrayListImpuestosR)
                    {
                        if (!version.Equals("3.3"))
                        {
                            if ((val[0].ToString() == "IVA" && Convert.ToDecimal(val[2].ToString()) >= 0))
                            {
                                val_Riva = true;
                            }
                            if ((val[0].ToString() == "ISR" && Convert.ToDecimal(val[2].ToString()) >= 0))
                            {
                                val_Risr = true;
                            }
                        }
                        else
                        {
                            if ((val[0].ToString() == "002" && Convert.ToDecimal(val[2].ToString()) >= 0))
                            {
                                val_Riva = true;
                            }
                            if ((val[0].ToString() == "001" && Convert.ToDecimal(val[2].ToString()) >= 0))
                            {
                                val_Risr = true;
                            }
                        }
                    }
                    if (val_Risr)
                    {
                        if (val_Riva)
                        {
                            return true;
                        }
                        else
                        {
                            copiarArc(nomTemp, rutaBCK, nombreSE, rfcEmisor, ordenCompra);
                            mensajeEmailError("RE033", "", emails);
                            mensajesLog("RE033", "", "", emails, "");
                        }
                    }
                    else
                    {
                        copiarArc(nomTemp, rutaBCK, nombreSE, rfcEmisor, ordenCompra);
                        mensajeEmailError("RE034", "", emails);
                        mensajesLog("RE034", "", "", emails, "");
                    }
                    return false;
                case "RENTAS":
                    return true;
                default:
                    return true;
            }
        }

        private Boolean valida_PaisRecep(String rfc)
        {
            String pais = "";
            DB.Conectar();
            DB.CrearComando("select PAIREC from RECEPTOR where RFCREC=@RFC");
            DB.AsignarParametroCadena("@RFC", rfc);
            DbDataReader DR = DB.EjecutarConsulta();

            while (DR.Read())
            {
                pais = DR[0].ToString().ToUpper().Replace("É", "E");
            }
            DB.Desconectar();

            if (pais.Equals(paisReceptor.ToUpper().Replace("É", "E").Replace(".", "").Replace("  ", " ").Replace("   ", " ").Replace("    ", " ").Trim()) || paisReceptor.ToUpper().Replace("É", "E").Replace(".", "").Replace("  ", " ").Replace("   ", " ").Trim().Equals("MEX") || paisReceptor.ToUpper().Replace("É", "E").Replace(".", "").Replace("  ", " ").Replace("   ", " ").Trim().Equals("MX"))
            {
                return true;

            }
            copiarArc(nomTemp, rutaBCK, nombreSE, rfcEmisor, ordenCompra);
            mensajeEmailError("RE039", "", emails);
            mensajesLog("RE039", "", "", emails, "");
            return false;
        }

        private Boolean validar_domicilioReceptor(string rfc)
        {
            String nombre = "", calle = "", noExt = "", noInt = "", colonia = "", mpio = "", estado = "", pais = "", CP = "", auxNoExt = "";
            DB.Conectar();
            DB.CrearComando("select NOMREC, CALLEREC, NUMEXTREC, NUMINTREC, COLREC, MUNREC, EDOREC, PAIREC, CODREC from RECEPTOR where RFCREC=@RFC");
            DB.AsignarParametroCadena("@RFC", rfc);
            DbDataReader DR = DB.EjecutarConsulta();
            while (DR.Read())
            {
                nombre = DR[0].ToString().ToUpper().Replace(".", "").Replace(",", "").Replace("É", "E");
                calle = DR[1].ToString().ToUpper().Replace("É", "E").Replace("-", " ");
                noExt = DR[2].ToString().ToUpper();
                noInt = DR[3].ToString().ToUpper();
                colonia = DR[4].ToString().ToUpper();
                mpio = DR[5].ToString().ToUpper().Replace("Á", "A").Replace(",", "");
                estado = DR[6].ToString().ToUpper().Replace("É", "E");
                pais = DR[7].ToString().ToUpper().Replace("É", "E");
                CP = DR[8].ToString();
            }
            DB.Desconectar();
            if (noExteriorReceptor.IndexOf(".") == 2)
            {
                noExteriorReceptor = noExteriorReceptor.Remove(2, 1);
            }
            if (nombre.Equals(nombreReceptor.ToUpper().Replace(".", "").Replace(",", "").Replace("É", "E").Replace("  ", " ").Replace("   ", " ").Replace("    ", " ").Trim()))
            {
                if (calle.Equals(calleReceptor.ToUpper().Replace("É", "E").Replace("-", " ").Replace("  ", " ").Replace("   ", " ").Replace("    ", " ").Trim()))
                {
                    if (noExt.Equals(noExteriorReceptor.ToUpper().Replace("  ", " ").Replace("   ", " ").Replace("    ", " ").Trim()))
                    {
                        if (noInt.Equals(noInteriorReceptor.ToUpper().Replace("  ", " ").Replace("   ", " ").Replace("    ", " ").Trim()))
                        {
                            if (colonia.Equals(coloniaReceptor.ToUpper().Replace("  ", " ").Replace("   ", " ").Replace("    ", " ").Trim()))
                            {
                                if (mpio.Equals(municipioReceptor.ToUpper().Replace("Á", "A").Replace(",", "").Replace("  ", " ").Replace("   ", " ").Replace("    ", " ").Trim()))
                                {
                                    if (estado.Equals(estadoReceptor.ToUpper().Replace("É", "E").Replace("  ", " ").Replace("   ", " ").Replace("    ", " ").Trim()))
                                    {
                                        if (pais.Equals(paisReceptor.ToUpper().Replace("É", "E").Replace(".", "").Replace("  ", " ").Replace("   ", " ").Replace("    ", " ").Trim()) || paisReceptor.ToUpper().Replace("É", "E").Replace(".", "").Replace("  ", " ").Replace("   ", " ").Trim().Equals("MEX") || paisReceptor.ToUpper().Replace("É", "E").Replace(".", "").Replace("  ", " ").Replace("   ", " ").Trim().Equals("MX"))
                                        {
                                            if (CP.Equals(codigoPostalReceptor.ToUpper().Replace("  ", " ").Replace("   ", " ").Replace("    ", " ").Trim()))
                                            {
                                                return true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                //falta nombre receptor
                copiarArc(nomTemp, rutaBCK, nombreSE, rfcEmisor, ordenCompra);
                mensajeEmailError("RE0328", "", emails);
                mensajesLog("RE038", "", "", emails, "");
                return false;
            }
            copiarArc(nomTemp, rutaBCK, nombreSE, rfcEmisor, ordenCompra);
            mensajeEmailError("RE039", "", emails);
            mensajesLog("RE039", "", "", emails, "");
            return false;
        }

        private bool valret()
        {
            bool aux = true;
            if (arrayImpuestosR != null)
            {
                if (arrayImpuestosR.Count() > 0)
                {
                    foreach (string[] val in arrayListImpuestosR)
                    {
                        // if ((val[0].ToString() == "ISR" && Convert.ToDecimal(val[2].ToString()) >=0 && TipoProveedor != "HONORARIOS" && TipoProveedor != "RENTAS"))
                        if ((val[0].ToString() == "ISR" && Convert.ToDecimal(val[2].ToString()) >= 0 && TipoProveedor == "HONORARIOS" && TipoProveedor == "RENTAS"))
                        {
                            aux = false;
                        }
                    }

                    if (aux)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        private void guardarBD1()
        {
            IDEFAC = "";
            IDEREC = "";
            IDEEMI = "";
            IDPROVEMI = "";
            IDEDOMEMIEXP = "";
            string str1 = "";
            var uid = "";
            var uid1 = "";
            var uid2 = "";
            if (!this.tipoDeComprobante.Equals("P"))
            {
                #region SAVE CFDI 3.2 AND 3.3
                BasesDatos BD = new BasesDatos();
                #region CONSULTAR UUID
                BD.Conectar();
                BD.CrearComando(@"SELECT UUID FROM CFDI WHERE UUID = @UUID;");
                BD.AsignarParametroCadena("@UUID", UUID);
                var dr = BD.EjecutarConsulta();
                if (dr.HasRows && dr.Read())
                {
                    uid = dr["UUID"].ToString();
                    BD.Desconectar();
                }
                BD.Desconectar();
                #endregion
                if (!UUID.Equals(uid, StringComparison.OrdinalIgnoreCase))///////////valida que uuid no exista en tabla cfdi
                {
                    if (idProvE2(rfcEmisor))
                    {
                        try
                        {
                            #region SAVE RECEPTOR
                            if (String.IsNullOrEmpty(Receptor(rfcReceptor)))
                            {
                                DB.Conectar();
                                DB.CrearComando(@"insert into Receptor
                                (RFCREC,NOMREC,CALLEREC,NUMEXTREC,NUMINTREC,COLREC,MUNREC,EDOREC,PAIREC,LOCREC,CODREC,REFREC) 
                                values 
                                (@RFCREC,@NOMREC,@DOMREC,@NUMEXTREC,@NUMINTREC,@COLREC,@MUNREC,@EDOREC,@PAIREC,@LOCREC,@CODREC,@REFREC)");
                                DB.AsignarParametroCadena("@RFCREC", rfcReceptor);
                                DB.AsignarParametroCadena("@NOMREC", nombreReceptor);
                                DB.AsignarParametroCadena("@DOMREC", calleReceptor);
                                DB.AsignarParametroCadena("@NUMEXTREC", noExteriorReceptor);
                                DB.AsignarParametroCadena("@NUMINTREC", noInteriorReceptor);
                                DB.AsignarParametroCadena("@COLREC", coloniaReceptor);
                                DB.AsignarParametroCadena("@MUNREC", municipioReceptor);
                                DB.AsignarParametroCadena("@EDOREC", estadoReceptor);
                                DB.AsignarParametroCadena("@PAIREC", paisReceptor);
                                DB.AsignarParametroCadena("@LOCREC", localidadReceptor);
                                DB.AsignarParametroCadena("@CODREC", codigoPostalReceptor);
                                DB.AsignarParametroCadena("@REFREC", referenciaEmisor);
                                if (ResidenciaFiscal.Equals((string)null))
                                    DB.AsignarParametroCadena("@ResidenciaFiscal", "-");
                                else
                                    DB.AsignarParametroCadena("@ResidenciaFiscal", ResidenciaFiscal);
                                if (UsoCFDI.Equals((string)null))
                                    DB.AsignarParametroCadena("@usoCFDI", "-");
                                else
                                    DB.AsignarParametroCadena("@usoCFDI", UsoCFDI);
                                DB.EjecutarConsulta1();
                                DB.Desconectar();
                            }
                            #endregion
                            IDEREC = Receptor(rfcReceptor);
                            # region SAVE EMISOR
                            if (String.IsNullOrEmpty(Emisor(rfcEmisor)))
                            {
                                DB.Conectar();
                                DB.CrearComando(@"insert into Emisor 
                                (RFCEMI,NOMEMI,CALLEEMI,NUMEXTEMI,NUMINTEMI,COLEMI,MUNEMI,EDOEMI,PAIEMI,CODEMI,REGIMEN,LOCEMI,REFEMI) 
                                values 
                                (@RFCEMI,@NOMEMI,@DOMEMIEXP,@NUMEXTEMI,@NUMINTEMI,@COLEMI,@MUNEMI,@EDOEMI,@PAIEMI,@CODEMI,@REGIMEN,@LOCEMI,@REFEMI)");
                                DB.AsignarParametroCadena("@RFCEMI", rfcEmisor);
                                DB.AsignarParametroCadena("@NOMEMI", nombreEmisor);
                                DB.AsignarParametroCadena("@DOMEMIEXP", calleEmisor);
                                DB.AsignarParametroCadena("@NUMEXTEMI", noExteriorEmisor);
                                DB.AsignarParametroCadena("@NUMINTEMI", noInteriorEmisor);
                                DB.AsignarParametroCadena("@COLEMI", coloniaEmisor);
                                DB.AsignarParametroCadena("@MUNEMI", municipioEmisor);
                                DB.AsignarParametroCadena("@EDOEMI", estadoEmisor);
                                DB.AsignarParametroCadena("@PAIEMI", paisEmisor);
                                DB.AsignarParametroCadena("@CODEMI", codigoPostalEmisor);
                                DB.AsignarParametroCadena("@REGIMEN", Regimen);
                                DB.AsignarParametroCadena("@LOCEMI", localidadEmisor);
                                DB.AsignarParametroCadena("@REFEMI", referenciaEmisor);
                                DB.EjecutarConsulta1();
                                DB.Desconectar();
                            }
                            #endregion
                            IDEEMI = Emisor(rfcEmisor);
                            IDPROVEMI = idProvE(rfcEmisor);
                            IDEDOMEMIEXP = consultarIDE(codigoPostalEmisorExp, calleEmisorExp, "CODEMIEXP", "CALLEEMIEXP", "select IDEDOMEMIEXP from DOMEMIEXP where ");
                            #region SAVE DOMEMIEXP
                            if (String.IsNullOrEmpty(IDEDOMEMIEXP))
                            {
                                DB.Conectar();
                                DB.CrearComando(@"insert into DOMEMIEXP 
                                (CALLEEMIEXP,NUMEXTEMIEXP,NUMINTEMIEXP,COLEMIEXP,MUNEMIEXP,EDOEMIEXP,PAIEMIEXP,CODEMIEXP,LOCEMIEXP,REFEMIEXP) 
                                values 
                                (@DOMEMIEXP,@NUMEXTEMIEXP,@NUMINTEMIEXP,@COLEMIEXP,@MUNEMIEXP,@EDOEMIEXP,@PAIEMIEXP,@CODEMIEXP,@LOCEMIEXP,@REFEMIEXP)");
                                DB.AsignarParametroCadena("@DOMEMIEXP", calleEmisorExp);
                                DB.AsignarParametroCadena("@NUMEXTEMIEXP", noExteriorEmisorExp);
                                DB.AsignarParametroCadena("@NUMINTEMIEXP", noInteriorEmisorExp);
                                DB.AsignarParametroCadena("@COLEMIEXP", coloniaEmisorExp);
                                DB.AsignarParametroCadena("@MUNEMIEXP", municipioEmisorExp);
                                DB.AsignarParametroCadena("@EDOEMIEXP", estadoEmisorExp);
                                DB.AsignarParametroCadena("@PAIEMIEXP", paisEmisorExp);
                                DB.AsignarParametroCadena("@CODEMIEXP", codigoPostalEmisorExp);
                                DB.AsignarParametroCadena("@LOCEMIEXP", localidadEmisorExp);
                                DB.AsignarParametroCadena("@REFEMIEXP", referenciaEmisorExp);
                                DB.EjecutarConsulta1();
                                DB.Desconectar();
                                IDEDOMEMIEXP = consultarIDE(codigoPostalEmisorExp, calleEmisorExp, "CODEMIEXP", "CALLEEMIEXP", "select IDEDOMEMIEXP from DOMEMIEXP where ");
                            }
                            #endregion
                            #region SAVE GENERAL
                            DB.Conectar();
                            DB.CrearComando(@"insert into General 
                                (xmlns,xmlns_xsi, xmlns_xsd, xsi_schemaLocation, version, serie, folio, fecha, sello, noAprobacion, anoAprobacion,
                                formaDePago,condicionesDePago, noCertificado, certificado, subTotal, total, tipoDeComprobante,metodoDePago, LugarExpedicion,
                                descuento, Moneda, NumCtaPago,TipoCambio,totalImpuestosTrasladados,totalImpuestosRetenidos,
                                id_Receptor,id_Emisor,IDE_DOMEMIEXP,tipoOrden,fechaRec,edoFact,detalleVal,resultadoVal,CodCont, tipProv,fechaUltimCam, fechaRechazo,causaRechazo,fechEmi,impuestos,retenciones,propinas,parentInvoice,tipCfdi,correoContac,estatus,idProv,estadoInterface,estadoReporte,noSabana,siteOrigen,correoAnalista,motivoDesc,facSAT,id_usuario,persFac, Confirmacion, nameFinancialCC,ImpSaldoAnt,ImpSaldoPagado,ImpSaldoInsoluto) 
                                output inserted.idFactura
                                values 
                               (@xmlns,@xmlns_xsi,@xmlns_xsd,@xsi_schemaLocation,@version,@serie,@folio,@fecha,@sello,@noAprobacion,@anoAprobacion,
                                @formaDePago,@condicionesDePago,@noCertificado,@certificado,@subTotal,@total,@tipoDeComprobante,@metodoDePago,@LugarExpedicion,
                                @descuento,@Moneda,@NumCtaPago,@TipoCambio,@totalImpuestosTrasladados,@totalImpuestosRetenidos,
                                @id_Receptor,@id_Emisor,@IDE_DOMEMIEXP,@tipoOrden,@fechaRec,@edoFact,@detalleVal,@resultadoVal,@CodCont, @tipProv,@fechaUltimCam,@fechaRechazo,@causaRechazo,@fechEmi,@impuestos,@retenciones,@propinas,@parentInvoice,@tipCfdi,@correoContac,@estatus,@idProv,@estadoInterface,@estadoReporte,@noSabana,@siteOrigen,@correoAnalista,@motivoDesc,@facSAT,@id_usuario,@persFac, @Confirmacion, @nameFinancialCC,@ImpSaldoAnt,@ImpSaldoPagado,@ImpSaldoInsoluto)  ");
                            DB.AsignarParametroCadena("@xmlns", xmlns);
                            DB.AsignarParametroCadena("@xmlns_xsi", xmlns_xsi);
                            DB.AsignarParametroCadena("@xmlns_xsd", xmlns_xsd);
                            DB.AsignarParametroCadena("@xsi_schemaLocation", xsi_schemaLocation);
                            DB.AsignarParametroCadena("@version", version);
                            DB.AsignarParametroCadena("@serie", serie);
                            DB.AsignarParametroCadena("@folio", folio);
                            DB.AsignarParametroCadena("@fecha", fecha2);
                            DB.AsignarParametroCadena("@sello", sello);
                            DB.AsignarParametroCadena("@noAprobacion", noAprobacion);
                            DB.AsignarParametroCadena("@anoAprobacion", anoAprobacion);
                            DB.AsignarParametroCadena("@formaDePago", formaDePago);
                            DB.AsignarParametroCadena("@condicionesDePago", condicionesDePago);
                            DB.AsignarParametroCadena("@noCertificado", noCertificado);
                            DB.AsignarParametroCadena("@certificado", certificado);
                            if (tipoDeComprobante.ToLower() == "egreso" || tipoDeComprobante.ToUpper() == "E")
                            {
                                DB.AsignarParametroCadena("@subTotal", cerosNull("-" + subTotal));
                                DB.AsignarParametroCadena("@total", cerosNull("-" + total));

                            }
                            else
                            {
                                DB.AsignarParametroCadena("@subTotal", cerosNull(subTotal));
                                DB.AsignarParametroCadena("@total", cerosNull(total));
                            }
                            if (version.Equals("3.3"))
                            {
                                string valor = "";
                                if (tipoDeComprobante.Equals("I")) valor = "ingreso";
                                if (tipoDeComprobante.Equals("E")) valor = "egreso";
                                if (tipoDeComprobante.Equals("P")) valor = "pago";
                                if (tipoDeComprobante.Equals("T")) valor = "traslado";
                                this.DB.AsignarParametroCadena("@tipoDeComprobante", valor);
                            }
                            else
                                DB.AsignarParametroCadena("@tipoDeComprobante", tipoDeComprobante);
                            DB.AsignarParametroCadena("@metodoDePago", metodoDePago);
                            DB.AsignarParametroCadena("@LugarExpedicion", LugarExpedicion);
                            if (descuento != "")
                            {
                                if (Convert.ToDecimal(descuento) > 0)
                                {
                                    // if ((tipoDeComprobante.ToLower() == "egreso" && (propinas != 0)) || (tipoDeComprobante.ToUpper() == "E" && (propinas != 0))) { DB.AsignarParametroCadena("@descuento", cerosNull(descuento)); }
                                    if ((tipoDeComprobante.ToLower() == "egreso") || (tipoDeComprobante.ToUpper() == "E")) { DB.AsignarParametroCadena("@descuento", cerosNull(descuento)); }
                                    else { DB.AsignarParametroCadena("@descuento", cerosNull("-" + descuento)); }
                                }
                                else
                                {
                                    DB.AsignarParametroCadena("@descuento", cerosNull(descuento));
                                }
                            }
                            else
                            {
                                DB.AsignarParametroCadena("@descuento", cerosNull(descuento));
                            }
                            DB.AsignarParametroCadena("@Moneda", moneda);
                            DB.AsignarParametroCadena("@NumCtaPago", NumCtaPago);
                            DB.AsignarParametroCadena("@TipoCambio", cerosNull(TipoCambio));
                            //      DB.AsignarParametroEntero("@dsd", System.);
                            // DB.AsignarParametroEntero("@TipoCambio", System.Data.SqlDbType.Int);
                            DB.AsignarParametroCadena("@totalImpuestosRetenidos", cerosNull(totalImpuestosRetenidos));
                            if (tipoDeComprobante.ToLower() == "egreso" || tipoDeComprobante.ToUpper() == "E")
                            {
                                if (totalImpuestosRetenidos != "")
                                {
                                    DB.AsignarParametroCadena("@totalImpuestosTrasladados", cerosNull("-" + totalImpuestosTrasladados));
                                }
                                else { DB.AsignarParametroCadena("@totalImpuestosTrasladados", cerosNull(totalImpuestosTrasladados)); }
                            }
                            else
                            {
                                DB.AsignarParametroCadena("@totalImpuestosTrasladados", cerosNull(totalImpuestosTrasladados));
                            }
                            DB.AsignarParametroCadena("@id_Receptor", IDEREC);
                            DB.AsignarParametroCadena("@id_Emisor", IDEEMI);
                            DB.AsignarParametroCadena("@IDE_DOMEMIEXP", IDEDOMEMIEXP);
                            TIPOORDEN = "";
                            DB.AsignarParametroCadena("@tipoOrden", TIPOORDEN);
                            DB.AsignarParametroCadena("@fechaRec", System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
                            DB.AsignarParametroEntero("@edoFact", 1);
                            DB.AsignarParametroCadena("@detalleVal", "Factura Válida");
                            DB.AsignarParametroCadena("@CodCont", codContable);
                            cadRes += version + Environment.NewLine;
                            cadRes += rfcEmisor + Environment.NewLine;
                            cadRes += folio + serie + Environment.NewLine;
                            cadRes += noAprobacion + anoAprobacion + Environment.NewLine;
                            cadRes += msgEstructura + Environment.NewLine;
                            cadRes += noCertificado + Environment.NewLine;
                            cadRes += CO + Environment.NewLine;
                            cadRes += sello + Environment.NewLine;
                            DB.AsignarParametroCadena("@resultadoVal", "");
                            DB.AsignarParametroCadena("@tipProv", TipoProveedor);
                            DB.AsignarParametroCadena("@fechaUltimCam", System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
                            DB.AsignarParametroCadena("@fechaRechazo", "");
                            DB.AsignarParametroCadena("@causaRechazo", "");
                            DB.AsignarParametroCadena("@fechEmi", fecha2);
                            DB.AsignarParametroCadena("@impuestos", cerosNull(impuesto));
                            DB.AsignarParametroCadena("@retenciones", cerosNull(totalImpuestosRetenidos));
                            if (tipoDeComprobante.ToLower() == "egreso" && (propinas != 0.0) || tipoDeComprobante.ToUpper() == "E" && propinas != 0.0)
                            {
                                DB.AsignarParametroCadena("@propinas", cerosNull("-" + propinas.ToString()));
                            }
                            else
                            {
                                DB.AsignarParametroCadena("@propinas", cerosNull(propinas.ToString()));
                            }
                            DB.AsignarParametroCadena("@parentInvoice", pInvoice);
                            if (version.Equals("3.3"))
                            {
                                string valor = "";
                                if (tipoDeComprobante.Equals("I")) valor = "ingreso";
                                if (tipoDeComprobante.Equals("E")) valor = "egreso";
                                if (tipoDeComprobante.Equals("P")) valor = "pago";
                                if (tipoDeComprobante.Equals("T")) valor = "traslado";
                                this.DB.AsignarParametroCadena("@tipCfdi", valor);
                            }
                            else
                            {
                                DB.AsignarParametroCadena("@tipCfdi", tipoDeComprobante);
                            }
                            if (!(emails.IndexOf("@dhl.com") < 0))
                            {
                                DB.AsignarParametroCadena("@correoContac", emails);
                            }
                            else
                            {
                                DB.AsignarParametroCadena("@correoContac", "");
                            }
                            DB.AsignarParametroCadena("@estatus", "validado");
                            DB.AsignarParametroCadena("@idProv", IDPROVEMI);
                            DB.AsignarParametroCadena("@estadoInterface", "0");
                            DB.AsignarParametroCadena("@estadoReporte", "0");
                            DB.AsignarParametroCadena("@noSabana", NumSabana);
                            DB.AsignarParametroCadena("@siteOrigen", siteOri);
                            DB.AsignarParametroCadena("@correoAnalista", correosFin);
                            DB.AsignarParametroCadena("@motivoDesc", MotivoDescuento);
                            DB.AsignarParametroEntero("@facSAT", 0);
                            DB.AsignarParametroEntero("@id_usuario", id_usuario);
                            DB.AsignarParametroCadena("@persFac", usuarioFac);
                            if (confirmacion == null)
                                DB.AsignarParametroCadena("@Confirmacion", "-");
                            else
                                DB.AsignarParametroCadena("@Confirmacion", confirmacion);
                            DB.AsignarParametroCadena("@nameFinancialCC", nomFin);
                            DB.AsignarParametroCadena("@ImpSaldoAnt", "0.00");
                            DB.AsignarParametroCadena("@ImpSaldoPagado", "0.00");
                            DB.AsignarParametroCadena("@ImpSaldoInsoluto", "0.00");
                            var x = DB.EjecutarConsulta();
                            if (x.Read())
                            {
                                IDEFAC = x[0].ToString();
                            }
                            DB.Desconectar();
                            #endregion

                            BanBD = true;

                            try
                            {
                                if (!UUID.Equals(uid, StringComparison.OrdinalIgnoreCase))
                                {
                                    #region SAVE CFDI
                                    DB.Conectar();
                                    DB.CrearComando(@"INSERT INTO CFDI 
                                             (schemaLocation,version_tim,UUID,fechaTimbrado,numCertificadoSAT,selloSAT,tfd,xsi,cadenaCFDI,id_Factura) VALUES 
                                             (@schema,@ver,@uuid,@fectim,@numCert,@sello,@tfd,@xsi,@cad,@idfac)");
                                    DB.AsignarParametroCadena("@schema", xsi_schemaLocation);
                                    DB.AsignarParametroCadena("@ver", version_tim);
                                    DB.AsignarParametroCadena("@uuid", UUID);
                                    DB.AsignarParametroCadena("@fectim", FechTimbrado);
                                    DB.AsignarParametroCadena("@numCert", noCertificadoSAT);
                                    DB.AsignarParametroCadena("@sello", selloSAT);
                                    DB.AsignarParametroCadena("@tfd", xmlns_tfd_cfdi);
                                    DB.AsignarParametroCadena("@xsi", xmlns_xsi_cfdi);
                                    DB.AsignarParametroCadena("@cad", cadenaCFDI);
                                    DB.AsignarParametroEntero("@idfac", Convert.ToInt32(IDEFAC));
                                    DB.EjecutarConsulta1();
                                    DB.Desconectar();
                                    #endregion
                                }
                                else
                                {
                                    msj = msj + Environment.NewLine + "Factura registrada";
                                }


                                foreach (string[] obj in arrayListConceptos)
                                {
                                    #region SAVE COCEPTOS
                                    DB.Conectar();
                                    DB.CrearComando(@"insert into Conceptos 
                                (cantidad, unidad, noIdentificacion, descripcion, valorUnitario, importe,id_Factura, claveProdServ, claveUnidad) 
                                values 
                               (@cantidad,@unidad,@noIdentificacion,@descripcion,@valorUnitario,@importe,@id_Factura,@claveProdServ,@claveUnidad)");

                                    DB.AsignarParametroCadena("@cantidad", obj[0].ToString().Replace(",", "").Trim());
                                    DB.AsignarParametroCadena("@unidad", obj[1].ToString().Trim());
                                    DB.AsignarParametroCadena("@noIdentificacion", obj[2].ToString().Trim());
                                    DB.AsignarParametroCadena("@descripcion", obj[3].ToString().Trim());

                                    if (tipoDeComprobante.ToLower() == "egreso" || tipoDeComprobante.ToUpper() == "E")
                                    {
                                        if (rfcEmisor == "CFE370814QI0")  //////////////ajuste validacion CFE
                                        {
                                            DB.AsignarParametroCadena("@valorUnitario", "-" + obj[4].ToString().Replace(",", "").Trim());
                                            DB.AsignarParametroCadena("@importe", "-" + totalCFE_Fin.ToString());
                                        }
                                        else //////////////////resto de clientes
                                        {
                                            DB.AsignarParametroCadena("@valorUnitario", "-" + obj[4].ToString().Replace("-", "").Replace(",", "").Trim());
                                            DB.AsignarParametroCadena("@importe", "-" + obj[5].ToString().Replace("-", "").Replace(",", "").Trim());
                                        }
                                    }
                                    else
                                    {
                                        if (rfcEmisor == "CFE370814QI0") ///////////////////validacion CFE
                                        {
                                            DB.AsignarParametroCadena("@valorUnitario", obj[4].ToString().Replace(",", "").Trim());
                                            DB.AsignarParametroCadena("@importe", totalCFE_Fin.ToString());
                                        }
                                        else //////////////////////resto de clientes
                                        {
                                            DB.AsignarParametroCadena("@valorUnitario", obj[4].ToString().Replace("-", "").Replace(",", "").Trim());
                                            DB.AsignarParametroCadena("@importe", obj[5].ToString().Replace("-", "").Replace(",", "").Trim());
                                        }

                                    }
                                    DB.AsignarParametroCadena("@id_Factura", IDEFAC);
                                    if (ClaveProdServ == null)
                                        DB.AsignarParametroCadena("@claveProdServ", "-");
                                    else
                                        DB.AsignarParametroCadena("@claveProdServ", ClaveProdServ);
                                    if (ClaveUnidad == null)
                                        DB.AsignarParametroCadena("@claveUnidad", "-");
                                    else
                                        DB.AsignarParametroCadena("@claveUnidad", ClaveUnidad);

                                    DB.EjecutarConsulta1();
                                    DB.Desconectar();
                                }
                                #endregion
                                #region SAVE IMPUESTOSR
                                if (version.Equals("3.3"))
                                {
                                    foreach (string[] obj in arrayListImpuestosR)
                                    {
                                        DB.Conectar();
                                        DB.CrearComando(@"insert into Impuestos (impuesto, tasa, importe,tipo,id_Factura, tipoFactor) 
                                values (@impuesto, @tasa, @importe,@tipo,@id_Factura,@tipoFactor)");
                                        if (obj[0].ToString().Trim().Equals("002"))
                                        {
                                            DB.AsignarParametroCadena("@impuesto", "IVA");
                                        }
                                        if (obj[0].ToString().Trim().Equals("001"))
                                        { DB.AsignarParametroCadena("@impuesto", "ISR"); }
                                        if (obj[0].ToString().Trim().Equals("003"))
                                        { DB.AsignarParametroCadena("@impuesto", "IEPS"); }
                                        if (obj[1].ToString().Equals("0.160000") || obj[1].ToString().Equals("0.16")) { DB.AsignarParametroCadena("@tasa", "16.00"); }
                                        else { DB.AsignarParametroCadena("@tasa", obj[1].ToString().Replace(",", "").Trim()); }
                                        DB.AsignarParametroCadena("@importe", obj[2].ToString().Replace(",", "").Trim());
                                        DB.AsignarParametroCadena("@tipo", "R");
                                        DB.AsignarParametroCadena("@id_Factura", IDEFAC);
                                        if (TipoFactor == null) DB.AsignarParametroCadena("@tipoFactor", "-");
                                        else DB.AsignarParametroCadena("@tipoFactor", TipoFactor);
                                        DB.EjecutarConsulta1();
                                        DB.Desconectar();

                                    }
                                }
                                else
                                {
                                    #region CFDI 3.2
                                    foreach (string[] obj in arrayListImpuestosR)
                                    {
                                        DB.Conectar();
                                        DB.CrearComando(@"insert into Impuestos (impuesto, tasa, importe,tipo,id_Factura, tipoFactor) 
                                values (@impuesto, @tasa, @importe,@tipo,@id_Factura,@tipoFactor)");
                                        DB.AsignarParametroCadena("@impuesto", obj[0].ToString().Trim());
                                        DB.AsignarParametroCadena("@tasa", obj[1].ToString().Replace(",", "").Trim());
                                        DB.AsignarParametroCadena("@importe", obj[2].ToString().Replace(",", "").Trim());
                                        DB.AsignarParametroCadena("@tipo", "R");
                                        DB.AsignarParametroCadena("@id_Factura", IDEFAC);
                                        if (TipoFactor == null) DB.AsignarParametroCadena("@tipoFactor", "-");
                                        else DB.AsignarParametroCadena("@tipoFactor", TipoFactor);
                                        DB.EjecutarConsulta1();
                                        DB.Desconectar();
                                    }
                                    #endregion
                                }
                                #endregion
                                #region SAVE IMPUESTOST
                                if (version.Equals("3.3"))
                                {
                                    foreach (string[] obj in arrayListImpuestosT)
                                    {
                                        DB.Conectar();
                                        DB.CrearComando(@"insert into Impuestos (impuesto, tasa, importe,tipo,id_Factura,tipoFactor) 
                                values  (@impuesto, @tasa, @importe,@tipo,@id_Factura,@tipoFactor)");
                                        if (obj[0].ToString().Trim().Equals("002"))
                                        { DB.AsignarParametroCadena("@impuesto", "IVA"); }
                                        else if (obj[0].ToString().Trim().Equals("001"))
                                        { DB.AsignarParametroCadena("@impuesto", "ISR"); }
                                        else if (obj[0].ToString().Trim().Equals("003"))
                                        { DB.AsignarParametroCadena("@impuesto", "IEPS"); }
                                        else { DB.AsignarParametroCadena("@impuesto", "EXENTO"); }
                                        //DB.AsignarParametroCadena("@impuesto", obj[0].ToString().Trim());
                                        if (obj[2].ToString().Replace(",", "").Trim().Equals("0.160000") || (obj[2].ToString().Replace(",", "").Trim().Equals("0.16")) || obj[2].ToString().Replace(",", "").Trim().Contains("16")) { DB.AsignarParametroCadena("@tasa", "16.00"); }
                                        else { DB.AsignarParametroCadena("@tasa", obj[2].ToString().Replace(",", "").Trim()); }
                                        if (tipoDeComprobante.ToUpper() == "E")
                                        {
                                            DB.AsignarParametroCadena("@importe", "-" + obj[3].ToString().Replace(",", "").Trim());
                                        }
                                        else
                                        {
                                            DB.AsignarParametroCadena("@importe", obj[3].ToString().Replace(",", "").Trim());
                                        }
                                        DB.AsignarParametroCadena("@tipo", "T");
                                        DB.AsignarParametroCadena("@id_Factura", IDEFAC);
                                        if (TipoFactor == null) DB.AsignarParametroCadena("@tipoFactor", "-");
                                        else DB.AsignarParametroCadena("@tipoFactor", TipoFactor);
                                        DB.EjecutarConsulta1();
                                        DB.Desconectar();
                                    }
                                }
                                else
                                {
                                    #region CFDI 3.2
                                    foreach (string[] obj in arrayListImpuestosT)
                                    {
                                        DB.Conectar();
                                        DB.CrearComando(@"insert into Impuestos (impuesto, tasa, importe,tipo,id_Factura,tipoFactor) 
                                values (@impuesto, @tasa, @importe,@tipo,@id_Factura,@tipoFactor)");
                                        DB.AsignarParametroCadena("@impuesto", obj[0].ToString().Trim());
                                        DB.AsignarParametroCadena("@tasa", obj[1].ToString().Replace(",", "").Trim());
                                        if (tipoDeComprobante.ToLower() == "egreso")
                                        {
                                            DB.AsignarParametroCadena("@importe", "-" + obj[2].ToString().Replace(",", "").Trim());
                                        }
                                        else
                                        {
                                            DB.AsignarParametroCadena("@importe", obj[2].ToString().Replace(",", "").Trim());
                                        }
                                        DB.AsignarParametroCadena("@tipo", "T");
                                        DB.AsignarParametroCadena("@id_Factura", IDEFAC);
                                        if (TipoFactor == null) DB.AsignarParametroCadena("@tipoFactor", "-");
                                        else DB.AsignarParametroCadena("@tipoFactor", TipoFactor);
                                        DB.EjecutarConsulta1();
                                        DB.Desconectar();
                                    }
                                    #endregion
                                }
                                #endregion
                                DateTime fech = DateTime.Today;

                                String feca = fech.ToString("yyyy/MM/dd");
                                feca = feca.Replace("/", @"\") + @"\";
                                #region SAVE CFDIrelacion
                                if (version.Equals("3.3"))
                                {
                                    DB.Conectar();
                                    DB.CrearComando("INSERT INTO CFDIrelacion (cfdiRelacion, uuidRelacion, id_Factura) VALUES (@cfdiRelacion, @uuidRelacion, @idfac)");
                                    if (CFDIrelacion == null)
                                        DB.AsignarParametroCadena("@cfdiRelacion", "-");
                                    else
                                        DB.AsignarParametroCadena("@cfdiRelacion", CFDIrelacion);
                                    if (UUIDrelacion == null)
                                        DB.AsignarParametroCadena("@uuidRelacion", "-");
                                    else
                                        DB.AsignarParametroCadena("@uuidRelacion", UUIDrelacion);
                                    DB.AsignarParametroCadena("@idfac", IDEFAC);
                                    DB.EjecutarConsulta1();
                                    DB.Desconectar();
                                }
                                #endregion
                                #region SAVE ARCHIVOS
                                BD.Conectar();
                                BD.CrearComando(@"SELECT IDEFAC FROM Archivos WHERE IDEFAC = @idefactu;");
                                BD.AsignarParametroCadena("@idefactu", IDEFAC);
                                var dr2 = BD.EjecutarConsulta();
                                if (dr2.HasRows && dr2.Read())
                                {
                                    uid = dr2["IDEFAC"].ToString();
                                    BD.Desconectar();
                                }
                                BD.Desconectar();
                                if (IDEFAC != uid)
                                {
                                    DB.Conectar();
                                    DB.CrearComando(@"insert into Archivos 
                                (PDFARC,XMLARC,ORDENARC,IDEFAC) 
                                values
                                (@PDFARC,@XMLARC,@ORDENARC,@IDEFAC)");
                                    DB.AsignarParametroCadena("@PDFARC", @"docus\" + feca + rfcEmisor.Replace("&", "_").Trim() + @"\" + nombreSE.Replace("&", "_").Replace("#", "").Replace("+", "").Trim().Replace(" ", "") + ".pdf");
                                    DB.AsignarParametroCadena("@XMLARC", @"docus\" + feca + rfcEmisor.Replace("&", "_").Trim() + @"\" + nombreSE.Replace("&", "_").Replace("#", "").Replace("+", "").Trim().Replace(" ", "") + ".xml");
                                    if (pInvoice == "OTM")
                                    {
                                        DB.AsignarParametroCadena("@ORDENARC", "");
                                    }
                                    else
                                    {
                                        DB.AsignarParametroCadena("@ORDENARC", @"docus\" + feca + rfcEmisor.Replace("&", "_").Trim() + @"\" + ordenCompra.Replace("&", "_").Replace("#", "").Replace("+", "").Trim().Replace(" ", ""));
                                    }
                                    DB.AsignarParametroCadena("@IDEFAC", IDEFAC);
                                    DB.EjecutarConsulta1();
                                    DB.Desconectar();

                                    copiarArc(nomTemp, rutaDOC, nombreSE, rfcEmisor.Replace("&", "_"), ordenCompra.Replace("&", "_").Replace("#", "").Replace("+", "").Trim().Replace(" ", ""));
                                    //.Replace("&","_")
                                }
                                else
                                {
                                    msj = msj + Environment.NewLine + "Factura registrada";
                                }
                                #endregion
                                #region SAVE ARCHIVOS ADICIONALES
                                if (LisAdi.Count > 0)
                                {
                                    foreach (string adi in LisAdi)
                                    {
                                        string[] resAdi = adi.Split('|');
                                        try
                                        {
                                            DB.Conectar();
                                            DB.CrearComando("insert into documentosAdicionales (ADIARC,NOMARC,NOMBRE,IDEFAC) values (@ADIARC,@NOMARC,@NOMBRE,@IDEFAC)");
                                            DB.AsignarParametroCadena("@ADIARC", @"docus\" + feca + rfcEmisor.Replace("&", "_").Trim() + @"\adicionales\" + resAdi[1].Replace("+", "").Trim());
                                            DB.AsignarParametroCadena("@NOMARC", resAdi[0]);
                                            DB.AsignarParametroCadena("@NOMBRE", resAdi[1].Replace("+", "").Trim());
                                            DB.AsignarParametroCadena("@IDEFAC", IDEFAC);
                                            DB.EjecutarConsulta();
                                            DB.Desconectar();

                                            if (System.IO.File.Exists(rutaDOC + feca + rfcEmisor.Replace("&", "_").Trim() + @"\adicionales\" + resAdi[1].Replace("+", "").Trim()))
                                            {
                                                System.IO.File.Delete(rutaDOC + feca + rfcEmisor.Replace("&", "_").Trim() + @"\adicionales\" + resAdi[1].Replace("+", "").Trim());
                                                System.IO.File.Copy(nomTemp + resAdi[1].Replace("+", "").Trim(), rutaDOC + feca + rfcEmisor.Replace("&", "_").Trim() + @"\adicionales\" + resAdi[1].Replace("+", "").Trim());
                                                System.IO.File.Delete(nomTemp + resAdi[1].Replace("+", "").Trim());
                                            }
                                            else
                                            {
                                                System.IO.File.Copy(nomTemp + resAdi[1].Replace("+", "").Trim(), rutaDOC + feca + rfcEmisor.Replace("&", "_").Trim() + @"\adicionales\" + resAdi[1].Replace("+", "").Trim());
                                                System.IO.File.Delete(nomTemp + resAdi[1].Replace("+", "").Trim());
                                            }

                                        }
                                        catch (Exception ex)
                                        {
                                            // enviar correo del documento adicional que no se guardo
                                            DB.Desconectar();
                                            mensajesLog("BD001", "", ex.ToString(), emails, DB.comando.CommandText);
                                            mensajeEmailErrorA(resAdi[1].Replace("+", "").Trim(), "", emails);

                                            anade_linea_archivo(archivo_log, "ErrorGuardado0" + ex.ToString());
                                        }
                                    }
                                }
                                #endregion
                                msj = msj + "Arhivo Procesado: " + nombreSE + Environment.NewLine;

                                if (!(correosFin.IndexOf("@") < 0) && correosFin != "")
                                {
                                    mensajeEmailReceptor("RE001", "", correosFin);
                                }
                                else
                                {
                                    if (emailNoti != "")//if(true)
                                    {
                                        mensajeEmailAdjuntar("RE001", "", emailNoti);
                                    }
                                }
                                mensajesLog("RE001", "", "", emails, resultadoVal);
                            }
                            catch (Exception ex)
                            {
                                DB.Desconectar();
                                mensajesLog("BD001", "", ex.ToString(), emails, DB.comando.CommandText);
                                mensajesLog("RE051", "", "", emails, "");
                                if (MENSAJE_ISR)
                                {
                                    mensajesLog("RE052", "", "", emails, "");
                                }
                                if (!String.IsNullOrEmpty(IDEFAC))
                                {
                                    DB.Conectar();
                                    DB.CrearComando("DELETE GENERAL WHERE idFactura=@idFactura");
                                    DB.AsignarParametroCadena("@idFactura", IDEFAC);
                                    DB.EjecutarConsulta1();
                                    DB.Desconectar();
                                    DB.Conectar();
                                    DB.CrearComando("DELETE CFDI WHERE id_Factura=@idFactura");
                                    DB.AsignarParametroCadena("@idFactura", IDEFAC);
                                    DB.EjecutarConsulta1();
                                    DB.Desconectar();
                                    IDEFAC = "";

                                    anade_linea_archivo(archivo_log, "ErrorGuardado1" + ex.ToString());
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            DB.Desconectar();
                            mensajesLog("BD001", "", ex.ToString(), emails, DB.comando.CommandText);
                            anade_linea_archivo(archivo_log, "ErrorGuardado2" + ex.ToString());
                        }
                        msj = msj + Environment.NewLine + "Factura registrada";
                    }
                    else
                    {
                        mensajesLog("RE021", "", "", emails, resultadoVal);
                        anade_linea_archivo(archivo_log, "RFC no habiltado aun " + rfcEmisor.ToString());
                    }
                }
                else
                {
                    mensajesLog("RE008", "", "", emails, resultadoVal);
                    anade_linea_archivo(archivo_log, "UUID ya existe " + UUID.ToString() + uid.ToString());
                }
                #endregion
            }
            else
            {
                #region SAVE COMPLEMENT PAYMENT 3.3
                BasesDatos BD = new BasesDatos();
                try
                {
                    var IDECOM = "";
                    bool flag = false;

                    if (this.rfcReceptorP == this.validaRFC(this.rfcReceptorP))
                    {
                        #region SAVE PAYMENT COMPLEMENT
                        DB.Conectar();
                        DB.CrearComando(@"insert into GeneralPago(version, serie, folio, fecha, noCertificado, tipoComprobante, moneda, subtotal, total, lugarExpedicion, montoLetra, regimenFiscal, usoCFDI, config, IDEEMI, IDEREC, IDEEMP, IDE_DOMEMIEXP, edoInter, numAprob, fechaPago, formaDePagoP, monedaP, tipoCambioP, monto, numOperacion, rfcEmisorCtaOrd, nomBancoOrdExt, ctaOrdenante, rfcEmisorCtaBen, ctaBeneficiario, tipoCadPago, certPago, cadPago, selloPago, codigoQR, cadenaQR, schemaLocation, uuidP, fechaTimbrado, numCertificadoSAT, selloSAT, tfd, cadenaCFDI, sello) output inserted.idComPago
                                 values (@version,@serie,@folio,@fecha,@noCertificado,@tipoComprobante,@moneda,@subtotal,@total,@lugarExpedicion,@montoLetra,@regimenFiscal,@usoCFDI,@config,@IDEEMI,@IDEREC,@IDEEMP,@IDE_DOMEMIEXP,@edoInter,@numAprob,@fechaPago,@formaDePagoP,@monedaP,@tipoCambioP,@monto,@numOperacion,@rfcEmisorCtaOrd,@nomBancoOrdExt,@ctaOrdenante,@rfcEmisorCtaBen,@ctaBeneficiario,@tipoCadPago,@certPago,@cadPago,@selloPago,@codigoQR,@cadenaQR,@schemaLocation,@uuidP,@fechaTimbrado,@numCertificadoSAT,@selloSAT,@tfd,@cadenaCFDI,@sello) ");
                        DB.AsignarParametroCadena("@version", "3.3");
                        DB.AsignarParametroCadena("@serie", serie);
                        DB.AsignarParametroCadena("@folio", folio);
                        DB.AsignarParametroCadena("@fecha", fecha2);
                        DB.AsignarParametroCadena("@noCertificado", noCertificado);
                        DB.AsignarParametroCadena("@tipoComprobante", "P");
                        DB.AsignarParametroCadena("@moneda", "XXX");
                        DB.AsignarParametroCadena("@subtotal", "0.00");
                        DB.AsignarParametroCadena("@total", "0.00");
                        DB.AsignarParametroCadena("@lugarExpedicion", LugarExpedicion);
                        DB.AsignarParametroCadena("@montoLetra", "-");
                        DB.AsignarParametroCadena("@regimenFiscal", "-");
                        DB.AsignarParametroCadena("@usoCFDI", "P01");
                        DB.AsignarParametroCadena("@config", "-");
                        DB.AsignarParametroCadena("@IDEEMI", "1");
                        DB.AsignarParametroCadena("@IDEREC", "1");
                        DB.AsignarParametroCadena("@IDEEMP", "1");
                        DB.AsignarParametroCadena("@IDE_DOMEMIEXP", "1");
                        DB.AsignarParametroCadena("@edoInter", "0");
                        DB.AsignarParametroCadena("@numAprob", "1");
                        DB.AsignarParametroCadena("@fechaPago", FechaPagoP);
                        DB.AsignarParametroCadena("@formaDePagoP", FormaDePagoP);
                        DB.AsignarParametroCadena("@monedaP", MonedaP);
                        DB.AsignarParametroCadena("@tipoCambioP", TipoCambioP);
                        DB.AsignarParametroCadena("@monto", MontoP.ToString());
                        DB.AsignarParametroCadena("@numOperacion", NumOperacionP);
                        DB.AsignarParametroCadena("@rfcEmisorCtaOrd", RfcEmisorCtaOrdP);
                        DB.AsignarParametroCadena("@nomBancoOrdExt", NomBancoOrdExtP);
                        DB.AsignarParametroCadena("@ctaOrdenante", CtaOrdenanteP);
                        DB.AsignarParametroCadena("@rfcEmisorCtaBen", RfcEmisorCtaBenP);
                        DB.AsignarParametroCadena("@ctaBeneficiario", CtaBeneficiarioP);
                        DB.AsignarParametroCadena("@tipoCadPago", TipoCadPagoP);
                        DB.AsignarParametroCadena("@certPago", CertPagoP);
                        DB.AsignarParametroCadena("@cadPago", CadPagoP);
                        DB.AsignarParametroCadena("@selloPago", SelloPagoP);
                        DB.AsignarParametroCadena("@codigoQR", "-");
                        DB.AsignarParametroCadena("@cadenaQR", "-");
                        DB.AsignarParametroCadena("@schemaLocation", schemaLocationP);
                        DB.AsignarParametroCadena("@uuidP", UUIDP);
                        DB.AsignarParametroCadena("@fechaTimbrado", FechaTimbradoP);
                        DB.AsignarParametroCadena("@numCertificadoSAT", noCertificadoSATP);
                        DB.AsignarParametroCadena("@selloSAT", selloSATP);
                        DB.AsignarParametroCadena("@tfd", tfdP);
                        DB.AsignarParametroCadena("@cadenaCFDI", "-");
                        DB.AsignarParametroCadena("@sello", sello);
                        var x = DB.EjecutarConsulta();
                        if (x.Read())
                        {
                            IDECOM = x[0].ToString();
                        }
                        DB.Desconectar();
                        #endregion

                        #region SAVE CONCEPTOS
                        DB.Conectar();
                        DB.CrearComando(@"insert into ConceptoPago 
                                (claveProdServ, cantidad, claveUnidad, descripcion, valorUnitario, importe, id_ComPago) 
                                values 
                                 (@claveProdServ,@cantidad,@claveUnidad,@descripcion,@valorUnitario,@importe,@id_ComPago)");
                        DB.AsignarParametroCadena("@claveProdServ", "84111506");
                        DB.AsignarParametroCadena("@cantidad", "1");
                        DB.AsignarParametroCadena("@claveUnidad", "ACT");
                        DB.AsignarParametroCadena("@descripcion", "Pago");
                        DB.AsignarParametroCadena("@valorUnitario", "0.00");
                        DB.AsignarParametroCadena("@importe", "0.00");
                        DB.AsignarParametroCadena("@id_ComPago", IDECOM);
                        DB.EjecutarConsulta1();
                        DB.Desconectar();
                        #endregion
                        foreach (string[] strArray in this.arrayListComPago)
                        {
                            var idFAC = "";
                            var rutaREcibo = "";
                            #region SAVE PAYMENT RELATION
                            BD.Conectar();
                            BD.CrearComando("SELECT UUID, id_Factura, Archivos.XMLARC  FROM CFDI inner join Archivos on Archivos.IDEFAC = CFDI.id_Factura WHERE UUID = @UUID;");
                            BD.AsignarParametroCadena("@UUID", strArray[0].ToString());
                            DbDataReader DRcp = BD.EjecutarConsulta();
                            if (DRcp.HasRows && DRcp.Read())
                            {
                                idFAC = DRcp[1].ToString().Trim();
                                rutaREcibo = DRcp[2].ToString().Trim();
                                flag = true;
                            }
                            BD.Desconectar();
                            if (flag)
                            {
                                this.DB.Conectar();
                                this.DB.CrearComando("insert into RelacionPago(idDocumento, serie, folio, monedaDR, tipoCambioDR, metodoDePagoDR, numParcialidad, impSaldoAnt, impPagado, impSaldoInsoluto, id_Factura, id_ComPago) output inserted.idPagoRelacion VALUES (@idDocumento,@serie,@folio,@monedaDR,@tipoCambioDR,@metodoDePagoDR,@numParcialidad,@impSaldoAnt,@impPagado,@impSaldoInsoluto,@id_Factura,@id_ComPago)");
                                this.DB.AsignarParametroCadena("@idDocumento", strArray[0].ToString());
                                this.DB.AsignarParametroCadena("@serie", strArray[1].ToString());
                                this.DB.AsignarParametroCadena("@folio", strArray[2].ToString());
                                this.DB.AsignarParametroCadena("@monedaDR", strArray[3].ToString());
                                this.DB.AsignarParametroCadena("@tipoCambioDR", strArray[4].ToString());
                                this.DB.AsignarParametroCadena("@metodoDePagoDR", strArray[5].ToString());
                                this.DB.AsignarParametroCadena("@numParcialidad", strArray[6].ToString());
                                this.DB.AsignarParametroCadena("@impSaldoAnt", strArray[7].ToString());
                                this.DB.AsignarParametroCadena("@impPagado", strArray[8].ToString());
                                this.DB.AsignarParametroCadena("@impSaldoInsoluto", strArray[9].ToString());
                                this.DB.AsignarParametroCadena("@id_Factura", idFAC);
                                this.DB.AsignarParametroCadena("@id_ComPago", IDECOM);
                                this.DB.EjecutarConsulta1();
                                this.DB.Desconectar();
                            }
                            #endregion
                            IMPPAGADODR = strArray[8].ToString();
                            DocRelacion(strArray[1].ToString(), strArray[2].ToString(), strArray[6].ToString(), strArray[8].ToString());

                            string[] ruta = rutaREcibo.Split(@"\".ToCharArray());
                            var Finalruta = ruta[0] + "\\" + ruta[1] + "\\" + ruta[2] + "\\" + ruta[3] + "\\" + rfcEmisorP.Replace(" & ", "_").Trim() + "\\Pagos\\";
                            // docus\2017\10\05\TN0M990610RF6\XMLAT17DEAGOSTO2017.xml
                            #region SAVE FILES
                            this.DB.Conectar();
                            this.DB.CrearComando("insert into ArchivosPago (PDFARC, XMLARC, id_ComPago) VALUES (@PDFARC,@XMLARC,@id_ComPago)");
                            this.DB.AsignarParametroCadena("@PDFARC", Finalruta + nameFINALpdf.Replace("&", "_").Replace("#", "").Replace("+", "").Trim().Replace(" ", "") + ".pdf");
                            this.DB.AsignarParametroCadena("@XMLARC", Finalruta + nameFINALxml.Replace("&", "_").Replace("#", "").Replace("+", "").Trim().Replace(" ", "") + ".xml");
                            this.DB.AsignarParametroCadena("@id_ComPago", IDECOM);
                            this.DB.EjecutarConsulta1();
                            this.DB.Desconectar();
                            // copiarArc(nomTemp, rutaDOC, nombreSE, rfcEmisor.Replace("&", "_"), ordenCompra.Replace("&", "_").Replace("#", "").Replace("+", "").Trim().Replace(" ", ""));
                            copiarArc(nomTemp, Finalruta, nameFINALxml, "", nameFINALpdf);
                            #endregion

                            #region UPDATE SALDOS GENERAL
                            DB.Conectar();
                            DB.CrearComando(@"UPDATE General SET ImpSaldoAnt=@ImpSaldoAnt,ImpSaldoPagado=@ImpSaldoPagado,ImpSaldoInsoluto=@ImpSaldoInsoluto WHERE idFactura=@idFac");
                            DB.AsignarParametroCadena("@ImpSaldoAnt", IMPSALDOANTDR);
                            DB.AsignarParametroCadena("@ImpSaldoPagado", IMPPAGADODR);
                            DB.AsignarParametroCadena("@ImpSaldoInsoluto", IMPSALDOINSOLUTODR);
                            DB.AsignarParametroCadena("@idFac", idFAC);
                            DB.EjecutarConsulta1();
                            DB.Desconectar();
                            #endregion
                        }


                    }
                }
                catch (Exception ex)
                {
                    BD.Desconectar();
                }
                #endregion
            }
        }

        private Boolean validarExistenciaAdicionales()
        {
            try
            {
                if (LisAdi.Count > 0)
                {
                    foreach (string adi in LisAdi)
                    {
                        string[] resAdi = adi.Split('|');
                        if (!File.Exists(nomTemp + resAdi[1].Replace("+", "").Trim()))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void guardarBD()
        {
            if (String.IsNullOrEmpty(consultarIDEFact(UUID, "UUID", "select idFactura from GENERAL inner join CFDI on GENERAL.idFactura=CFDI.id_Factura where ")))
            {
                if (sesionAdmin)
                {
                    guardarBD1();
                    goto continuarDespuesBD;
                }
                if (tipoDeComprobante.ToLower() == "egreso" || tipoDeComprobante.ToLower() == "ingreso" || tipoDeComprobante.ToUpper() == "I" || tipoDeComprobante.ToUpper() == "E")
                {
                    DateTime hoy = DateTime.Now;
                    string an = hoy.ToString("yyyy");
                    string[] fh = fecha2.Split('-');
                    if (Convert.ToDateTime(fecha2).Year == DateTime.Now.Year)//valida factura corresponda al año en curso
                    {
                        TimeSpan ts = hoy - Convert.ToDateTime(fecha2);
                        int dias = ts.Days + 2;
                        if (banDate.ToUpper().Equals("FALSE")) { dias = 20; }

                        if (dias <= timFact)
                        {
                            if (validarDesc())
                            {
                                if (varRetFletes())
                                //if (true)
                                {
                                    if (valret())
                                    {
                                        if (valTasa())
                                        {
                                            if (operaciones() || version == "3.3")
                                            {
                                                guardarBD1();
                                            }
                                            else
                                            {
                                                //mensajeEmailAdjuntar("RE020", "", emails);
                                                mensajesLog("RE020", "", "", emails, resultadoVal);
                                            }
                                        }
                                        else
                                        {
                                            mensajesLog("RE026", "", "", emails, resultadoVal);
                                        }
                                    }
                                    else
                                    {
                                        mensajesLog("RE025", "", "", emails, resultadoVal);
                                    }
                                }
                                else
                                {
                                    mensajesLog("RE028", "", "", emails, resultadoVal);
                                }
                            }
                            else
                            {
                                mensajesLog("RE024", "", "", emails, resultadoVal);
                            }
                        }
                        else
                        {
                            mensajesLog("RE023", "", "", emails, resultadoVal);
                        }
                    }
                    else
                    {
                        mensajesLog("RE022", "", "", emails, resultadoVal);
                    }
                }
                else
                {
                    mensajesLog("RE027", "", "", emails, resultadoVal);
                }

            }
            else
            {
                copiarArc(nomTemp, rutaBCK, nombreSE, rfcEmisor, ordenCompra);
                try
                {
                    if (LisAdi.Count > 0)
                    {
                        foreach (string adi in LisAdi)
                        {

                            string[] resAdi = adi.Split('|');
                            if (System.IO.File.Exists(rutaBCK + resAdi[1].Replace("+", "")))
                            {
                                System.IO.File.Delete(rutaBCK + resAdi[1].Replace("+", ""));
                                System.IO.File.Copy(nomTemp + resAdi[1].Replace("+", ""), rutaBCK + resAdi[1].Replace("+", ""));
                                System.IO.File.Delete(nomTemp + resAdi[1].Replace("+", ""));
                            }
                            else
                            {
                                System.IO.File.Copy(nomTemp + resAdi[1].Replace("+", ""), rutaBCK + resAdi[1].Replace("+", ""));
                                System.IO.File.Delete(nomTemp + resAdi[1].Replace("+", ""));
                            }
                        }
                    }
                }
                catch (Exception)
                {

                }

                //mensajeEmailAdjuntar("RE008", "", emails);
                mensajesLog("RE008", "", "", emails, resultadoVal);//  msj = msj + "La ya existe en el sistema";

            }

            continuarDespuesBD:

            if (BanBD != true)
            {

            }
        }

        private string Receptor(string rfc)
        {
            string val = "";
            DB.Conectar();
            DB.CrearComando("select idreceptorCFDI from receptorCFDI where rfc=@RFC");
            DB.AsignarParametroCadena("@RFC", rfc);
            DbDataReader DR = DB.EjecutarConsulta();

            while (DR.Read())
            {
                val = DR[0].ToString();
            }
            DB.Desconectar();
            return val;
        }

        private bool idProvE2(string rfc)
        {
            try
            {
                bool ax = false;
                DB.Conectar();
                DB.CrearComando("select idProveedor from Proveedores where rfc=@RFC and habilitado=@habilitado");
                DB.AsignarParametroCadena("@RFC", rfc);
                DB.AsignarParametroCadena("@habilitado", "si");
                DbDataReader DR = DB.EjecutarConsulta();

                while (DR.Read())
                {
                    ax = true;
                }
                DB.Desconectar();
                if (ax)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                DB.Desconectar();
                return false;
            }
        }

        private string idProvE(string rfc)
        {
            string val = "";
            DB.Conectar();
            DB.CrearComando("select idProveedor from Proveedores where rfc=@RFC");
            DB.AsignarParametroCadena("@RFC", rfc);
            DbDataReader DR = DB.EjecutarConsulta();
            while (DR.Read())
            {
                val = DR[0].ToString();
            }
            DB.Desconectar();
            return val;
        }

        private string Emisor(string rfc)
        {
            string val = "";
            DB.Conectar();
            DB.CrearComando("select IDEEMI from Emisor where RFCEMI=@RFC");
            DB.AsignarParametroCadena("@RFC", rfc);
            DbDataReader DR = DB.EjecutarConsulta();
            while (DR.Read())
            {
                val = DR[0].ToString();
            }
            DB.Desconectar();
            return val;
        }

        private string correoProveedor(string rfc)
        {
            String val = "";
            DB.Conectar();
            DB.CrearComando("select correo from Proveedores where rfc=@RFC");
            DB.AsignarParametroCadena("@RFC", rfc);
            DbDataReader DR = DB.EjecutarConsulta();
            while (DR.Read())
            {
                val = DR[0].ToString();
            }
            DB.Desconectar();
            return val;
        }

        private String consultarIDE(string valor1, string valor2, string campo1, string campo2, string consulta)
        {
            try
            {
                String ide;
                DB.Conectar();
                DB.CrearComando(consulta + " " + campo1 + "=@a and " + campo2 + "=@b");
                DB.AsignarParametroCadena("@a", valor1);
                DB.AsignarParametroCadena("@b", valor2);
                DbDataReader DR = DB.EjecutarConsulta();

                while (DR.Read())
                {
                    ide = DR[0].ToString();
                    DB.Desconectar();
                    return ide;
                }
                DB.Desconectar();
                return null;
            }
            catch (DbException de)
            {
                mensajesLog("BD001", "", de.Message, emails, "");
                return null;
            }
        }

        private String consultarIDE(string valor1, string valor2, string valor3, string valor4, string valor5, string campo1, string campo2, string campo3, string campo4, string campo5, string consulta)
        {
            try
            {
                String ide;
                DB.Conectar();
                DB.CrearComando(consulta + " " + campo1 + "=@a and " + campo2 + "=@b and " + campo3 + "=@c and " + campo4 + "=@d and " + campo5 + " like '%" + valor5 + "%'");
                DB.AsignarParametroCadena("@a", valor1);
                DB.AsignarParametroCadena("@b", valor2);
                DB.AsignarParametroCadena("@c", valor3);
                DB.AsignarParametroCadena("@d", valor4);
                //DB.AsignarParametroCadena("@e", valor5);
                DbDataReader DR = DB.EjecutarConsulta();

                while (DR.Read())
                {
                    ide = DR[0].ToString();
                    DB.Desconectar();
                    return ide;
                }
                DB.Desconectar();
                return null;
            }
            catch (DbException de)
            {
                mensajesLog("BD001", "", de.Message, emails, "");
                return null;
            }
        }

        private String consultarIDEFact(string valor1, string campo1, string consulta)
        {
            try
            {
                String ide = "", edo = "";
                DB.Conectar();
                DB.CrearComando(consulta + " " + campo1 + "=@a ");
                DB.AsignarParametroCadena("@a", valor1);
                //DB.AsignarParametroCadena("@d", valor4);
                DbDataReader DR = DB.EjecutarConsulta();

                if (DR.Read())
                {
                    ide = DR[0].ToString();
                    //DB.Desconectar();
                    //return ide;
                }
                DB.Desconectar();

                if (ide != "")
                {
                    DB.Conectar();
                    DB.CrearComando("select estatus from GENERAL where idFactura=@id");
                    DB.AsignarParametroCadena("@id", ide);
                    DbDataReader DR2 = DB.EjecutarConsulta();
                    if (DR2.Read())
                    {
                        edo = DR2[0].ToString();
                    }
                    DB.Desconectar();

                    if (edo == "rechazado")
                    {
                        //DB.Conectar();
                        //DB.CrearComando("delete from general where idFactura=@ide");
                        //DB.AsignarParametroCadena("@ide", ide);
                        //DB.EjecutarConsulta();
                        //DB.Desconectar();

                        return null;
                    }
                    else
                    {
                        return ide;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (DbException de)
            {
                mensajesLog("BD001", "", de.Message, emails, "");
                return null;
            }
        }

        private String consultarFechaRec(string valor1, string valor2, string valor3, string campo1, string campo2, string campo3, string consulta)
        {
            try
            {
                DB.Conectar();
                DB.CrearComando(consulta + " " + campo1 + "=@a and " + campo2 + "=@b and " + campo3 + "=@c");
                DB.AsignarParametroCadena("@a", valor1);
                DB.AsignarParametroCadena("@b", valor2);
                DB.AsignarParametroCadena("@c", valor3);
                DbDataReader DR = DB.EjecutarConsulta();

                while (DR.Read())
                {
                    fecharec = DR[0].ToString();
                    DB.Desconectar();
                    return fecharec;
                }
                DB.Desconectar();
                return null;
            }
            catch (DbException de)
            {
                mensajesLog("BD001", "", de.Message, emails, "");
                return null;
            }
        }

        private void copiarArc33(string rutaAR, string rutaDO, string nombre, string cliente, string Ocompra)
        {
            string directorio, directoriocom;
            string dirBAk;
            cliente = cliente.Replace("&", "_");
            nombre = nombre.Replace("&", "_").Replace("#", "").Replace("+", "").Trim().Replace(" ", "");
            Ocompra = Ocompra.Replace(" ", "");
            DateTime fech = DateTime.Today;
            String fecha = fech.ToString("yyyy/MM/dd");
            fecha = fecha.Replace("/", @"\") + @"\";
            var ruta = filesPagos.Replace("docus", "") + rutaDO;
            if (rutaDO.Contains("docus"))
            {
                directoriocom = rutaDO;// + fecha + cliente + @"\adicionales\";
                directoriocom = rutaDO + fecha + cliente + @"\adicionales\";
                directorio = rutaDO + fecha + cliente + @"\";
            }
            else
            {
                directoriocom = rutaDO + cliente + @"\";
                directorio = rutaDO + cliente + @"\";
                dirBAk = directorio;
            }
            if (directoriocom.Contains("Pagos"))
            {
                DirectoryInfo DIR = new DirectoryInfo(ruta);
                if (!DIR.Exists) { DIR.Create(); }
            }
            else
            {
                DirectoryInfo DIR = new DirectoryInfo(directoriocom);
                if (!DIR.Exists) { DIR.Create(); }
            }

            try
            {
                if (!this.tipoDeComprobante.Equals("P"))
                {
                    #region FACTURAS AND NC
                    if (System.IO.File.Exists(rutaAR + nombre + ".xml"))
                    {
                        if (System.IO.File.Exists(directorio + nombre + ".xml"))
                        {
                            System.IO.File.Delete(directorio + nombre + ".xml");
                            System.IO.File.Copy(rutaAR + nombre + ".xml", directorio + nombre + this.extension);
                            System.IO.File.Delete(rutaAR + nombre + ".xml");
                        }
                        else
                        {
                            System.IO.File.Copy(rutaAR + nombre + ".xml", directorio + nombre + this.extension);
                            System.IO.File.Delete(rutaAR + nombre + ".xml");
                        }
                    }
                    if (System.IO.File.Exists(rutaAR + nombre + ".XML"))
                    {
                        if (System.IO.File.Exists(directorio + nombre + ".XML"))
                        {
                            System.IO.File.Delete(directorio + nombre + ".XML");
                            System.IO.File.Copy(rutaAR + nombre + ".XML", directorio + nombre + this.extension);
                            System.IO.File.Delete(rutaAR + nombre + ".XML");
                        }
                        else
                        {
                            System.IO.File.Copy(rutaAR + nombre + ".XML", directorio + nombre + this.extension);
                            System.IO.File.Delete(rutaAR + nombre + ".XML");
                        }
                    }
                    if (this.pInvoice == "ORACLE" && System.IO.File.Exists(rutaAR + Ocompra))
                    {
                        if (System.IO.File.Exists(directorio + Ocompra))
                        {
                            System.IO.File.Delete(directorio + Ocompra);
                            System.IO.File.Copy(rutaAR + Ocompra, directorio + Ocompra);
                            System.IO.File.Delete(rutaAR + Ocompra);
                        }
                        else
                        {
                            System.IO.File.Copy(rutaAR + Ocompra, directorio + Ocompra);
                            System.IO.File.Delete(rutaAR + Ocompra);
                        }
                    }
                    if (System.IO.File.Exists(rutaAR + nombre + ".pdf"))
                    {
                        if (System.IO.File.Exists(directorio + nombre + ".pdf"))
                        {
                            System.IO.File.Delete(directorio + nombre + ".pdf");
                            System.IO.File.Copy(rutaAR + nombre + ".pdf", directorio + nombre + ".pdf");
                            System.IO.File.Delete(rutaAR + nombre + ".pdf");
                        }
                        else
                        {
                            System.IO.File.Copy(rutaAR + nombre + ".pdf", directorio + nombre + ".pdf");
                            System.IO.File.Delete(rutaAR + nombre + ".pdf");
                        }
                    }
                    if (!System.IO.File.Exists(rutaAR + nombre + ".PDF"))
                        return;
                    if (System.IO.File.Exists(directorio + nombre + ".PDF"))
                    {
                        System.IO.File.Delete(directorio + nombre + ".PDF");
                        System.IO.File.Copy(rutaAR + nombre + ".PDF", directorio + nombre + ".PDF");
                        System.IO.File.Delete(rutaAR + nombre + ".PDF");
                    }
                    else
                    {
                        System.IO.File.Copy(rutaAR + nombre + ".PDF", directorio + nombre + ".PDF");
                        System.IO.File.Delete(rutaAR + nombre + ".PDF");
                    }
                    #endregion
                }
                else
                {
                    #region RECIBOS PAGO
                    if (System.IO.File.Exists(rutaAR + nombre + extension))
                    {
                        if (System.IO.File.Exists(rutaAR + nombre + extension))//revisa si el archivo existe en al carpeta de respaldo 
                        {
                            System.IO.File.Delete(ruta + nombre + ".xml");
                            System.IO.File.Copy(rutaAR + nombre + extension, ruta + nombre + ".xml");
                            System.IO.File.Delete(rutaAR + nombre + extension);
                        }
                        else
                        {
                            System.IO.File.Copy(rutaAR + nombre + extension, ruta + nombre + ".xml");
                            System.IO.File.Delete(rutaAR + nombre + extension);
                        }
                    }
                    #region as
                    //if (System.IO.File.Exists(rutaAR + nombre + ".XML"))
                    //{

                    //    if (System.IO.File.Exists(directorio + nombre + ".XML"))//revisa si el archivo existe en al carpeta de respaldo 
                    //    {
                    //        System.IO.File.Delete(directorio + nombre + ".XML");
                    //        System.IO.File.Copy(rutaAR + nombre + ".XML", directorio + nombre + extension);
                    //        System.IO.File.Delete(rutaAR + nombre + ".XML");
                    //    }
                    //    else
                    //    {
                    //        System.IO.File.Copy(rutaAR + nombre + ".XML", directorio + nombre + extension);
                    //        System.IO.File.Delete(rutaAR + nombre + ".XML");
                    //    }
                    //}
                    #endregion
                    #region CHECAR PAGOS ORACLE
                    if (pInvoice == "ORACLE")
                    {
                        if (System.IO.File.Exists(rutaAR + Ocompra))
                        {
                            if (System.IO.File.Exists(directorio + Ocompra))//revisa si el archivo existe en al carpeta de respaldo 
                            {
                                System.IO.File.Delete(directorio + Ocompra);
                                System.IO.File.Copy(rutaAR + Ocompra, directorio + Ocompra);
                                System.IO.File.Delete(rutaAR + Ocompra);
                            }
                            else
                            {
                                System.IO.File.Copy(rutaAR + Ocompra, directorio + Ocompra);
                                System.IO.File.Delete(rutaAR + Ocompra);
                            }
                        }
                    }
                    #endregion
                    if (System.IO.File.Exists(rutaAR + Ocompra + ".pdf"))
                    {
                        try
                        {
                            if (System.IO.File.Exists(rutaAR + Ocompra + ".pdf"))//revisa si el archivo existe en al carpeta de respaldo 
                            {
                                System.IO.File.Delete(ruta + Ocompra + ".PDF");
                                var bytes = File.ReadAllBytes(rutaAR + Ocompra + ".pdf");
                                SaveData(ruta + Ocompra + ".pdf", bytes);
                                System.IO.File.Delete(rutaAR + Ocompra + ".pdf");
                            }
                            else
                            {
                                //System.IO.File.Copy(rutaAR + Ocompra + ".pdf", ruta + Ocompra + ".pdf");
                                var bytes = File.ReadAllBytes(rutaAR + Ocompra + ".pdf");
                                SaveData(ruta + Ocompra + ".pdf", bytes);
                                System.IO.File.Delete(rutaAR + Ocompra + ".pdf");
                            }
                        }
                        catch (Exception es) { }
                    }

                    if (System.IO.File.Exists(rutaAR + Ocompra + ".PDF"))
                    {

                        if (System.IO.File.Exists(rutaAR + Ocompra + ".PDF"))//revisa si el archivo existe en al carpeta de respaldo 
                        {
                            System.IO.File.Delete(ruta + Ocompra + ".PDF");
                            //System.IO.File.Copy(rutaAR + Ocompra + ".PDF", ruta + Ocompra + ".PDF");
                            var bytes = File.ReadAllBytes(rutaAR + Ocompra + ".pdf");
                            SaveData(ruta + Ocompra + ".pdf", bytes);
                            System.IO.File.Delete(rutaAR + Ocompra + ".PDF");
                        }
                        else
                        {
                            //System.IO.File.Copy(rutaAR + Ocompra + ".PDF", ruta + Ocompra + ".PDF");
                            var bytes = File.ReadAllBytes(rutaAR + Ocompra + ".pdf");
                            SaveData(ruta + Ocompra + ".pdf", bytes);
                            System.IO.File.Delete(rutaAR + Ocompra + ".PDF");
                        }
                    }
                    #endregion
                }
            }
            catch (Exception e)
            {
                mensajesLog("ES001", "", e.Message, emails, "");
            }
        }

        private void copiarArc(string rutaAR, string rutaDO, string nombre, string cliente, string Ocompra)
        {
            string directorio, directoriocom;
            string dirBAk;
            string path2;
            cliente = cliente.Replace("&", "_");
            nombre = nombre.Replace("&", "_").Replace("#", "").Replace("+", "").Trim().Replace(" ", "");
            Ocompra = Ocompra.Replace(" ", "");
            DateTime fech = DateTime.Today;
            if (rutaDO.Contains("docus"))
            {
                String fecha = fech.ToString("yyyy/MM/dd");
                fecha = fecha.Replace("/", @"\") + @"\";
                directoriocom = rutaDO + fecha + cliente + @"\adicionales\";
                path2 = rutaDO + fecha + cliente + "\\Pagos\\";
                directorio = rutaDO + fecha + cliente + @"\";

            }
            else
            {
                directoriocom = rutaDO; //+ cliente + @"\";
                directorio = rutaDO + cliente + @"\";
                path2 = rutaDO + cliente + "\\";
                dirBAk = directorio;
            }

            DirectoryInfo DIR = new DirectoryInfo(directoriocom);

            //  string nomorigen = nombre.Substring(0, nombre.IndexOf("─"));
            if (!DIR.Exists)
            {
                DIR.Create();
            }
            try
            {
                if (!this.tipoDeComprobante.Equals("P"))
                {
                    if (System.IO.File.Exists(rutaAR + nombre + ".xml"))
                    {
                        if (System.IO.File.Exists(directorio + nombre + ".xml"))
                        {
                            System.IO.File.Delete(directorio + nombre + ".xml");
                            System.IO.File.Copy(rutaAR + nombre + ".xml", directorio + nombre + this.extension);
                            System.IO.File.Delete(rutaAR + nombre + ".xml");
                        }
                        else
                        {
                            System.IO.File.Copy(rutaAR + nombre + ".xml", directorio + nombre + this.extension);
                            System.IO.File.Delete(rutaAR + nombre + ".xml");
                        }
                    }
                    if (System.IO.File.Exists(rutaAR + nombre + ".XML"))
                    {
                        if (System.IO.File.Exists(directorio + nombre + ".XML"))
                        {
                            System.IO.File.Delete(directorio + nombre + ".XML");
                            System.IO.File.Copy(rutaAR + nombre + ".XML", directorio + nombre + this.extension);
                            System.IO.File.Delete(rutaAR + nombre + ".XML");
                        }
                        else
                        {
                            System.IO.File.Copy(rutaAR + nombre + ".XML", directorio + nombre + this.extension);
                            System.IO.File.Delete(rutaAR + nombre + ".XML");
                        }
                    }
                    if (this.pInvoice == "ORACLE" && System.IO.File.Exists(rutaAR + Ocompra))
                    {
                        if (System.IO.File.Exists(directorio + Ocompra))
                        {
                            System.IO.File.Delete(directorio + Ocompra);
                            System.IO.File.Copy(rutaAR + Ocompra, directorio + Ocompra);
                            System.IO.File.Delete(rutaAR + Ocompra);
                        }
                        else
                        {
                            System.IO.File.Copy(rutaAR + Ocompra, directorio + Ocompra);
                            System.IO.File.Delete(rutaAR + Ocompra);
                        }
                    }
                    if (System.IO.File.Exists(rutaAR + nombre + ".pdf"))
                    {
                        if (System.IO.File.Exists(directorio + nombre + ".pdf"))
                        {
                            System.IO.File.Delete(directorio + nombre + ".pdf");
                            System.IO.File.Copy(rutaAR + nombre + ".pdf", directorio + nombre + ".pdf");
                            System.IO.File.Delete(rutaAR + nombre + ".pdf");
                        }
                        else
                        {
                            System.IO.File.Copy(rutaAR + nombre + ".pdf", directorio + nombre + ".pdf");
                            System.IO.File.Delete(rutaAR + nombre + ".pdf");
                        }
                    }
                    if (!System.IO.File.Exists(rutaAR + nombre + ".PDF"))
                        return;
                    if (System.IO.File.Exists(directorio + nombre + ".PDF"))
                    {
                        System.IO.File.Delete(directorio + nombre + ".PDF");
                        System.IO.File.Copy(rutaAR + nombre + ".PDF", directorio + nombre + ".PDF");
                        System.IO.File.Delete(rutaAR + nombre + ".PDF");
                    }
                    else
                    {
                        System.IO.File.Copy(rutaAR + nombre + ".PDF", directorio + nombre + ".PDF");
                        System.IO.File.Delete(rutaAR + nombre + ".PDF");
                    }
                }
                else
                {
                    if (System.IO.File.Exists(rutaAR + nombre + ".xml"))
                    {
                        if (System.IO.File.Exists(rutaDO + nombre + ".xml"))//revisa si el archivo existe en al carpeta de respaldo 
                        {
                            System.IO.File.Delete(rutaDO + nombre + ".xml");
                            System.IO.File.Copy(rutaAR + nombre + ".xml", rutaDO + nombre + extension);
                            System.IO.File.Delete(rutaAR + nombre + ".xml");
                        }
                        else
                        {
                            System.IO.File.Copy(rutaAR + nombre + ".xml", DIR + nombre + extension);
                            System.IO.File.Delete(rutaAR + nombre + ".xml");
                        }
                    }



                    if (System.IO.File.Exists(rutaAR + nombre + ".XML"))
                    {

                        if (System.IO.File.Exists(directorio + nombre + ".XML"))//revisa si el archivo existe en al carpeta de respaldo 
                        {
                            System.IO.File.Delete(directorio + nombre + ".XML");
                            System.IO.File.Copy(rutaAR + nombre + ".XML", directorio + nombre + extension);
                            System.IO.File.Delete(rutaAR + nombre + ".XML");
                        }
                        else
                        {
                            System.IO.File.Copy(rutaAR + nombre + ".XML", directorio + nombre + extension);
                            System.IO.File.Delete(rutaAR + nombre + ".XML");
                        }
                    }

                    if (pInvoice == "ORACLE")
                    {
                        if (System.IO.File.Exists(rutaAR + Ocompra))
                        {
                            if (System.IO.File.Exists(directorio + Ocompra))//revisa si el archivo existe en al carpeta de respaldo 
                            {
                                System.IO.File.Delete(directorio + Ocompra);
                                System.IO.File.Copy(rutaAR + Ocompra, directorio + Ocompra);
                                System.IO.File.Delete(rutaAR + Ocompra);
                            }
                            else
                            {
                                System.IO.File.Copy(rutaAR + Ocompra, directorio + Ocompra);
                                System.IO.File.Delete(rutaAR + Ocompra);
                            }
                        }
                    }
                    //}



                    if (System.IO.File.Exists(rutaAR + Ocompra + ".pdf"))
                    {
                        if (System.IO.File.Exists(rutaDO + Ocompra + ".pdf"))//revisa si el archivo existe en al carpeta de respaldo 
                        {
                            System.IO.File.Delete(rutaDO + Ocompra + ".pdf");
                            System.IO.File.Copy(rutaAR + Ocompra + ".pdf", DIR + Ocompra + ".pdf");
                            System.IO.File.Delete(rutaAR + Ocompra + ".pdf");
                        }
                        else
                        {
                            System.IO.File.Copy(rutaAR + Ocompra + ".pdf", DIR + Ocompra + ".pdf");
                            System.IO.File.Delete(rutaAR + Ocompra + ".pdf");
                        }
                    }

                    if (System.IO.File.Exists(rutaAR + nombre + ".PDF"))
                    {

                        if (System.IO.File.Exists(directorio + nombre + ".PDF"))//revisa si el archivo existe en al carpeta de respaldo 
                        {
                            System.IO.File.Delete(directorio + nombre + ".PDF");
                            System.IO.File.Copy(rutaAR + nombre + ".PDF", directorio + nombre + ".PDF");
                            System.IO.File.Delete(rutaAR + nombre + ".PDF");
                        }
                        else
                        {
                            System.IO.File.Copy(rutaAR + nombre + ".PDF", directorio + nombre + ".PDF");
                            System.IO.File.Delete(rutaAR + nombre + ".PDF");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                mensajesLog("ES001", "", e.Message, emails, "");
            }
        }

        private String cerosNull(string a)
        {
            if (a.Equals(""))
                return "0.00";
            else
                return a;
        }

        private void mensajeEmailReceptor(string codigo, string mensaje2, string mail)
        {
            string[] array;
            array = PA_mensajes(codigo);
            DateTime fech = DateTime.Today;

            String fecad = fech.ToString("yyyy/MM/dd");
            fecad = fecad.Replace("/", @"\") + @"\";
            try
            {
                if (mail.Length > 5)
                {
                    em = new EnviarMail();
                    em.servidorSTMP(servidor, puerto, ssl, emailCredencial, passCredencial);
                    em.adjuntar(rutaDOC + fecad + rfcEmisor.Replace("&", "_") + @"\" + nombreSE + ".pdf");

                    asunto = "Acabas de recibir una factura con folio. " + folio + " y serie " + serie + ". de: " + rfcEmisor;
                    mensaje = @"Estimado(s): " + nomFin + "<br><br>";
                    mensaje += @"El cliente: " + nombreEmisor + ",con RFC:  " + rfcEmisor + " <br>";
                    mensaje += "Te envio la factura con fecha: " + fech.ToString("yyyy/MM/dd") + @"<br>
                            y  folio " + folio + serie + ".";
                    if (pInvoice == "OTM")
                    {
                        mensaje += "<br>Sector OTM:<br>";
                        mensaje += "No. Sabana: " + NumSabana + "<br>";
                        mensaje += "Site Origen: " + siteOri + "<br>";
                    }
                    else if (pInvoice == "REN")
                    {
                        mensaje += "<br>Factura de RENTA";
                        mensaje += "<br>Dirigida al CC: " + codContable;
                        //mail = "jesus.elias@dhl.com,maria.ginez@dhl.com,Claudia.rojas@dhl.com";
                    }
                    else
                    {
                        mensaje += "<br>Dirigida al CC: " + codContable;
                    }
                    mensaje += "<br><br><br>Saludos cordiales. ";
                    mensaje += "<br>" + nombreReceptor;
                    mensaje += "<br>Servicio proporcionado por DataExpress";
                    mensaje += "<br>ventas@dataexpressintmx.com";
                    //mail = "dmrodriguez@dataexpressintmx.com,alpalacios@dataexpressintmx.com";

                    //mail = em.obtener_mail(mail, IDEFAC);

                    //em.llenarEmail(emailEnviar, mail, "", "dataExpressDHL@gmail.com", asunto, mensaje);

                    //mail = em.obtener_mail(mail, IDEFAC);
                    if (pInvoice == "REN") { mail = mail + ",jesus.elias@dhl.com"; }
                    em.llenarEmail(emailEnviar, mail.Trim(','), "", "dataExpressDHL@gmail.com", asunto, mensaje);


                    //em.llenarEmail(emailEnviar, mail, "", "", asunto, mensaje);
                    //em.adjuntar(rutaBCK + rfcEmisor + @"\" + nombreSE + ".xml");


                    em.enviarEmail();
                    msj = msj + ":";
                }
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                mensajesLog("EM001", "", ex.ToString(), emails, "");
            }

        }

        private void mensajeEmailAdjuntar(string codigo, string mensaje2, string mail)
        {
            string[] array;
            array = PA_mensajes(codigo);
            DateTime fech = DateTime.Today;

            String fecad = fech.ToString("yyyy/MM/dd");
            fecad = fecad.Replace("/", @"\") + @"\";

            if (mail.Length > 5)
            {
                em = new EnviarMail();
                em.servidorSTMP(servidor, puerto, ssl, emailCredencial, passCredencial);
                try
                {
                    em.adjuntar(rutaDOC + fecad + rfcEmisor.Replace("&", "_") + @"\" + nombreSE + ".pdf");
                }
                catch (Exception e)
                {
                    em.adjuntar(rutaBCK + rfcEmisor.Replace("&", "_") + @"\" + nombreSE + ".pdf");
                }
                asunto = "Acabas de recibir una factura con folio. " + folio + " y serie " + serie + ". de: " + rfcEmisor;
                mensaje = @"Estimado(s):<br><br>";
                mensaje += @"El cliente: " + nombreEmisor + ",con RFC:  " + rfcEmisor + " <br>";
                mensaje += "Te envio la factura con fecha: " + fech.ToString("yyyy/MM/dd") + @"<br>
                            y  folio " + folio + serie + ".";
                mensaje += " " + array[0] + " " + nombreEmisor + ",con RFC:  " + rfcEmisor + " <br>";
                if (pInvoice == "OTM")
                {
                    mensaje += "<br>Sector OTM:<br>";
                    mensaje += "No. Sabana: " + NumSabana + "<br>";
                    mensaje += "Site Origen: " + siteOri + "<br>";
                }
                else if (pInvoice == "REN")
                {
                    mensaje += "<br>Factura de RENTA";
                    mensaje += "<br>Dirigida al CC: " + codContable;
                    //mail = "jesus.elias@dhl.com,maria.ginez@dhl.com,Claudia.rojas@dhl.com";
                }
                else
                {
                    mensaje += "<br>Dirigida al CC: " + codContable;
                }
                mensaje += "<br><br><br>Saludos cordiales. ";
                mensaje += "<br>" + nombreReceptor;
                mensaje += "<br>Servicio proporcionado por DataExpress";
                mensaje += "<br>ventas@dataexpressintmx.com";



                //mail = em.obtener_mail(mail, IDEFAC);

                //em.llenarEmail(emailEnviar, mail, "", "dataExpressDHL@gmail.com", asunto, mensaje);


                //mail = em.obtener_mail(mail, IDEFAC);
                if (pInvoice == "REN") { mail = mail + ",jesus.elias@dhl.com"; }
                em.llenarEmail(emailEnviar, mail.Trim(','), "", "dataExpressDHL@gmail.com", asunto, mensaje);

                //em.llenarEmail(emailEnviar, mail, "", "", asunto, mensaje);
                //em.adjuntar(rutaBCK + rfcEmisor + @"\" + nombreSE + ".xml");
                //em.adjuntar(rutaBCK + rfcEmisor + @"\" + nombreSE + ".pdf");
                //try
                //{                
                em.enviarEmail();
                msj = msj + ":";
                //}
                //catch (System.Net.Mail.SmtpException ex)
                //{
                //    mensajesLog("EM001", "", ex.ToString(), "", "");
                //}
            }
        }

        private void mensajeEmailError(string nomAdicional, string mensaje2, string emails)
        {
        }
        private void mensajeEmailErrorA(string nomAdicional, string mensaje2, string emails)
        {
            DateTime fech = DateTime.Today;
            if (correosFin != "")
            {
                emails = (emails.Trim(',') + "," + correosFin).Trim(',');
            }

            if (emails.Length > 5)
            {
                em = new EnviarMail();
                em.servidorSTMP(servidor, puerto, ssl, emailCredencial, passCredencial);

                asunto = "Documentos adicionales de la factura enviada con Folio " + folio + serie;
                mensaje = @"Buen dia! <br>
                            La factura que enviaste " + rfcEmisor + " con fecha: " + fech.ToString("yyyy/MM/dd") + @"<br>
                            ,  folio " + folio + serie + " y UUID " + UUID + ".";
                mensaje += "<br> Tuvo problemas con el archivo adicional:";
                mensaje += "<br>    " + nomAdicional + " no se guardo satisfactoriamente, por favor de responder dicho correo adjuntando el archivo adicional. ";
                mensaje += "<br><br><br>Saludos cordiales. ";
                mensaje += "<br>" + nombreReceptor;
                mensaje += "<br>Servicio proporcionado por DataExpress";
                em.llenarEmail("helpdesk@dataexpressintmx.com", emails, "", "dataExpressDHL@gmail.com", asunto, mensaje);
                em.enviarEmail();
            }
        }

        private void mensajesLog(string codigo, string mensaje, string mensajeTecnico, string emails, string resultadovalidacion)
        {

            string[] array;
            array = PA_mensajes(codigo);
            if (codigo == "RE009")
            {
                msgarrayLog = array[0] + "<br>" + resultadovalidacion;
            }
            else
            {
                msgarrayLog = array[0];
            }
            if (String.IsNullOrEmpty(mensaje))
            {
                mensaje = "";
            }
            if (codigo == "RE008")
            {
                consultarFechaRec(folio, serie, noCertificado, "folio", "serie", "noCertificado", "select fechaRec from General where ");
            }

            DB.Conectar();
            DB.CrearComando(@"insert into LogErrorFacturas
                                (detalle,fecha,archivo,linea,numeroDocumento,tipo,detalleTecnico, resultadoValidacion) 
                                values 
                                (@detalle,@fecha,@archivo,@linea,@numeroDocumento,@tipo,@detalleTecnico,@resultadoValidacion)");
            if (array[0] != null)
            {
                DB.AsignarParametroCadena("@detalle", array[0].Replace("'", "''") + Environment.NewLine + mensaje.Replace("'", "''"));
            }
            else
            {
                DB.AsignarParametroCadena("@detalle", "");
            }
            DB.AsignarParametroCadena("@fecha", System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
            DB.AsignarParametroCadena("@archivo", nombre);
            DB.AsignarParametroCadena("@linea", emails);
            if (array[1] != null)
            {
                DB.AsignarParametroCadena("@tipo", array[1].Replace("'", "''"));
            }
            else
            {
                DB.AsignarParametroCadena("@tipo", "");
            }
            //    if (codigo == "RE008")
            //   {
            //msj = msj + 
            DB.AsignarParametroCadena("@numeroDocumento", folio + serie);
            DB.AsignarParametroCadena("@detalleTecnico", mensajeTecnico.Replace("'", "''"));
            DB.AsignarParametroCadena("@resultadoValidacion", resultadovalidacion.Replace("'", "''"));
            DB.EjecutarConsulta1();
            DB.Desconectar();
            msj = msj + Environment.NewLine + array[1].Replace("'", "''") + ": " + Environment.NewLine + array[0].Replace("'", "''") + "Fecha de recepción:" + fecharec + " " + " " + folio + serie;
            //    }
            //    else
            //    {

            msj = msj + Environment.NewLine + array[1].Replace("'", "''") + ": " + Environment.NewLine + array[0].Replace("'", "''");
            mensenger = msj;

            //    }
        }

        private String[] PA_mensajes(string codigo)
        {
            string[] array;
            array = new string[2];
            DB.Conectar();
            DB.CrearComandoProcedimiento("PA_Errores");
            DB.AsignarParametroProcedimiento("@CODIGO", System.Data.DbType.String, codigo);
            DbDataReader DRE = DB.EjecutarConsulta();
            if (DRE.Read())
            {
                array[0] = codigo + ": " + DRE[0].ToString();

                array[1] = DRE[1].ToString();
            }
            DB.Desconectar();
            return array;
        }

        private decimal Truncate(decimal value, int length)
        {
            if (value.ToString().Contains("."))
            {
                string[] param = value.ToString().Split('.');

                if (param[1].Length >= length)
                    return Convert.ToDecimal(param[0] + "." + param[1].Substring(0, length));
                else
                    return Convert.ToDecimal(param[0] + "." + param[1].Substring(0, param[1].Length));
            }
            else
            {
                return value;
            }
        }

        public String validaRFC(string rfcR)
        {
            string rfcx = "";
            DB.Conectar();
            DB.CrearComando("select RFC,email from Modulos where RFC=@rfcrec");
            DB.AsignarParametroCadena("@rfcrec", rfcR);
            DbDataReader DR3 = DB.EjecutarConsulta();
            if (DR3.Read())
            {
                //rfcx = DR3[0].ToString();
                emailsReceptor = emailsReceptor.Trim(',') + "," + DR3[1].ToString().Trim(',') + "";
            }
            DB.Desconectar();


            DB.Conectar();
            DB.CrearComando("select rfc from receptorCFDI where rfc=@rfcrec");
            DB.AsignarParametroCadena("@rfcrec", rfcR);
            DbDataReader DR4 = DB.EjecutarConsulta();
            if (DR4.Read())
            {
                rfcx = DR4[0].ToString();
                // emailsReceptor = emailsReceptor.Trim(',') + "," + DR3[1].ToString().Trim(',') + "";
            }
            DB.Desconectar();
            return rfcx;
        }

        private bool validarDesc()
        {
            if (descuento != "")
            {
                if (Convert.ToDecimal(descuento) > 0)
                {
                    if (MotivoDescuento != "")
                    {
                        return true;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        public void readComplementoPaid(string fileXML, string filePDF, string rutafiles)
        {
            FileInfo fileInfo = new FileInfo(fileXML);
            XmlDocument xmlDocument = new XmlDocument();
            this.nombre = fileInfo.Name;
            this.extension = fileInfo.Extension;
            this.nombreSE = this.nombre.Replace(this.extension, "");
            // this.nomTemp = fileInfo.DirectoryName + "\\";

            FileInfo fileInfoXML = new FileInfo(fileXML);
            FileInfo fileInfoPDF = new FileInfo(filePDF);
            this.nameXMLp = fileInfoXML.Name;
            this.namePDFp = fileInfoPDF.Name;
            this.extensionXMLp = fileInfoXML.Extension;
            this.extensionPDFp = fileInfoPDF.Extension;
            nameFINALxml = nameXMLp.Replace(this.extensionXMLp, "");
            nameFINALpdf = namePDFp.Replace(this.extensionPDFp, "");
            this.nomTemp = fileInfoXML.DirectoryName + "\\";
            filesPagos = rutafiles;

            if (readXMLPaid(fileXML, filePDF))
            {
                ComplementValidation();
                #region CHECK BANDERAS
                if (banUUIDexistBD)//valida existencia de mismo UUId en base de complemento de pago
                {
                    if (banNumOPI)
                    {
                        if (banFechaI)
                        {
                            if (banMonedaI)
                            {
                                if (banMontoI)
                                {
                                    if (banRFCordenanteI)
                                    {
                                        if (banCtaOrdenanteI)
                                        {
                                            if (banRFCbenefI)
                                            {
                                                if (banCtaBenefI)
                                                {
                                                    if (banNumOPB)
                                                    {
                                                        if (banFechaB)
                                                        {
                                                            if (banMonedaB)
                                                            {
                                                                if (banMontoB)
                                                                {
                                                                    if (banRFCordenanteB)
                                                                    {
                                                                        if (banCtaOrdenanteB)
                                                                        {
                                                                            if (banRFCbenefB)
                                                                            {
                                                                                if (banCtaBenefB)
                                                                                {
                                                                                    if (GeneralComple)
                                                                                    {
                                                                                        if (TxtComple)
                                                                                        {
                                                                                            if (BancosComple)
                                                                                            {
                                                                                                if (bantotal)///totales
                                                                                                {
                                                                                                    if (banMoneda)///moneda
                                                                                                    {
                                                                                                        if (banParcialidades)///parcialaidad
                                                                                                        {
                                                                                                            if (banUUID)//UUID
                                                                                                            {
                                                                                                                if (banSumaTotal)
                                                                                                                {
                                                                                                                    this.guardarBD1();
                                                                                                                    Facturas.anade_linea_archivo(this.archivo_logCOM, "Complemento Valido (Informacion guardada correctamente)");
                                                                                                                }
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                #endregion
            }
            else
            {
                Facturas.anade_linea_archivo(this.archivo_logCOM, "");
            }
        }

        private bool readXMLPaid(string fileXML, string filePDF)
        {
            XmlTextReader xmlTextReader = (XmlTextReader)null;
            #region VARIABLES PAGO
            this.asunto = "";
            this.mensaje = "";
            this.tipoDeComprobante = "";
            this.versionP10 = "";
            this.FechaPagoP = "";
            this.FormaDePagoP = "";
            this.MonedaP = "";
            this.TipoCambioP = "";
            this.MontoP = "";
            this.NumOperacionP = "";
            this.RfcEmisorCtaOrdP = "";
            this.NomBancoOrdExtP = "";
            this.CtaOrdenanteP = "";
            this.RfcEmisorCtaBenP = "";
            this.CtaBeneficiarioP = "";
            this.TipoCadPagoP = "";
            this.CertPagoP = "";
            this.CadPagoP = "";
            this.SelloPagoP = "";
            this.versionP = "";
            this.UUIDP = "";
            this.FechaTimbradoP = "";
            this.selloCFDP = "";
            this.noCertificadoSATP = "";
            this.selloSATP = "";
            this.schemaLocationP = "";
            this.tfdP = "";
            #endregion
            this.banCFDI = true;
            XmlDocument xmlDocument = new XmlDocument();
            string str1 = "cfdi:";
            try
            {
                xmlDocument.Load(fileXML);
                xmlTextReader = new XmlTextReader((TextReader)new StringReader(xmlDocument.OuterXml));
                string str2;
                XmlNodeList elementsByTagName1;
                if ((uint)xmlDocument.GetElementsByTagName(str1 + "Comprobante").Count > 0U)
                {
                    str2 = "cfdi:";
                    elementsByTagName1 = xmlDocument.GetElementsByTagName(str2 + "Comprobante");
                    this.banCFDI = true;
                }
                else
                {
                    str2 = "";
                    elementsByTagName1 = xmlDocument.GetElementsByTagName("Comprobante");
                    this.banCFDI = false;
                }
                foreach (XmlElement xmlElement1 in elementsByTagName1)
                {
                    #region Comprobante
                    try
                    {
                        xmlns = xmlElement1.GetAttribute("xmlns");
                        xmlns_xsi = xmlElement1.GetAttribute("xmlns:xsi");
                        xmlns_xsd = xmlElement1.GetAttribute("xmlns:xsd");
                        xsi_schemaLocation = xmlElement1.GetAttribute("xsi:schemaLocation");
                        version = xmlElement1.GetAttribute("Version").Trim();
                        serie = xmlElement1.GetAttribute("Serie");
                        folio = xmlElement1.GetAttribute("Folio");
                        fecha2 = xmlElement1.GetAttribute("Fecha");
                        sello = xmlElement1.GetAttribute("Sello");
                        formaDePago = xmlElement1.GetAttribute("FormaPago");
                        noCertificado = xmlElement1.GetAttribute("NoCertificado");
                        certificado = xmlElement1.GetAttribute("Certificado");
                        condicionesDePago = xmlElement1.GetAttribute("CondicionesDePago");
                        subTotal = xmlElement1.GetAttribute("SubTotal");
                        descuento = xmlElement1.GetAttribute("Descuento");
                        moneda = xmlElement1.GetAttribute("Moneda");
                        TipoCambio = xmlElement1.GetAttribute("TipoCambio");
                        total = xmlElement1.GetAttribute("Total");
                        tipoDeComprobante = xmlElement1.GetAttribute("TipoDeComprobante");
                        metodoDePago = xmlElement1.GetAttribute("MetodoPago");
                        LugarExpedicion = xmlElement1.GetAttribute("LugarExpedicion");
                        confirmacion = xmlElement1.GetAttribute("Confirmacion");
                    }
                    catch (Exception ex)
                    {
                        this.ValidarXML1 = true;
                        Facturas.anade_linea_archivo(this.archivo_logCOM, "La estructura del Nodo Comprobante es invalida,");
                    }
                    #endregion
                }
                foreach (XmlElement nodo in elementsByTagName1)
                {
                    XmlNodeList emisorP = nodo.GetElementsByTagName(str2 + "Emisor");
                    foreach (XmlElement nodohi in emisorP)
                    {
                        rfcEmisorP = nodohi.GetAttribute("Rfc");
                        nombreEmisor = nodohi.GetAttribute("Nombre");
                        Regimen = nodohi.GetAttribute("RegimenFiscal");
                    }
                    XmlNodeList receptorP = nodo.GetElementsByTagName(str2 + "Receptor");
                    foreach (XmlElement nodohi in receptorP)
                    {
                        rfcReceptorP = nodohi.GetAttribute("Rfc").Trim();
                        nombreReceptor = nodohi.GetAttribute("Nombre");
                        UsoCFDI = nodohi.GetAttribute("UsoCFDI").Trim();
                    }

                    foreach (XmlElement xmlElement2 in nodo.GetElementsByTagName(str2 + "Complemento"))
                    {
                        foreach (XmlElement xmlElement3 in nodo.GetElementsByTagName("pago10:Pagos"))
                        {
                            this.versionP10 = xmlElement3.GetAttribute("version").Trim();
                            foreach (XmlElement xmlElement4 in nodo.GetElementsByTagName("pago10:Pago"))
                            {
                                try
                                {
                                    #region PAGO
                                    this.FechaPagoP = xmlElement4.GetAttribute("FechaPago").Trim();
                                    this.FormaDePagoP = xmlElement4.GetAttribute("FormaDePagoP").Trim();
                                    this.MonedaP = xmlElement4.GetAttribute("MonedaP").Trim();
                                    this.TipoCambioP = xmlElement4.GetAttribute("TipoCambioP").Trim();
                                    this.MontoP = xmlElement4.GetAttribute("Monto").Trim();
                                    this.NumOperacionP = xmlElement4.GetAttribute("NumOperacion").Trim();
                                    this.RfcEmisorCtaOrdP = xmlElement4.GetAttribute("RfcEmisorCtaOrd").Trim();
                                    this.NomBancoOrdExtP = xmlElement4.GetAttribute("NomBancoOrdExt").Trim();
                                    this.CtaOrdenanteP = xmlElement4.GetAttribute("CtaOrdenante").Trim();
                                    this.RfcEmisorCtaBenP = xmlElement4.GetAttribute("RfcEmisorCtaBen").Trim();
                                    this.CtaBeneficiarioP = xmlElement4.GetAttribute("CtaBeneficiario").Trim();
                                    this.TipoCadPagoP = xmlElement4.GetAttribute("TipoCadPago").Trim();
                                    this.CertPagoP = xmlElement4.GetAttribute("CertPago").Trim();
                                    this.CadPagoP = xmlElement4.GetAttribute("CadPago").Trim();
                                    this.SelloPagoP = xmlElement4.GetAttribute("SelloPago").Trim();
                                    #endregion
                                    XmlNodeList elementsByTagName3 = nodo.GetElementsByTagName("pago10:DoctoRelacionado");
                                    this.arrayListComPago = new ArrayList();
                                    foreach (XmlElement xmlElement5 in elementsByTagName3)
                                    {
                                        #region DOCRELACIONADO
                                        try
                                        {
                                            this.IdDocumentoP = "";
                                            this.SerieP = "";
                                            this.FolioP = "";
                                            this.MonedaDRP = "";
                                            this.TipoCambioDRP = "";
                                            this.MetodoDePagoDRP = "";
                                            this.NumParcialidadP = "";
                                            this.ImpSaldoAntP = "";
                                            this.ImpPagadoP = "";
                                            this.ImpSaldoInsolutoP = "";
                                            this.arrayComPago = new string[10];
                                            this.arrayComPago[0] = this.IdDocumentoP = xmlElement5.GetAttribute("IdDocumento").Trim();
                                            this.arrayComPago[1] = this.SerieP = xmlElement5.GetAttribute("Serie").Trim();
                                            this.arrayComPago[2] = this.FolioP = xmlElement5.GetAttribute("Folio").Trim();
                                            this.arrayComPago[3] = this.MonedaDRP = xmlElement5.GetAttribute("MonedaDR").Trim();
                                            this.arrayComPago[4] = this.TipoCambioDRP = xmlElement5.GetAttribute("TipoCambioDR").Trim();
                                            this.arrayComPago[5] = this.MetodoDePagoDRP = xmlElement5.GetAttribute("MetodoDePagoDR").Trim();
                                            this.arrayComPago[6] = this.NumParcialidadP = xmlElement5.GetAttribute("NumParcialidad").Trim();
                                            this.arrayComPago[7] = this.ImpSaldoAntP = xmlElement5.GetAttribute("ImpSaldoAnt").Trim();
                                            this.arrayComPago[8] = this.ImpPagadoP = xmlElement5.GetAttribute("ImpPagado").Trim();
                                            this.arrayComPago[9] = this.ImpSaldoInsolutoP = xmlElement5.GetAttribute("ImpSaldoInsoluto").Trim();
                                            this.arrayListComPago.Add((object)this.arrayComPago);
                                        }
                                        catch (Exception ex)
                                        {
                                            this.ValidarXML1 = true;
                                            Facturas.anade_linea_archivo(this.archivo_logCOM, "Estructura del Nodo DoctoRelacionado incorrecta,");
                                        }
                                        #endregion
                                    }
                                }
                                catch (Exception ex)
                                {
                                    this.ValidarXML1 = true;
                                    Facturas.anade_linea_archivo(this.archivo_logCOM, "Estructura del Nodo Pago es invalida,");
                                }
                            }
                        }
                        foreach (XmlElement xmlElement3 in nodo.GetElementsByTagName("tfd:TimbreFiscalDigital"))
                        {
                            #region TIMBRE
                            this.versionP = xmlElement3.GetAttribute("Version").Trim();
                            this.UUIDP = xmlElement3.GetAttribute("UUID").Trim();
                            this.FechaTimbradoP = xmlElement3.GetAttribute("FechaTimbrado").Trim();
                            this.selloCFDP = xmlElement3.GetAttribute("SelloCFD").Trim();
                            this.noCertificadoSATP = xmlElement3.GetAttribute("NoCertificadoSAT").Trim();
                            this.selloSATP = xmlElement3.GetAttribute("SelloSAT").Trim();
                            this.schemaLocationP = xmlElement3.GetAttribute("xsi:schemaLocation").Trim();
                            this.tfdP = xmlElement3.GetAttribute("xmlns:tfd").Trim();
                            #endregion|
                        }
                    }
                }
                return true;

            }
            catch (Exception ex)
            {
                Facturas.anade_linea_archivo(this.archivo_logCOM, "La estructura del XML no es valida,");
                return false;
            }
        }

        private bool ComplementValidation()
        {

            #region VARIABLES FILTER DHL

            #endregion
            #region INFOTXTPAGO

            var RefTransf = "";
            decimal suma = 0;
            #endregion
            try
            {
                DB.Conectar();
                DB.CrearComando("select uuidP from generalPago where uuidP=@uuidP");
                DB.AsignarParametroCadena("@uuidP", UUIDP);
                DbDataReader DRV = DB.EjecutarConsulta();
                if (DRV.Read())
                {
                    Facturas.anade_linea_archivo(this.archivo_logCOM, "Existe un recibo con mismo folio fiscal " + UUIDP);
                    banUUIDexistBD = false;
                }
                else { banUUIDexistBD = true; }
                DB.Desconectar();

                #region OBTAIN DATES INFOTXTPAGO CON PAGO10 DE XML
                gPago = new List<string>();
                DB.Conectar();
                DB.CrearComando("SELECT FechaPago, MonedaP, Monto, RfcEmisorCtaOrd, CtaBanOrden, RfcEmisorCtaRec, CtaBanBenef FROM InfoTxtPago  where RefTransf=@numOper");
                DB.AsignarParametroCadena("@numOper", NumOperacionP);
                DbDataReader DRT1 = DB.EjecutarConsulta();
                if (DRT1.Read())
                {
                    gPago.Add(DRT1[0].ToString());
                    gPago.Add(DRT1[1].ToString());
                    gPago.Add(DRT1[2].ToString());
                    gPago.Add(DRT1[3].ToString());
                    gPago.Add(DRT1[4].ToString());
                    gPago.Add(DRT1[5].ToString());
                    gPago.Add(DRT1[6].ToString());
                    banNumOPI = true;
                }
                else { anade_linea_archivo(this.archivo_logCOM, "El Numero de Operacion nodo Pago es diferente al enviado en el recibo de oracle"); banNumOPI = false; }
                DB.Desconectar();
                if (Convert.ToDateTime(gPago[0]).ToString("yyyy/MM/dd").Equals(Convert.ToDateTime(FechaPagoP).ToString("yyyy/MM/dd"))) { banFechaI = true; } else { anade_linea_archivo(archivo_logCOM, "La fecha de pago del nodo Pago es diferente al enviado en el recibo de oracle"); banFechaI = false; }
                if (gPago[1].Equals(MonedaP)) { banMonedaI = true; } else { anade_linea_archivo(archivo_logCOM, "El tipo de moneda del nodo Pago es diferente al enviado en el recibo de oracle"); banMonedaI = false; }
                if (gPago[2].Equals(MontoP)) { banMontoI = true; } else { anade_linea_archivo(archivo_logCOM, "El monto del nodo Pago es diferente al enviado en el recibo de oracle"); banMontoI = false; }
                //    if (gPago[3].Equals(RfcEmisorCtaOrdP)) { banRFCordenanteI = true; } else { anade_linea_archivo(archivo_logCOM, "El RFC Ordenante del nodo Pago es diferente al enviado en el recibo de oracle"); banRFCordenanteI = false; }
                if (gPago[4].Equals(CtaOrdenanteP)) { banCtaOrdenanteI = true; } else { anade_linea_archivo(archivo_logCOM, "La Cuenta Ordenante del nodo Pago es diferente al enviado en el recibo de oracle"); banCtaOrdenanteI = false; }
                //   if (gPago[5].Equals(RfcEmisorCtaBenP)) { banRFCbenefI = true; } else { anade_linea_archivo(archivo_logCOM, "El RFC Beneficiario del nodo Pago es diferente al enviado en el recibo de oracle"); banRFCbenefI = false; }
                if (gPago[6].Equals(CtaBeneficiarioP)) { banCtaBenefI = true; } else { anade_linea_archivo(this.archivo_logCOM, "La Cuenta Ordenante del nodo Pago es diferente al enviado en el recibo de oracle"); banCtaBenefI = false; }
                #endregion
                #region OBTAIN DATES INFOTXTPAGO CON PAGO10 DE XML
                gBanco = new List<string>();
                DB.Conectar();
                DB.CrearComando("SELECT Fecha, Moneda, Monto, RfcOrdenante, CtaOrdenanteTrans, RfcBenef, CtaBenef FROM BancosInfo  where RefNumTrans=@numOper");
                DB.AsignarParametroCadena("@numOper", NumOperacionP);
                DbDataReader DRT2 = DB.EjecutarConsulta();
                if (DRT2.Read())
                {
                    gBanco.Add(DRT2[0].ToString());
                    gBanco.Add(DRT2[1].ToString());
                    gBanco.Add(DRT2[2].ToString());
                    gBanco.Add(DRT2[3].ToString());
                    gBanco.Add(DRT2[4].ToString());
                    gBanco.Add(DRT2[5].ToString());
                    gBanco.Add(DRT2[6].ToString());
                }
                else { anade_linea_archivo(this.archivo_logCOM, "El Numero de Operacion nodo Pago es diferente al enviado en el recibo de oracle"); banNumOPI = false; }
                DB.Desconectar();
                if (Convert.ToDateTime(gBanco[0]).ToString("yyyy/MM/dd").Equals(Convert.ToDateTime(FechaPagoP).ToString("yyyy/MM/dd"))) { banFechaB = true; } else { anade_linea_archivo(archivo_logCOM, "La fecha de pago del nodo Pago es diferente al enviado en el recibo de oracle"); banFechaB = false; }
                if (gBanco[1].Equals(MonedaP)) { banMonedaB = true; } else { anade_linea_archivo(archivo_logCOM, "El tipo de moneda del nodo Pago es diferente al enviado en el recibo de oracle"); banMonedaB = false; }
                if (gBanco[2].Equals(MontoP)) { banMontoB = true; } else { anade_linea_archivo(archivo_logCOM, "El monto del nodo Pago es diferente al enviado en el recibo de oracle"); banMontoB = false; }
                if (gBanco[3].Equals(RfcEmisorCtaOrdP)) { banRFCordenanteB = true; } else { anade_linea_archivo(archivo_logCOM, "El RFC Ordenante del nodo Pago es diferente al enviado en el recibo de oracle"); banRFCordenanteB = false; }
                if (gBanco[4].Equals(CtaOrdenanteP)) { banCtaOrdenanteB = true; } else { anade_linea_archivo(archivo_logCOM, "La Cuenta Ordenante del nodo Pago es diferente al enviado en el recibo de oracle"); banCtaOrdenanteB = false; }
                if (gBanco[5].Equals(RfcEmisorCtaBenP)) { banRFCbenefB = true; } else { anade_linea_archivo(archivo_logCOM, "El RFC Beneficiario del nodo Pago es diferente al enviado en el recibo de oracle"); banRFCbenefB = false; }
                if (gBanco[6].Equals(CtaBeneficiarioP)) { banCtaBenefB = true; } else { anade_linea_archivo(this.archivo_logCOM, "La Cuenta Ordenante del nodo Pago es diferente al enviado en el recibo de oracle"); banCtaBenefB = false; }
                #endregion




                foreach (string[] obj in arrayListComPago)
                {
                    DetGen = new List<string>();
                    DetPago = new List<string>();
                    DetBanco = new List<string>();
                    General = new List<List<string>>();
                    txtPago = new List<List<string>>();
                    Bancos = new List<List<string>>();
                    #region OBTAIN DATES GENERAL PAGO
                    DB.Conectar();
                    DB.CrearComando("SELECT GENERAL.serie, GENERAL.folio, GENERAL.Moneda, GENERAL.TipoCambio, GENERAL.metodoDePago, RFCEMI, rfc FROM GENERAL INNER JOIN CFDI ON GENERAL.idFactura = CFDI.id_Factura inner join Proveedores ON Proveedores.idProveedor = GENERAL.idProv inner join EMISOR ON EMISOR.IDEEMI = GENERAL.id_Emisor WHERE UUID =@UUIDFAC");
                    DB.AsignarParametroCadena("@UUIDFAC", obj[0].ToString());
                    DbDataReader DR = DB.EjecutarConsulta();
                    if (DR.Read())
                    {
                        DetGen.Add(DR[0].ToString());
                        DetGen.Add(DR[1].ToString());
                        DetGen.Add(DR[2].ToString());
                        DetGen.Add(DR[3].ToString());
                        DetGen.Add(DR[4].ToString());
                        DetGen.Add(DR[5].ToString());
                        DetGen.Add(DR[6].ToString());
                        General.Add(DetGen);
                        GeneralComple = true;
                    }
                    else
                    {
                        Facturas.anade_linea_archivo(this.archivo_logCOM, "No existe una factuta relacionada " + obj[0].ToString() + ",");
                        GeneralComple = false;
                    }
                    DB.Desconectar();
                    #endregion

                    #region OBTAIN DATES INFOTXTPAGO CON IDDOCUMENTO DE XML
                    DB.Conectar();
                    DB.CrearComando("SELECT InfoTxtPago.RFCEmisor, InfoTxtPago.RFCReceptor, InfoTxtDetalles.FolioOrig, InfoTxtDetalles.MonedaP, InfoTxtDetalles.TipoDeCambioP, InfoTxtDetalles.MetododePagoDR, InfoTxtDetalles.NumParcialidad, InfoTxtDetalles.ImpPagado, InfoTxtPago.RefTransf, InfoTxtPago.CtaBanOrden FROM InfoTxtPago INNER JOIN InfoTxtDetalles ON InfoTxtDetalles.id_InfoTxt = InfoTxtPago.idInfoTxtPago where FolioOrig=@FolioOrig and NumParcialidad=@parcia");
                    DB.AsignarParametroCadena("@FolioOrig", obj[0].ToString());
                    DB.AsignarParametroCadena("@parcia", obj[6].ToString());
                    DbDataReader DRT = DB.EjecutarConsulta();
                    if (DRT.Read())
                    {
                        DetPago.Add(DRT[0].ToString());
                        DetPago.Add(DRT[1].ToString());
                        DetPago.Add(DRT[2].ToString());
                        DetPago.Add(DRT[3].ToString());
                        DetPago.Add(DRT[4].ToString());
                        DetPago.Add(DRT[5].ToString());
                        DetPago.Add(DRT[6].ToString());
                        DetPago.Add(DRT[7].ToString());
                        DetPago.Add(DRT[8].ToString());
                        RefTransf = DRT[8].ToString();
                        DetPago.Add(DRT[9].ToString());
                        txtPago.Add(DetPago);
                        TxtComple = true;
                    }
                    else
                    {
                        Facturas.anade_linea_archivo(this.archivo_logCOM, "No hay recibo de oracle para validar el complemento " + obj[0].ToString() + ",");
                        TxtComple = false;
                    }
                    DB.Desconectar();
                    #endregion

                    #region OBTAIN INFO BANCOS CON IDDOCUMENTO DE XML
                    DB.Conectar();
                    DB.CrearComando("SELECT Monto, RefNumTrans, moneda, RfcOrdenante, CtaOrdenanteTrans, RfcBenef, CtaBenef FROM BancosInfo WHERE RefNumTrans=@numTrans");
                    DB.AsignarParametroCadena("@numTrans", RefTransf);
                    DbDataReader DRB = DB.EjecutarConsulta();
                    if (DRB.Read())
                    {
                        DetBanco.Add(DRB[0].ToString());
                        DetBanco.Add(DRB[1].ToString());
                        DetBanco.Add(DRB[2].ToString());
                        DetBanco.Add(DRB[3].ToString());
                        DetBanco.Add(DRB[4].ToString());
                        DetBanco.Add(DRB[5].ToString());
                        DetBanco.Add(DRB[6].ToString());
                        Bancos.Add(DetBanco);
                        BancosComple = true;
                    }
                    else
                    {
                        if (DetPago[9].Contains("PAGOS EN CERO")) { BancosComple = true; }
                        else
                        {
                            Facturas.anade_linea_archivo(this.archivo_logCOM, "No hay informacion de banco para validar el complemento " + obj[0].ToString() + ",");
                            BancosComple = false;
                        }
                    }
                    DB.Desconectar();
                    #endregion


                    if (txtPago.Count > 0 && Bancos.Count > 0)
                    {
                        if (obj[8].Equals(DetPago[7])) { bantotal = true; }
                        else { Facturas.anade_linea_archivo(this.archivo_logCOM, "El total de complemento es diferente al recibo de pago"); bantotal = false; }
                        if (obj[3].Equals(DetPago[3]) && obj[3].Equals(DetBanco[2])) { banMoneda = true; }
                        else { Facturas.anade_linea_archivo(this.archivo_logCOM, "Moneda diferente entre XML Complemento e informacion de bancos"); banMoneda = false; }
                        if (obj[6].Equals(DetPago[6])) { banParcialidades = true; }
                        else { Facturas.anade_linea_archivo(this.archivo_logCOM, "Las parcialidades son diferentes entre XML complemento y recibo Oracle"); banParcialidades = false; }
                        if (obj[0].Equals(DetPago[2])) { banUUID = true; }
                        else { Facturas.anade_linea_archivo(this.archivo_logCOM, "El folio fiscal del XML es diferente al recibo oracle"); banUUID = false; }

                        //var metodoPago = "";
                        //if (DetPago[5].Equals("WIRE")) { metodoPago = "PPD"; }
                        //if (obj[5].Equals(metodoPago)) { banUUID = true; }
                        //else { Facturas.anade_linea_archivo(this.archivo_logCOM, "El folio fiscal del XML es diferente al recibo oracle"); banUUID = false; }

                    }
                    suma += Convert.ToDecimal(obj[8]);
                }
                if (DetPago[9].Contains("PAGOS EN CERO")) { banSumaTotal = true; }
                else
                {
                    if (suma == Convert.ToDecimal(DetBanco[0])) { banSumaTotal = true; }
                    else { banSumaTotal = false; }
                }

                return true;
            }
            catch (Exception es)
            {
                Facturas.anade_linea_archivo(this.archivo_logCOM, es.ToString());
                return false; ;
            }

        }

        private bool validation33(string rfcE)
        {
            VregFiscal = "";
            VusoCFDI = "";
            Vimpuestos = "";
            VtipoFactor = "";
            VtasaCuota = "";

            string str = "";
            DB.Conectar();
            DB.CrearComando("select tipoProveedor from proveedores where rfc=@rfc");
            DB.AsignarParametroCadena("@rfc", rfcE);
            DbDataReader dbDataReader = DB.EjecutarConsulta();
            if (dbDataReader.Read())
                str = dbDataReader[0].ToString();
            DB.Desconectar();
            string upper = TipoProveedor.ToUpper();
            // ISSUE: reference to a compiler-generated method
            switch (str.ToUpper())
            {
                #region BIENES Y SERVICIOS
                case "BIENES Y SERVICIOS":
                    this.VregFiscal = "601,603,612,621,620,623,624";
                    this.VusoCFDI = "G03,I01,I02,I03,I04,I08,P01,G01";
                    this.Vimpuestos = "002,003";
                    this.VtipoFactor = "TASA";
                    this.VtasaCuota = "0.16";
                    if (ReadConceptosTR(this.VregFiscal, this.VusoCFDI, this.Vimpuestos, this.VtipoFactor, this.VtasaCuota, str))
                    { return true; }
                    else { return false; }
                #endregion
                case "FLETES":
                    this.VregFiscal = "601,612,624,621,623";
                    this.VusoCFDI = "G03,G02,P01";
                    this.Vimpuestos = "002";
                    this.VtipoFactor = "TASA";
                    this.VtasaCuota = "0.04,0.16";
                    if (ReadConceptosTR(this.VregFiscal, this.VusoCFDI, this.Vimpuestos, this.VtipoFactor, this.VtasaCuota, str))
                    { return true; }
                    else { return false; }
                case "AGENCIAS":
                    this.VregFiscal = "601";
                    this.VusoCFDI = "G03,P01";
                    this.Vimpuestos = "002";
                    this.VtipoFactor = "TASA";
                    this.VtasaCuota = "0.16";
                    if (ReadConceptosTR(this.VregFiscal, this.VusoCFDI, this.Vimpuestos, this.VtipoFactor, this.VtasaCuota, str))
                    { return true; }
                    else { return false; }
                case "RENTA CON RETENCION":
                    this.VregFiscal = "603,606,612";
                    this.VusoCFDI = "G03,P01";
                    this.Vimpuestos = "001,002";
                    this.VtipoFactor = "TASA";
                    this.VtasaCuota = "0.1,0.1066,0.106666,0.1067,0.16,0.106667";
                    if (ReadConceptosTR(this.VregFiscal, this.VusoCFDI, this.Vimpuestos, this.VtipoFactor, this.VtasaCuota, str))
                    { return true; }
                    else { return false; }
                case "IMSS SAR INFONAVIT ENE-JUN":
                    this.VregFiscal = "603";
                    this.VusoCFDI = "G03,P01";
                    this.Vimpuestos = "002";
                    this.VtipoFactor = "EXENTO";
                    this.VtasaCuota = "0.00";
                    if (ReadConceptosTR(this.VregFiscal, this.VusoCFDI, this.Vimpuestos, this.VtipoFactor, this.VtasaCuota, str))
                    { return true; }
                    else { return false; }
                case "IMSS SAR INFONAVIT JUL-DIC":
                    this.VregFiscal = "603";
                    this.VusoCFDI = "G03,P01";
                    this.Vimpuestos = "002";
                    this.VtipoFactor = "EXENTO";
                    this.VtasaCuota = "0.00";
                    if (ReadConceptosTR(this.VregFiscal, this.VusoCFDI, this.Vimpuestos, this.VtipoFactor, this.VtasaCuota, str))
                    { return true; }
                    else { return false; }
                case "IMPUESTOS ENE-JUN":
                    this.VregFiscal = "603";
                    this.VusoCFDI = "G03,P01";
                    this.Vimpuestos = "002";
                    this.VtipoFactor = "EXENTO";
                    this.VtasaCuota = "0.00";
                    if (ReadConceptosTR(this.VregFiscal, this.VusoCFDI, this.Vimpuestos, this.VtipoFactor, this.VtasaCuota, str))
                    { return true; }
                    else { return false; }
                case "RENTAS":
                    this.VregFiscal = "601,606,603";
                    this.VusoCFDI = "G03,P01";
                    this.Vimpuestos = "002";
                    this.VtipoFactor = "TASA";
                    this.VtasaCuota = "0.16";
                    if (ReadConceptosTR(this.VregFiscal, this.VusoCFDI, this.Vimpuestos, this.VtipoFactor, this.VtasaCuota, str))
                    { return true; }
                    else { return false; }
                case "HOSPEDAJES Y CONVENCIONES":
                    this.VregFiscal = "601,603";
                    this.VusoCFDI = "G03,P01";
                    this.Vimpuestos = "002";
                    this.VtipoFactor = "TASA";
                    this.VtasaCuota = "0.16";
                    if (ReadConceptosTR(this.VregFiscal, this.VusoCFDI, this.Vimpuestos, this.VtipoFactor, this.VtasaCuota, str))
                    { return true; }
                    else { return false; }
                case "BIENES Y SERVICIOS SIN IVA":
                    this.VregFiscal = "601,603,612,621";
                    this.VusoCFDI = "G03,P01";
                    this.Vimpuestos = "002,003";
                    this.VtipoFactor = "EXENTO";
                    this.VtasaCuota = "0.00";
                    if (ReadConceptosTR(this.VregFiscal, this.VusoCFDI, this.Vimpuestos, this.VtipoFactor, this.VtasaCuota, str))
                    { return true; }
                    else { return false; }
                case "HONORARIOS":
                    this.VregFiscal = "612";
                    this.VusoCFDI = "G03,P01";
                    this.Vimpuestos = "001,002";
                    this.VtipoFactor = "TASA";
                    this.VtasaCuota = "0.10,0.1066,0.1067,0.16,0.106667";
                    if (ReadConceptosTR(this.VregFiscal, this.VusoCFDI, this.Vimpuestos, this.VtipoFactor, this.VtasaCuota, str))
                    { return true; }
                    else { return false; }
                case "HONORARIOS EXENTO":
                    this.VregFiscal = "612";
                    this.VusoCFDI = "G03,P01";
                    this.Vimpuestos = "001,002";
                    this.VtipoFactor = "EXENTO";
                    this.VtasaCuota = "0.00";
                    if (ReadConceptosTR(this.VregFiscal, this.VusoCFDI, this.Vimpuestos, this.VtipoFactor, this.VtasaCuota, str))
                    { return true; }
                    else { return false; }
                default:
                    return false;
            }
        }

        private bool ReadConceptosTR(string VregFiscal, string VusoCFDI, string Vimpuestos, string VtipoFactor, string VtasaCuota, string str)
        {
            bool validador = false;
            string str1 = "";
            string str2 = "";
            string str3 = "";
            try
            {
                if (str.Equals("BIENES Y SERVICIOS SIN IVA") || str.Equals("IMSS SAR INFONAVIT ENE-JUN") || str.Equals("IMPUESTOS ENE-JUN")) { return true; }
                else
                {
                    if (arrayListImpuestosTC.Count > 0)
                    {
                        foreach (string[] strArray in arrayListImpuestosTC)
                        {
                            if (!str3.Contains(VtasaCuota) || str3 == "")
                            {
                                str1 = strArray[0].ToString();
                                str2 = strArray[1].ToString();
                                str3 = Convert.ToDouble(strArray[2]).ToString();
                            }

                            #region LOG POR IMPUESTO
                            if (!VregFiscal.Contains(Regimen))
                                Facturas.anade_linea_archivo(archivo_logXSD, "-Regimen Fiscal invalido para tipo de proveedor,");
                            if (!VusoCFDI.Contains(UsoCFDI))
                                Facturas.anade_linea_archivo(archivo_logXSD, "-Uso CFDI invalido para tipo de proveedor,");
                            if (!Vimpuestos.Contains(str1))
                                Facturas.anade_linea_archivo(archivo_logXSD, "-Codigo impuesto invalido para tipo de proveedor,");
                            if (arrayListImpuestosRC.Count > 0 || arrayListImpuestosTC.Count > 0)
                            {
                                if (!VtipoFactor.ToUpper().Equals(str2.ToUpper()))
                                    Facturas.anade_linea_archivo(archivo_logXSD, "-Tipo Factor invalido para tipo de proveedor,");
                            }
                            if (arrayListImpuestosRC.Count > 0)
                            {
                                if (!VtasaCuota.Contains(str3))
                                    Facturas.anade_linea_archivo(archivo_logXSD, "-Tasa o Cuota invalida en conceptos para tipo de proveedor,");
                            }
                            if (VregFiscal.Contains(Regimen) && VusoCFDI.Contains(UsoCFDI) && ((Vimpuestos.Contains(str1) && VtipoFactor.ToUpper().Equals(str2.ToUpper())) || (arrayListImpuestosRC.Count.Equals(0) || arrayListImpuestosRC.Count.Equals(0))) && (VtasaCuota.Contains(str3) || arrayListImpuestosRC.Count.Equals(0)))
                            { validador = true; }
                            else { return false; }
                            #endregion
                        }
                        //     return validador;
                    }
                    else { str3 = VtasaCuota; }
                    if (arrayListImpuestosRC.Count > 0)
                    {
                        if (VtasaCuota.Contains(str3))
                        {
                            foreach (string[] strArray in arrayListImpuestosRC)
                            {
                                if (!str3.Contains(VtasaCuota) || str3 == "")
                                {
                                    str1 = strArray[0].ToString();
                                    str2 = strArray[1].ToString();
                                    str3 = Convert.ToDouble(strArray[2]).ToString();
                                }


                                if (!VregFiscal.Contains(Regimen))
                                    Facturas.anade_linea_archivo(archivo_logXSD, "-Regimen Fiscal invalido para tipo de proveedor,");
                                if (!VusoCFDI.Contains(UsoCFDI))
                                    Facturas.anade_linea_archivo(archivo_logXSD, "-Uso CFDI invalido para tipo de proveedor,");
                                if (!Vimpuestos.Contains(str1))
                                    Facturas.anade_linea_archivo(archivo_logXSD, "-Codigo impuesto invalido para tipo de proveedor,");
                                if (arrayListImpuestosRC.Count > 0 || arrayListImpuestosTC.Count > 0)
                                {
                                    if (!VtipoFactor.ToUpper().Equals(str2.ToUpper()))
                                        Facturas.anade_linea_archivo(archivo_logXSD, "-Tipo Factor invalido para tipo de proveedor,");
                                }
                                if (arrayListImpuestosRC.Count > 0)
                                {
                                    if (!VtasaCuota.Contains(str3))
                                        Facturas.anade_linea_archivo(archivo_logXSD, "-Tasa o Cuota invalida en conceptos para tipo de proveedor,");
                                }
                                if (VregFiscal.Contains(Regimen) && VusoCFDI.Contains(UsoCFDI) && ((Vimpuestos.Contains(str1) && VtipoFactor.ToUpper().Equals(str2.ToUpper())) || (arrayListImpuestosRC.Count.Equals(0) || arrayListImpuestosRC.Count.Equals(0))) && (VtasaCuota.Contains(str3) || arrayListImpuestosRC.Count.Equals(0)))
                                { validador = true; }
                                else { return false; }
                            }
                        }
                    }
                    return validador;
                }
            }
            catch
            {
                Facturas.anade_linea_archivo(archivo_logXSD, "-El comprobante no contiene impuestos a nivel de conceptos,");
                return false;
            }
        }

        private string ObtainMPproveedores(string MPproveedores)
        {
            DB.Conectar();
            DB.CrearComando("select formaPago from proveedores where rfc=@rfc");
            DB.AsignarParametroCadena("@rfc", rfcReceptor);
            DbDataReader dbDataReader = DB.EjecutarConsulta();
            if (dbDataReader.Read())
                MPaymentBD = dbDataReader[0].ToString();
            DB.Desconectar();
            return tMPaymentBD;
        }

        public static void anade_linea_archivo(string archivo, string linea)
        {
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + @"logFACTURAS"))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"logFACTURAS");
            }
            using (StreamWriter w = File.AppendText(archivo))
            {
                w.WriteLine(linea.Replace(Environment.NewLine, ""));
                w.Flush();
                w.Close();
            }
        }

        private void DocRelacion(string serie, string folio, string numPar, string monto)
        {
            if (Convert.ToInt32(numPar) > 1)
            {
                try
                {
                    decimal uno = 0;
                    decimal dos = 0;
                    decimal tres = 0;
                    decimal totalFAC = 0;
                    DB.Conectar();
                    DB.CrearComando(@"select GENERAL.TOTAL, SUM(relacionPago.impSaldoAnt), SUM(relacionPago.impPagado), SUM(relacionPago.impSaldoInsoluto) from  General left outer join 
            relacionPago ON  general.IDEFAC=relacionPago.id_factura left outer join
            GeneralPago ON relacionPago.id_ComPago = GeneralPago.idComPago 
            where serie=@serieFac and folio=@folioFac group by GENERAL.TOTAL");
                    DB.AsignarParametroCadena("@folioFac", folio);
                    DB.AsignarParametroCadena("@serieFac", serie);
                    DbDataReader DRG = DB.EjecutarConsulta();
                    if (DRG.Read())
                    {
                        totalFAC = Convert.ToDecimal(DRG[0]);
                        uno = Convert.ToDecimal(monto) + Convert.ToDecimal(DRG[1]);
                        dos = Convert.ToDecimal(monto) + Convert.ToDecimal(DRG[1]);
                        tres = Convert.ToDecimal(monto) + Convert.ToDecimal(DRG[2]);
                    }
                    DB.Desconectar();
                    decimal CUATRO = uno - Convert.ToDecimal(monto);
                    IMPSALDOANTDR = uno.ToString();
                    IMPSALDOINSOLUTODR = CUATRO.ToString();
                    IMPPAGADODR = tres.ToString();
                    //    if (dos > totalFAC) { metodoPagoOK = false; msjPagos33 = "El importe del pago excede el total de la factura.\n"; }
                }
                catch { DB.Desconectar(); }
            }
            else
            {
                IMPSALDOANTDR = monto;
                IMPSALDOINSOLUTODR = "0.00";
            }

        }

        protected bool SaveData(string FileName, byte[] Data)
        {
            BinaryWriter Writer = null;
            string Name = FileName;

            try
            {
                Writer = new BinaryWriter(File.OpenWrite(Name));
                Writer.Write(Data);
                Writer.Flush();
                Writer.Close();
            }
            catch
            {
                return false;
            }

            return true;
        }

        private string obtenerNumOper(string folio, string parcia, string idCom)
        {
            var numOperacion = "";
            DB.Conectar();
            DB.CrearComando("select RefTransf from InfoTxtPago inner join InfoTxtDetalles ON InfoTxtDetalles.id_InfoTxt = InfoTxtPago.idInfoTxtPago where FolioOrig = @folio and NumParcialidad = @parcia");
            DB.AsignarParametroCadena("@folio", folio);
            DB.AsignarParametroCadena("@parcia", parcia);
            var dbDataReader = DB.EjecutarConsulta();
            if (dbDataReader.Read())
                numOperacion = dbDataReader[0].ToString();
            DB.Desconectar();

            DB.Conectar();
            DB.CrearComando(@"update GeneralPago set numOperacion=@numOpe where idComPago=@idfa");
            DB.AsignarParametroCadena("@numOpe", numOperacion);
            DB.AsignarParametroCadena("@idfa", idCom);
            DB.EjecutarConsulta1();
            DB.Desconectar();

            return numOperacion;
        }

    }
}
