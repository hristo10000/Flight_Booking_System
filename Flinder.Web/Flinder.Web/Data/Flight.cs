using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flinder.Web.Data
{
    public class Flight
    {
        public int Id { get; set; }
        public string Airline_Name { get; set; }
        public string Origin_Airport_Name { get; set; }
        public string Destination_Airport_Name { get; set; }
        public DateTime TakeOff_Time { get; set; }
        public DateTime Landing_Time { get; set; }
        [NotMapped]public FlightClass[] Classes { get; set; }
    }
}