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
using System.Windows.Shapes;
using TimeTracker.ViewModel;

namespace TimeTracker.View
{
    /// <summary>
    /// Interaction logic for TimeTrackerMain.xaml
    /// </summary>
    public partial class TimeTrackerMain : Window
    {
        //TimeTrackerViewModel viewModel;

        public TimeTrackerMain()
        {

            InitializeComponent();
            //viewModel = this.FindResource("timeTrackerViewModel") as TimeTrackerViewModel;
            //this.DataContext = viewModel;
        }

        private void ProjectViewButton_Click(object sender, RoutedEventArgs e)
        {
            var project = new ProjectView();
            project.Show();
            this.Close();
        }
    }
}
