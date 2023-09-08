using CoreLand.UI.MVVM.ViewModels;

namespace Temphouse.MVVM.ViewModels
{
    public class FillinableViewModel : BaseViewModel
    {
        private bool _IsFillingFinished = false;

        public bool IsFillingFinished
        {
            get { return _IsFillingFinished; }
            set
            {
                SetValue(ref _IsFillingFinished, value);
            }
        }
    }
}
