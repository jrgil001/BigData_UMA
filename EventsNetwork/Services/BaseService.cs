using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventsNetwork
{
    public abstract class BaseService
    {
        public abstract Task<IList<JObject>> GetEvents();
    }
}