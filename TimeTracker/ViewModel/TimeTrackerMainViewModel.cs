using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Security.Cryptography;

namespace TimeTracker.ViewModel
{
    class TimeTrackerMainViewModel : TimeTrackerBase,INotifyPropertyChanged
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
        private string _userName;
        public String UserName { get { return _userName; } set { _userName = value; OnPropertyChanged("LoginName"); } }

        public CommandHandler SubmitCommand { get { return new CommandHandler(s => CheckPass(s), true); } }

        private void CheckPass(object password)
        {
            addUsers();
            var userData = _ctx.Creditential.Where(x => x.Email == UserName).SingleOrDefault();
            var passwordBox = password as PasswordBox;

            if (userData == null)
                return;

            if (userData.Password==hashPassword(passwordBox.Password) && userData.Email==UserName)
            {
                _userLogged = true;
                OnPropertyChanged("ButtonVisibility");
                passwordBox.Password = ""; 
            }
            else
            {
                _userLogged = false;
                OnPropertyChanged("ButtonVisibility");
                passwordBox.Password = "";
            }
        }

        public TimeTrackerMainViewModel()
        {
            _userLogged = false;
            OnPropertyChanged("ButtonVisibility");
        }

        private string hashPassword(string pass)
        {
            SHA256 crypt = new SHA256Managed();
            var hash = string.Empty;
            byte[] hashedPass = crypt.ComputeHash(Encoding.UTF8.GetBytes(pass),0,Encoding.UTF8.GetByteCount(pass));
            foreach(byte element in hashedPass)
            {
                hash += element;
            }
            return hash;
        }

        private void addUsers()
        {
            if (_ctx.Creditential.Count() == 0)
            {
                _ctx.Creditential.Add(new Creditential() { Email = "dupa@dupa.pl", Password = hashPassword("dupa")});
                _ctx.Creditential.Add(new Creditential() { Email = "pupa@dupa.pl", Password = hashPassword("pupa")});
                _ctx.SaveChanges();
            }

        }
    }

}
