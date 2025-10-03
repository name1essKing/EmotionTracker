using Autofac;
using EmotionTracker.Client;
using EmotionTracker.Client.Views;

namespace EmotionTracker.client.Modules
{
    internal class ViewModelsModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<MainWindowView>()
                .AsSelf()
                .SingleInstance();
            builder
                .RegisterType<MainWindowViewModel>()
                .AsSelf()
                .SingleInstance();
        }
    }
}
