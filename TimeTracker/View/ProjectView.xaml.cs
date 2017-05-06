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
    /// Interaction logic for ProjectView.xaml
    /// </summary>
    public partial class ProjectView : Window
    {
        private TimeTrackerViewModel _vm;
        private System.Windows.Data.CollectionViewSource projectViewSource;

        public ProjectView()
        {
            InitializeComponent();
            _vm = (TimeTrackerViewModel) this.FindResource("viewModel");
            projectViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("projectViewSource")));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Load data by setting the CollectionViewSource.Source property:
            projectViewSource.Source = _vm.GetProjects(DateTime.Today);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            TimeTrackerMain main = new TimeTrackerMain();
            main.Show();
        }

    }
}
