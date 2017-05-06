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
    class TimeTrackerViewModel : INotifyPropertyChanged
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
        public ObservableCollection<string> ProjectNumbers { get; set; }
        public ObservableCollection<string> ProjectNames { get; set; }

        private TimeTrackerModel _model = new TimeTrackerModel();

        public TimeTrackerViewModel()
        {
            ProjectNumbers = new ObservableCollection<string>();
            ProjectNames = new ObservableCollection<string>();
            GetProjectNumbers();
            GetProjectNames();
        }

        private void GetProjectNumbers()
        {
            var projectNumbers = _model.GetProjectNumbers();

            foreach(var element in projectNumbers)
            {
                ProjectNumbers.Add(element);
            }
        }

        public void GetProjectNames(string name = "")
        {
            ProjectNames.Clear();

            var projectNames = _model.GetProjectNames(name);

            foreach(var element in projectNames)
            {
                ProjectNames.Add(element);
            }
        }

        public List<Project> GetProjects(DateTime? day)
        {
            return _model.GetProjects(day);
        }
    }
}
