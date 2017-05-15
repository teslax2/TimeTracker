using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.ViewModel
{
    class TimeTrackerViewModel : TimeTrackerBase,INotifyPropertyChanged
    {
#region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string property)
        {
            PropertyChangedEventHandler propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
#endregion
        private ObservableCollection<Project> _projects = new ObservableCollection<Project>();
        public ObservableCollection<Project> Projects { get { return _projects; } set { _projects = value;} }
        private ObservableCollection<string> _projectList = new ObservableCollection<string>();
        public ObservableCollection<string> ProjectList { get { return _projectList; } set { _projectList = value; } }
        private ObservableCollection<string> _numberList = new ObservableCollection<string>();
        public ObservableCollection<string> NumberList { get { return _projectList; } set { _projectList = value; } }

        private DateTime _selectedDate = DateTime.Today;
        public DateTime SelectedDate { get { return _selectedDate; } set { _selectedDate = value; OnPropertyChanged("SelectedDate"); GetSpecificData(value); } }

        public CommandHandler SaveCommand { get { return new CommandHandler(() => HandleCommand(CommandTypes.Commit), true); } }

        public TimeTrackerViewModel() : base() { }

        protected override void GetData()
        {
            GetSpecificData(DateTime.Today);
        }

        private void GetSpecificData(DateTime value)
        {
            var allProjects = _ctx.Projects.ToList();
            var projects = allProjects.Where(c => c.Calendar.Date == value.Date).ToList();
            var proj = new ObservableCollection<Project>();
            var projList = new ObservableCollection<string>();
            var numList = new ObservableCollection<string>();

            foreach (var element in allProjects)
            {
                projList.Add(element.Name);
                numList.Add(element.Number);
            }

            foreach(var element in projects)
            {
                proj.Add(element);
            }
            Projects = proj;
            ProjectList = projList;
            NumberList = numList;
            OnPropertyChanged("Projects");
            OnPropertyChanged("ProjectList");
            OnPropertyChanged("NumberList");
        }

        protected override void CommitUpdates()
        {
            _ctx.SaveChanges();
        }

    }
}
