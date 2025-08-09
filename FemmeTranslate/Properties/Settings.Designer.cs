namespace FemmeTranslate.Properties {
    [global::System.Runtime.CompilerServices.CompilerGenerated()]
    [global::System.CodeDom.Compiler.GeneratedCode("SettingsSingleFileGenerator", "1.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        public static Settings Default {
            get { return defaultInstance; }
        }
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("es")]
        public string DefaultLanguage {
            get { return ((string)(this["DefaultLanguage"])); }
            set { this["DefaultLanguage"] = value; }
        }
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool DarkTheme {
            get { return ((bool)(this["DarkTheme"])); }
            set { this["DarkTheme"] = value; }
        }
    }
}
