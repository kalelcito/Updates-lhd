﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// Microsoft.VSDesigner generó automáticamente este código fuente, versión=4.0.30319.42000.
// 
#pragma warning disable 1591

namespace DataExpressWeb.WebServiceInterfaz {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="GenerarInterfazSoap", Namespace="http://tempuri.org/")]
    public partial class GenerarInterfaz : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GeneraInterfazOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public GenerarInterfaz() {
            this.Url = global::DataExpressWeb.Properties.Settings.Default.DataExpressWeb_WebServiceInterfaz_GenerarInterfaz;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event GeneraInterfazCompletedEventHandler GeneraInterfazCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GeneraInterfaz", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void GeneraInterfaz(string RazonSocial, string TipoProveedor, bool grabar_en_bd, string numero_registros) {
            this.Invoke("GeneraInterfaz", new object[] {
                        RazonSocial,
                        TipoProveedor,
                        grabar_en_bd,
                        numero_registros});
        }
        
        /// <remarks/>
        public void GeneraInterfazAsync(string RazonSocial, string TipoProveedor, bool grabar_en_bd, string numero_registros) {
            this.GeneraInterfazAsync(RazonSocial, TipoProveedor, grabar_en_bd, numero_registros, null);
        }
        
        /// <remarks/>
        public void GeneraInterfazAsync(string RazonSocial, string TipoProveedor, bool grabar_en_bd, string numero_registros, object userState) {
            if ((this.GeneraInterfazOperationCompleted == null)) {
                this.GeneraInterfazOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGeneraInterfazOperationCompleted);
            }
            this.InvokeAsync("GeneraInterfaz", new object[] {
                        RazonSocial,
                        TipoProveedor,
                        grabar_en_bd,
                        numero_registros}, this.GeneraInterfazOperationCompleted, userState);
        }
        
        private void OnGeneraInterfazOperationCompleted(object arg) {
            if ((this.GeneraInterfazCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GeneraInterfazCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void GeneraInterfazCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
}

#pragma warning restore 1591