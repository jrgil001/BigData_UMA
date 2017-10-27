using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace EventsNetwork
{
    internal class CommonHelper
    {
        public static HttpClient CreateClient(String url)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        public static IList<JObject> TypeAdder(IList<JObject> events, String type)
        {
            IList<JObject> result = new List<JObject>();

            foreach (var eventObj in events)
            {
                eventObj.Add("dsType", type);
                result.Add(eventObj);
            }

            return result;
        }

        public static IList<JObject> GroupLists(IList<JObject> records, IList<JObject> recordsToAdd)
        {
            foreach (var record in recordsToAdd)
            {
                records.Add(record);
            }

            return records;
        }
    }
}