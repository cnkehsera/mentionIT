using Microsoft.AspNetCore.Http;
using System;

namespace mentionIT.Models
{
    public class MealViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cuisine { get; set; }
        public int Likes { get; set; }
        public string Comments { get; set; }
        public string YLink { get; set; }
        public IFormFile MealImage { get; set; }
    }
}