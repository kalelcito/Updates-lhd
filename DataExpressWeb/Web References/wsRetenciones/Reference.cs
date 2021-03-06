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

namespace DataExpressWeb.wsRetenciones {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="RetencionesSoap", Namespace="http://tempuri.org/")]
    public partial class Retenciones : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback retencionFacturaOperationCompleted;
        
        private System.Threading.SendOrPostCallback procesarRetencionTXTOperationCompleted;
        
        private System.Threading.SendOrPostCallback procesarRetencionArchivoOperationCompleted;
        
        private System.Threading.SendOrPostCallback cancelarRetencionOperationCompleted;
        
        private System.Threading.SendOrPostCallback obtenerMensajeErrorOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public Retenciones() {
            this.Url = global::DataExpressWeb.Properties.Settings.Default.DataExpressWeb_wsRetenciones_Retenciones;
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
        public event retencionFacturaCompletedEventHandler retencionFacturaCompleted;
        
        /// <remarks/>
        public event procesarRetencionTXTCompletedEventHandler procesarRetencionTXTCompleted;
        
        /// <remarks/>
        public event procesarRetencionArchivoCompletedEventHandler procesarRetencionArchivoCompleted;
        
        /// <remarks/>
        public event cancelarRetencionCompletedEventHandler cancelarRetencionCompleted;
        
        /// <remarks/>
        public event obtenerMensajeErrorCompletedEventHandler obtenerMensajeErrorCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/retencionFactura", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Xml.XmlNode retencionFactura(string idFactura, string correo) {
            object[] results = this.Invoke("retencionFactura", new object[] {
                        idFactura,
                        correo});
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        public void retencionFacturaAsync(string idFactura, string correo) {
            this.retencionFacturaAsync(idFactura, correo, null);
        }
        
        /// <remarks/>
        public void retencionFacturaAsync(string idFactura, string correo, object userState) {
            if ((this.retencionFacturaOperationCompleted == null)) {
                this.retencionFacturaOperationCompleted = new System.Threading.SendOrPostCallback(this.OnretencionFacturaOperationCompleted);
            }
            this.InvokeAsync("retencionFactura", new object[] {
                        idFactura,
                        correo}, this.retencionFacturaOperationCompleted, userState);
        }
        
        private void OnretencionFacturaOperationCompleted(object arg) {
            if ((this.retencionFacturaCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.retencionFacturaCompleted(this, new retencionFacturaCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/procesarRetencionTXT", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Xml.XmlNode procesarRetencionTXT(string txt, string correo) {
            object[] results = this.Invoke("procesarRetencionTXT", new object[] {
                        txt,
                        correo});
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        public void procesarRetencionTXTAsync(string txt, string correo) {
            this.procesarRetencionTXTAsync(txt, correo, null);
        }
        
        /// <remarks/>
        public void procesarRetencionTXTAsync(string txt, string correo, object userState) {
            if ((this.procesarRetencionTXTOperationCompleted == null)) {
                this.procesarRetencionTXTOperationCompleted = new System.Threading.SendOrPostCallback(this.OnprocesarRetencionTXTOperationCompleted);
            }
            this.InvokeAsync("procesarRetencionTXT", new object[] {
                        txt,
                        correo}, this.procesarRetencionTXTOperationCompleted, userState);
        }
        
        private void OnprocesarRetencionTXTOperationCompleted(object arg) {
            if ((this.procesarRetencionTXTCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.procesarRetencionTXTCompleted(this, new procesarRetencionTXTCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/procesarRetencionArchivo", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Xml.XmlNode procesarRetencionArchivo(string fileName, string correo) {
            object[] results = this.Invoke("procesarRetencionArchivo", new object[] {
                        fileName,
                        correo});
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        public void procesarRetencionArchivoAsync(string fileName, string correo) {
            this.procesarRetencionArchivoAsync(fileName, correo, null);
        }
        
        /// <remarks/>
        public void procesarRetencionArchivoAsync(string fileName, string correo, object userState) {
            if ((this.procesarRetencionArchivoOperationCompleted == null)) {
                this.procesarRetencionArchivoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnprocesarRetencionArchivoOperationCompleted);
            }
            this.InvokeAsync("procesarRetencionArchivo", new object[] {
                        fileName,
                        correo}, this.procesarRetencionArchivoOperationCompleted, userState);
        }
        
        private void OnprocesarRetencionArchivoOperationCompleted(object arg) {
            if ((this.procesarRetencionArchivoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.procesarRetencionArchivoCompleted(this, new procesarRetencionArchivoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/cancelarRetencion", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool cancelarRetencion(string idFactura, string correo) {
            object[] results = this.Invoke("cancelarRetencion", new object[] {
                        idFactura,
                        correo});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void cancelarRetencionAsync(string idFactura, string correo) {
            this.cancelarRetencionAsync(idFactura, correo, null);
        }
        
        /// <remarks/>
        public void cancelarRetencionAsync(string idFactura, string correo, object userState) {
            if ((this.cancelarRetencionOperationCompleted == null)) {
                this.cancelarRetencionOperationCompleted = new System.Threading.SendOrPostCallback(this.OncancelarRetencionOperationCompleted);
            }
            this.InvokeAsync("cancelarRetencion", new object[] {
                        idFactura,
                        correo}, this.cancelarRetencionOperationCompleted, userState);
        }
        
        private void OncancelarRetencionOperationCompleted(object arg) {
            if ((this.cancelarRetencionCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.cancelarRetencionCompleted(this, new cancelarRetencionCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/obtenerMensajeError", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string obtenerMensajeError() {
            object[] results = this.Invoke("obtenerMensajeError", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void obtenerMensajeErrorAsync() {
            this.obtenerMensajeErrorAsync(null);
        }
        
        /// <remarks/>
        public void obtenerMensajeErrorAsync(object userState) {
            if ((this.obtenerMensajeErrorOperationCompleted == null)) {
                this.obtenerMensajeErrorOperationCompleted = new System.Threading.SendOrPostCallback(this.OnobtenerMensajeErrorOperationCompleted);
            }
            this.InvokeAsync("obtenerMensajeError", new object[0], this.obtenerMensajeErrorOperationCompleted, userState);
        }
        
        private void OnobtenerMensajeErrorOperationCompleted(object arg) {
            if ((this.obtenerMensajeErrorCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.obtenerMensajeErrorCompleted(this, new obtenerMensajeErrorCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void retencionFacturaCompletedEventHandler(object sender, retencionFacturaCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class retencionFacturaCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal retencionFacturaCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Xml.XmlNode Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Xml.XmlNode)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void procesarRetencionTXTCompletedEventHandler(object sender, procesarRetencionTXTCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class procesarRetencionTXTCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal procesarRetencionTXTCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Xml.XmlNode Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Xml.XmlNode)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void procesarRetencionArchivoCompletedEventHandler(object sender, procesarRetencionArchivoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class procesarRetencionArchivoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal procesarRetencionArchivoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Xml.XmlNode Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Xml.XmlNode)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void cancelarRetencionCompletedEventHandler(object sender, cancelarRetencionCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class cancelarRetencionCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal cancelarRetencionCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void obtenerMensajeErrorCompletedEventHandler(object sender, obtenerMensajeErrorCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class obtenerMensajeErrorCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal obtenerMensajeErrorCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591