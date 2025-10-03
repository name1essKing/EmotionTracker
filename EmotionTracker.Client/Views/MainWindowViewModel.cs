using EmotionTracker.ui;
using EmotionTracker.Client.Views.EmotionTracker;

namespace EmotionTracker.Client.Views
{
    public sealed partial class MainWindowViewModel : ReactiveViewModelBase
    {
        public EmotionTrackerViewModel EmotionTrackerViewModel { get; }

        public MainWindowViewModel()
        {
            EmotionTrackerViewModel = new EmotionTrackerViewModel();
        }
    }
}
