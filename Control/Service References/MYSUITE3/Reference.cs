﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Control.MYSUITE3 {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.fact.com.mx/schema/ws", ConfigurationName="MYSUITE3.FactWSFrontSoap")]
    public interface FactWSFrontSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.fact.com.mx/schema/ws/RequestTransaction", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Control.MYSUITE3.TransactionTag RequestTransaction(string Requestor, string Transaction, string Country, string Entity, string User, string UserName, string Data1, string Data2, string Data3);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.fact.com.mx/schema/ws/SSLTransaction", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string SSLTransaction(string DataExchange);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.fact.com.mx/schema/ws/SecureTransaction", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string SecureTransaction(string DataExchange);
    }
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1038.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.fact.com.mx/schema/ws")]
    public partial class TransactionTag : object, System.ComponentModel.INotifyPropertyChanged {
        
        private FactRequest requestField;
        
        private FactResponse responseField;
        
        private FactResponseData responseDataField;
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public FactRequest Request {
            get {
                return this.requestField;
            }
            set {
                this.requestField = value;
                this.RaisePropertyChanged("Request");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public FactResponse Response {
            get {
                return this.responseField;
            }
            set {
                this.responseField = value;
                this.RaisePropertyChanged("Response");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public FactResponseData ResponseData {
            get {
                return this.responseDataField;
            }
            set {
                this.responseDataField = value;
                this.RaisePropertyChanged("ResponseData");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1038.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.fact.com.mx/schema/ws")]
    public partial class FactRequest : object, System.ComponentModel.INotifyPropertyChanged {
        
        private System.Guid requestorField;
        
        private string requestorNameField;
        
        private bool requestorActiveField;
        
        private Transactions transactionField;
        
        private string countryField;
        
        private string entityField;
        
        private System.Guid userField;
        
        private string userNameField;
        
        private System.Guid idField;
        
        private System.DateTime timeStampField;
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public System.Guid Requestor {
            get {
                return this.requestorField;
            }
            set {
                this.requestorField = value;
                this.RaisePropertyChanged("Requestor");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string RequestorName {
            get {
                return this.requestorNameField;
            }
            set {
                this.requestorNameField = value;
                this.RaisePropertyChanged("RequestorName");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public bool RequestorActive {
            get {
                return this.requestorActiveField;
            }
            set {
                this.requestorActiveField = value;
                this.RaisePropertyChanged("RequestorActive");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public Transactions Transaction {
            get {
                return this.transactionField;
            }
            set {
                this.transactionField = value;
                this.RaisePropertyChanged("Transaction");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string Country {
            get {
                return this.countryField;
            }
            set {
                this.countryField = value;
                this.RaisePropertyChanged("Country");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string Entity {
            get {
                return this.entityField;
            }
            set {
                this.entityField = value;
                this.RaisePropertyChanged("Entity");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public System.Guid User {
            get {
                return this.userField;
            }
            set {
                this.userField = value;
                this.RaisePropertyChanged("User");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string UserName {
            get {
                return this.userNameField;
            }
            set {
                this.userNameField = value;
                this.RaisePropertyChanged("UserName");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public System.Guid Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
                this.RaisePropertyChanged("Id");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public System.DateTime TimeStamp {
            get {
                return this.timeStampField;
            }
            set {
                this.timeStampField = value;
                this.RaisePropertyChanged("TimeStamp");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1038.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.fact.com.mx/schema/ws")]
    public enum Transactions {
        
        /// <comentarios/>
        BASE,
        
        /// <comentarios/>
        NO_TRANSACTION,
        
        /// <comentarios/>
        CONVERT_NATIVE_XML,
        
        /// <comentarios/>
        GET_MTE_BATCH,
        
        /// <comentarios/>
        PROCESS_BATCH,
        
        /// <comentarios/>
        SYSTEM_REQUEST,
        
        /// <comentarios/>
        RECEIVE_BATCH,
        
        /// <comentarios/>
        ENROLL_CERT,
        
        /// <comentarios/>
        GET_XML,
        
        /// <comentarios/>
        GET_HTML,
        
        /// <comentarios/>
        GET_XML_AND_HTML,
        
        /// <comentarios/>
        CANCEL_XML,
        
        /// <comentarios/>
        MARK_XML_AS_PAID,
        
        /// <comentarios/>
        MARK_XML_AS_UNPAID,
        
        /// <comentarios/>
        SEARCH_BASIC,
        
        /// <comentarios/>
        GET_MONTHLY_REPORT,
        
        /// <comentarios/>
        GET_MONTHLY_REPORT_FOR_PROVIDER,
        
        /// <comentarios/>
        GET_FOLIOS_BY_RFC,
        
        /// <comentarios/>
        DOES_ASSIGNMENT_EXIST,
        
        /// <comentarios/>
        CANCEL_XML_BY_INTERNAL_ID,
        
        /// <comentarios/>
        ACTIVATE_ASSIGNMENT,
        
        /// <comentarios/>
        COUNT_ACTIVE_ASSIGNMENTS,
        
        /// <comentarios/>
        GET_DOCUMENT,
        
        /// <comentarios/>
        GET_HISTORY,
        
        /// <comentarios/>
        AUTHENTICATE_USER,
        
        /// <comentarios/>
        GET_ACCOUNT,
        
        /// <comentarios/>
        DISTRIBUTE,
        
        /// <comentarios/>
        QUEUE_FOR_DISTRIBUTION,
        
        /// <comentarios/>
        GET_EFFECTIVE_RIGHTS,
        
        /// <comentarios/>
        EXEC_STORED_PROC,
        
        /// <comentarios/>
        GET_USER_INFO,
        
        /// <comentarios/>
        RECEIVE,
        
        /// <comentarios/>
        GET_PREVIEW,
        
        /// <comentarios/>
        RETRIEVE_DOCUMENT,
        
        /// <comentarios/>
        MARK_DOCUMENT_AS_PAID,
        
        /// <comentarios/>
        MARK_DOCUMENT_AS_NOT_PAID,
        
        /// <comentarios/>
        CANCEL_DOCUMENT,
        
        /// <comentarios/>
        MARK_DOCUMENT_AS_DELETED,
        
        /// <comentarios/>
        MARK_DOCUMENT_AS_NOT_DELETED,
        
        /// <comentarios/>
        RETRIEVE_HISTORY,
        
        /// <comentarios/>
        GET_ADDENDA_RECEIVERS,
        
        /// <comentarios/>
        REQUEST_PASSWORD_CHANGE,
        
        /// <comentarios/>
        CHANGE_DOCUMENT_SUCURSAL,
        
        /// <comentarios/>
        CREATE_ACCOUNT_AS_OWNER,
        
        /// <comentarios/>
        CREATE_PASSWORD,
        
        /// <comentarios/>
        PASSWORD_FORGOT,
        
        /// <comentarios/>
        CREATE_USER,
        
        /// <comentarios/>
        INCREMENT_BUNDLE_SIZE,
        
        /// <comentarios/>
        TIMBRAR,
        
        /// <comentarios/>
        LOOKUP_ISSUED_INTERNAL_ID,
        
        /// <comentarios/>
        VALIDATE_CERT,
        
        /// <comentarios/>
        BATCH_SERIAL_OPERATIONS,
        
        /// <comentarios/>
        PROCESS_LCO,
        
        /// <comentarios/>
        ENROLL_THIRD_PARTY_CERT,
        
        /// <comentarios/>
        CANCEL_CFDI,
        
        /// <comentarios/>
        UPDATE_ACCOUNT_DATA,
        
        /// <comentarios/>
        ASSIGN_ACCOUNT_REQUESTOR,
        
        /// <comentarios/>
        UPDATE_USER_DATA,
        
        /// <comentarios/>
        UPDATE_ADMIN_USER_DATA,
        
        /// <comentarios/>
        CREATE_ADMIN_USER,
        
        /// <comentarios/>
        UPSERT_GRAPHIC_REPRESENTATION,
    }
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1038.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.fact.com.mx/schema/ws")]
    public partial class FactResponseData : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string responseData1Field;
        
        private string responseData2Field;
        
        private string responseData3Field;
        
        private System.Data.DataSet responseDataSetField;
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string ResponseData1 {
            get {
                return this.responseData1Field;
            }
            set {
                this.responseData1Field = value;
                this.RaisePropertyChanged("ResponseData1");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string ResponseData2 {
            get {
                return this.responseData2Field;
            }
            set {
                this.responseData2Field = value;
                this.RaisePropertyChanged("ResponseData2");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string ResponseData3 {
            get {
                return this.responseData3Field;
            }
            set {
                this.responseData3Field = value;
                this.RaisePropertyChanged("ResponseData3");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public System.Data.DataSet ResponseDataSet {
            get {
                return this.responseDataSetField;
            }
            set {
                this.responseDataSetField = value;
                this.RaisePropertyChanged("ResponseDataSet");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1038.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.fact.com.mx/schema/ws")]
    public partial class BatchID : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string batchIdField;
        
        private string batchTimeStampField;
        
        private string batchRequestorCountryField;
        
        private string batchRequestorEntityField;
        
        private string batchPositionField;
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string BatchId {
            get {
                return this.batchIdField;
            }
            set {
                this.batchIdField = value;
                this.RaisePropertyChanged("BatchId");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string BatchTimeStamp {
            get {
                return this.batchTimeStampField;
            }
            set {
                this.batchTimeStampField = value;
                this.RaisePropertyChanged("BatchTimeStamp");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string BatchRequestorCountry {
            get {
                return this.batchRequestorCountryField;
            }
            set {
                this.batchRequestorCountryField = value;
                this.RaisePropertyChanged("BatchRequestorCountry");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string BatchRequestorEntity {
            get {
                return this.batchRequestorEntityField;
            }
            set {
                this.batchRequestorEntityField = value;
                this.RaisePropertyChanged("BatchRequestorEntity");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string BatchPosition {
            get {
                return this.batchPositionField;
            }
            set {
                this.batchPositionField = value;
                this.RaisePropertyChanged("BatchPosition");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1038.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.fact.com.mx/schema/ws")]
    public partial class DocID : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string countryField;
        
        private string entityField;
        
        private string fiscalNameField;
        
        private string aYearField;
        
        private string aNumberField;
        
        private string batchField;
        
        private string serialField;
        
        private string documentGUIDField;
        
        private string issuedTimeStampField;
        
        private string enrolledTimeStampField;
        
        private string paidTimeStampField;
        
        private string cancelledTimeStampField;
        
        private string internalIDField;
        
        private string batchIDField;
        
        private string batchTimeStampField;
        
        private string batchRequestorCountryField;
        
        private string batchRequestorEntityField;
        
        private string batchPositionField;
        
        private string receiverCountryField;
        
        private string receiverEntityField;
        
        private string receiverTaxIDField;
        
        private string receiverNameField;
        
        private string claveAgenteField;
        
        private string numeroDePolizaField;
        
        private string currencyField;
        
        private string totalAmountField;
        
        private string type1Field;
        
        private string type2Field;
        
        private string suggestedFileNameField;
        
        private string suggestedFileName2Field;
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Country {
            get {
                return this.countryField;
            }
            set {
                this.countryField = value;
                this.RaisePropertyChanged("Country");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Entity {
            get {
                return this.entityField;
            }
            set {
                this.entityField = value;
                this.RaisePropertyChanged("Entity");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string FiscalName {
            get {
                return this.fiscalNameField;
            }
            set {
                this.fiscalNameField = value;
                this.RaisePropertyChanged("FiscalName");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string AYear {
            get {
                return this.aYearField;
            }
            set {
                this.aYearField = value;
                this.RaisePropertyChanged("AYear");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string ANumber {
            get {
                return this.aNumberField;
            }
            set {
                this.aNumberField = value;
                this.RaisePropertyChanged("ANumber");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string Batch {
            get {
                return this.batchField;
            }
            set {
                this.batchField = value;
                this.RaisePropertyChanged("Batch");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string Serial {
            get {
                return this.serialField;
            }
            set {
                this.serialField = value;
                this.RaisePropertyChanged("Serial");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string DocumentGUID {
            get {
                return this.documentGUIDField;
            }
            set {
                this.documentGUIDField = value;
                this.RaisePropertyChanged("DocumentGUID");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string IssuedTimeStamp {
            get {
                return this.issuedTimeStampField;
            }
            set {
                this.issuedTimeStampField = value;
                this.RaisePropertyChanged("IssuedTimeStamp");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string EnrolledTimeStamp {
            get {
                return this.enrolledTimeStampField;
            }
            set {
                this.enrolledTimeStampField = value;
                this.RaisePropertyChanged("EnrolledTimeStamp");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string PaidTimeStamp {
            get {
                return this.paidTimeStampField;
            }
            set {
                this.paidTimeStampField = value;
                this.RaisePropertyChanged("PaidTimeStamp");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public string CancelledTimeStamp {
            get {
                return this.cancelledTimeStampField;
            }
            set {
                this.cancelledTimeStampField = value;
                this.RaisePropertyChanged("CancelledTimeStamp");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        public string InternalID {
            get {
                return this.internalIDField;
            }
            set {
                this.internalIDField = value;
                this.RaisePropertyChanged("InternalID");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public string BatchID {
            get {
                return this.batchIDField;
            }
            set {
                this.batchIDField = value;
                this.RaisePropertyChanged("BatchID");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        public string BatchTimeStamp {
            get {
                return this.batchTimeStampField;
            }
            set {
                this.batchTimeStampField = value;
                this.RaisePropertyChanged("BatchTimeStamp");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        public string BatchRequestorCountry {
            get {
                return this.batchRequestorCountryField;
            }
            set {
                this.batchRequestorCountryField = value;
                this.RaisePropertyChanged("BatchRequestorCountry");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=16)]
        public string BatchRequestorEntity {
            get {
                return this.batchRequestorEntityField;
            }
            set {
                this.batchRequestorEntityField = value;
                this.RaisePropertyChanged("BatchRequestorEntity");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=17)]
        public string BatchPosition {
            get {
                return this.batchPositionField;
            }
            set {
                this.batchPositionField = value;
                this.RaisePropertyChanged("BatchPosition");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=18)]
        public string ReceiverCountry {
            get {
                return this.receiverCountryField;
            }
            set {
                this.receiverCountryField = value;
                this.RaisePropertyChanged("ReceiverCountry");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=19)]
        public string ReceiverEntity {
            get {
                return this.receiverEntityField;
            }
            set {
                this.receiverEntityField = value;
                this.RaisePropertyChanged("ReceiverEntity");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=20)]
        public string ReceiverTaxID {
            get {
                return this.receiverTaxIDField;
            }
            set {
                this.receiverTaxIDField = value;
                this.RaisePropertyChanged("ReceiverTaxID");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=21)]
        public string ReceiverName {
            get {
                return this.receiverNameField;
            }
            set {
                this.receiverNameField = value;
                this.RaisePropertyChanged("ReceiverName");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=22)]
        public string ClaveAgente {
            get {
                return this.claveAgenteField;
            }
            set {
                this.claveAgenteField = value;
                this.RaisePropertyChanged("ClaveAgente");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=23)]
        public string NumeroDePoliza {
            get {
                return this.numeroDePolizaField;
            }
            set {
                this.numeroDePolizaField = value;
                this.RaisePropertyChanged("NumeroDePoliza");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=24)]
        public string Currency {
            get {
                return this.currencyField;
            }
            set {
                this.currencyField = value;
                this.RaisePropertyChanged("Currency");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=25)]
        public string TotalAmount {
            get {
                return this.totalAmountField;
            }
            set {
                this.totalAmountField = value;
                this.RaisePropertyChanged("TotalAmount");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=26)]
        public string Type1 {
            get {
                return this.type1Field;
            }
            set {
                this.type1Field = value;
                this.RaisePropertyChanged("Type1");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=27)]
        public string Type2 {
            get {
                return this.type2Field;
            }
            set {
                this.type2Field = value;
                this.RaisePropertyChanged("Type2");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=28)]
        public string SuggestedFileName {
            get {
                return this.suggestedFileNameField;
            }
            set {
                this.suggestedFileNameField = value;
                this.RaisePropertyChanged("SuggestedFileName");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=29)]
        public string SuggestedFileName2 {
            get {
                return this.suggestedFileName2Field;
            }
            set {
                this.suggestedFileName2Field = value;
                this.RaisePropertyChanged("SuggestedFileName2");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1038.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.fact.com.mx/schema/ws")]
    public partial class FactResponse : object, System.ComponentModel.INotifyPropertyChanged {
        
        private bool resultField;
        
        private System.DateTime timeStampField;
        
        private string lastResultField;
        
        private int codeField;
        
        private string descriptionField;
        
        private string hintField;
        
        private string dataField;
        
        private string processorField;
        
        private DocID identifierField;
        
        private BatchID batchIdentifierField;
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public bool Result {
            get {
                return this.resultField;
            }
            set {
                this.resultField = value;
                this.RaisePropertyChanged("Result");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public System.DateTime TimeStamp {
            get {
                return this.timeStampField;
            }
            set {
                this.timeStampField = value;
                this.RaisePropertyChanged("TimeStamp");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string LastResult {
            get {
                return this.lastResultField;
            }
            set {
                this.lastResultField = value;
                this.RaisePropertyChanged("LastResult");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public int Code {
            get {
                return this.codeField;
            }
            set {
                this.codeField = value;
                this.RaisePropertyChanged("Code");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string Description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
                this.RaisePropertyChanged("Description");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string Hint {
            get {
                return this.hintField;
            }
            set {
                this.hintField = value;
                this.RaisePropertyChanged("Hint");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string Data {
            get {
                return this.dataField;
            }
            set {
                this.dataField = value;
                this.RaisePropertyChanged("Data");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string Processor {
            get {
                return this.processorField;
            }
            set {
                this.processorField = value;
                this.RaisePropertyChanged("Processor");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public DocID Identifier {
            get {
                return this.identifierField;
            }
            set {
                this.identifierField = value;
                this.RaisePropertyChanged("Identifier");
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public BatchID BatchIdentifier {
            get {
                return this.batchIdentifierField;
            }
            set {
                this.batchIdentifierField = value;
                this.RaisePropertyChanged("BatchIdentifier");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface FactWSFrontSoapChannel : Control.MYSUITE3.FactWSFrontSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FactWSFrontSoapClient : System.ServiceModel.ClientBase<Control.MYSUITE3.FactWSFrontSoap>, Control.MYSUITE3.FactWSFrontSoap {
        
        public FactWSFrontSoapClient() {
        }
        
        public FactWSFrontSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FactWSFrontSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FactWSFrontSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FactWSFrontSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Control.MYSUITE3.TransactionTag RequestTransaction(string Requestor, string Transaction, string Country, string Entity, string User, string UserName, string Data1, string Data2, string Data3) {
            return base.Channel.RequestTransaction(Requestor, Transaction, Country, Entity, User, UserName, Data1, Data2, Data3);
        }
        
        public string SSLTransaction(string DataExchange) {
            return base.Channel.SSLTransaction(DataExchange);
        }
        
        public string SecureTransaction(string DataExchange) {
            return base.Channel.SecureTransaction(DataExchange);
        }
    }
}
