﻿using Core.Entities;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts
{
    public partial class ApplicationDbContext : DbContext
    {
        //representacion de customer en la base de datos
        public DbSet<Customer> Customers { get; set; } //code first
        public DbSet<Account> Accounts { get; set; } 

        public ApplicationDbContext()
        {  
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {     
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
