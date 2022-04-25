using System.ComponentModel.DataAnnotations;

namespace QuadBook.Models
{
    public class Booking : IValidatableObject
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "BrukerEpost")]
        [StringLength(50, MinimumLength = 3)]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "Vennligst spesifiser startdato")]
        [Display(Name = "Startdato")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Vennligst spesifiser sluttdato")]
        [Display(Name = "Sluttdato")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "Ressurs")]
        public int ResourceID { get; set; }
        public Resource? Resource { get; set; }

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            if (EndDate < StartDate)
            {
                yield return new ValidationResult("Sluttdato kan ikke være før Startdato!");
            }
        }
    }
}
