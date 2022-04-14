using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuadBook.Models
{
    public class Location
    {
        public int LocationID { get; set; }
        [Required]
        [Display(Name = "Rom Navn")]
        [StringLength(50, ErrorMessage = "Romnavnet må være fra 2 til 50 tegn eller bokstaver", MinimumLength = 2)]
        public String? RoomName { get; set; }

        [Required]
        [Display(Name = "Bygning")]
        [StringLength(50, ErrorMessage = "Bygningsnavnet må være fra 2 til 50 tegn eller bokstaver", MinimumLength = 1)]
        public String? BuildingName { get; set; }
    }
}
