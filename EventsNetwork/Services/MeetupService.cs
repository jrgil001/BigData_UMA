using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EventsNetwork
{
    internal class MeetupService : BaseService
    {
        public override async Task<IList<JObject>> GetEvents()
        {
            var url = GetEventsURL();
            HttpClient client = CommonHelper.CreateClient(url);

            IList<JObject> result = null;
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<IList<JObject>>();
                result = CommonHelper.TypeAdder(result, Constants.DataSourceTypes.Meetup);
            }
            return result;
        }

        private String GetEventsURL()
        {
            return Constants.MeetupDataSource.BaseUrl + Constants.MeetupDataSource.EventsUri + "?" + Constants.MeetupDataSource.IdName + "=" + Constants.MeetupDataSource.Id + "&" + Constants.MeetupDataSource.KeyName + "=" + Constants.MeetupDataSource.Key;
        }
    }
}