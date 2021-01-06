namespace Bygfoot.ViewModels
{
    using System.ComponentModel;

    public class StartupWindowViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public StartupWindowViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}