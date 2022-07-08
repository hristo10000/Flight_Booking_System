using System.ComponentModel.DataAnnotations;

namespace Flinder.Web.Data
{
    public class FlightClass
    {
        [Required] public string Type { get; set; }
        [Required] public string Rows { get; set; }
        [Required] public string Cols { get; set; }
    }
}