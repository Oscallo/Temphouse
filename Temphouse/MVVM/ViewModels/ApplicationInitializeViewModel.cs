using CoreLand.UI.Managers.Enumeration;
using CoreLand.UI.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
