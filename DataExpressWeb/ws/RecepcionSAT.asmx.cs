using Control;
using Control.ConsultaCFDIService;
using Datos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Services;
using System.Xml;
using System.Xml.XPath;
using ValSign;

namespace DataExpressWeb.ws
{
    /// <summary>
    /// Descripción breve de RecepcionSAT
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class RecepcionSAT : System.Web.Services.WebService
    {
        ValidacionCert VC = new ValidacionCert();
        ValidacionFolios VF = new ValidacionFolios();
        ValidacionEstructura VE = new ValidacionEstructura();
        String archivo_Corrup = AppDomain.CurrentDomain.BaseDirectory + @"\ErrorCorrup.txt";
        String archivo_log = AppDomain.CurrentDomain.BaseDirectory + @"\LOG.txt";

        BasesDatos DB = new BasesDatos();

        int auxContCer = 0;
        bool ban = false;
        string[] rutaFAC;
        string rutaBCK;
        string fileCer, urlCer;
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
        string emailEnviar;
        string emailNoti;
        EnviarMail em;
        public String emails = "";
        string emailsReceptor = "";
        String asunto;
        string mensaje;
        string cadRes = "";
        string IDEREC;
        string IDEEMI;
        string IDEFAC;
        string IDEDOMEMIEXP;
        public string TIPOORDEN;

        private bool ValidarXML1 = false;
        private bool ValidarXML2 = false;
        private bool ValidarXML3 = false;
        private bool ValidarXML4 = false;
        private bool ValidarXML5 = false;
        private bool ValidarXML6 = false;
        private bool ValidarXML7 = false;
        private bool ValidarXML_ctaPredial = false;
        private string MPaymentBD = "";
        string tMPaymentBD = "";
        Boolean val_FaD_d_Total = false;

        //comprobante
        string xmlns, xmlns_xsi, xmlns_xsd, xsi_schemaLocation, folio, fecha2;
        string version;
        string serie;
        public string sello;
        string noAprobacion;
        string anoAprobacion;
        string codContable = "";
        string moneda = "";
        string NumSabana = "";
        string siteOri = "";
        string correosFin;
        string nomFin;
        string estadoFinal = "";

        string formaDePago, subTotal, total, tipoDeComprobante, LugarExpedicion;
        string descuento, Moneda = "", NumCtaPago, TipoCambio, condicionesDePago, MotivoDescuento;
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
        private ArrayList arrayListImpuestosTC;
        private ArrayList arrayListImpuestosRC;
        private string[] arrayComPago;
        private ArrayList arrayListComPago;

        //Campos Aduana
        string[] arrayAduana;
        ArrayList arrayListAduana;
        //Campos Aux Impuestos
        string[] arrayImpuestosT, arrayImpuestosR;
        ArrayList arrayListImpuestosT, arrayListImpuestosR;
        //CFDI
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
        private string Viva;
        private string Visr;
        private string Vretencion;
        private string VimpHospedaje;
        private string menCFDI33;
        #endregion


        Boolean banCFDI;
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
        Boolean valida_numNegativos = true;
        Boolean validacion_importe = true;
        Boolean validacion_formaDePago = true;
        Boolean validacion_metodoDePago = true;
        Boolean validacion_numDeCta = true;
        Boolean validacion_numDeCtaTieneNum = false;
        Boolean validaDomReceptor = false;
        Boolean valida_IVA = false;
        Boolean valida_domicilioReceptor = false;
        Boolean valida_fleteDesc = false;
        Boolean valida_Desc_motDes = false;
        Boolean sesionAdmin = false;
        Boolean continuar = false;
        Boolean valInter = false;
        Boolean val_totalT = true;
        Boolean val_totalR = true;
        Boolean valida_moneda = false;
        Double totalRetenciones = 0;
        Double totalTraslados = 0;
        Decimal sumaT;
        public string CO;
        Validacion Val;
        string fecharec;
        string[] eval;
        string nomTemp;
        int id_usuario = 0;

        private string archivo_logXSD = AppDomain.CurrentDomain.BaseDirectory + "logErrorNEW\\ErrorREADXML.txt";

        public String msj { get; set; }
        public string msjT { get; set; }
        [WebMethod]
        public string getVersion() { return version; }
        [WebMethod]
        public string getSerie() { return serie; }
        [WebMethod]
        public string getSello() { return sello; }
        [WebMethod]
        public string getNoAprobacion() { return noAprobacion; }
        [WebMethod]
        public string getAnoAprobacion() { return anoAprobacion; }
        [WebMethod]
        public string getNoCertificado() { return noCertificado; }
        [WebMethod]
        public string getCertificado() { return certificado; }
        [WebMethod]
        public void setCertificado(string cert) { certificado = cert; }
        [WebMethod]
        public void getCadCont(string ccon) { codContable = ccon.ToUpper(); }
        [WebMethod]
        public void getInteface(Boolean interf) { valInter = interf; }
        [WebMethod]
        public void getSesionAdm(Boolean sesionAdm) { sesionAdmin = sesionAdm; }
        [WebMethod]
        public void getMon(string tmon) { moneda = tmon; }
        [WebMethod]
        public void getTimFac(string tm) { timFact = Convert.ToInt32(tm); }

        //--------------nuevos datos general-----------------------

        ArrayList LisAdi = new ArrayList();
        string usuarioFac = "";
        string TipoProveedor = "";
        double propinas = 0.0;
        string pInvoice = "";
        string ordenCompra = "";
        [WebMethod]
        public void getUsuarioFac(string usFac) { usuarioFac = usFac; }
        [WebMethod]
        public void getTipoProveedor(string tProv) { TipoProveedor = tProv; }
        [WebMethod]
        public void getPropi(double pr) { propinas = pr; }
        [WebMethod]
        public void getParentInv(string PI) { pInvoice = PI; }
        [WebMethod]
        public void getLAdi(string ad) { LisAdi.Add(ad); }
        [WebMethod]
        public void getNomOrden(string ord) { ordenCompra = ord; }
        [WebMethod]
        public void getSabana(string sb) { NumSabana = sb; }
        [WebMethod]
        public void getSiteOr(string st) { siteOri = st; }
        [WebMethod]
        public void getFinancieros(string corr, string noms)
        {
            correosFin = corr;
            nomFin = noms;
        }

        //------------FIN------------------------------

        [WebMethod]
        public string getCO() { return CO; }
        [WebMethod]
        public string getSelloSAT() { return selloSAT; }
        [WebMethod]
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

        String banXc = "";

        string resSello = "";
        string resExistCer = "";
        string resVigCer = "";
        string resFolser = "";
        string resultadoVal = "";
        string resCO = "";
        string estadoValfs = "";
        bool BanBD = false;
        [WebMethod]
        public Boolean getbanValCadena() { return banValCadena; }
        [WebMethod]
        public Boolean getbanexistenciaCer() { return banexistenciaCer; }
        [WebMethod]
        public Boolean getbanstatusCer() { return banstatusCer; }
        [WebMethod]
        public Boolean getbanfolser() { return banfolser; }
        [WebMethod]
        public Boolean getbanRangofol() { return banRangofol; }
        [WebMethod]
        public Boolean getbanNoAprob() { return banNoAprob; }
        [WebMethod]
        public string getmsgEstructura() { return msgEstructura; }
        [WebMethod]
        public string getRFCEMISOR() { return rfcEmisor; }
        [WebMethod]
        public string getFolio() { return folio; }
        [WebMethod]
        public Boolean getbanCFDI() { return banCFDI; }
        [WebMethod]
        public Boolean getbanVigCer() { return banstatusCer; }
        [WebMethod]
        public string getestadovalf() { return estadoValfs; }
        [WebMethod]
        public string getmsgarrayLog() { return msgarrayLog; }
        [WebMethod]
        public string getFechaRec() { return fecharec; }
        [WebMethod]
        public string getEstadoFinal() { return estadoFinal; }

        [WebMethod]
        public void Factura(String[] fac, string bck, string doc, string origen, string mail)
        {
            rutaFAC = fac;
            rutaBCK = bck;
            rutaDOC = doc;
            rutaORG = origen;
            //emails ="recepcion@dataexpress.com.mx,"+ mail;
            emails = mail;
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
        [WebMethod]
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
        [WebMethod]
        public String leerIndividualX(string file, String rutaBCK, String moneda, String CC, String tipProv, String pInvo, Boolean sAdm, Boolean valInt, String corr, String noms, String[] fac, string doc, string origen, string mail, String noSabana, String siteOrigen, string id_usuario)
        {

            FileInfo InfoFile = new FileInfo(file);
            XmlDocument xDoc = new XmlDocument();
            nombre = InfoFile.Name;
            extension = InfoFile.Extension;
            nombreSE = nombre.Replace(extension, "");
            nomTemp = InfoFile.DirectoryName + @"\";
            this.rutaBCK = rutaBCK;
            this.Moneda = moneda;
            this.codContable = CC.ToUpper();
            this.TipoProveedor = tipProv;
            this.pInvoice = pInvo;
            this.sesionAdmin = sAdm;
            this.valInter = valInt;
            this.correosFin = corr;
            this.nomFin = noms;
            this.NumSabana = noSabana;
            this.siteOri = siteOrigen;
            try
            {
                this.id_usuario = Convert.ToInt16(id_usuario);
            }
            catch (Exception ex)
            {

            }
            Factura(fac, rutaBCK, doc, origen, mail);
            leerXML(file);
            if (!string.IsNullOrEmpty(IDEFAC))
            {
                var ObjMyService = new wsRetenciones.Retenciones();
                var correo = Session["correo"] != null ? Session["correo"].ToString() : "";
                var result = ObjMyService.retencionFactura(IDEFAC, correo);
            }
            return estadoFinal;
        }


        [WebMethod]
        private void leerXML(string file)
        {
            XmlTextReader xtrReader = null;
            asunto = "";
            mensaje = "";
            Val = new Validacion();
            //comprobante
            xmlns = ""; xmlns_xsi = ""; xmlns_xsd = ""; xsi_schemaLocation = ""; version = ""; serie = "";
            folio = ""; fecha2 = ""; sello = ""; noAprobacion = ""; anoAprobacion = "";
            formaDePago = ""; noCertificado = ""; certificado = ""; subTotal = ""; total = ""; tipoDeComprobante = ""; LugarExpedicion = "";
            descuento = ""; MotivoDescuento = ""; NumCtaPago = ""; TipoCambio = ""; condicionesDePago = "";
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
            // if (eval[1].Equals("xml") || eval[1].Equals("XML"))
            //{
            try
            {
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

                string az = "";
                XPathDocument x = new XPathDocument(xtrReader);
                XPathNavigator foo = x.CreateNavigator();
                foo.MoveToFollowing(XPathNodeType.Element);
                IDictionary<string, string> whatever = foo.GetNamespacesInScope(XmlNamespaceScope.All);
                foreach (String a in whatever.Keys)
                {
                    az = a;

                }
                ///version 3.2 AND 3.3
                foreach (XmlElement xmlElement in comprobante)
                {
                    version = xmlElement.GetAttribute("Version").Trim();
                    if (string.IsNullOrEmpty(version)) { version = xmlElement.GetAttribute("version").Trim(); }
                }
                if (version.Equals("3.3"))
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

                    XmlDocument xtr = new XmlDocument();
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
                        string str5 = this.formaDePago.ToUpper().Replace("??", "O");
                        string str6 = this.metodoDePago.ToUpper().Replace("??", "O");
                        if (!str5.Contains("EXHIBICION") && !str5.Contains("EXIBICION"))
                            this.validacion_formaDePago = false;
                        this.validacion_metodoDePago = str6.Equals("03") || str6.Equals("17") || (str6.Equals("NA") || str6.Equals("TRANSFERENCIA")) || (str6.Equals("TRANSFERENCIA ELECTRONICA DE FONDOS") || str6.Equals("COMPENSACION")) || str6.Equals("NO IDENTIFICADO");
                        if (this.metodoDePago.ToUpper().Contains("TRANSFERENCIA") || this.metodoDePago.ToUpper().Contains("CHEQUE") || this.metodoDePago.Equals(""))
                            this.validacion_metodoDePago = false;
                        foreach (XmlElement xmlElement2 in xmlElement1.GetElementsByTagName(cfdi + "Emisor"))
                            this.rfcEmisor = xmlElement2.GetAttribute("Rfc");
                        foreach (XmlElement xmlElement2 in xmlElement1.GetElementsByTagName(cfdi + "Receptor"))
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
                                foreach (XmlElement xmlElement2 in xmlElement1.GetElementsByTagName(cfdi + "CfdiRelacionados"))
                                {
                                    this.CFDIrelacion = xmlElement2.GetAttribute("TipoRelacion");
                                    foreach (XmlElement xmlElement3 in xmlElement2.GetElementsByTagName(cfdi + "CfdiRelacionado"))
                                        this.UUIDrelacion = xmlElement3.GetAttribute("UUID");
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
                                foreach (XmlElement xmlElement2 in xmlElement1.GetElementsByTagName(cfdi + "Emisor"))
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
                                foreach (XmlElement xmlElement2 in xmlElement1.GetElementsByTagName(cfdi + "Receptor"))
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
                                this.arrayListAduana = new ArrayList();
                                XmlNodeList elementsByTagName3 = ((XmlElement)xmlElement1.GetElementsByTagName(cfdi + "Conceptos")[0]).GetElementsByTagName(cfdi + "Concepto");
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
                                    xmlElement2.GetElementsByTagName(cfdi + "Concepto");
                                    if ((uint)xmlElement2.GetElementsByTagName(cfdi + "InformacionAduanera").Count > 0U)
                                    {
                                        try
                                        {
                                            foreach (XmlElement xmlElement3 in xmlElement2.GetElementsByTagName(cfdi + "InformacionAduanera"))
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
                                    foreach (XmlElement xmlElement3 in xmlElement2.GetElementsByTagName(cfdi + "Impuestos"))
                                    {
                                        if (xmlElement3.ParentNode.Name == "cfdi:Concepto")
                                        {
                                            #region NODO CONCEPTOS RETENCIONES
                                            try
                                            {
                                                this.arrayListImpuestosRC = new ArrayList();
                                                XmlNodeList elementsByTagName4 = xmlElement3.GetElementsByTagName(cfdi + "Retenciones");
                                                if ((uint)xtr.GetElementsByTagName(cfdi + "Retencion").Count > 0U)
                                                {
                                                    foreach (XmlElement xmlElement4 in ((XmlElement)elementsByTagName4[0]).GetElementsByTagName(cfdi + "Retencion"))
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
                                                this.arrayListImpuestosTC = new ArrayList();
                                                XmlNodeList elementsByTagName4 = xmlElement2.GetElementsByTagName(cfdi + "Traslados");
                                                if ((uint)xtr.GetElementsByTagName(cfdi + "Traslados").Count > 0U)
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
                                    DbDataReader dbDataReader = this.DB.EjecutarConsulta();
                                    if (dbDataReader.Read())
                                        str8 = dbDataReader[0].ToString();
                                    this.DB.Desconectar();
                                    if (str8.Equals("RENTA CON RETENCION") || str8.Equals("RENTA"))
                                    {
                                        XmlNodeList elementsByTagName4 = xmlElement2.GetElementsByTagName(cfdi + "CuentaPredial");
                                        if ((uint)xmlElement2.GetElementsByTagName(cfdi + "CuentaPredial").Count > 0U)
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
                            foreach (XmlElement xmlElement2 in xmlElement1.GetElementsByTagName(cfdi + "Impuestos"))
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
                                    #region NODO TRASLADOS
                                    try
                                    {
                                        this.arrayListImpuestosT = new ArrayList();
                                        XmlNodeList elementsByTagName3 = xmlElement2.GetElementsByTagName(cfdi + "Traslados");
                                        if ((uint)xtr.GetElementsByTagName(cfdi + "Traslados").Count > 0U)
                                        {
                                            foreach (XmlElement xmlElement3 in ((XmlElement)elementsByTagName3[0]).GetElementsByTagName(cfdi + "Traslado"))
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
                                        this.ValidarXML6 = true;
                                        Facturas.anade_linea_archivo(this.archivo_logXSD, "La estructura del Nodo ImpuestosTraslados es invalida,");
                                    }
                                    #endregion
                                    #region NODO RETENCIONES
                                    try
                                    {
                                        this.arrayListImpuestosR = new ArrayList();
                                        XmlNodeList elementsByTagName3 = xmlElement2.GetElementsByTagName(cfdi + "Retenciones");
                                        if ((uint)xtr.GetElementsByTagName(cfdi + "Retencion").Count > 0U)
                                        {
                                            foreach (XmlElement xmlElement3 in ((XmlElement)elementsByTagName3[0]).GetElementsByTagName(cfdi + "Retencion"))
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
                                        this.ValidarXML7 = true;
                                        Facturas.anade_linea_archivo(this.archivo_logXSD, "La estructura del Nodo ImpuestosRetenidos es invalida,");
                                    }
                                    #endregion
                                }
                            }
                            if (this.totalImpuestosTrasladados.Equals("") && this.totalTraslados > 0.0)
                                this.totalImpuestosTrasladados = this.totalTraslados.ToString();
                            if (this.totalImpuestosRetenidos.Equals("") && this.totalRetenciones > 0.0)
                                this.totalImpuestosRetenidos = this.totalRetenciones.ToString();
                            #endregion
                            #region VALIDACION CFE
                            //if (this.rfcEmisor == "CFE370814QI0")
                            //{
                            //    Decimal sumaT = this.sumaT;
                            //    if (Convert.ToDecimal(this.total) != sumaT)
                            //    {
                            //        this.totalMas = Convert.ToDecimal(this.total) - sumaT;
                            //        this.totalCFE_Fin = Convert.ToDecimal(this.totalMas.ToString().Replace("-", "")) + Convert.ToDecimal(this.importe);
                            //    }
                            //    else
                            //        this.totalCFE_Fin = Convert.ToDecimal(this.total);
                            //}
                            #endregion
                            #region NODO COMPLEMENTOS
                            if (this.banCFDI)
                            {
                                XmlNodeList elementsByTagName3 = xmlElement1.GetElementsByTagName(cfdi + "Complemento");
                                if ((uint)xtr.GetElementsByTagName(cfdi + "Complemento").Count > 0U)
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
                                                XmlNodeList elementsByTagName5 = xmlElement3.GetElementsByTagName("implocal:TrasladosLocales");
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
                                                        this.arrayImpuestosT = new string[3];
                                                        this.arrayImpuestosT[0] = this.impuesto;
                                                        this.arrayImpuestosT[1] = this.tasa;
                                                        this.arrayImpuestosT[2] = this.importeImpuesto;
                                                        this.arrayListImpuestosT.Add((object)this.arrayImpuestosT);
                                                    }
                                                }
                                                #region NODO RETENCIONES LOCALES
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
                                                        this.arrayImpuestosR = new string[3];
                                                        this.arrayImpuestosR[0] = this.impuesto;
                                                        this.arrayImpuestosR[1] = this.tasa;
                                                        this.arrayImpuestosR[2] = this.importeImpuesto;
                                                        this.arrayListImpuestosR.Add((object)this.arrayImpuestosR);
                                                    }
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
                                                                this.arrayListConceptos.Add((object)this.arrayConceptos);
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
                        //       this.evaluar(xtr);
                        #region WRITE GENERAL LOG
                        string mpproveedores = "";
                        if (!tipoDeComprobante.ToUpper().Equals("I"))
                        {
                            if (!tipoDeComprobante.ToUpper().Equals("E"))
                            {
                                if (!tipoDeComprobante.ToUpper().Equals("P"))
                                {
                                    anade_linea_archivo(archivo_logXSD, "Tipo de comprobante invalido");
                                }
                            }
                        }
                        sesionAdmin = true;
                        if (!this.metodoDePago.Equals("PPD"))
                            Facturas.anade_linea_archivo(this.archivo_logXSD, "Metodo de pago invalido,");
                        //        if (!this.validation33(this.rfcEmisor))
                        //            mpproveedores = this.ObtainMPproveedores(this.rfcEmisor);
                        if (!mpproveedores.Equals(this.formaDePago) && !string.IsNullOrEmpty(mpproveedores))
                            this.formaDePago = mpproveedores;
                        if (!this.formaDePago.Equals("99"))
                            Facturas.anade_linea_archivo(this.archivo_logXSD, "Forma de pago invalida,");
                        #endregion
                        string str9 = "Vigente";
                        if (str9 == "Vigente" || this.version == "3.3")
                        {
                            #region VALIDACIONES CFDI 3.3
                            if (!this.ValidarXML1)
                            {
                                if (!this.ValidarXML2)
                                {
                                    if (!this.ValidarXML3)
                                    {
                                        if (!this.ValidarXML4)
                                        {
                                            if (!this.ValidarXML5)
                                            {
                                                if (!this.ValidarXML6)
                                                {
                                                    if (!this.ValidarXML7)
                                                    {
                                                        if (!this.ValidarXML_ctaPredial)
                                                        {
                                                            if (this.formaDePago.Equals("99"))
                                                            {
                                                                if (this.metodoDePago.Equals("PPD"))
                                                                {
                                                                    if (this.tipoDeComprobante.Equals("I") || this.tipoDeComprobante.Equals("E") || this.tipoDeComprobante.Equals("P"))
                                                                    {
                                                                        if (this.valida_moneda)
                                                                        {
                                                                            //if (this.validation33(this.rfcEmisor))
                                                                            //{
                                                                            if (this.sesionAdmin)
                                                                                this.continuar = true;
                                                                            else if (this.validacion_formaDePago || this.RFCPrivilegiado(this.rfcEmisor) || this.version == "3.3")
                                                                            {
                                                                                if (this.validacion_metodoDePago || this.RFCPrivilegiado(this.rfcEmisor) || this.version == "3.3")
                                                                                {
                                                                                    if (this.validacion_numDeCta)
                                                                                    {
                                                                                        if (this.operaciones33())
                                                                                        {
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
                                                                                                                if (this.valida_IVA || this.version == "3.3")
                                                                                                                {
                                                                                                                    if (this.version == "3.3")
                                                                                                                    {
                                                                                                                        if (this.val_totalR && this.val_totalT)
                                                                                                                        {
                                                                                                                            this.continuar = true;
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
                                                                                        this.mensajeEmailError("RE029", "", this.emails);
                                                                                        this.mensajesLog("RE029", "", "", this.emails, "");
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
                                                                            //}
                                                                            //else
                                                                            //{
                                                                            //    this.copiarArc(this.nomTemp, this.rutaBCK, this.nombreSE, this.rfcEmisor, this.ordenCompra);
                                                                            //    this.mensajeEmailError("RE032", "", this.emails);
                                                                            //    this.mensajesLog("RE032", "", "", this.emails, "");
                                                                            //}
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

                    if (!this.continuar || !this.banValCadena && !(this.version == "3.3"))
                        return;
                    if (!this.banCFDI || this.version == "3.3")
                    {
                        if (this.banfolser || this.version == "3.3")
                            this.guardarBD();
                    }
                    else
                        this.guardarBD();

                    #endregion

                }
                else
                {
                    #region version 3.2
                    sumaT = 0;
                    sesionAdmin = true;
                    foreach (XmlElement nodo in comprobante)
                    {
                        #region NODO COMPROBANTE
                        xmlns = nodo.GetAttribute("xmlns"); xmlns_xsi = nodo.GetAttribute("xmlns:xsi");
                        xmlns_xsd = nodo.GetAttribute("xmlns:xsd"); xsi_schemaLocation = nodo.GetAttribute("xsi:schemaLocation");
                        version = nodo.GetAttribute("version").Trim(); serie = nodo.GetAttribute("serie");
                        folio = nodo.GetAttribute("folio"); fecha2 = nodo.GetAttribute("fecha");
                        sello = nodo.GetAttribute("sello"); noAprobacion = nodo.GetAttribute("noAprobacion");
                        anoAprobacion = nodo.GetAttribute("anoAprobacion"); formaDePago = nodo.GetAttribute("formaDePago");
                        noCertificado = nodo.GetAttribute("noCertificado"); certificado = nodo.GetAttribute("certificado");
                        subTotal = nodo.GetAttribute("subTotal"); total = nodo.GetAttribute("total");
                        tipoDeComprobante = nodo.GetAttribute("tipoDeComprobante"); LugarExpedicion = nodo.GetAttribute("LugarExpedicion");
                        descuento = nodo.GetAttribute("descuento"); MotivoDescuento = nodo.GetAttribute("motivoDescuento"); Moneda = nodo.GetAttribute("Moneda");
                        NumCtaPago = nodo.GetAttribute("NumCtaPago"); TipoCambio = nodo.GetAttribute("TipoCambio");
                        condicionesDePago = nodo.GetAttribute("condicionesDePago");
                        moneda = nodo.GetAttribute("Moneda");
                        if (moneda.Contains("M") || moneda == "")
                        {///////////////moneda
                            moneda = "MXN";
                        }
                        else
                        {
                            moneda = "USD";
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
                        //  fecha = Convert.ToDateTime(fecha).ToString("dd/MM/yyyy HH:mm:ss");
                        metodoDePago = nodo.GetAttribute("metodoDePago");
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

                        string tempmetodoPago = metodoDePago.ToUpper().Replace("Ó", "O");
                        if (!formaDePago.ToUpper().Replace("Ó", "O").Contains("EXHIBICION") && !formaDePago.ToUpper().Replace("Ó", "O").Contains("EXIBICION")) { validacion_formaDePago = false; }
                        if (tempmetodoPago.Equals("03") || tempmetodoPago.Equals("17") || tempmetodoPago.Equals("NA")
                            || tempmetodoPago.Equals("TRANSFERENCIA") || tempmetodoPago.Equals("TRANSFERENCIA ELECTRONICA DE FONDOS")
                            || tempmetodoPago.Equals("COMPENSACION") || tempmetodoPago.Equals("NO IDENTIFICADO")) { validacion_metodoDePago = true; }
                        else { validacion_metodoDePago = false; }
                        //if (metodoDePago.ToUpper().Contains("TRANSFERENCIA") || metodoDePago.ToUpper().Contains("CHEQUE") || metodoDePago.Equals("")) { validacion_metodoDePago = false; }
                        XmlAttribute numCta = nodo.GetAttributeNode("NumCtaPago");
                        if ((NumCtaPago.Equals("") && numCta == null) || (!NumCtaPago.Equals("") && System.Text.RegularExpressions.Regex.IsMatch(NumCtaPago, @"^[a-zA-Z_áéíóúñ\s]*$"))) // @"^[a-zA-Z_áéíóúñ\s\D]*$" excepto numeros
                        {
                            validacion_numDeCtaTieneNum = true;
                            validacion_numDeCta = true;
                        }
                        else
                        {
                            validacion_numDeCta = false;
                        }

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

                    string valRFC = "";
                    valRFC = validaRFC(rfcReceptor);
                    emails = (emails.Trim(',') + "," + correoProveedor(rfcEmisor)).Trim(',');
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
                                    if (calleReceptor == "" && noInteriorReceptor == "" && municipioReceptor == "" && paisReceptor != "" && localidadReceptor == "" &&
                                        noExteriorReceptor == "" && coloniaReceptor == "" && estadoReceptor == "" && codigoPostalReceptor == "" && referenciaReceptor == "" && rfcReceptor != "")
                                    {
                                        validaDomReceptor = true;
                                    }
                                    else
                                    {
                                        validaDomReceptor = false;
                                    }
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
                                    valorUnitario = nodohi2.GetAttribute("valorUnitario"); importe = nodohi2.GetAttribute("importe");
                                    arrayConceptos = new String[6];
                                    arrayConceptos[0] = cantidad; arrayConceptos[1] = unidad; arrayConceptos[2] = noIdentificacion;
                                    arrayConceptos[3] = descripcion; arrayConceptos[4] = valorUnitario; arrayConceptos[5] = importe;
                                    sumaT = sumaT + Convert.ToDecimal(importe);
                                    arrayListConceptos.Add(arrayConceptos);
                                    if (descripcion.ToUpper().Contains("FLETE") || unidad.ToUpper().Contains("FLETE"))
                                    {
                                        valida_fleteDesc = true;
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
                                        //                                       validacion_importe = false;
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
                                    totalImpuestosTrasladados = nodohi.GetAttribute("totalImpuestosTrasladados");
                                    if (totalImpuestosTrasladados != "" && Convert.ToDecimal(totalImpuestosTrasladados) < 0)
                                    {
                                        valida_numNegativos = false;
                                    }

                                    if (totalImpuestosRetenidos != "" && Convert.ToDecimal(totalImpuestosRetenidos) < 0)
                                    {
                                        valida_numNegativos = false;
                                    }

                                    //Nodo Traslados
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
                                            if (impuesto.Equals("IVA") && ((Convert.ToDecimal(importeImpuesto) > 0 && Convert.ToDecimal(tasa) == 16) ||
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

                                    XmlNodeList Retenciones = nodohi.GetElementsByTagName(cfdi + "Retenciones");
                                    existe = xDoc.GetElementsByTagName(cfdi + "Retencion");
                                    if (existe.Count != 0)
                                    {
                                        XmlNodeList listaRetencion = ((XmlElement)Retenciones[0]).GetElementsByTagName(cfdi + "Retencion");
                                        //nodo Retenciones
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
                                }
                                if (totalImpuestosTrasladados.Equals("") && totalTraslados > 0)
                                {
                                    totalImpuestosTrasladados = totalTraslados.ToString();
                                }
                                if (totalImpuestosRetenidos.Equals("") && totalRetenciones > 0)
                                {
                                    totalImpuestosRetenidos = totalRetenciones.ToString();
                                }
                                #endregion
                                #region Complemento CFDI
                                if (banCFDI)
                                {

                                    XmlNodeList Complementos = nodo.GetElementsByTagName(cfdi + "Complemento");
                                    existe = xDoc.GetElementsByTagName(cfdi + "Complemento");
                                    if (existe.Count != 0)
                                    {
                                        existe = null;
                                        foreach (XmlElement nodohi in Complementos)
                                        {

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
                                                                    arrayListConceptos.Add(arrayConceptos);
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }

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
                                        }
                                    }
                                }
                            }
                            #endregion
                            //Estructura

                            //estructura(xtrReader);
                            evaluar(xDoc);
                            //if (banValCadena && banexistenciaCer && banstatusCer)
                            String estado = ConsultaWSSAT(rfcEmisor.Replace("&", "&amp;"), rfcReceptor.Replace("&", "&amp;"), total, UUID);
                            if (estado == "Vigente")
                            {
                                #region ESTADO VIEGENTE
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
                                                                        else
                                                                        {
                                                                            //falta IVA
                                                                            copiarArc(nomTemp, rutaBCK, nombreSE, rfcEmisor, ordenCompra);
                                                                            mensajeEmailAdjuntar("RE032", "", emails);
                                                                            mensajesLog("RE032", "", "", "", "");
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

                                                                //copiarArc(nomTemp, rutaBCK, nombreSE, rfcEmisor, ordenCompra);
                                                                //mensajeEmailAdjuntar("RE040", "", emails);
                                                                //mensajesLog("RE040", "", "", "", "");
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
                                #endregion
                            }
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
                    if (continuar)
                    {
                        if (banValCadena)
                        {
                            if (!banCFDI)
                            {
                                if (banfolser)
                                {
                                    guardarBD();
                                }
                            }
                            else
                            {
                                guardarBD();
                            }
                        }
                    }
                    #endregion
                }
            }
            catch (Exception e)
            {
                DB.Desconectar();
                copiarArc(nomTemp, rutaBCK, nombreSE, rfcEmisor, ordenCompra);
                anade_linea_archivo(archivo_Corrup, "LeerXML " + e.ToString());
                mensajesLog("RE009", msj, e.ToString(), "", e.Message);
            }

        }
        [WebMethod]
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
            return false;
        }

        [WebMethod]
        public void anade_linea_archivo(string archivo, string linea)
        {
            using (StreamWriter w = File.AppendText(archivo))
            {
                w.WriteLine(linea.Replace(Environment.NewLine, ""));
                w.Flush();
                w.Close(); // Close the writer and underlying file.
            }
        }

        [WebMethod]
        private void evaluar(XmlDocument xtr)
        {
            string[] mensajes, mensajesT;
            mensajes = new String[10];
            mensajesT = new string[10];
            //Validar Cadena
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

            //Verificar la Existencia del Certificado
            if (VC.existenciaCertificado(rfcEmisor, noCertificado))
            {
                banexistenciaCer = true;
                banstatusCer = true;
                mensajes[1] = "Existencia de certificado:Correcto";
            }
            else
            {
                banexistenciaCer = false;
                banstatusCer = true;
                mensajes[1] = "No existe el Certificado";
                mensajesT[1] = msjT;
            }

            //Verificar el Estatus del Certificado
            //if (VC.estatusCertificado(rfcEmisor, noCertificado))
            //{
            //    banstatusCer = true;
            //    mensajes[2] = "Vigencia Certifido:Correcto";
            //}
            //else
            //{
            //    banstatusCer = false;
            //    mensajes[2] = "El certificado no esta vigente.";
            //    mensajesT[2] = msjT;
            //}
            //Valida si es CFD
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
            //Envio de email,copia de archivos,registro en logErrores
            if (!banValCadena)
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

                //copiarArc(nomTemp, rutaBCK, nombreSE, rfcEmisor);
                //mensajeEmailAdjuntar("RE005", "", emails);
                mensajesLog("RE005", mensajes[1], mensajesT[1], emails, resultadoVal);

            }
            //else if (!banstatusCer)
            //{ //estatus del certificado

            //    resSello = mensajes[0].ToString() + Environment.NewLine;
            //    resExistCer = mensajes[1].ToString() + Environment.NewLine;
            //    //resVigCer = mensajes[2].ToString() + Environment.NewLine;
            //    msgVesiondoc = "Versión del comprobante" + version + Environment.NewLine;
            //    msgCadenaOriginal = getCO();

            //    resCO = "Cadena Original: " + Environment.NewLine + getCO() + Environment.NewLine;
            //    msgCertidicado = "No de certificado" + Environment.NewLine + noCertificado;
            //    resultadoVal = msj + resSello + resExistCer; //resVigCer + 
            //    resultadoVal += resFolser + msgVesiondoc + resCO + msgCertidicado;

            //    copiarArc(nomTemp, rutaBCK, nombreSE, rfcEmisor);
            //    mensajeEmailAdjuntar("RE013", "", emails);
            //    mensajesLog("RE013", mensajes[1], mensajesT[2], emails, resultadoVal);
            //}

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

            else if (banValCadena && banexistenciaCer && banstatusCer)//Si la factrura es válida 
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
        [WebMethod]
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
        [WebMethod]
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
                        //xtrtfd.InnerText = xtr.SelectSingleNode("/cfdi:Comprobante/cfdi:Complemento/tfd:TimbreFiscalDigital").InnerText;
                        //xtrtfd.DocumentElement.AppendChild(xmlNode);
                        timbre = xmlNode.OuterXml;
                        xtrtfd.LoadXml(timbre);

                        Val.version = "tfd1.0";
                        Val.fecha = fecha2;
                        fileCer = AppDomain.CurrentDomain.BaseDirectory + @"certificados\" + noCertificado + ".cer";

                        Val.generaCadena(dir, xtrtfd);
                        certificadoSAT = obtenerCertificado(noCertificadoSAT);
                        //certificadoSAT = Val.extraerCertificado(fileCer);
                        //  MessageBox.Show("Llego al fin validacion cfdi");

                        //2014/06/05
                        //if (Val.validarXML(selloSAT, certificadoSAT)) { Val.msj += " ( timbre )"; return true; }
                        //else { Val.msj += "( timbre )"; return false; }

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
        [WebMethod]
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
            //try
            //{
            //    fileCer = "";
            //    urlCer = "";
            //    WebClient webClient = new WebClient();
            //    fileCer = AppDomain.CurrentDomain.BaseDirectory + @"certificados\" + CertificadoSAT + ".cer";
            //    if (!System.IO.File.Exists(fileCer))
            //    {
            //        urlCer = "ftp://ftp2.sat.gob.mx/Certificados/FEA/" + "/" + CertificadoSAT.Substring(0, 6) + "/";
            //        urlCer += CertificadoSAT.Substring(6, 6) + "/" + CertificadoSAT.Substring(12, 2) + "/";
            //        urlCer += CertificadoSAT.Substring(14, 2) + "/" + CertificadoSAT.Substring(16, 2) + "/" + CertificadoSAT + ".cer";

            //        webClient.DownloadFile(urlCer, fileCer);
            //    }

            //    return Val.extraerCertificado(fileCer);
            //}
            //catch(IOException g){

            //    return null;
            //}

        }
        [WebMethod]
        private bool operaciones()
        {

            Decimal suma = 0;
            bool ax = true;
            foreach (String[] obj in arrayListConceptos)
            {
                suma = suma + Convert.ToDecimal(obj[5]);
            }

            foreach (string[] val in arrayListImpuestosT)
            {
                suma = suma + Convert.ToDecimal(val[2]);
            }

            //if (propinas != 0.0)
            //{
            //    suma = suma + Convert.ToDecimal(propinas);
            //}   

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
                suma = Truncate(Decimal.Round(Convert.ToDecimal(suma), 2), 1);
                totAux = Truncate(Decimal.Round(Convert.ToDecimal(total), 2), 1).ToString();

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
        [WebMethod]
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
                                auxTa = false;
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
        [WebMethod]
        private bool varRetFletes()
        {
            if (TipoProveedor == "FLETES" && tipoDeComprobante.ToLower() != "egreso")
            {
                if (totalImpuestosRetenidos != "")
                {
                    if (Convert.ToDecimal(totalImpuestosRetenidos) > 0)
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
        [WebMethod]
        private bool valTiProv() //Valida campos obligatorios segun tipo de proveedor
        {

            bool val_Risr = false;
            bool val_Riva = false;
            switch (TipoProveedor.ToUpper())
            {
                case "FLETES":
                    foreach (string[] val in arrayListImpuestosR)
                    {
                        if ((val[0].ToString() == "IVA" && Convert.ToDecimal(val[2].ToString()) >= 0))
                        {
                            val_Riva = true;
                        }
                    }
                    if (tipoDeComprobante.ToLower().Equals("ingreso") || (tipoDeComprobante.ToLower().Equals("egreso") && valida_fleteDesc))
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
                        if (tipoDeComprobante.ToLower().Equals("egreso") && valida_fleteDesc == false)
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
                        if ((val[0].ToString() == "IEPS" && Convert.ToDecimal(val[2].ToString()) < 0))
                        {
                            copiarArc(nomTemp, rutaBCK, nombreSE, rfcEmisor, ordenCompra);
                            mensajeEmailError("RE041", "", emails);
                            mensajesLog("RE041", "", "", emails, "");
                            return false;
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
                        if ((val[0].ToString() == "IVA" && Convert.ToDecimal(val[2].ToString()) >= 0))
                        {
                            val_Riva = true;
                        }
                        if ((val[0].ToString() == "ISR" && Convert.ToDecimal(val[2].ToString()) >= 0))
                        {
                            val_Risr = true;
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
        [WebMethod]
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
        [WebMethod]
        private bool valret()
        {
            bool aux = true;
            if (arrayImpuestosR != null)
            {
                if (arrayImpuestosR.Count() > 0)
                {
                    foreach (string[] val in arrayListImpuestosR)
                    {
                        // 
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

        [WebMethod]
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

        [WebMethod]
        private void guardarBD1()
        {
            if (idProvE2(rfcEmisor))
            {
                try
                {
                    //Receptor
                    //if (String.IsNullOrEmpty(Receptor(rfcReceptor)))
                    //{

                    //    DB.Conectar();
                    //    DB.CrearComando(@"insert into Receptor
                    //            (RFCREC,NOMREC,CALLEREC,NUMEXTREC,NUMINTREC,COLREC,MUNREC,EDOREC,PAIREC,LOCREC,CODREC,REFREC) 
                    //            values 
                    //            (@RFCREC,@NOMREC,@DOMREC,@NUMEXTREC,@NUMINTREC,@COLREC,@MUNREC,@EDOREC,@PAIREC,@LOCREC,@CODREC,@REFREC)");
                    //    DB.AsignarParametroCadena("@RFCREC", rfcReceptor);
                    //    DB.AsignarParametroCadena("@NOMREC", nombreReceptor);
                    //    DB.AsignarParametroCadena("@DOMREC", calleReceptor);
                    //    DB.AsignarParametroCadena("@NUMEXTREC", noExteriorReceptor);
                    //    DB.AsignarParametroCadena("@NUMINTREC", noInteriorReceptor);
                    //    DB.AsignarParametroCadena("@COLREC", coloniaReceptor);
                    //    DB.AsignarParametroCadena("@MUNREC", municipioReceptor);
                    //    DB.AsignarParametroCadena("@EDOREC", estadoReceptor);
                    //    DB.AsignarParametroCadena("@PAIREC", paisReceptor);
                    //    DB.AsignarParametroCadena("@LOCREC", localidadReceptor);
                    //    DB.AsignarParametroCadena("@CODREC", codigoPostalReceptor);
                    //    DB.AsignarParametroCadena("@REFREC", referenciaEmisor);
                    //    DB.EjecutarConsulta1();
                    //    DB.Desconectar();
                    //}
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

                    //Emisor
                    #region SAVE EMISOR
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
                    IDEEMI = Emisor(rfcEmisor);
                    IDPROVEMI = idProvE(rfcEmisor);


                    IDEDOMEMIEXP = consultarIDE(codigoPostalEmisorExp, calleEmisorExp, "CODEMIEXP", "CALLEEMIEXP", "select IDEDOMEMIEXP from DOMEMIEXP where ");
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

                    //DB.Conectar();
                    //DB.CrearComando(@"insert into General 
                    //            (xmlns,xmlns_xsi, xmlns_xsd, xsi_schemaLocation, version, serie, folio, fecha, sello, noAprobacion, anoAprobacion,
                    //            formaDePago,condicionesDePago, noCertificado, certificado, subTotal, total, tipoDeComprobante,metodoDePago, LugarExpedicion,
                    //            descuento, Moneda, NumCtaPago,TipoCambio,totalImpuestosTrasladados,totalImpuestosRetenidos,
                    //            id_Receptor,id_Emisor,IDE_DOMEMIEXP,tipoOrden,fechaRec,edoFact,detalleVal,resultadoVal,CodCont, tipProv,fechaUltimCam, fechaRechazo,
                    //             causaRechazo,fechEmi,impuestos,retenciones,propinas,parentInvoice,tipCfdi,correoContac,estatus,idProv,estadoInterface,estadoReporte,noSabana,siteOrigen,correoAnalista,motivoDesc,facSAT,id_usuario,persFac) 
                    //             values 
                    //           (@xmlns,@xmlns_xsi,@xmlns_xsd,@xsi_schemaLocation,@version,@serie,@folio,@fecha,@sello,@noAprobacion,@anoAprobacion,
                    //            @formaDePago,@condicionesDePago,@noCertificado,@certificado,@subTotal,@total,@tipoDeComprobante,@metodoDePago,@LugarExpedicion,
                    //            @descuento,@Moneda,@NumCtaPago,@TipoCambio,@totalImpuestosTrasladados,@totalImpuestosRetenidos,
                    //            @id_Receptor,@id_Emisor,@IDE_DOMEMIEXP,@tipoOrden,@fechaRec,@edoFact,@detalleVal,@resultadoVal,@CodCont, @tipProv,@fechaUltimCam,@fechaRechazo,
                    //             @causaRechazo,@fechEmi,@impuestos,@retenciones,@propinas,@parentInvoice,@tipCfdi,@correoContac,@estatus,@idProv,@estadoInterface,@estadoReporte,@noSabana,@siteOrigen,@correoAnalista,@motivoDesc,@facSAT,@id_usuario,@persFac)  ");
                    //DB.AsignarParametroCadena("@xmlns", xmlns);
                    //DB.AsignarParametroCadena("@xmlns_xsi", xmlns_xsi);
                    //DB.AsignarParametroCadena("@xmlns_xsd", xmlns_xsd);
                    //DB.AsignarParametroCadena("@xsi_schemaLocation", xsi_schemaLocation);
                    //DB.AsignarParametroCadena("@version", version);
                    //DB.AsignarParametroCadena("@serie", serie);
                    //DB.AsignarParametroCadena("@folio", folio);
                    //DB.AsignarParametroCadena("@fecha", fecha2);
                    //DB.AsignarParametroCadena("@sello", sello);
                    //DB.AsignarParametroCadena("@noAprobacion", noAprobacion);
                    //DB.AsignarParametroCadena("@anoAprobacion", anoAprobacion);
                    //DB.AsignarParametroCadena("@formaDePago", formaDePago);
                    //DB.AsignarParametroCadena("@condicionesDePago", condicionesDePago);
                    //DB.AsignarParametroCadena("@noCertificado", noCertificado);
                    //DB.AsignarParametroCadena("@certificado", certificado);
                    //if (tipoDeComprobante.ToLower() == "egreso")
                    //{
                    //    DB.AsignarParametroCadena("@subTotal", cerosNull("-" + subTotal));
                    //    DB.AsignarParametroCadena("@total", cerosNull("-" + total));
                    //}
                    //else
                    //{
                    //    DB.AsignarParametroCadena("@subTotal", cerosNull(subTotal));
                    //    DB.AsignarParametroCadena("@total", cerosNull(total));
                    //}
                    //DB.AsignarParametroCadena("@tipoDeComprobante", tipoDeComprobante);
                    //DB.AsignarParametroCadena("@metodoDePago", metodoDePago);
                    //DB.AsignarParametroCadena("@LugarExpedicion", LugarExpedicion);
                    //if (descuento != "")
                    //{
                    //    if (Convert.ToDecimal(descuento) > 0)
                    //    {
                    //        if (tipoDeComprobante.ToLower() == "egreso" && (propinas != 0))
                    //        {
                    //            DB.AsignarParametroCadena("@descuento", cerosNull(descuento));
                    //        }
                    //        else
                    //        {
                    //            DB.AsignarParametroCadena("@descuento", cerosNull("-" + descuento));
                    //        }
                    //    }
                    //    else
                    //    {
                    //        DB.AsignarParametroCadena("@descuento", cerosNull(descuento));
                    //    }
                    //}
                    //else
                    //{
                    //    DB.AsignarParametroCadena("@descuento", cerosNull(descuento));
                    //}
                    //DB.AsignarParametroCadena("@Moneda", moneda);
                    //DB.AsignarParametroCadena("@NumCtaPago", NumCtaPago);
                    //DB.AsignarParametroCadena("@TipoCambio", cerosNull(TipoCambio));
                    //DB.AsignarParametroCadena("@totalImpuestosRetenidos", cerosNull(totalImpuestosRetenidos));
                    //if (tipoDeComprobante.ToLower() == "egreso")
                    //{
                    //    if (totalImpuestosRetenidos != "")
                    //    {
                    //        DB.AsignarParametroCadena("@totalImpuestosTrasladados", cerosNull("-" + totalImpuestosTrasladados));
                    //    }
                    //    else { DB.AsignarParametroCadena("@totalImpuestosTrasladados", cerosNull(totalImpuestosTrasladados)); }
                    //}
                    //else
                    //{
                    //    DB.AsignarParametroCadena("@totalImpuestosTrasladados", cerosNull(totalImpuestosTrasladados));
                    //}
                    //DB.AsignarParametroCadena("@id_Receptor", IDEREC);
                    //DB.AsignarParametroCadena("@id_Emisor", IDEEMI);
                    //DB.AsignarParametroCadena("@IDE_DOMEMIEXP", IDEDOMEMIEXP);
                    //TIPOORDEN = "";
                    //DB.AsignarParametroCadena("@tipoOrden", TIPOORDEN);
                    //DB.AsignarParametroCadena("@fechaRec", System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
                    //DB.AsignarParametroEntero("@edoFact", 1);
                    //DB.AsignarParametroCadena("@detalleVal", "Factura Válida");
                    //DB.AsignarParametroCadena("@CodCont", codContable);
                    //cadRes += version + Environment.NewLine;
                    //cadRes += rfcEmisor + Environment.NewLine;
                    //cadRes += folio + serie + Environment.NewLine;
                    //cadRes += noAprobacion + anoAprobacion + Environment.NewLine;
                    //cadRes += msgEstructura + Environment.NewLine;
                    //cadRes += noCertificado + Environment.NewLine;
                    //cadRes += CO + Environment.NewLine;
                    //cadRes += sello + Environment.NewLine;
                    //DB.AsignarParametroCadena("@resultadoVal", "");
                    //DB.AsignarParametroCadena("@tipProv", TipoProveedor);
                    //DB.AsignarParametroCadena("@fechaUltimCam", System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
                    //DB.AsignarParametroCadena("@fechaRechazo", "");
                    //DB.AsignarParametroCadena("@causaRechazo", "");
                    //DB.AsignarParametroCadena("@fechEmi", fecha2);
                    //DB.AsignarParametroCadena("@impuestos", cerosNull(impuesto));
                    //DB.AsignarParametroCadena("@retenciones", cerosNull(totalImpuestosRetenidos));
                    //if (tipoDeComprobante.ToLower() == "egreso" && (propinas != 0.0))
                    //{
                    //    DB.AsignarParametroCadena("@propinas", cerosNull("-" + propinas.ToString()));
                    //}
                    //else
                    //{
                    //    DB.AsignarParametroCadena("@propinas", cerosNull(propinas.ToString()));
                    //}

                    //DB.AsignarParametroCadena("@parentInvoice", pInvoice);
                    //DB.AsignarParametroCadena("@tipCfdi", tipoDeComprobante);
                    //if (!(emails.IndexOf("@dhl.com") < 0))
                    //{
                    //    DB.AsignarParametroCadena("@correoContac", emails);
                    //}
                    //else
                    //{
                    //    DB.AsignarParametroCadena("@correoContac", "");
                    //}
                    //DB.AsignarParametroCadena("@estatus", "validado");
                    //DB.AsignarParametroCadena("@idProv", IDPROVEMI);
                    //if (valInter)
                    //{
                    //    DB.AsignarParametroCadena("@estadoInterface", "0");
                    //}
                    //else
                    //{
                    //    DB.AsignarParametroCadena("@estadoInterface", "1");
                    //}

                    //DB.AsignarParametroCadena("@estadoReporte", "0");
                    //DB.AsignarParametroCadena("@noSabana", NumSabana);
                    //DB.AsignarParametroCadena("@siteOrigen", siteOri);
                    //DB.AsignarParametroCadena("@correoAnalista", correosFin);
                    //DB.AsignarParametroCadena("@motivoDesc", MotivoDescuento);
                    //DB.AsignarParametroEntero("@facSAT", 1);
                    //DB.AsignarParametroEntero("@id_usuario", id_usuario);
                    //DB.AsignarParametroCadena("@persFac", usuarioFac);
                    //DB.EjecutarConsulta1();
                    //DB.Desconectar();
                    #region SAVE GENERAL
                    DB.Conectar();
                    DB.CrearComando(@"insert into General 
                                (xmlns,xmlns_xsi, xmlns_xsd, xsi_schemaLocation, version, serie, folio, fecha, sello, noAprobacion, anoAprobacion,
                                formaDePago,condicionesDePago, noCertificado, certificado, subTotal, total, tipoDeComprobante,metodoDePago, LugarExpedicion,
                                descuento, Moneda, NumCtaPago,TipoCambio,totalImpuestosTrasladados,totalImpuestosRetenidos,
                                id_Receptor,id_Emisor,IDE_DOMEMIEXP,tipoOrden,fechaRec,edoFact,detalleVal,resultadoVal,CodCont, tipProv,fechaUltimCam, fechaRechazo,
                                 causaRechazo,fechEmi,impuestos,retenciones,propinas,parentInvoice,tipCfdi,correoContac,estatus,idProv,estadoInterface,estadoReporte,noSabana,siteOrigen,correoAnalista,motivoDesc,facSAT,id_usuario,persFac, Confirmacion, nameFinancialCC) 
                                output inserted.idFactura
                                values 
                               (@xmlns,@xmlns_xsi,@xmlns_xsd,@xsi_schemaLocation,@version,@serie,@folio,@fecha,@sello,@noAprobacion,@anoAprobacion,
                                @formaDePago,@condicionesDePago,@noCertificado,@certificado,@subTotal,@total,@tipoDeComprobante,@metodoDePago,@LugarExpedicion,
                                @descuento,@Moneda,@NumCtaPago,@TipoCambio,@totalImpuestosTrasladados,@totalImpuestosRetenidos,
                                @id_Receptor,@id_Emisor,@IDE_DOMEMIEXP,@tipoOrden,@fechaRec,@edoFact,@detalleVal,@resultadoVal,@CodCont, @tipProv,@fechaUltimCam,@fechaRechazo,
                                 @causaRechazo,@fechEmi,@impuestos,@retenciones,@propinas,@parentInvoice,@tipCfdi,@correoContac,@estatus,@idProv,@estadoInterface,@estadoReporte,@noSabana,@siteOrigen,@correoAnalista,@motivoDesc,@facSAT,@id_usuario,@persFac, @Confirmacion, @nameFinancialCC)");
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
                            if (tipoDeComprobante.ToLower() == "egreso" && (propinas != 0)) { DB.AsignarParametroCadena("@descuento", cerosNull(descuento)); }
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
                    //////if (version.Equals("3.3"))
                    //////{
                    //////    if (metodoDePago.Equals("PUE"))
                    //////        DB.AsignarParametroCadena("@estatus", "Pagado");
                    //////    else
                    //////        DB.AsignarParametroCadena("@estatus", "En proceso");
                    //////}
                    //////else
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

                    var x = DB.EjecutarConsulta();
                    if (x.Read())
                    {
                        IDEFAC = x[0].ToString();
                    }
                    DB.Desconectar();
                    #endregion


                    BanBD = true;

                    IDEFAC = consultarIDE(folio, serie, IDPROVEMI, noCertificado, sello, "folio", "serie", "idProv", "noCertificado", "sello", "select idFactura from General where ");

                    try
                    {
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
                                DB.AsignarParametroCadena("@valorUnitario", "-" + obj[4].ToString().Replace("-", "").Replace(",", "").Trim());
                                DB.AsignarParametroCadena("@importe", "-" + obj[5].ToString().Replace("-", "").Replace(",", "").Trim());
                            }
                            else
                            {
                                DB.AsignarParametroCadena("@valorUnitario", obj[4].ToString().Replace("-", "").Replace(",", "").Trim());
                                DB.AsignarParametroCadena("@importe", obj[5].ToString().Replace("-", "").Replace(",", "").Trim());
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

                            #endregion
                        }

                        //foreach (string[] obj in arrayListImpuestosR)
                        //{
                        //    DB.Conectar();
                        //    DB.CrearComando(@"insert into Impuestos 
                        //        (impuesto, tasa, importe,tipo,id_Factura) 
                        //        values 
                        //         (@impuesto, @tasa, @importe,@tipo,@id_Factura)");
                        //    DB.AsignarParametroCadena("@impuesto", obj[0].ToString().Trim());
                        //    DB.AsignarParametroCadena("@tasa", obj[1].ToString().Replace(",", "").Trim());
                        //    DB.AsignarParametroCadena("@importe", obj[2].ToString().Replace(",", "").Trim());
                        //    DB.AsignarParametroCadena("@tipo", "R");
                        //    DB.AsignarParametroCadena("@id_Factura", IDEFAC);
                        //    DB.EjecutarConsulta1();
                        //    DB.Desconectar();
                        //}
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
                        }
                        #endregion
                        //foreach (string[] obj in arrayListImpuestosT)
                        //{
                        //    DB.Conectar();
                        //    DB.CrearComando(@"insert into Impuestos 
                        //        (impuesto, tasa, importe,tipo,id_Factura) 
                        //        values 
                        //         (@impuesto, @tasa, @importe,@tipo,@id_Factura)");
                        //    DB.AsignarParametroCadena("@impuesto", obj[0].ToString().Trim());
                        //    DB.AsignarParametroCadena("@tasa", obj[1].ToString().Replace(",", "").Trim());
                        //    if (tipoDeComprobante.ToLower() == "egreso")
                        //    {
                        //        DB.AsignarParametroCadena("@importe", "-" + obj[2].ToString().Replace(",", "").Trim());
                        //    }
                        //    else
                        //    {
                        //        DB.AsignarParametroCadena("@importe", obj[2].ToString().Replace(",", "").Trim());
                        //    }
                        //    DB.AsignarParametroCadena("@tipo", "T");
                        //    DB.AsignarParametroCadena("@id_Factura", IDEFAC);
                        //    DB.EjecutarConsulta1();
                        //    DB.Desconectar();
                        //}
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
                                if (obj[0].ToString().Trim().Equals("001"))
                                { DB.AsignarParametroCadena("@impuesto", "ISR"); }
                                if (obj[0].ToString().Trim().Equals("003"))
                                { DB.AsignarParametroCadena("@impuesto", "IEPS"); }
                                //DB.AsignarParametroCadena("@impuesto", obj[0].ToString().Trim());
                                if (obj[2].ToString().Replace(",", "").Trim().Equals("0.160000") || obj[2].ToString().Replace(",", "").Trim().Equals("0.16")) { DB.AsignarParametroCadena("@tasa", "16.00"); }
                                else { DB.AsignarParametroCadena("@tasa", obj[2].ToString().Replace(",", "").Trim()); }
                                if (tipoDeComprobante.ToLower() == "egreso")
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

                        DB.Conectar();
                        DB.CrearComando(@"insert into Archivos 
                                (PDFARC,XMLARC,ORDENARC,IDEFAC) 
                                values
                                (@PDFARC,@XMLARC,@ORDENARC,@IDEFAC)");
                        DB.AsignarParametroCadena("@PDFARC", "");
                        DB.AsignarParametroCadena("@XMLARC", @"docus\" + feca + rfcEmisor.Replace("&", "_").Trim() + @"\" + nombreSE.Replace("&", "_").Replace("#", "").Replace("+", "") + ".xml");
                        if (pInvoice == "OTM")
                        {
                            DB.AsignarParametroCadena("@ORDENARC", "");
                        }
                        else
                        {
                            DB.AsignarParametroCadena("@ORDENARC", @"docus\" + feca + rfcEmisor.Replace("&", "_").Trim() + @"\" + ordenCompra);
                        }
                        DB.AsignarParametroCadena("@IDEFAC", IDEFAC);
                        DB.EjecutarConsulta1();
                        DB.Desconectar();

                        copiarArc(nomTemp, rutaDOC, nombreSE, rfcEmisor, ordenCompra);
                        //.Replace("&","_")

                        if (LisAdi.Count > 0)
                        {
                            foreach (string adi in LisAdi)
                            {
                                string[] resAdi = adi.Split('|');
                                //string[] ext = resAdi[1].Split('.');
                                DB.Conectar();
                                DB.CrearComando("insert into documentosAdicionales (ADIARC,NOMARC,NOMBRE,IDEFAC) values (@ADIARC,@NOMARC,@NOMBRE,@IDEFAC)");
                                DB.AsignarParametroCadena("@ADIARC", @"docus\" + feca + rfcEmisor.Replace("&", "_").Trim() + @"\adicionales\" + resAdi[1]);
                                DB.AsignarParametroCadena("@NOMARC", resAdi[0]);
                                DB.AsignarParametroCadena("@NOMBRE", resAdi[1]);
                                DB.AsignarParametroCadena("@IDEFAC", IDEFAC);
                                DB.EjecutarConsulta();
                                DB.Desconectar();

                                if (System.IO.File.Exists(rutaDOC + feca + rfcEmisor.Replace("&", "_").Trim() + @"\adicionales\" + resAdi[1]))
                                {
                                    System.IO.File.Delete(rutaDOC + feca + rfcEmisor.Replace("&", "_").Trim() + @"\adicionales\" + resAdi[1]);
                                    System.IO.File.Copy(nomTemp + resAdi[1], rutaDOC + feca + rfcEmisor.Replace("&", "_").Trim() + @"\adicionales\" + resAdi[1]);
                                    System.IO.File.Delete(nomTemp + resAdi[1]);
                                }
                                else
                                {
                                    System.IO.File.Copy(nomTemp + resAdi[1], rutaDOC + feca + rfcEmisor.Replace("&", "_").Trim() + @"\adicionales\" + resAdi[1]);
                                    System.IO.File.Delete(nomTemp + resAdi[1]);
                                }
                            }
                        }
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
                        if (!String.IsNullOrEmpty(IDEFAC))
                        {
                            DB.Conectar();
                            DB.CrearComando("DELETE GENERAL WHERE idFactura=@idFactura");
                            DB.AsignarParametroCadena("@idFactura", IDEFAC);
                            DB.EjecutarConsulta1();
                            DB.Desconectar();
                            IDEFAC = "";
                        }
                    }
                }
                catch (Exception ex)
                {
                    DB.Desconectar();
                    mensajesLog("BD001", "", ex.ToString(), "", DB.comando.CommandText);
                }
                msj = msj + Environment.NewLine + "Factura registrada";

            }
            else
            {
                mensajesLog("RE021", "", "", emails, resultadoVal);
            }
        }
        [WebMethod]
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

        [WebMethod]
        private void guardarBD()
        {

            if (String.IsNullOrEmpty(consultarIDEFact(UUID, "UUID", "select idFactura from GENERAL inner join CFDI on GENERAL.idFactura=CFDI.id_Factura where ")))
            {
                if (sesionAdmin)
                {
                    guardarBD1();
                    goto continuarDespuesBD;
                }

                //tipoDeComprobante = "Traslado";
                if (tipoDeComprobante.ToLower() == "egreso" || tipoDeComprobante.ToLower() == "ingreso")
                {
                    DateTime hoy = DateTime.Now;
                    string an = hoy.ToString("yyyy");
                    //fecha2 = "2014-10-02T11:11:11";
                    string[] fh = fecha2.Split('-');
                    //if (Convert.ToInt32(fh[0]) == Convert.ToInt32(an))
                    if (Convert.ToDateTime(fecha2).Year == DateTime.Now.Year)
                    {
                        //fecha2 = "2014-10-02T11:11:11";
                        TimeSpan ts = hoy - Convert.ToDateTime(fecha2);
                        int dias = ts.Days + 2;
                        if (dias <= 30)
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
                                            if (operaciones())
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

                if (LisAdi.Count > 0)
                {
                    foreach (string adi in LisAdi)
                    {

                        string[] resAdi = adi.Split('|');
                        if (System.IO.File.Exists(rutaBCK + resAdi[1]))
                        {
                            System.IO.File.Delete(rutaBCK + resAdi[1]);
                            System.IO.File.Copy(nomTemp + resAdi[1], rutaBCK + resAdi[1]);
                            System.IO.File.Delete(nomTemp + resAdi[1]);
                        }
                        else
                        {
                            System.IO.File.Copy(nomTemp + resAdi[1], rutaBCK + resAdi[1]);
                            System.IO.File.Delete(nomTemp + resAdi[1]);
                        }
                    }
                }

                //mensajeEmailAdjuntar("RE008", "", emails);
                mensajesLog("RE008", "", "", emails, resultadoVal);//  msj = msj + "La ya existe en el sistema";

            }
        continuarDespuesBD:

            if (BanBD != true)
            {
                //                DB.Conectar();
                //                DB.CrearComando(@"insert into General 
                //                                (xmlns,xmlns_xsi, xmlns_xsd, xsi_schemaLocation, version, serie, folio, fecha, sello, noAprobacion, anoAprobacion,
                //                                formaDePago,condicionesDePago, noCertificado, certificado, subTotal, total, tipoDeComprobante,metodoDePago, LugarExpedicion,
                //                                descuento, Moneda, NumCtaPago,TipoCambio,totalImpuestosTrasladados,totalImpuestosRetenidos,
                //                                id_Receptor,id_Emisor,IDE_DOMEMIEXP,tipoOrden,fechaRec,edoFact,detalleVal,resultadoVal,CodCont, tipProv,fechaUltimCam, fechaRechazo,
                //                                 causaRechazo,fechEmi,impuestos,retenciones,propinas,parentInvoice,tipCfdi,correoContac,estatus,idProv,estadoInterface) 
                //                                 values 
                //                               (@xmlns,@xmlns_xsi,@xmlns_xsd,@xsi_schemaLocation,@version,@serie,@folio,@fecha,@sello,@noAprobacion,@anoAprobacion,
                //                                @formaDePago,@condicionesDePago,@noCertificado,@certificado,@subTotal,@total,@tipoDeComprobante,@metodoDePago,@LugarExpedicion,
                //                                @descuento,@Moneda,@NumCtaPago,@TipoCambio,@totalImpuestosTrasladados,@totalImpuestosRetenidos,
                //                                @id_Receptor,@id_Emisor,@IDE_DOMEMIEXP,@tipoOrden,@fechaRec,@edoFact,@detalleVal,@resultadoVal,@CodCont, @tipProv,@fechaUltimCam,@fechaRechazo,
                //                                 @causaRechazo,@fechEmi,@impuestos,@retenciones,@propinas,@parentInvoice,@tipCfdi,@correoContac,@estatus,@idProv,@estadoInterface)  ");
                //                DB.AsignarParametroCadena("@xmlns", xmlns);
                //                DB.AsignarParametroCadena("@xmlns_xsi", xmlns_xsi);
                //                DB.AsignarParametroCadena("@xmlns_xsd", xmlns_xsd);
                //                DB.AsignarParametroCadena("@xsi_schemaLocation", xsi_schemaLocation);
                //                DB.AsignarParametroCadena("@version", version);
                //                DB.AsignarParametroCadena("@serie", serie);
                //                DB.AsignarParametroCadena("@folio", folio);
                //                DB.AsignarParametroCadena("@fecha", fecha2);
                //                DB.AsignarParametroCadena("@sello", sello);
                //                DB.AsignarParametroCadena("@noAprobacion", noAprobacion);
                //                DB.AsignarParametroCadena("@anoAprobacion", anoAprobacion);
                //                DB.AsignarParametroCadena("@formaDePago", formaDePago);
                //                DB.AsignarParametroCadena("@condicionesDePago", condicionesDePago);
                //                DB.AsignarParametroCadena("@noCertificado", noCertificado);
                //                DB.AsignarParametroCadena("@certificado", certificado);
                //                DB.AsignarParametroCadena("@subTotal", cerosNull(subTotal));
                //                DB.AsignarParametroCadena("@total", cerosNull(total));
                //                DB.AsignarParametroCadena("@tipoDeComprobante", tipoDeComprobante);
                //                DB.AsignarParametroCadena("@metodoDePago", metodoDePago);
                //                DB.AsignarParametroCadena("@LugarExpedicion", LugarExpedicion);
                //                DB.AsignarParametroCadena("@descuento", cerosNull(descuento));
                //                DB.AsignarParametroCadena("@Moneda", moneda);
                //                DB.AsignarParametroCadena("@NumCtaPago", NumCtaPago);
                //                DB.AsignarParametroCadena("@TipoCambio", cerosNull(TipoCambio));
                //                DB.AsignarParametroCadena("@totalImpuestosRetenidos", cerosNull(totalImpuestosRetenidos));
                //                DB.AsignarParametroCadena("@totalImpuestosTrasladados", cerosNull(totalImpuestosTrasladados));
                //                DB.AsignarParametroCadena("@id_Receptor", IDEREC);
                //                DB.AsignarParametroCadena("@id_Emisor", IDEEMI);
                //                DB.AsignarParametroCadena("@IDE_DOMEMIEXP", IDEDOMEMIEXP);
                //                TIPOORDEN = "";
                //                DB.AsignarParametroCadena("@tipoOrden", TIPOORDEN);
                //                DB.AsignarParametroCadena("@fechaRec", "");
                //                DB.AsignarParametroEntero("@edoFact", 1);
                //                DB.AsignarParametroCadena("@detalleVal", "Factura Válida");
                //                DB.AsignarParametroCadena("@CodCont", codContable);
                //                cadRes += version + Environment.NewLine;
                //                cadRes += rfcEmisor + Environment.NewLine;
                //                cadRes += folio + serie + Environment.NewLine;
                //                cadRes += noAprobacion + anoAprobacion + Environment.NewLine;
                //                cadRes += msgEstructura + Environment.NewLine;
                //                cadRes += noCertificado + Environment.NewLine;
                //                cadRes += CO + Environment.NewLine;
                //                cadRes += sello + Environment.NewLine;
                //                DB.AsignarParametroCadena("@resultadoVal", "");
                //                DB.AsignarParametroCadena("@tipProv", TipoProveedor);
                //                DB.AsignarParametroCadena("@fechaUltimCam", System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
                //                DB.AsignarParametroCadena("@fechaRechazo", "");
                //                DB.AsignarParametroCadena("@causaRechazo", "");
                //                DB.AsignarParametroCadena("@fechEmi", fecha2);
                //                DB.AsignarParametroCadena("@impuestos", cerosNull(totalImpuestosTrasladados));
                //                DB.AsignarParametroCadena("@retenciones", cerosNull(totalImpuestosRetenidos));
                //                DB.AsignarParametroCadena("@propinas", cerosNull(propinas.ToString()));
                //                DB.AsignarParametroCadena("@parentInvoice", pInvoice);
                //                DB.AsignarParametroCadena("@tipCfdi", tipoDeComprobante);
                //                DB.AsignarParametroCadena("@correoContac", emails);
                //                DB.AsignarParametroCadena("@estatus", "proceso");
                //                DB.AsignarParametroCadena("@idProv", IDPROVEMI);
                //                DB.AsignarParametroCadena("@estadoInterface", "0");
                //                DB.EjecutarConsulta1();
                //                DB.Desconectar();
            }
        }
        [WebMethod]
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
            //string val = "";
            //DB.Conectar();
            //DB.CrearComando("select IDEREC from Receptor where RFCREC=@RFC AND NOMREC=@RAZON");
            //DB.AsignarParametroCadena("@RFC", rfc);
            //DB.AsignarParametroCadena("@RAZON", razon);
            //DbDataReader DR = DB.EjecutarConsulta();

            //while (DR.Read())
            //{
            //    val = DR[0].ToString();
            //}
            //DB.Desconectar();
            //return val;
        }
        [WebMethod]
        private bool idProvE2(string rfc)
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
        [WebMethod]
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
        [WebMethod]
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

        [WebMethod]
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

        [WebMethod]
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
                mensajesLog("BD001", "", de.Message, "", "");
                return null;
            }
        }
        [WebMethod]
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
                mensajesLog("BD001", "", de.Message, "", "");
                return null;
            }
        }
        [WebMethod]
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
                        DB.Conectar();
                        DB.CrearComando("delete from general where idFactura=@ide");
                        DB.AsignarParametroCadena("@ide", ide);
                        DB.EjecutarConsulta();
                        DB.Desconectar();

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
                mensajesLog("BD001", "", de.Message, "", "");
                return null;
            }
        }
        [WebMethod]
        private String consultarFechaRec(string valor1, string valor2, string valor3, string campo1, string campo2, string campo3, string consulta)
        {
            try
            {
                String ide;
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
                mensajesLog("BD001", "", de.Message, "", "");
                return null;
            }
        }
        [WebMethod]
        private void copiarArc(string rutaAR, string rutaDO, string nombre, string cliente, string Ocompra)
        {
            string directorio, directoriocom;
            string dirBAk;
            cliente = cliente.Replace("&", "_");
            nombre = nombre.Replace("&", "_").Replace("#", "").Replace("+", "");
            DateTime fech = DateTime.Today;
            if (rutaDO.Contains("docus"))
            {
                String fecha = fech.ToString("yyyy/MM/dd");
                fecha = fecha.Replace("/", @"\") + @"\";

                directoriocom = rutaDO + fecha + cliente + @"\adicionales\";
                directorio = rutaDO + fecha + cliente + @"\";

            }

            else
            {
                directoriocom = rutaDO + cliente + @"\";
                directorio = rutaDO + cliente + @"\";
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
                //  if (!System.IO.File.Exists(directorio + Val.espacios(nombre.Replace("x", "")).Replace(" ", "") + ".xml"))
                // {
                if (System.IO.File.Exists(rutaAR + nombre + ".xml"))
                {
                    if (System.IO.File.Exists(directorio + nombre + ".xml"))//revisa si el archivo existe en al carpeta de respaldo 
                    {
                        System.IO.File.Delete(directorio + nombre + ".xml");
                        System.IO.File.Copy(rutaAR + nombre + ".xml", directorio + nombre + extension);
                        System.IO.File.Delete(rutaAR + nombre + ".xml");
                    }
                    else
                    {
                        System.IO.File.Copy(rutaAR + nombre + ".xml", directorio + nombre + extension);
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

            }
            catch (Exception e)
            {
                anade_linea_archivo(archivo_log, "copiarArc: " + e.ToString());
                mensajesLog("ES001", "", e.Message, "", "");
            }
        }
        [WebMethod]
        private String cerosNull(string a)
        {
            if (a.Equals(""))
                return "0.00";
            else
                return a;
        }
        [WebMethod]
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
                    //em.adjuntar(rutaDOC + fecad + rfcEmisor + @"\" + nombreSE + ".pdf");

                    asunto = "Acabas de recibir una factura con folio. " + folio + " y serie" + serie + ". de: " + rfcEmisor;
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
                        mail = "jesus.elias@dhl.com,maria.ginez@dhl.com";
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
                    if (pInvoice == "REN") { mail = mail + ",jesus.elias@dhl.com,maria.ginez@dhl.com,Claudia.rojas@dhl.com"; }
                    em.llenarEmail(emailEnviar, mail.Trim(','), "", "dataExpressDHL@gmail.com", asunto, mensaje);


                    //em.llenarEmail(emailEnviar, mail, "", "", asunto, mensaje);
                    //em.adjuntar(rutaBCK + rfcEmisor + @"\" + nombreSE + ".xml");


                    em.enviarEmail();
                    msj = msj + ":";
                }
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                mensajesLog("EM001", "", ex.ToString(), "", "");
            }

        }
        [WebMethod]
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
                //em.adjuntar(rutaDOC + fecad + rfcEmisor + @"\" + nombreSE + ".pdf");
                asunto = "Acabas de recibir una factura con folio. " + folio + " y serie" + serie + ". de: " + rfcEmisor;
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
                    mail = "jesus.elias@dhl.com,maria.ginez@dhl.com,Claudia.rojas@dhl.com";
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
                if (pInvoice == "REN") { mail = mail + ",jesus.elias@dhl.com,maria.ginez@dhl.com,Claudia.rojas@dhl.com"; }
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

        [WebMethod]
        private void mensajeEmailError(string codigo, string mensaje2, string emails)
        {
            string[] array;
            array = PA_mensajes(codigo);
            DateTime fech = DateTime.Today;
            if (correosFin != "")
            {
                emails = (emails.Trim(',') + "," + correosFin).Trim(',');
            }

            if (emails.Length > 5)
            {
                em = new EnviarMail();
                em.servidorSTMP(servidor, puerto, ssl, emailCredencial, passCredencial);

                asunto = "Información sobre la factura enviada con Folio " + folio + serie;
                mensaje = @"Buen dia! <br>
                            La factura que enviaste " + rfcEmisor + " con fecha: " + fech.ToString("yyyy/MM/dd") + @"<br>
                            ,  folio " + folio + serie + " y UUID " + UUID + ".";
                mensaje += "<br> Presentó la siguiente observación:";
                mensaje += "<br>    " + array[0];
                mensaje += "<br>    " + array[1];
                mensaje += "<br><br><br>Saludos cordiales. ";
                mensaje += "<br>" + nombreReceptor;
                mensaje += "<br>Servicio proporcionado por DataExpress";
                //em.llenarEmail(emailEnviar, emails, "Josue.BecerrilG@dhl.com", "dataExpressDHL@gmail.com", asunto, mensaje);
                //em.enviarEmail();
            }
        }

        [WebMethod]
        private void mensajesLog(string codigo, string mensaje, string mensajeTecnico, string emails, string resultadovalidacion)
        {
            //String archivo = System.AppDomain.CurrentDomain.BaseDirectory + @"ErrorLog.txt";
            //Label2.Text = archivo;
            //using (System.IO.StreamWriter escritor = new System.IO.StreamWriter(archivo))
            //{
            //    escritor.WriteLine(codigo);
            //    escritor.WriteLine(mensaje);
            //    escritor.WriteLine(mensajeTecnico);
            //    escritor.WriteLine(emails);
            //    escritor.WriteLine(resultadovalidacion);
            //}

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
            // cosultar Fecha de recepcion si codigo es RE008

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
                estadoFinal = array[0].Replace("'", "''") + Environment.NewLine + mensaje.Replace("'", "''");
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
            DB.AsignarParametroCadena("@numeroDocumento", folio + serie);
            DB.AsignarParametroCadena("@detalleTecnico", mensajeTecnico.Replace("'", "''"));
            DB.AsignarParametroCadena("@resultadoValidacion", resultadovalidacion.Replace("'", "''"));
            DB.EjecutarConsulta1();
            DB.Desconectar();

            //if (array[1] != null && array[0] != null)
            //{
            if (codigo == "RE008")
            {
                msj = msj + Environment.NewLine + array[1].Replace("'", "''") + ": " + Environment.NewLine + array[0].Replace("'", "''") + "Fecha de recepción:" + fecharec + " " + " " + folio + serie;
            }
            else
            {
                msj = msj + Environment.NewLine + array[1].Replace("'", "''") + ": " + Environment.NewLine + array[0].Replace("'", "''");
            }
            // }
        }

        [WebMethod]
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

        [WebMethod]
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

        [WebMethod]
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

        [WebMethod]
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

        private bool validation33(string rfcE)
        {
            VregFiscal = "";
            VusoCFDI = "";
            Vimpuestos = "";
            VtipoFactor = "";
            VtasaCuota = "";
            Viva = "";
            Visr = "";
            Vretencion = "";
            VimpHospedaje = "";
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
                case "BIENES Y SERVICIOS":
                    this.VregFiscal = "601,603,612,621";
                    this.VusoCFDI = "G03,I101,I102,I103,I104,I108,P01";
                    this.Vimpuestos = "002,003";
                    this.VtipoFactor = "TASA";
                    this.VtasaCuota = "0.16";
                    if (ReadConceptosTR(this.VregFiscal, this.VusoCFDI, this.Vimpuestos, this.VtipoFactor, this.VtasaCuota))
                    { return true; }
                    else { return false; }
                case "FLETES":
                    this.VregFiscal = "601,612,624,621";
                    this.VusoCFDI = "G03,P01";
                    this.Vimpuestos = "002";
                    this.VtipoFactor = "TASA";
                    this.VtasaCuota = "0.04,0.16";
                    if (ReadConceptosTR(this.VregFiscal, this.VusoCFDI, this.Vimpuestos, this.VtipoFactor, this.VtasaCuota))
                    { return true; }
                    else { return false; }
                case "AGENCIAS":
                    this.VregFiscal = "601";
                    this.VusoCFDI = "G03,P01";
                    this.Vimpuestos = "002";
                    this.VtipoFactor = "TASA";
                    this.VtasaCuota = "0.16";
                    if (ReadConceptosTR(this.VregFiscal, this.VusoCFDI, this.Vimpuestos, this.VtipoFactor, this.VtasaCuota))
                    { return true; }
                    else { return false; }
                case "RENTA CON RETENCION":
                    this.VregFiscal = "603";
                    this.VusoCFDI = "G03,P01";
                    this.Vimpuestos = "001,002";
                    this.VtipoFactor = "TASA";
                    this.VtasaCuota = "0.1,0.1066,0.1067,0.16";
                    if (ReadConceptosTR(this.VregFiscal, this.VusoCFDI, this.Vimpuestos, this.VtipoFactor, this.VtasaCuota))
                    { return true; }
                    else { return false; }
                case "IMSS SAR INFONAVIT JUL-DIC":
                    this.VregFiscal = "603";
                    this.VusoCFDI = "G03,P01";
                    this.Vimpuestos = "002";
                    this.VtipoFactor = "EXENTO";
                    this.VtasaCuota = "0.00";
                    if (ReadConceptosTR(this.VregFiscal, this.VusoCFDI, this.Vimpuestos, this.VtipoFactor, this.VtasaCuota))
                    { return true; }
                    else { return false; }
                case "RENTA":
                    this.VregFiscal = "606";
                    this.VusoCFDI = "G03,P01";
                    this.Vimpuestos = "002";
                    this.VtipoFactor = "TASA";
                    this.VtasaCuota = "0.16";
                    if (ReadConceptosTR(this.VregFiscal, this.VusoCFDI, this.Vimpuestos, this.VtipoFactor, this.VtasaCuota))
                    { return true; }
                    else { return false; }
                case "HOSPEDAJES Y CONVENCIONES":
                    this.VregFiscal = "601";
                    this.VusoCFDI = "G03,P01";
                    this.Vimpuestos = "002";
                    this.VtipoFactor = "TASA";
                    this.VtasaCuota = "0.16";
                    if (ReadConceptosTR(this.VregFiscal, this.VusoCFDI, this.Vimpuestos, this.VtipoFactor, this.VtasaCuota))
                    { return true; }
                    else { return false; }
                case "BIENES Y SERVICIOS SIN IVA":
                    this.VregFiscal = "601,603,612,621";
                    this.VusoCFDI = "G03,P01";
                    this.Vimpuestos = "002,003";
                    this.VtipoFactor = "EXENTO";
                    this.VtasaCuota = "0.00";
                    if (ReadConceptosTR(this.VregFiscal, this.VusoCFDI, this.Vimpuestos, this.VtipoFactor, this.VtasaCuota))
                    { return true; }
                    else { return false; }
                case "HONORARIOS":
                    this.VregFiscal = "612";
                    this.VusoCFDI = "G03,P01";
                    this.Vimpuestos = "001,002";
                    this.VtipoFactor = "TASA";
                    this.VtasaCuota = "0.10,0.1066,0.1067,0.16";
                    if (ReadConceptosTR(this.VregFiscal, this.VusoCFDI, this.Vimpuestos, this.VtipoFactor, this.VtasaCuota))
                    { return true; }
                    else { return false; }
                case "HONORARIOS EXENTO":
                    this.VregFiscal = "612";
                    this.VusoCFDI = "G03,P01";
                    this.Vimpuestos = "001,002";
                    this.VtipoFactor = "EXENTO";
                    this.VtasaCuota = "0.00";
                    if (ReadConceptosTR(this.VregFiscal, this.VusoCFDI, this.Vimpuestos, this.VtipoFactor, this.VtasaCuota))
                    { return true; }
                    else { return false; }
                default:
                    return false;
            }
        }

        private bool ReadConceptosTR(string VregFiscal, string VusoCFDI, string Vimpuestos, string VtipoFactor, string VtasaCuota)
        {
            string str1 = "";
            string str2 = "";
            string str3 = "";
            foreach (string[] strArray in arrayListImpuestosTC)
            {
                if (!str3.Contains(VtasaCuota) || str3 == "")
                {
                    str1 = strArray[0].ToString();
                    str2 = strArray[1].ToString();
                    str3 = Convert.ToDouble(strArray[2]).ToString();
                    var alf = Convert.ToDecimal(strArray[2]).ToString();
                }
            }
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
                }
            }
            if (!VregFiscal.Contains(Regimen))
                Facturas.anade_linea_archivo(archivo_logXSD, "Regimen Fiscal invalido para tipo de proveedor,");
            if (!VusoCFDI.Contains(UsoCFDI))
                Facturas.anade_linea_archivo(archivo_logXSD, "Uso CFDI invalido para tipo de proveedor,");
            if (!Vimpuestos.Contains(str1))
                Facturas.anade_linea_archivo(archivo_logXSD, "Codigo impuesto invalido invalido para tipo de proveedor,");
            if (!VtipoFactor.ToUpper().Equals(str2.ToUpper()))
                Facturas.anade_linea_archivo(archivo_logXSD, "Tipo Factor invalido para tipo de proveedor,");
            if (!VtasaCuota.Contains(str3))
                Facturas.anade_linea_archivo(archivo_logXSD, "Tasa o Cuota invalida en conceptos para tipo de proveedor,");
            if (VregFiscal.Contains(Regimen) && VusoCFDI.Contains(UsoCFDI) && (Vimpuestos.Contains(str1) && VtipoFactor.ToUpper().Equals(str2.ToUpper())) && VtasaCuota.Contains(str3))
            { return true; }
            else { return false; }
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

        private bool operaciones33()
        {
            Decimal num1 = new Decimal();
            foreach (string[] arrayListConcepto in this.arrayListConceptos)
                num1 += Convert.ToDecimal(arrayListConcepto[5]);
            foreach (string[] strArray in this.arrayListImpuestosT)
                num1 += Convert.ToDecimal(strArray[3]);
            if (this.descuento != "" && Convert.ToDecimal(this.descuento) > Decimal.Zero)
                num1 -= Convert.ToDecimal(this.descuento);
            foreach (string[] strArray in this.arrayListImpuestosR)
                num1 -= Convert.ToDecimal(strArray[2]);
            if (num1 == Convert.ToDecimal(this.total))
                return true;
            Decimal num2 = this.Truncate(Convert.ToDecimal(num1), 1);
            string str = this.Truncate(Convert.ToDecimal(this.total), 1).ToString();
            if (Convert.ToInt32(num2.ToString().Split('.')[1]) == 9 && num2 != Convert.ToDecimal(str))
                num2 = Convert.ToDecimal(Convert.ToDouble(num2) + 0.1);
            if (Math.Abs(num2 - Convert.ToDecimal(str)) <= Convert.ToDecimal("0.90"))
                num2 = Convert.ToDecimal(str);
            return num2 == Convert.ToDecimal(str);
        }

    }
}
