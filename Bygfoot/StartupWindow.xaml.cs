namespace Bygfoot
{
    using System.ComponentModel;
    using Avalonia;
    using Avalonia.Controls;
    using Avalonia.Markup.Xaml;

    public class StartupWindow : Window
    {
        public StartupWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            DataContext = new StartupWindowViewModel();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }

    public class StartupWindowViewModel : INotifyPropertyChanged
    {
        public StartupWindowViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
