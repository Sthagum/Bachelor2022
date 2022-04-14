using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuadBook.Models
{
    public class Booking
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
        public int ResourceID { get; set; }
        public Resource? Resource { get; set; }
    }
}
