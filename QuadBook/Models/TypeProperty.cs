using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuadBook.Models
{
    public class TypeProperty
    {
        public int TypePropertyID { get; set; }

        [Required(ErrorMessage = "Vennligst fyll ut type egenskap navn")]
        [Display(Name = "Egenskap")]
        [StringLength(30, ErrorMessage = "Må være fra 2 til 30 tegn eller bokstaver", MinimumLength = 3)]
        public string TypePropertyName { get; set; }
    }
}
