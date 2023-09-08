using CoreLand.UI.Managers.Enumeration;
using CoreLand.UI.MVVM.ViewModels;
using System;
using Temphouse.DataAccess.Adapters.Subject;
using Temphouse.DataAccess.Enums;
using Temphouse.MVVM.Models;

namespace Temphouse.MVVM.ViewModels
{
    public class ApplicationInitializeViewModel : BaseViewModel
    {
        private bool _IsDatabaseAlredyCreated = false;
        private UserModel _AdministratorData = new UserModel();

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

        public UserModel AdministratorData 
        {
            get { return _AdministratorData; }
            set
            {
                SetValue(ref _AdministratorData, value);
            }
        }
    }
}
