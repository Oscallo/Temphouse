using CoreLand.UI.Managers.Enumeration;
using CoreLand.UI.MVVM.ViewModels;
using System;
using Temphouse.DataAccess.Adapters.Subject;
using Temphouse.DataAccess.Enums;

namespace Temphouse.MVVM.ViewModels
{
    public class ApplicationInitializeViewModel : BaseViewModel
    {
        public DatabaseTypeEnum DatabaseType
        {
            get { return UserSettingsAdapter.Instance.DatabaseConnectionType; }
            set
            {
                if (value == UserSettingsAdapter.Instance.DatabaseConnectionType) { return; }
                OnPropertyChanging(nameof(DatabaseType));
                UserSettingsAdapter.Instance.DatabaseConnectionType = value;
                OnPropertyChanged(nameof(DatabaseType));
            }
        }

        public Array DatabaseTypes => EnumerationManager.GetValues(typeof(DatabaseTypeEnum));

        public bool IsDatabaseAlredyCreated 
        {
            get { return _IsDatabaseAlredyCreated; }
            set
            {
                if (value == _IsDatabaseAlredyCreated) { return; }
                OnPropertyChanging(nameof(DatabaseType));
                _IsDatabaseAlredyCreated = value;
                OnPropertyChanged(nameof(DatabaseType));
            }
        }

        private bool _IsDatabaseAlredyCreated = true;
    }
}
