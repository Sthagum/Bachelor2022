using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuadBook.Models
{
    public class ResourceProperty
    {
        public int ResourcePropertyID { get; set; }

        [Required(ErrorMessage = "Vennligst fyll ut verdien")]
        [Display(Name = "Verdi")]
        [StringLength(30, ErrorMessage = "Verdien må være fra 1 til 30 tegn eller bokstaver", MinimumLength = 1)]
        public string ResourcePropertyValue { get; set; }

        [Required]
        public int TypePropertyID { get; set; }
        public TypeProperty? TypeProperty { get; set; }
    }
}
