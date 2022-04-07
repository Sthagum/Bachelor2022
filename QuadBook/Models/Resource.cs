namespace QuadBook.Models
{
    public class Resource
    {
        public int resourceId { get; set; }
        
        public int resourceType { get; set; }
        
        public string resourceName { get; set; }
        
        public int locationId { get; set; }
        public Location Location { get; set; }
        
        public int resourcePropertiesID { get; set; }
        public ResourceProperties ResourceProperties { get; set; } 
        
        public int ResourceTypeID { get; set; }
        public ResourceType ResourceType { get; set; }

        public Resource()
        {

        }
    }
}
