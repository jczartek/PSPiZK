using System;
using System.ComponentModel;
using System.Windows.Threading;

namespace Clock.ViewModel
{
    class Clock : INotifyPropertyChanged
    {
        private const int refreshViewModelMs = 250;
        private readonly DateTime previousTime = DateTime.Now;
        public event PropertyChangedEventHandler PropertyChanged;

        public DateTime CurrentTime
        {
            get { return DateTime.Now; }
        }

        private void OnPropertyChanged()
        {
            if (CurrentTime - previousTime < TimeSpan.FromSeconds(1) && CurrentTime == previousTime)
                return;

            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("CurrentTime"));
        }

        public Clock()
        {
            DispatcherTimer dTimer = new DispatcherTimer();

            dTimer.Tick += (s, e) => { OnPropertyChanged(); };
            dTimer.Interval = TimeSpan.FromMilliseconds(refreshViewModelMs);
            dTimer.Start();
        }
    }
}
