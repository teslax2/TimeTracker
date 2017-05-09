using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Model;

namespace TimeTracker.ViewModel
{
    class TimeTrackerViewModel : TimeTrackerBase,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string property)
        {
            PropertyChangedEventHandler propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        public ObservableCollection<Project> Projects { get; set; }
        public ObservableCollection<string> ProjectList { get; set; }


        public CommandHandler SaveCommand { get { return new CommandHandler(() => HandleCommand(CommandTypes.Update), true); } }

        public TimeTrackerViewModel():base()
        {
            GetData();
        }

        protected override void GetData()
        {
            ObservableCollection<Project> proj = _ctx.Projects.Local;
            Projects = proj;
        }

    }
}
