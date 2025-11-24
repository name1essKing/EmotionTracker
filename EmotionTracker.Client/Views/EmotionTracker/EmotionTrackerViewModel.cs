using DynamicData;
using EmotionTracker.ui;
using ReactiveUI;
using System;
using System.Collections.Generic;

namespace EmotionTracker.Client.Views.EmotionTracker
{
    public sealed partial class EmotionTrackerViewModel : ReactiveViewModelBase
    {
        private readonly SourceCache<EmotionItem, DateTime> _emotionRecords = new(x => x.DateTime);

        private bool _isEmotionSelected;

        private DateTime _selectedDate;

        private EmotionItem _currentEmotionForDate;

        private EmotionItem _selectedEmotionRecord;



        public SourceCache<EmotionItem, DateTime> EmotionRecords => _emotionRecords;

        /// <summary>
        /// Флаг для отслеживания, выбрана ли эмоция
        /// </summary>
        public bool IsEmotionSelected
        {
            get => _isEmotionSelected;
            set => this.RaiseAndSetIfChanged(ref _isEmotionSelected, value);
        }
        
        /// <summary>
        /// Выбранная дата
        /// </summary>
        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedDate, value);
            }
        }
        
        /// <summary>
        /// Текущая эмоция для выбранной даты
        /// </summary>
        public EmotionItem CurrentEmotionForDate
        {
            get => _currentEmotionForDate;
            set => this.RaiseAndSetIfChanged(ref _currentEmotionForDate, value);
        }
        
        /// <summary>
        ///  Выбранная эмоция (для UI)
        /// </summary>
        public EmotionItem SelectedEmotionRecord
        {
            get => _selectedEmotionRecord;
            set => this.RaiseAndSetIfChanged(ref _selectedEmotionRecord, value);
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public EmotionTrackerViewModel()
        {
            SelectedDate = DateTime.Today;
        }

        /// <summary>
        /// Метод для проверки и обновления эмоции для выбранной даты
        /// </summary>
        public void CheckEmotionForSelectedDate()
        {
            if (SelectedDate == default)
            {
                return;
            }

            var emotion = EmotionRecords.Lookup(SelectedDate.Date).Value;
        }

        /// <summary>
        /// Метод для выбора счастливой эмоции
        /// </summary>
        public void SelectHappy()
        {
            if (SelectedDate == default) return;

            var item = EmotionRecords.Lookup(SelectedDate.Date);
            var emotion = EmotionEnum.Happy;
            if (!item.HasValue)
            {
                EmotionRecords.AddOrUpdate(new EmotionItem(SelectedDate.Date, emotion));
            }
            else
            {
                EmotionRecords.Lookup(SelectedDate.Date).Value.SelectedEmotion = emotion;
            }
        }

        /// <summary>
        /// Метод для выбора нейтральной эмоции
        /// </summary>
        public void SelectNeutral()
        {
            if (SelectedDate == default) return;

            var item = EmotionRecords.Lookup(SelectedDate.Date);
            var emotion = EmotionEnum.Neutral;
            if (!item.HasValue)
            {
                EmotionRecords.AddOrUpdate(new EmotionItem(SelectedDate.Date, emotion));
            }
            else
            {
                EmotionRecords.Lookup(SelectedDate.Date).Value.SelectedEmotion = emotion;
            }
        }

        /// <summary>
        /// Метод для выбора грустной эмоции
        /// </summary>
        public void SelectSad()
        {
            if (SelectedDate == default) return;

            var item = EmotionRecords.Lookup(SelectedDate.Date);
            var emotion = EmotionEnum.Sad;
            if (!item.HasValue)
            {
                EmotionRecords.AddOrUpdate(new EmotionItem(SelectedDate.Date, emotion));
            }
            else
            {
                EmotionRecords.Lookup(SelectedDate.Date).Value.SelectedEmotion = emotion;
            }
        }

        /// <summary>
        /// Метод для очистки эмоции
        /// </summary>
        public void ClearEmotion()
        {
            if (SelectedDate == default) return;

            var item = EmotionRecords.Lookup(SelectedDate.Date);
            var emotion = EmotionEnum.None;
            if (!item.HasValue)
            {
                EmotionRecords.AddOrUpdate(new EmotionItem(SelectedDate.Date, emotion));
            }
            else
            {
                EmotionRecords.Lookup(SelectedDate.Date).Value.SelectedEmotion = emotion;
            }
        }
    }
}