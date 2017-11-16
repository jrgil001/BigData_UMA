using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventsNetwork
{
    internal class EventsManager : IEventsManager
    {
        private IMeetupService _meetupService;
        private ITicketmasterService _ticketmasterService;

        public EventsManager()
        {
            _meetupService = new MeetupService();
            _ticketmasterService = new TicketmasterService();
        }

        public async Task<IList<JObject>> GetAllEvents()
        {
            try
            {
                IList<JObject> meetups = await _meetupService.GetEvents();
                IList<JObject> ticketmasters = await _ticketmasterService.GetEvents();

                CommonHelper.GroupLists(meetups, ticketmasters);

                return meetups;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}