using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EventsNetwork
{
    internal class TicketmasterService : BaseService
    {
        public override async Task<IList<JObject>> GetEvents()
        {
            var url = GetEventsURL();
            HttpClient client = CommonHelper.CreateClient(url);

            IList<JObject> result = null;
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                JToken callResponse = await response.Content.ReadAsAsync<JToken>();
                result = GetEventsFromResult(callResponse);
                result = CommonHelper.TypeAdder(result, Constants.DataSourceTypes.Ticketmaster);
            }
            return result;
        }

        private String GetEventsURL()
        {
            return Constants.TicketmasterDataSource.BaseUrl + Constants.TicketmasterDataSource.EventsUri + "?" + Constants.TicketmasterDataSource.IdName + "=" + Constants.TicketmasterDataSource.Id + "&" + Constants.TicketmasterDataSource.KeyName + "=" + Constants.TicketmasterDataSource.Key;
        }

        private IList<JObject> GetEventsFromResult(JToken result)
        {
            JToken r2 = result["_embedded"].Value<JToken>();
            JArray r3 = r2["events"].Value<JArray>();
            return r3.ToObject<IList<JObject>>();
        }
    }
}