using System;

namespace EventsNetwork
{
    internal class CkanService
    {
        private String CreateEstacionamientosCkanURL()
        {
            return Constants.EstacionamientosCkanDataSource.BaseUrl + Constants.EstacionamientosCkanDataSource.SearchUri + "?" + Constants.EstacionamientosCkanDataSource.ResIdName + "=" + Constants.EstacionamientosCkanDataSource.ResId;
        }
    }
}