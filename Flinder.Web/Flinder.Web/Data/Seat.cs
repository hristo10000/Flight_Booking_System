namespace Flinder.Web.Data
{
    public class Seat
    {
        public int Id { get; set; }
        public int Flight_Id { get; set; }
        public string Seat_Class { get; set; }
        public bool Is_Booked { get; set; }
        public int Row { get; set; }
        public char Col { get; set; }

    }
}