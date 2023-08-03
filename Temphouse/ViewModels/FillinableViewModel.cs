using CoreLand.UI.MVVM.ViewModels;

namespace Temphouse.ViewModels
{
    public class FillinableViewModel : BaseViewModel
    {
        private bool _IsFillingFinished = false;

        public bool IsFillingFinished
        {
            get { return _IsFillingFinished; }
            set
            {
                if (value == _IsFillingFinished) { return; }
                OnPropertyChanging(nameof(IsFillingFinished));
                _IsFillingFinished = value;
                OnPropertyChanged(nameof(IsFillingFinished));
            }
        }
    }
}
