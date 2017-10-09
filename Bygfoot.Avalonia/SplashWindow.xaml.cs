using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Bygfoot.Avalonia
{
    public class SplashWindow : Window
    {
        public SplashWindow()
        {
            this.InitializeComponent();
            this.AttachDevTools();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
