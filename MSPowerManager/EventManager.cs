using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MSPowerInfo;
using MSPowerRepo;

namespace MSPowerManager
{
    public class EventManager
    {

        public EventRepo _eRepo = null;

        public EventManager()
        {
            _eRepo = new EventRepo();
        }

         public List<EventInfo> Get_Events(ref PaginationInfo pager, int language_Id)
        {
            return _eRepo.Get_Events(ref pager, language_Id);
        }

         public EventInfo Get_Event_By_Id(int events_Id, int language_Id)
        {
            return _eRepo.Get_Event_By_Id(events_Id, language_Id);
        }

        public int Insert_Event(EventInfo events)
        {
            return _eRepo.Insert_Event(events);
        }

        public void Update_Event(EventInfo events)
        {
            _eRepo.Update_Event(events);
        }

    }
}
