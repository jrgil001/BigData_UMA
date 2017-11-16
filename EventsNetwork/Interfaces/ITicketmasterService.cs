using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventsNetwork
{
    interface ITicketmasterService
    {
        Task<IList<JObject>> GetEvents();
    }
}
