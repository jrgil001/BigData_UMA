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
            public const string Id = "89850152";
            public const string KeyName = "sig";
            public const string Key = "1a1bb0e2c7beca8a5044dd07b3db58e1f0084783";
            public const string EventsUri = "events";
        }

        public static class TicketmasterDataSource
        {
            public const string BaseUrl = "https://app.ticketmaster.com/discovery/v2/";
            public const string IdName = "city";
            public const string Id = "Málaga";
            public const string KeyName = "apikey";
            public const string Key = "MFAKsdfb5xVlWlkK3HsmnJCtGB9mluiv";
            public const string EventsUri = "events.json";
        }

        public static class EstacionamientosCkanDataSource
        {
            public const string BaseUrl = "https://demo.ckan.org/api/3/action/";
            public const string ResIdName = "resource_id";
            public const string ResId = "b4be2269-b917-49ce-8b8b-01f0395da9c3";
            public const string AuthorizationName = "Authorization";
            public const string Authorization = "8b9db36e-0dc9-4797-ae8e-f9a946a760e6";
            public const string SearchUri = "datastore_search";
        }
    }
}