using System.ComponentModel.DataAnnotations;

namespace QuadBook.Models
{
    public class ResourceType
    {
        public int ResourceTypeID { get; set; }

        [Required(ErrorMessage = "Vennligst fyll ut Ressurs type navn")]
        [Display(Name = "Ressurs type navn")]
        [StringLength(30, ErrorMessage = "Navn må være fra 2 til 30 tegn eller bokstaver", MinimumLength = 3)]
        public string ResourceTypeName { get; set; }
    }
}
