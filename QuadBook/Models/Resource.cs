using System.ComponentModel.DataAnnotations;

namespace QuadBook.Models
{
    public class Resource
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Vennligst fyll ut ressursnavn")]
        [Display(Name = "Ressursnavn")]
        [StringLength(30, ErrorMessage = "Ressursnavnet må være fra 2 til 30 tegn eller bokstaver", MinimumLength = 3)]
        public string ResourceName { get; set; }

        [Required]
        [Display(Name = "Type")]
        public int ResourceTypeID { get; set; }
        public ResourceType? ResourceType { get; set; }

        [Required]
        [Display(Name = "Egenskap")]
        public int ResourcePropertiesID { get; set; }
        public ResourceProperty? ResourceProperty { get; set; }

        [Required]
        [Display(Name = "Lokasjon")]
        public int LocationID { get; set; }
        public Location? Location { get; set; }

        public ICollection<Booking>? Bookings { get; set; }

    }
}
