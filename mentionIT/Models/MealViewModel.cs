using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace mentionIT.Models
{
    public class MealViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Cuisine { get; set; }
        public int Likes { get; set; }
        public string Comments { get; set; }
        public string YLink { get; set; }
        [Required(ErrorMessage = "Please Upload a photo")]
        public IFormFile MealImage { get; set; }
    }
}