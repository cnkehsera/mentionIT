using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mentionIT.Models
{
    public class LikesUserLink
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Liked { get; set; }
        public int MealId { get; set; }
    }
}
