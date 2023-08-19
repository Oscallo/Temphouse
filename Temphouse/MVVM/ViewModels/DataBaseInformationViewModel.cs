using CoreLand.UI.Managers.Enumeration;
using CoreLand.UI.Reporters.Information;
using System;
using Temphouse.DataAccess.Adapters.Subject;
using Temphouse.DataAccess.Enums;

namespace Temphouse.MVVM.ViewModels
{
    public class DataBaseInformationViewModel : FillinableViewModel
    {
        public DatabaseTypeEnum DatabaseType
        {
            get { return UserSettingsAdapter.Instance.DatabaseConnectionType; }
            set
            {
                if (value == UserSettingsAdapter.Instance.DatabaseConnectionType) { return; }

                OnPropertyChanging(nameof(DatabaseType));
                OnPropertyChanging(nameof(TabControlIndex));

                UserSettingsAdapter.Instance.DatabaseConnectionType = value;

                OnPropertyChanged(nameof(DatabaseType));
                OnPropertyChanged(nameof(TabControlIndex));
            }
        }

        private string _FilePath  = InformationReporter.ApplicationFolder;

        public string FilePath
        {
            get { return _FilePath; }
            set
            {
                if (value == _FilePath) { return; }
                OnPropertyChanging(nameof(FilePath));
                _FilePath = value;
                OnPropertyChanged(nameof(FilePath));
            }
        }

        public int TabControlIndex => (int)DatabaseType;

        public Array DatabaseTypes => EnumerationManager.GetValues(typeof(DatabaseTypeEnum));
    }
}
