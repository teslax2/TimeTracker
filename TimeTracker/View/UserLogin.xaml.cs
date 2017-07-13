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



        public string LoginProperty
        {   
            get { return (string)GetValue(LoginPropertyProperty); }
            set { SetValue(LoginPropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LoginProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoginPropertyProperty =
            DependencyProperty.Register("LoginProperty", typeof(string), typeof(UserLogin), new PropertyMetadata(String.Empty));



        public ICommand CommandProperty
        {
            get { return (ICommand)GetValue(CommandPropertyProperty); }
            set { SetValue(CommandPropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CommandProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandPropertyProperty =
            DependencyProperty.Register("CommandProperty", typeof(ICommand), typeof(UserLogin), new PropertyMetadata(null));

        private void Password_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Enter)
                CommandProperty.Execute(this.Password);
        }
    }
}
