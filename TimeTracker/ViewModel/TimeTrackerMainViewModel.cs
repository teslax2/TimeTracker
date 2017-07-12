using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TimeTracker.ViewModel
{
    class TimeTrackerMainViewModel : INotifyPropertyChanged
    {
#region propertychanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            PropertyChangedEventHandler propertyChanged = PropertyChanged;
            if (propertyChanged != null)
                propertyChanged(this, new PropertyChangedEventArgs(property));
        }
        #endregion
        private bool _userLogged = false;
        public Visibility ButtonVisibility { get { return _userLogged?Visibility.Visible:Visibility.Hidden; } }
        private string _login;
        public String Login { get { return _login; } set { _login = value; } }

        public CommandHandler SubmitCommand { get { return new CommandHandler((s) => SubmitComm(s), true); } }

        private void SubmitComm(object password)
        {
            var pass = password as string;
            if (pass == "dupa" && Login=="dupa")
            {
                _userLogged = true;
            }
            else
                _userLogged = false;
        }

        public TimeTrackerMainViewModel()
        {
            _userLogged = false;
            OnPropertyChanged("ButtonVisibility");
        }
    }

}
