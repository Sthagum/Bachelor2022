using System.ComponentModel.DataAnnotations;

namespace QuadBook.Models

{
    public class Company
    {
        public int CompanyID { get; set; }
        [Required]
        [Display(Name = "Firmanavn")]
        [StringLength(30, ErrorMessage = "Firmanavnet må være fra 2 til 30 tegn eller bokstaver", MinimumLength = 2)]
        public String? CompanyName { get; set; }
    }
}
