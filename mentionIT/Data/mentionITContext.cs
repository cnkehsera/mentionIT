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
                new Meal { Id = 1, Name = "Chicken Scarpariello", Cuisine = "Italian", Likes = 3, Comments = "", YLink = "https://www.youtube.com/watch?v=kyCGjn_sjlk"  },
                new Meal { Id = 2, Name = "Mughlai Chicken Handi",Cuisine = "Indian", Likes = 8, Comments = "", YLink = "https://www.youtube.com/watch?v=u66pG73UroY" },
                new Meal { Id = 3, Name = "Lebanese Chicken", Cuisine = "Lebanese", Likes = 15, Comments = "", YLink = "https://www.youtube.com/watch?v=EwYGQ9Rx53w" },
                new Meal { Id = 4, Name = "Cataplana ",  Cuisine = "Portuguese", Likes = 22, Comments = "", YLink = "https://www.youtube.com/watch?v=utv-GpSJypk" },
                new Meal { Id = 5, Name = "Karahi chicken", Cuisine = "Pakistani", Likes = 12, Comments = "", YLink = "https://www.youtube.com/watch?v=RBS-ptrMAgI" },
                new Meal { Id = 6, Name = "Cassoulet", Cuisine = "French", Likes = 9, Comments = "", YLink = "https://www.youtube.com/watch?v=nKGsoQM5YJk" }
                );
            modelBuilder.Entity<LikesUserLink>().HasData(
                new LikesUserLink { Id=1, Name="nkeerthimeher@gmail.com", Liked=true, MealId=1 }
                );
        }
    }
}
