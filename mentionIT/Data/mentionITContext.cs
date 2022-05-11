using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mentionIT.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.IO;
namespace mentionIT.Data
{
    public class mentionITContext : IdentityDbContext
    {
        public mentionITContext (DbContextOptions<mentionITContext> options)
            : base(options)
        {
        }
        
        public DbSet<mentionIT.Models.Meal> Meal { get; set; }
        public DbSet<mentionIT.Models.LikesUserLink> LikesUserLink { get; set; }
        public DbSet<mentionIT.Models.MealComment> MealComment { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Meal>().HasData(
                new Meal { Id = 1, Name = "Chicken Scarpariello", Cuisine = "Italian", Likes = 3, Comments = "", YLink = "https://www.youtube.com/watch?v=kyCGjn_sjlk"  }
                );
            modelBuilder.Entity<LikesUserLink>().HasData(
                new LikesUserLink { Id=1, Name="nkeerthimeher@gmail.com", Liked=true, MealId=1 }
                );
        }
    }
}
