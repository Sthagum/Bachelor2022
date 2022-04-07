namespace QuadBook.Models
{
    public class Resource
    {
        public int resourceId { get; set; }
        public int resourceType { get; set; }
        public string resourceName { get; set; }
        public int locationId { get; set; }
        public int resourceProperties { get; set; }
        public Resource()
        {

        }
    }
}
