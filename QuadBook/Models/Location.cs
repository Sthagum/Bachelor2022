using System.ComponentModel.DataAnnotations;

namespace QuadBook.Models
{
    public class Location
    {
        public int LocationID { get; set; }
        [Required]
        [Display(Name = "Rom")]
        [StringLength(50, ErrorMessage = "Romnavnet må være fra 2 til 50 tegn eller bokstaver", MinimumLength = 2)]
        public String? RoomName { get; set; }
    }
}
