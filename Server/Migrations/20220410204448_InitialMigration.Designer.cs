﻿// <auto-generated />
using BlazorApp.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorApp.Server.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220410204448_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BlazorApp.Server.Models.Ingredient", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("ItemAmount")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long>("RecipeId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("Ingredients");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            ItemAmount = "20 grams",
                            ItemName = "Chicken Thighs",
                            RecipeId = 1L
                        },
                        new
                        {
                            Id = 2L,
                            ItemAmount = "15 grams",
                            ItemName = "Milk",
                            RecipeId = 1L
                        },
                        new
                        {
                            Id = 3L,
                            ItemAmount = "6 grams",
                            ItemName = "Tomatoes",
                            RecipeId = 2L
                        },
                        new
                        {
                            Id = 4L,
                            ItemAmount = "10 grams",
                            ItemName = "Bread",
                            RecipeId = 2L
                        },
                        new
                        {
                            Id = 5L,
                            ItemAmount = "40 grams",
                            ItemName = "Chicken Wings",
                            RecipeId = 3L
                        },
                        new
                        {
                            Id = 6L,
                            ItemAmount = "6 grams",
                            ItemName = "Honey",
                            RecipeId = 3L
                        });
                });

            modelBuilder.Entity("BlazorApp.Server.Models.Recipe", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RecipeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Recipes");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Author = "Mike",
                            RecipeName = "Alfrado"
                        },
                        new
                        {
                            Id = 2L,
                            Author = "Jake",
                            RecipeName = "Tomato Soup"
                        },
                        new
                        {
                            Id = 3L,
                            Author = "Paul",
                            RecipeName = "Spicy Honey Wings"
                        });
                });

            modelBuilder.Entity("BlazorApp.Server.Models.Ingredient", b =>
                {
                    b.HasOne("BlazorApp.Server.Models.Recipe", "Recipe")
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("BlazorApp.Server.Models.Recipe", b =>
                {
                    b.Navigation("Ingredients");
                });
#pragma warning restore 612, 618
        }
    }
}