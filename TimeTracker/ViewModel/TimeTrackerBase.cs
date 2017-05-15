using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.ViewModel
{
    class TimeTrackerBase:IDisposable
    {
        protected TimeTrackerDataModelContainer _ctx = new TimeTrackerDataModelContainer();

        protected virtual void GetData() { }
        protected virtual void CommitUpdates() { }
        protected virtual void Delete() { }
        protected virtual void Refresh()
        {
            GetData();
        }

        protected void HandleCommand(CommandTypes command)
        {
            switch (command)
            {
                case CommandTypes.Create:
                    break;
                case CommandTypes.Delete:
                    break;
                case CommandTypes.Remove:
                    break;
                case CommandTypes.Update:
                    Refresh();
                    break;
                case CommandTypes.Commit:
                    CommitUpdates();
                    break;
                default:
                    break;
            }
        }
        private void SeedDb()
        {
            using (_ctx = new TimeTrackerDataModelContainer())
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
                    CalendarId = 4
                };

                var project2 = new Project()
                {
                    Id = 2,
                    Name = "Cipa",
                    Number = "PD894",
                    Description = "Projekt z pipki",
                    CalendarId = 5
                };

                var project3 = new Project()
                {
                    Id = 3,
                    Name = "Cipka",
                    Number = "PD895",
                    Description = "Projekt z pipki2",
                    CalendarId = 6
                };

                _ctx.Employees.Add(employee);
                _ctx.Employees.Add(employee2);
                _ctx.Projects.Add(project);
                _ctx.Projects.Add(project2);
                _ctx.Projects.Add(project3);
                _ctx.SaveChanges();
            }
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }

        public TimeTrackerBase()
        {
            //SeedDb();
        }

    }
}
