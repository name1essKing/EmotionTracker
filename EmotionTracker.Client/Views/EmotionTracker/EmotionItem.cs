using EmotionTracker.ui;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmotionTracker.Client.Views.EmotionTracker
{
    // Класс для представления элемента эмоции
    public class EmotionItem : ReactiveViewModelBase
    {
        private EmotionEnum _selectedEmotion;
        public EmotionEnum SelectedEmotion
        {
            get => _selectedEmotion;
            set => this.RaiseAndSetIfChanged(ref _selectedEmotion, value);
        }

        public EmotionItem(EmotionEnum emotion)
        {
           
            SelectedEmotion = emotion;

        }
    }
}
