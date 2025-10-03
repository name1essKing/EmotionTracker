namespace EmotionTracker.Client.Views
{
    public sealed partial class MainWindowViewModel
    {
        public sealed class MainWindowViewModelCommands
        {
            public MainWindowViewModelCommands(MainWindowViewModel vm)
            {

            }
        }

        private MainWindowViewModelCommands _commands;

        public MainWindowViewModelCommands Commands => _commands ??= new(this);
    }
}
