using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotePad.ViewModel
{
    using Model;
    using System.Windows.Input;

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

        private ICommand printCommand;
        public ICommand Print
        {
            get
            {
                if (printCommand == null)
                {
                    printCommand = new RelayCommand(
                        p => Printing.PrintText(text.ToString()),
                        p => !text.IsEmpty());
                }
                return printCommand;

            }
        }
    }
}
