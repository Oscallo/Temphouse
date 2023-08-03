using Temphouse.DataAccess.Adapters.Subject;
using Temphouse.DataAccess.Enums;

namespace Temphouse.MVVM.ViewModels
{
    public class DataBaseInformationViewModel : FillinableViewModel
    {
        private DatabaseTypeEnum _DatabaseType = UserSettingsAdapter.Instance.DatabaseConnectionType;

        public DatabaseTypeEnum DatabaseType
        {
            get { return _DatabaseType; }
            set
            {
                if (value == _DatabaseType) { return; }
                OnPropertyChanging(nameof(DatabaseType));
                _DatabaseType = value;
                OnPropertyChanged(nameof(DatabaseType));
            }
        }
    }
}
