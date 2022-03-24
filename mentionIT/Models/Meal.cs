﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mentionIT.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cuisine { get; set; }
        public int Likes { get; set; }
        public string Comments { get; set; }
        public string YLink { get; set; }
        public string MealImage { get; set; }

    }
}