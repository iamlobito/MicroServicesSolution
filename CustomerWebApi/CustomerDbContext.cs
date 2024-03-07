using CustomerWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace CustomerWebApi
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> dbContextOptions) 
            : base(dbContextOptions) 
        {
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

            //Seed customer data

            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, CustomerName = "Nelson Silva", Email = "demo1@email.com", MobileNumber = "9346723425"});

            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 2, CustomerName = "André Silva", Email = "demo2@email.com", MobileNumber = "99999999" });

        }

    }
}
