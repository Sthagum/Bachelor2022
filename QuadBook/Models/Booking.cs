namespace QuadBook.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string user { get; set; }
        public string resource { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        public int UserID { get; set; }
        public User User { get; set; }

        public int ResourceID { get; set; }
        public Resource Resource { get; set; }
    }
}