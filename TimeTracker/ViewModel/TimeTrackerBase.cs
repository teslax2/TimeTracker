using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.ViewModel
{
    class TimeTrackerBase
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
                    break;
                default:
                    break;
            }
        }

        public TimeTrackerBase() { }

    }
}
