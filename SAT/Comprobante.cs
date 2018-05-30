using System.Collections.Generic;

namespace SAT
{
    public class JsonCFDI
    {
        public string tipo { get { return "JSON"; } }
        public string noControl { get; set; }
        public Comprobante comprobante { get; set; }
    }
    public class Comprobante
    {
        public string version { get { return "3.2"; } }
        public string serie { get; set; }
        public string folio { get; set; }
        private string _fecha = "";
        public string fecha { get { return Utilidades.FormatoFecha(_fecha); } set { _fecha = value; } }
        public string sello { get; set; }
        public string formaDePago { get; set; }
        public string noCertificado { get; set; }
        public string certificado { get; set; }
        public string condicionesDePago { get; set; }
        public string subTotal { get; set; }
        public string descuento { get; set; }
        public string descuentoSpecified { get { return (!string.IsNullOrEmpty(descuento)).ToString().ToLower(); } }
        public string motivoDescuento { get; set; }
        public string tipoCambio { get; set; }
        public string moneda { get; set; }
        private string _total = "";
        public string total { get { return Utilidades.CerosNull(_total); } set { _total = value; } }
        public string tipoDeComprobante { get; set; }
        public string metodoDePago { get; set; }
        public string lugarExpedicion { get; set; }
        public string numCtaPago { get; set; }
        public string folioFiscalOrig { get; set; }
        public string serieFolioFiscalOrig { get; set; }

