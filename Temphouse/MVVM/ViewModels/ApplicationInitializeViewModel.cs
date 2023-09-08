using CoreLand.UI.Managers.Enumeration;
using CoreLand.UI.MVVM.ViewModels;
using System;
using Temphouse.DataAccess.Adapters.Subject;
using Temphouse.DataAccess.Enums;

namespace Temphouse.MVVM.ViewModels
{
    public class ApplicationInitializeViewModel : BaseViewModel
    {
        private bool _IsDatabaseAlredyCreated = false;
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
                SetValue(ref _IsDatabaseAlredyCreated, value);
            }
        }

        private bool _IsDatabaseAlredyCreated = false;
    }
}
