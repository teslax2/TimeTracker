using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.Model
{
    class TimeTrackerModel : INotifyPropertyChanged
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
        
        public TimeTrackerModel()
        {
            using(var ctx = new TimeTrackerDataContext())
            {
                if (ctx.Employees == null)
                    SeedDb(ctx);
            }
        }

        private void SeedDb(TimeTrackerDataContext ctx)
        {
            var employee = new Employee()
            {
                Id = 1,
                FirstName = "Wieslaw",
                Surname = "Urban",
                Role = Roles.Engineer,
                Calendar = new List<Calendar>() { new Calendar() { EmployeeId = 1, Id = 1, Date = DateTime.Today } }
            };

            var employee2 = new Employee()
            {
                Id = 2,
                FirstName = "Ewelina",
                Surname = "Urban",
                Role = Roles.Manager,
                Calendar = new List<Calendar>() { new Calendar() { EmployeeId = 2, Id = 2, Date = DateTime.Today } }
            };

            var project = new Project()
            {
                Id = 1,
                Name = "Dupa",
                Number = "PD892",
                Description = "Projekt z dupki",
                CalendarId = 1
            };

            var project2 = new Project()
            {
                Id = 2,
                Name = "Cipa",
                Number = "PD894",
                Description = "Projekt z pipki",
                CalendarId = 2
            };

            ctx.Employees.Add(employee);
            ctx.Employees.Add(employee2);
            ctx.Projects.Add(project);
            ctx.Projects.Add(project2);
            ctx.SaveChanges();
        }

        public List<Project> GetProjects(DateTime? day)
        {
            if (day.HasValue)
            {
                using(var ctx = new TimeTrackerDataContext())
                {
                    var projects = ctx.Projects.Where(s => s.Calendar.Date.Date == day.Value).ToList();
                    return projects;
                }
            }
            else
                using(var ctx = new TimeTrackerDataContext())
                {
                    var projects = ctx.Projects.Where(s => s.Calendar.Date.Date == DateTime.Today).ToList();
                    return projects;
                }
        }
    }
}
