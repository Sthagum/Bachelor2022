namespace QuadBook.Models
{
    public class CompanyLocation
    {
        public int LocationID { get; set; }
        public Location Location { get; set; }

        public int CompanyID { get; set; }
        public Company Company { get; set; }

        public CompanyLocation()
        {

        }
    }
}
