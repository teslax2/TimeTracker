using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        TimeTrackerViewModel viewModel;

        public ProjectView()
        {
            InitializeComponent();
            viewModel = this.FindResource("viewModel") as TimeTrackerViewModel;
            this.DataContext = viewModel;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            TimeTrackerMain main = new TimeTrackerMain();
            main.Show();
            viewModel.Dispose();
        }

        private void projectDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            var dataGrid = sender as DataGrid;
            viewModel.RowEditEnding(dataGrid, e);
        }

        private void ComboBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            viewModel.ComboboxTextChanged(comboBox.Text);
        }

        private void projectDataGrid_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {

        }
    }
}
