using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Bygfoot.Avalonia
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
            base.Initialize();
        }

        public static void Run()
        {
            AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .Start<MainWindow>();
        }
    }
}
