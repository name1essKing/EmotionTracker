using ReactiveUI;
using System.Windows.Input;


namespace EmotionTracker.Client.Views.EmotionTracker
{
    public sealed partial class EmotionTrackerViewModel
    {
        public sealed class EmotionTrackerViewModelCommands
        {

            
            
            public EmotionTrackerViewModelCommands(EmotionTrackerViewModel vm)
            {
                // Команды для выбора даты
                SelectDateCommand = ReactiveCommand.Create<DateTime>(date =>
                {
                    vm.SelectedDate = date; 
                    vm.CheckEmotionForSelectedDate();
                    vm.SelectedEmotionRecord = vm.CurrentEmotionForDate; // Обновляем выбранную эмоцию в UI

                });


                SelectHappy = ReactiveCommand.Create(() =>
                {
                    vm.SelectHappy();
                });

                SelectNeutral = ReactiveCommand.Create(() =>
                {
                    vm.SelectNeutral();
                });

                SelectSad = ReactiveCommand.Create(() =>
                {
                    vm.SelectSad();
                });

                ClearEmotion = ReactiveCommand.Create(() =>
                {
                    vm.ClearEmotion();
                });

            }
            public ICommand SelectDateCommand { get; }
            public ICommand SelectHappy { get; }
            public ICommand SelectNeutral { get; }
            public ICommand SelectSad { get; }
            public ICommand ClearEmotion { get; }
        }
        
        private EmotionTrackerViewModelCommands _commands;

        public EmotionTrackerViewModelCommands Commands => _commands ??= new(this);
    }
}
