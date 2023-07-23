using System;
using System.Collections.Generic;
using System.Linq;
using Temphouse.Enums;
using Temphouse.Modules.Adapters;

namespace Temphouse.ViewModels
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

        public IEnumerable<DatabaseTypeEnum> DatabaseTypes
        {
            get
            {
                return Enum.GetValues(typeof(DatabaseTypeEnum)).Cast<DatabaseTypeEnum>();
            }
        }
    }
}
