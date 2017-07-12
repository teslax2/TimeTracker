using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TimeTracker.View
{
    /// <summary>
    /// Interaction logic for UserLogin.xaml
    /// </summary>
    public partial class UserLogin : UserControl
    {
        public UserLogin()
        {
            InitializeComponent();
        }


        public string LoginName
        {
            get { return (string)GetValue(LoginNameProperty); }
            set { SetValue(LoginNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LoginName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoginNameProperty =
            DependencyProperty.Register("LoginName", typeof(string), typeof(UserLogin), new PropertyMetadata(null));



        public ICommand LoginButton
        {
            get { return (ICommand)GetValue(LoginButtonProperty); }
            set { SetValue(LoginButtonProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LoginButton.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoginButtonProperty =
            DependencyProperty.Register("LoginButton", typeof(ICommand), typeof(UserLogin), new PropertyMetadata(null));

        private void LoginPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                LoginButton.Execute(this.LoginPassword);
        }
    }
}
