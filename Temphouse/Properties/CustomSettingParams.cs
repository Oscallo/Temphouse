
namespace Temphouse.Properties
{
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase
    {
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValue("0")] /// = DatabaseConnectionTypeEnum.None
        public global::Temphouse.Enums.DatabaseConnectionTypeEnum DatabaseConnectionType
        {
            get
            {
                return ((global::Temphouse.Enums.DatabaseConnectionTypeEnum)(this["DatabaseConnectionType"]));
            }
            set
            {
                this["DatabaseConnectionType"] = value;
            }
        }
    }
}
