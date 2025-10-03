using Autofac;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using EmotionTracker.client.Services;
using EmotionTracker.Client.Views;

namespace EmotionTracker.Client
{
    public partial class App : Application
    {
        private IContainer? _container;

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            _container = RegistrationService.CreateContainer();

            var mainWindow = GetMainWindow(_container);

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = mainWindow;
            }

            mainWindow.Closed += OnMainWindowClosed;
            mainWindow.Show();
            mainWindow.Activate();

            base.OnFrameworkInitializationCompleted();
        }

        private MainWindowView GetMainWindow(IContainer container)
        {
            var mainWindow = container.Resolve<MainWindowView>();
            mainWindow.DataContext = container.Resolve<MainWindowViewModel>();

            return mainWindow;
        }

        private async void OnMainWindowClosed(object? sender, System.EventArgs e)
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.Shutdown(0);
            }
        }
    }
}