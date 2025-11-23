using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Xaml.Interactivity;
using DynamicData;
using EmotionTracker.Client.Views.EmotionTracker;
using EmotionTracker.UI.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmotionTracker.Client.Behaviors
{
    public class CalendarDayStateUpdateBehavior : Behavior<Border>
    {
        private List<IDisposable> _disposables = new List<IDisposable>();
        private DateTime _itemDay;
        
        public static readonly StyledProperty<SourceCache<EmotionItem, DateTime>> RecordedEmotionsProperty =
            AvaloniaProperty.Register<Control, SourceCache<EmotionItem, DateTime>>(nameof(RecordedEmotions),
                 defaultBindingMode: Avalonia.Data.BindingMode.OneTime);

        public static readonly StyledProperty<DateTime> ItemDayProperty =
            AvaloniaProperty.Register<Control, DateTime>(nameof(ItemDay));

        /// <summary>
        /// Список эмоций из VM.
        /// </summary>
        public SourceCache<EmotionItem, DateTime> RecordedEmotions
        {
            get => GetValue(RecordedEmotionsProperty);
            set => SetValue(RecordedEmotionsProperty, value);
        }

        /// <summary>
        /// DateTime, который лежит в CalendarDay
        /// </summary>
        public DateTime ItemDay
        {
            get => GetValue(ItemDayProperty);
            set => SetValue(ItemDayProperty, value); 
        }

        protected override void OnAttached()
        {
            if(AssociatedObject is null) return; 
        } 
        protected override void OnDetaching()
        {
            if(AssociatedObject is null) return;

            _disposables.DisposeAll();
        }

        protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
        {
            if(change.Property == RecordedEmotionsProperty)
            {
                RecordedEmotions?
                    .Connect()
                    .Do(x => SetCurrentEmotionItem())
                    .Subscribe()
                    .AddTo(_disposables);
            }
            if(change.Property == ItemDayProperty)
            {
                SetCurrentEmotionItem();
            }

            base.OnPropertyChanged(change);
        }  

        private void SetCurrentEmotionItem()
        {  
            if(RecordedEmotions != null)
            { 
                var lookingEmotionItemByData = RecordedEmotions.Lookup(ItemDay);
                if(lookingEmotionItemByData.HasValue)
                {
                    SetClasses(lookingEmotionItemByData.Value.SelectedEmotion);
                }
                else
                {
                    SetClasses(EmotionEnum.None);
                }
            } 
        }

        private void SetClasses(EmotionEnum emotionEnum)
        {
            AssociatedObject.Classes.Remove("none");
            AssociatedObject.Classes.Remove("happy");
            AssociatedObject.Classes.Remove("neutral");
            AssociatedObject.Classes.Remove("sad");

            switch(emotionEnum)
            {
                case EmotionEnum.None:
                    AssociatedObject.Classes.Add("none"); 
                    break;
                case EmotionEnum.Happy:
                    AssociatedObject.Classes.Add("happy"); 
                    break;
                case EmotionEnum.Neutral:
                    AssociatedObject.Classes.Add("neutral");
                    break;
                case EmotionEnum.Sad:
                    AssociatedObject.Classes.Add("sad"); 
                    break;
            }
        }
    }
}
