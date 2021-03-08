using Entities;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //Context : Db tabloları ile proje class'larını bağlamak
    //DbContext : Entityframework'le gelen bir yapı
    public class NorthwindContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Northwind;Trusted_Connection=true");
        }

                            
        public DbSet<Product> Products { get; set; } //Product nesnemi veritabanındaki products ile bağla
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("Employees");

            modelBuilder.Entity<Employee>().Property(p => p.Id).HasColumnName("EmployeeID");
            modelBuilder.Entity<Employee>().Property(p => p.Name).HasColumnName("FirstName");
            modelBuilder.Entity<Employee>().Property(p => p.Surname).HasColumnName("LastName");
        }

        public DbSet<Order> Orders { get; set; }
    }
}
