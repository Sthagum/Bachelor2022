namespace QuadBook.Models
{
    public class ResourceProperties
    {
        public int resourcePropertiesId { get; set; }
        
        public string value { get; set; }
        
        public int typePropertiesId { get; set; }
        public TypeProperties TypeProperties { get; set; }
        
        public ResourceProperties()
        {

        }
    }
}
