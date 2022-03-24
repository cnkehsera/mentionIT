﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using mentionIT.Data;

namespace mentionIT.Migrations
{
    [DbContext(typeof(mentionITContext))]
    [Migration("20220302115841_Initialize")]
    partial class Initialize
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("mentionIT.Models.Meal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cuisine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YLink")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Meal");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Comments = "",
                            Cuisine = "Italian",
                            Likes = 3,
                            Name = "Chicken Scarpariello",
                            YLink = "https://www.youtube.com/results?search_query=italian+recipes+for+dinner"
                        },
                        new
                        {
                            Id = 2,
                            Comments = "",
                            Cuisine = "Indian",
                            Likes = 3,
                            Name = "Mughlai Chicken Handi",
                            YLink = "https://www.youtube.com/watch?v=u66pG73UroY"
                        },
                        new
                        {
                            Id = 3,
                            Comments = "",
                            Cuisine = "Lebanese",
                            Likes = 3,
                            Name = "Lebanese Chicken",
                            YLink = "https://www.youtube.com/watch?v=EwYGQ9Rx53w"
                        },
                        new
                        {
                            Id = 4,
                            Comments = "",
                            Cuisine = "Portuguese",
                            Likes = 3,
                            Name = "Cataplana ",
                            YLink = "https://www.youtube.com/watch?v=utv-GpSJypk"
                        },
                        new
                        {
                            Id = 5,
                            Comments = "",
                            Cuisine = "Pakistani",
                            Likes = 3,
                            Name = "Karahi chicken",
                            YLink = "https://www.youtube.com/watch?v=RBS-ptrMAgI"
                        },
                        new
                        {
                            Id = 6,
                            Comments = "",
                            Cuisine = "French",
                            Likes = 3,
                            Name = "Cassoulet",
                            YLink = "https://www.youtube.com/watch?v=nKGsoQM5YJk"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}