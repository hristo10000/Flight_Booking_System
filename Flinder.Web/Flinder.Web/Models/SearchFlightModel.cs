using System;
using System.Collections.Generic;

namespace Flinder.Web.Models
{
    public class SearchFlightModel
    {
        public string OriginAirportName { get; set; }
        public string DestinationAirportName { get; set; }
        public DateTime TakeOffTime { get; set; }
        public List<string> AirportNames { get; set; }
    }
}