using Microsoft.AspNetCore.Http;
using System;

namespace mentionIT.Models
{
    public class MealViewModel
    {
        public string Name { get; set; }

        public IFormFile MealImage { get; set; }
    }
}