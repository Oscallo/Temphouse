using System.ComponentModel;

namespace Temphouse.Properties {
    
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {

        protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Save();
            base.OnPropertyChanged(sender, e);
        }
    }
}
