namespace QuadBook.Models
{
    public class User
    {
        public int UserID { get; set; }
       
        public String UserName { get; set; }
        
        public String Email { get; set; }
        
        public int CompanyID { get; set; }
        public Company Company { get; set; }
        
        public User()
        {

        }
    }
}
