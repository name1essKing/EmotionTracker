using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EmotionTracker.ui
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new(propertyName));
    }
}
