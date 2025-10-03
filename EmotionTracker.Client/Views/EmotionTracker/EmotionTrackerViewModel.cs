using EmotionTracker.ui;
using ReactiveUI;
using System;
using System.Collections.Generic;

namespace EmotionTracker.Client.Views.EmotionTracker
{
    public sealed partial class EmotionTrackerViewModel : ReactiveViewModelBase
    {
        private bool _isEmotionSelected;

        // Флаг для отслеживания, выбрана ли эмоция
        public bool IsEmotionSelected
        {
            get => _isEmotionSelected;
            set => this.RaiseAndSetIfChanged(ref _isEmotionSelected, value);
        }

        private DateTime _selectedDate;
        // Выбранная дата
        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedDate, value);
                CheckEmotionForSelectedDate();
            }
        }

        private EmotionItem _currentEmotionForDate;
        // Текущая эмоция для выбранной даты
        public EmotionItem CurrentEmotionForDate
        {
            get => _currentEmotionForDate;
            set => this.RaiseAndSetIfChanged(ref _currentEmotionForDate, value);
        }

        // Словарь для хранения эмоций по датам
        public Dictionary<DateTime, EmotionItem> EmotionRecords { get; } = new();

        private EmotionItem _selectedEmotionRecord;
        // Выбранная эмоция (для UI)
        public EmotionItem SelectedEmotionRecord
        {
            get => _selectedEmotionRecord;
            set => this.RaiseAndSetIfChanged(ref _selectedEmotionRecord, value);
        }
        // Конструктор
        public EmotionTrackerViewModel()
        {
            SelectedDate = DateTime.Today;
            CheckEmotionForSelectedDate();
        }
        // Метод для проверки и обновления эмоции для выбранной даты
        public void CheckEmotionForSelectedDate()
        {
            if (SelectedDate == default)
            {
                CurrentEmotionForDate = new EmotionItem(EmotionEnum.None);
                return;
            }

            EmotionRecords.TryGetValue(SelectedDate.Date, out var emotion);
            CurrentEmotionForDate = emotion ?? new EmotionItem(EmotionEnum.None);
        }
        // Методы для выбора эмоций
        public void SelectHappy()
        {
            if (SelectedDate == default) return;

            var happyItem = new EmotionItem(EmotionEnum.Happy);
            EmotionRecords[SelectedDate.Date] = happyItem;
            CurrentEmotionForDate = happyItem;
        }
        // Метод для выбора нейтральной эмоции
        public void SelectNeutral()
        {
            if (SelectedDate == default) return;

            var neutralItem = new EmotionItem(EmotionEnum.Neutral);
            EmotionRecords[SelectedDate.Date] = neutralItem;
            CurrentEmotionForDate = neutralItem;
        }
        // Метод для выбора грустной эмоции
        public void SelectSad()
        {
            if (SelectedDate == default) return;

            var sadItem = new EmotionItem(EmotionEnum.Sad);
            EmotionRecords[SelectedDate.Date] = sadItem;
            CurrentEmotionForDate = sadItem;
        }
        // Метод для очистки эмоции
        public void ClearEmotion()
        {
            if (SelectedDate == default) return;

            var noneEmotion = new EmotionItem(EmotionEnum.None);
            EmotionRecords[SelectedDate.Date] = noneEmotion;
            CurrentEmotionForDate = noneEmotion;
        }
    }
}