        private string _fechaFolioFiscalOrig = "";
        public string fechaFolioFiscalOrig { get { return Utilidades.FormatoFecha(_fechaFolioFiscalOrig); } set { _fecha = value; } }
        public string fechaFolioFiscalOrigSpecified { get { return (!string.IsNullOrEmpty(fechaFolioFiscalOrig)).ToString().ToLower(); } }
        private string _montoFolioFiscalOrig = "";
        public string montoFolioFiscalOrig { get { return Utilidades.CerosNull(_montoFolioFiscalOrig); } set { _montoFolioFiscalOrig = value; } }
        public string montoFolioFiscalOrigSpecified { get { return (!string.IsNullOrEmpty(montoFolioFiscalOrig)).ToString().ToLower(); } }
        public Emisor emisor { get; set; }
        public Receptor receptor { get; set; }
        public Impuestos impuestos { get; set; }
        public Conceptos[] conceptos { get; set; }
        public Complemento complemento { get; set; }
    }
    public class Emisor
    {
        public string nombre { get; set; }
        public string rfc { get; set; }
        public Ubicacion domicilioFiscal { get; set; }
        public Ubicacion expedidoEn { get; set; }
        public RegimenFiscal[] regimenFiscal { get; set; }
    }
    public class RegimenFiscal
    {
        public string regimen { get; set; }
    }
    public class Receptor
    {
        public string nombre { get; set; }
        public string rfc { get; set; }
        public Ubicacion domicilio { get; set; }
    }
    public class Impuestos
    {
        private string _totalImpuestosRetenidos = "";
        public string totalImpuestosRetenidos { get { return Utilidades.CerosNull(_totalImpuestosRetenidos); } set { _totalImpuestosRetenidos = value; } }
        public string totalImpuestosRetenidosSpecified { get { return (!string.IsNullOrEmpty(totalImpuestosRetenidos)).ToString().ToLower(); } }
        private string _totalImpuestosTrasladados = "";
        public string totalImpuestosTrasladados { get { return Utilidades.CerosNull(_totalImpuestosTrasladados); } set { _totalImpuestosTrasladados = value; } }
        public string totalImpuestosTrasladadosSpecified { get { return (!string.IsNullOrEmpty(totalImpuestosTrasladados)).ToString().ToLower(); } }
        public Retencion[] retenciones { get; set; }
        public Traslado[] traslados { get; set; }
    }
    public class Traslado
    {
        public string impuesto { get; set; }
        private string _tasa = "";
        public string tasa { get { return Utilidades.CerosNull(_tasa); } set { _tasa = value; } }
        private string _importe = "";
        public string importe { get { return Utilidades.CerosNull(_importe); } set { _importe = value; } }
    }
    public class Retencion
    {
        public string impuesto { get; set; }
        private string _importe = "";
        public string importe { get { return Utilidades.CerosNull(_importe); } set { _importe = value; } }
    }
    public class Conceptos
    {
        public string cantidad { get; set; }
        public string unidad { get; set; }
        public string noIdentificacion { get; set; }
        public string descripcion { get; set; }
        private string _valorUnitario = "";
        public string valorUnitario { get { return Utilidades.CerosNull(_valorUnitario); } set { _valorUnitario = value; } }
        private string _importe = "";
        public string importe { get { return Utilidades.CerosNull(_importe); } set { _importe = value; } }
        public object[] items { get; set; }
    }
    public class ConceptoAduanera
    {
        public string objectType { get { return "t_InformacionAduanera"; } }
        public string numero { get; set; }
        private string _fecha = "";
        public string fecha { get { return Utilidades.FormatoFecha(_fecha); } set { _fecha = value; } }
        public string aduana { get; set; }
    }
    public class ConceptoComplementoAduanera
    {
        public string objectType { get { return "ComprobanteConceptoComplementoConcepto"; } }
        public ConceptoAduanera[] items { get; set; }
    }
    public class ConceptoPredial
    {
        public string objectType { get { return "NodoComprobateConceptoCuentaPredial"; } }
        public string numero { get; set; }
    }
    public class ConceptoParte
    {
        public string objectType { get { return "NodoComprobateConceptoParte"; } }
        private string _cantidad = "";
        public string cantidad { get { return Utilidades.CerosNull(_cantidad); } set { _cantidad = value; } }
        public string unidad { get; set; }
        public string noIdentificacion { get; set; }
        public string descripcion { get; set; }
        private string _valorUnitario = "";
        public string valorUnitario { get { return Utilidades.CerosNull(_valorUnitario); } set { _valorUnitario = value; } }
        public string valorUnitarioSpecified { get; set; }
        private string _importe = "";
        public string importe { get { return Utilidades.CerosNull(_importe); } set { _importe = value; } }
        public string importeSpecified { get { return (!string.IsNullOrEmpty(importe)).ToString().ToLower(); } }
        public ConceptoAduanera informacionAduanera { get; set; }
    }
    public class Complemento
    {
        public object[] items { get; set; }
    }
    public class ComplementoNomina
    {
        public string objectType { get { return "Nomina"; } }
        public string version { get { return "1.0"; } }
        public string registroPatronal { get; set; }
        public string numEmpleado { get; set; }
        public string curp { get; set; }
        public string tipoRegimen { get; set; }
        public string numSeguridadSocial { get; set; }
        private string _fechaPago = "";
        public string fechaPago { get { return Utilidades.FormatoFecha(_fechaPago); } set { _fechaPago = value; } }
        private string _fechaInicialPago = "";
        public string fechaInicialPago { get { return Utilidades.FormatoFecha(_fechaInicialPago); } set { _fechaInicialPago = value; } }
        private string _fechaFinalPago = "";
        public string fechaFinalPago { get { return Utilidades.FormatoFecha(_fechaFinalPago); } set { _fechaFinalPago = value; } }
        public string numDiasPagados { get; set; }
        public string departamento { get; set; }
        public string clabe { get; set; }
        public string banco { get; set; }
        public string bancoSpecified { get { return (!string.IsNullOrEmpty(banco)).ToString().ToLower(); } }
        public string fechaInicioRelLaboral { get; set; }
        public string fechaInicioRelLaboralSpecified { get { return (!string.IsNullOrEmpty(fechaInicioRelLaboral)).ToString().ToLower(); } }
        public string antiguedad { get; set; }
        public string antiguedadSpecified { get { return (!string.IsNullOrEmpty(antiguedad)).ToString().ToLower(); } }
        public string puesto { get; set; }
        public string tipoContrato { get; set; }
        public string tipoJornada { get; set; }
        public string periodicidadPago { get; set; }
        public string salarioBaseCotApor { get; set; }
        public string salarioBaseCotAporSpecified { get { return (!string.IsNullOrEmpty(salarioBaseCotApor)).ToString().ToLower(); } }
        public string riesgoPuesto { get; set; }
        public string riesgoPuestoSpecified { get { return (!string.IsNullOrEmpty(riesgoPuesto)).ToString().ToLower(); } }
        public string salarioDiarioIntegrado { get; set; }
        public string salarioDiarioIntegradoSpecified { get { return (!string.IsNullOrEmpty(salarioDiarioIntegrado)).ToString().ToLower(); } }
        public PercepcionesNomina percepciones { get; set; }
        public DeduccionesNomina deducciones { get; set; }
        public Incapacidad[] incapacidades { get; set; }
        public HorasExtra[] horasExtras { get; set; }
    }
    public class DeduccionesNomina
    {
        private string _totalGravado = "";
        private string _totalExento = "";
        public string totalGravado { get { return Utilidades.CerosNull(_totalGravado); } set { _totalGravado = value; } }
        public string totalExento { get { return Utilidades.CerosNull(_totalExento); } set { _totalExento = value; } }
        public Deduccion[] deduccion { get; set; }
    }
    public class Deduccion
    {
        public string tipoDeduccion { get; set; }
        public string clave { get; set; }
        public string concepto { get; set; }
        private string _importeGravado = "";
        private string _importeExento = "";
        public string importeGravado { get { return Utilidades.CerosNull(_importeGravado); } set { _importeGravado = value; } }
        public string importeExento { get { return Utilidades.CerosNull(_importeExento); } set { _importeExento = value; } }
    }
    public class Incapacidad
    {
        public string diasIncapacidad { get; set; }
        public string tipoIncapacidad { get; set; }
        private string _descuento = "";
        public string descuento { get { return Utilidades.CerosNull(_descuento); } set { _descuento = value; } }
    }
    public class HorasExtra
    {
        public string dias { get; set; }
        public string tipoHoras { get; set; }
        public string horasExtra { get; set; }
        private string _importePagado = "";
        public string importePagado { get { return Utilidades.CerosNull(_importePagado); } set { _importePagado = value; } }
    }
    public class PercepcionesNomina
    {

