using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.Model
{
    class TimeTrackerModel
    { 
        public TimeTrackerModel()
        {
            using(var ctx = new TimeTrackerDataModelContainer())
            {
                if (ctx.Employees.Count() == 0)
                    SeedDb(ctx);
            }
        }
        private void SeedDb(TimeTrackerDataModelContainer ctx)
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

            var project3 = new Project()
            {
                Id = 3,
                Name = "Cipka",
                Number = "PD895",
                Description = "Projekt z pipki2",
                CalendarId = 1
            };

            ctx.Employees.Add(employee);
            ctx.Employees.Add(employee2);
            ctx.Projects.Add(project);
            ctx.Projects.Add(project2);
            ctx.Projects.Add(project3);
            ctx.SaveChanges();
        }

        public List<Project> GetProjects(DateTime? day)
        {
            if (day.HasValue)
            {
                using(var ctx = new TimeTrackerDataModelContainer())
                {
                    var projects = ctx.Projects.Where(s => s.Calendar.Date == day.Value).ToList();
                    return projects;
                }
            }
            else
                using(var ctx = new TimeTrackerDataModelContainer())
                {
                    var projects = ctx.Projects.Where(s => s.Calendar.Date.Date == DateTime.Today).ToList();
                    return projects;
                }
        }

        public List<string> GetProjectNumbers()
        {
            using(var ctx = new TimeTrackerDataModelContainer())
            {
                var projectNumbers = (from c in ctx.Projects
                                     orderby c.Number
                                     select c.Number).ToList();

                return projectNumbers;
            }
        }

        public List<string> GetProjectNames(string name)
        {
            using(var ctx = new TimeTrackerDataModelContainer())
            {
                if (name == "")
                {
                    var allNames = (from c in ctx.Projects
                                 orderby c.Name
                                 select c.Name);
                    return allNames.ToList();
                }
                else
                {
                    var names = (from c in ctx.Projects
                                 orderby c.Name
                                 where c.Name.Contains(name)
                                 select c.Name);

                    if (names != null)
                        return names.ToList();
                    else
                        return new List<string>();
                }


            }
        }
    }
}
