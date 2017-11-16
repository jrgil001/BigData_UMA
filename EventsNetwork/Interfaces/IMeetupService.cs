using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventsNetwork
{
    interface IMeetupService
    {
        Task<IList<JObject>> GetEvents();
    }
}