        private string _totalGravado = "";
        private string _totalExento = "";
        public string totalGravado { get { return Utilidades.CerosNull(_totalGravado); } set { _totalGravado = value; } }
        public string totalExento { get { return Utilidades.CerosNull(_totalExento); } set { _totalExento = value; } }
        public Percepcion[] percepcion;
    }
    public class Percepcion
    {
        public string tipoPercepcion { get; set; }
        public string clave { get; set; }
        public string concepto { get; set; }
        private string _importeGravado = "";
        private string _importeExento = "";
        public string importeGravado { get { return Utilidades.CerosNull(_importeGravado); } set { _importeGravado = value; } }
        public string importeExento { get { return Utilidades.CerosNull(_importeExento); } set { _importeExento = value; } }
    }
    public class ComplementoDonatarias
    {
        public string objectType { get { return "Donatarias"; } }
        public string version { get { return "1.1"; } }
        public string noAutorizacion { get; set; }
        private string _fechaAutorizacion = "";
        public string fechaAutorizacion { get { return Utilidades.FormatoFecha(_fechaAutorizacion); } set { _fechaAutorizacion = value; } }
        private string _leyenda = "Este comprobante ampara un donativo, el cual será destinado por la donataria a los fines propios de su objeto social. En el caso de que los bienes donados hayan sido deducidos previamente para los efectos del impuesto sobre la renta, este donativo no es deducible. La reproducción no autorizada de este comprobante constituye un delito en los términos de las disposiciones fiscales.";
        public string leyenda { get { return _leyenda; } set { _leyenda = value; } }
    }
    public class Ubicacion
    {
        public string calle { get; set; }
        public string noExterior { get; set; }
        public string noInterior { get; set; }
        public string colonia { get; set; }
        public string localidad { get; set; }
        public string referencia { get; set; }
        public string municipio { get; set; }
        public string estado { get; set; }
        public string pais { get; set; }
        public string codigoPostal { get; set; }
    }
}
