using Flinder.Web.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Flinder.Web.Models
{
    public class FlightCreateModel
    {
        [Required] public int Id { get; set; }
        [Required] public string Airline_Name { get; set; }
        [Required] public string Origin_Airport_Name { get; set; }
        [Required] public string Destination_Airport_Name { get; set; }
        [Required] public DateTime TakeOff_Time { get; set; }
        [Required] public DateTime Landing_Time { get; set; }
        public List<string> AirlineNames { get; set; }
        public List<string> AirportIds { get; set; }
        [Required] public FlightClass[] Classes { get; set; }
    }
}