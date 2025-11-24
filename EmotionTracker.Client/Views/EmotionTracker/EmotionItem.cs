using EmotionTracker.ui;
using ReactiveUI;

namespace EmotionTracker.Client.Views.EmotionTracker
{
    // Класс для представления элемента эмоции
    public class EmotionItem : ReactiveViewModelBase
    {
        private EmotionEnum _selectedEmotion;
        private DateTime _dateTime;

        public EmotionEnum SelectedEmotion
        {
            get => _selectedEmotion;
            set => this.RaiseAndSetIfChanged(ref _selectedEmotion, value);
        }

        public DateTime DateTime
        {
            get => _dateTime;
            set => this.RaiseAndSetIfChanged(ref _dateTime, value);
        }

        public EmotionItem(DateTime dateTime, EmotionEnum emotion = EmotionEnum.None)
        {
            DateTime = dateTime;
            SelectedEmotion = emotion;
        }
    }
}
