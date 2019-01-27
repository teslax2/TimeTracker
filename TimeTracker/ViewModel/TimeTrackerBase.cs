using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
                    Delete();
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

            if (_ctx.Projects.Count() > 0)
                return;

                var calendar = new Calendar() { EmployeeId = 1, Id = 1, Date = DateTime.Parse("2017/05/20") };
                var calendar2 = new Calendar() { EmployeeId = 2, Id = 2, Date = DateTime.Today };

            var employee = new Employee()
            {
                Id = 1,
                FirstName = "Wieslaw",
                Surname = "Urban",
                Role = Roles.Engineer,
                Email="dsafa@dsaf.pl",
                Password=hashPassword("sdfa")
            };

            var employee2 = new Employee()
            {
                Id = 2,
                FirstName = "Ewelina",
                Surname = "Urban",
                Role = Roles.Manager,
                Email = "fdsdf@fdas.pl",
                Password = hashPassword("cfds")
            };

            var projectName = new ProjectName()
            {
                Id =1,
                Name = "PD1234 fds",
                Number = "PD1234",
                Description = "dfsdsa"
            };

            var projectName2 = new ProjectName()
            {
                Id =2,
                Name = "PD333sdfa",
                Number = "PD333",
                Description = "Duzasdf"
            };

            var projectName3 = new ProjectName()
            {
                Id =3,
                Name = "PD4 sdf",
                Number = "PD4",
                Description = "Dudsfa"
            };

            var project = new Project()
            { 
                Id =1,
                Hours = 0,
                Description = "Projekt z ddfi",
                CalendarId = 1,
                ProjectNameId = 1
            };

            var project2 = new Project()
            {
                Id=2,
                Hours=0,
                Description = "Projekt dsf",
                CalendarId = 2,
                ProjectNameId = 2
            };

            var project3 = new Project()
            {
                Id=3,
                Hours= 3,
                Description = "Projektdsfds",
                CalendarId = 2,
                ProjectNameId = 3
            };

            _ctx.Employees.Add(employee);
            _ctx.Employees.Add(employee2);
            _ctx.Calendars.Add(calendar);
            _ctx.Calendars.Add(calendar2);
            _ctx.Projects.Add(project);
            _ctx.Projects.Add(project2);
            _ctx.Projects.Add(project3);
            _ctx.ProjectNameSet.Add(projectName);
            _ctx.ProjectNameSet.Add(projectName2);
            _ctx.ProjectNameSet.Add(projectName3);
            _ctx.SaveChanges();
            
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }

        public TimeTrackerBase()
        {
            SeedDb();
        }

        public string hashPassword(string pass)
        {
            SHA256 crypt = new SHA256Managed();
            var hash = string.Empty;
            byte[] hashedPass = crypt.ComputeHash(Encoding.UTF8.GetBytes(pass), 0, Encoding.UTF8.GetByteCount(pass));
            foreach (byte element in hashedPass)
            {
                hash += element;
            }
            return hash;
        }

    }
}
