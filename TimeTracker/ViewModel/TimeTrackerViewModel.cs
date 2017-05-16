using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

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
        public ObservableCollection<string> NumberList { get { return _numberList; } set { _numberList = value; System.Diagnostics.Debug.WriteLine(value.Count); } }
        private ObservableCollection<string> _filteredList = new ObservableCollection<string>();
        public ObservableCollection<string> FilteredList { get { return _filteredList; } set { _filteredList = value; } }

        private List<Project> _projectsToAdd = new List<Project>();
        private List<Project> _projectsToDelete = new List<Project>();

        private DateTime _selectedDate = DateTime.Today;
        public DateTime SelectedDate { get { return _selectedDate; } set { _selectedDate = value; OnPropertyChanged("SelectedDate"); GetSpecificData(value); } }
        private Project _selectedItem = new Project();
        public Project SelectedItem { get { return _selectedItem; } set { _selectedItem = value; } }

        public CommandHandler SaveCommand { get { return new CommandHandler(() => HandleCommand(CommandTypes.Commit), true); } }
        public CommandHandler DeleteCommand { get { return new CommandHandler(() => HandleCommand(CommandTypes.Delete), true); } }

        public TimeTrackerViewModel() : base() { }

        protected override void GetData()
        {
            GetSpecificData(DateTime.Today);
        }

        private void GetSpecificData(DateTime value)
        {
            var allProjects = _ctx.Projects.ToList();
            var projNumbers = allProjects.Select(s => s.Number).Distinct().ToList();
            var projNames = allProjects.Select(s => s.Name).Distinct().ToList();
            var projects = allProjects.Where(c => c.Calendar.Date == value.Date).ToList();
            var proj = new ObservableCollection<Project>();
            var projList = new ObservableCollection<string>();
            var numList = new ObservableCollection<string>();

            foreach (var element in projNumbers)
            {
                numList.Add(element);
            }

            foreach (var element in projNames)
            {
                projList.Add(element);
            }

            foreach (var element in projects)
            {
                proj.Add(element);
            }
            Projects = proj;
            ProjectList = projList;
            FilteredList = projList;
            NumberList = numList;
            OnPropertyChanged("Projects");
            OnPropertyChanged("ProjectList");
            OnPropertyChanged("FilteredList");
            OnPropertyChanged("NumberList");
        }

        public void RowEditEnding(DataGrid dataGrid, DataGridRowEditEndingEventArgs e)
        {
            try
            {
                var entity = (Project)e.Row.Item;

                if (_ctx.Projects.Any(s => s.Id == entity.Id))
                    return;
                if (!_ctx.Calendars.Any(s => s.Id == entity.CalendarId))
                {
                    entity.Calendar = new Calendar() { Date = _selectedDate, EmployeeId = 1 };
                    _projectsToAdd.Add(entity);
                }

            }
            catch (InvalidCastException ex)
            {
                System.Diagnostics.Debug.WriteLine("Cast exception in RwoEditEnding" + ex.Message);
            }

        }


        internal void ComboboxTextChanged(string text)
        {
            if (text.Length < 2)
            {
                FilteredList = ProjectList;
                OnPropertyChanged("FilteredList");
            }
            else
            {
                var filtered = (from element in ProjectList
                                where element.Contains(text)
                                select element).ToList();
                var fillteredCollection = new ObservableCollection<string>();
                foreach(var element in filtered)
                {
                    fillteredCollection.Add(element);
                }
                FilteredList = fillteredCollection;
                OnPropertyChanged("FilteredList");
            }

        }

        protected override void CommitUpdates()
        {
            try
            {
                if (_projectsToAdd.Count > 0)
                {
                    foreach (var entity in _projectsToAdd)
                    {
                        _ctx.Projects.Add(entity);
                    }
                    _projectsToAdd.Clear();
                }
                if (_projectsToDelete.Count > 0)
                {
                    foreach (var entity in _projectsToDelete)
                    {
                        _ctx.Projects.Remove(entity);
                    }
                    _projectsToDelete.Clear();
                }
                _ctx.SaveChanges();
            }
            catch(InvalidOperationException ex)
            {
                System.Diagnostics.Debug.WriteLine("Invalid Operation Exception" + ex.Message);
            }

        }

        protected override void Delete()
        {
            if (SelectedItem == null)
                return;

            _projectsToDelete.Add(SelectedItem);
            Projects.Remove(SelectedItem);
            OnPropertyChanged("Projects");
        }
    }
}
