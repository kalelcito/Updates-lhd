﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Control.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=DATAEXPRESS\\DATASQL;Initial Catalog=recepcion_DHL;User ID=sa;Password" +
            "=123456")]
        public string dataexpressConnectionString {
            get {
                return ((string)(this["dataexpressConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=DATAEXPRESS\\DATASQL;Initial Catalog=recepcion_DHL;Persist Security In" +
            "fo=True;User ID=sa;Password=123456")]
        public string dataexpressConnectionString1 {
            get {
                return ((string)(this["dataexpressConnectionString1"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=DATAEXPRESS\\DATASQL;Initial Catalog=recepcion_DHL;Persist Security In" +
            "fo=True;User ID=sa;Password=123456")]
        public string recepcionConnectionString {
            get {
                return ((string)(this["recepcionConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=DATAEXPRESS\\DATASQL;Initial Catalog=recepcion_DHL;User ID=sa;Password" +
            "=123456")]
        public string DHLRecepcionConnectionString {
            get {
                return ((string)(this["DHLRecepcionConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=DATAEXPRESS\\DATASQL;Initial Catalog=Recepcion_DHL_pruebas;Persist Sec" +
            "urity Info=True;User ID=sa")]
        public string Recepcion_DHL_pruebasConnectionString {
            get {
                return ((string)(this["Recepcion_DHL_pruebasConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=DATAEXPRESS\\DATASQL;Initial Catalog=recepcion_DHL;Persist Security In" +
            "fo=True;User ID=sa;Password=123456;Connect Timeout=2000000000")]
        public string recepcion_DHLConnectionString {
            get {
                return ((string)(this["recepcion_DHLConnectionString"]));
            }
        }
    }
}
