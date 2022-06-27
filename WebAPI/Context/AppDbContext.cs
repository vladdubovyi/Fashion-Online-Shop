using Domain;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Context
{
	public class AppDbContext : DbContext
	{
		public DbSet<Product> Products { get; set; }
		public DbSet<Purchase> Purchases { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Tag> Tags { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<PurchaseProduct> PurchaseProduct { get; set; }
		public DbSet<Slide> Slides { get; set; }

		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
			Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Slide>().HasData(
				new Slide
				{
					Id = Guid.NewGuid(),
					Header = "Summer collection",
					Text = "Fall - Winter Collections 2022",
					BackgroundColor = "#56CCFF",
					ImageSrc = "MainPage/Slider/sample1.png",
					ButtonText = "Shop now!",
					ButtonLink = "/Shop"
				}
				);
			base.OnModelCreating(builder);
		}
	}
}
