using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotePad.ViewModel
{
    using Model;
    class Editor : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        private Text text = new Text();
        public string Content
        {
            get { return text.Content; }
            set
            {
                text.Clear();
                text.Content = value;
                OnPropertyChanged(nameof(Content));
            }
        }
        public string PathFile { get; set; } = "[None]";
    }
}
