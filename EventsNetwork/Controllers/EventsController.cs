using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace EventsNetwork
{
    public class EventsController : ApiController
    {
        static HttpClient client = new HttpClient();
        IEventsManager eventsManager;

        public EventsController()
        {
            eventsManager = new EventsManager();
        }

        public async Task<IList<JObject>> GetAllEvents()
        {
            DataController dc = new DataController();
            //await dc.GenerateData();
            await dc.GenerateDataCase2();

            return await eventsManager.GetAllEvents();
        }
    }
}