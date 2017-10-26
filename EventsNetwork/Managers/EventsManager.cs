using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace EventsNetwork
{
    public class EventsManager : IEventsManager
    {
        public async Task<IList<JObject>> GetAllEvents()
        {
            try
            {
                IList<JObject> meetups = await GetMeetupEvents();
                IList<JObject> ticketmasters = await GetTicketmasterEvents();

                foreach (var ticketmaster in ticketmasters)
                {
                    // Change this shit for something like meetups.Concat(ticketmasters.ToList()).ToList();
                    meetups.Add(ticketmaster);
                }

                return meetups;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        private async Task<IList<JObject>> GetMeetupEvents()
        {
            var url = GetMetupEventsURL();
            HttpClient client = CreateMetupClient(url);

            IList<JObject> result = null;
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<IList<JObject>>();
                result = TypeAdder(result, Constants.DataSourceTypes.Meetup);
            }
            return result;
        }

        private String GetMetupEventsURL()
        {
            return Constants.MeetupDataSource.BaseUrl + Constants.MeetupDataSource.EventsUri + "?" + Constants.MeetupDataSource.IdName + "=" + Constants.MeetupDataSource.Id + "&" + Constants.MeetupDataSource.KeyName + "=" + Constants.MeetupDataSource.Key;
        }

        private HttpClient CreateMetupClient(String url)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        private async Task<IList<JObject>> GetTicketmasterEvents()
        {
            var url = GetTicketmasterEventsURL();
            HttpClient client = CreateMetupClient(url);

            IList<JObject> result = null;
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                JToken result2 = await response.Content.ReadAsAsync<JToken>();
                JToken r2 = result2["_embedded"].Value<JToken>();
                JArray r3 = r2["events"].Value<JArray>();
                result = TypeAdder(r3.ToObject<IList<JObject>>(), Constants.DataSourceTypes.Ticketmaster);
            }
            return result;
        }

        private String GetTicketmasterEventsURL()
        {
            return Constants.TicketmasterDataSource.BaseUrl + Constants.TicketmasterDataSource.EventsUri + "?" + Constants.TicketmasterDataSource.IdName + "=" + Constants.TicketmasterDataSource.Id + "&" + Constants.TicketmasterDataSource.KeyName + "=" + Constants.TicketmasterDataSource.Key;
        }

        private IList<JObject> TypeAdder(IList<JObject> meetupObjects, String type)
        {
            IList<JObject> result = new List<JObject>();

            foreach (var meetupObject in meetupObjects)
            {
                meetupObject.Add("dsType", type);
                result.Add(meetupObject);
            }

            return result;
        }

        private String CreateEstacionamientosCkanURL()
        {            
            return Constants.EstacionamientosCkanDataSource.BaseUrl + Constants.EstacionamientosCkanDataSource.SearchUri + "?" + Constants.EstacionamientosCkanDataSource.ResIdName + "=" + Constants.EstacionamientosCkanDataSource.ResId;
        }
    }
}