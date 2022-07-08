namespace Flinder.Web.Models
{
    public class SeatCreateModel
    {
        public int Flight_Id { get; set; }
        public string Seat_Class { get; set; }
        public int Row { get; set; }
        public char Col { get; set; }
    }
}