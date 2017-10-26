namespace EventsNetwork
{
    public static class Constants
    {
        public static class DataSourceTypes
        {
            public const string Meetup = "Meetup";
            public const string Ticketmaster = "Ticketmaster";
        }

        public static class MeetupDataSource
        {
            public const string BaseUrl = "https://api.meetup.com/find/";
            public const string IdName = "sig_id";
            public const string Id = "------";
            public const string KeyName = "sig";
            public const string Key = "--------";
            public const string EventsUri = "events";
        }

        public static class TicketmasterDataSource
        {
            public const string BaseUrl = "https://app.ticketmaster.com/discovery/v2/";
            public const string IdName = "city";
            public const string Id = "Málaga";
            public const string KeyName = "apikey";
            public const string Key = "----------";
            public const string EventsUri = "events.json";
        }

        public static class EstacionamientosCkanDataSource
        {
            public const string BaseUrl = "https://demo.ckan.org/api/3/action/";
            public const string ResIdName = "resource_id";
            public const string ResId = "-------";
            public const string AuthorizationName = "Authorization";
            public const string Authorization = "----------";
            public const string SearchUri = "datastore_search";
        }
    }
}