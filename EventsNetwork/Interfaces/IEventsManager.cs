using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventsNetwork
{
    public interface IEventsManager
    {
        Task<IList<JObject>> GetAllEvents();
    }
}