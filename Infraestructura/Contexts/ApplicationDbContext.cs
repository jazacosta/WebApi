using Core.Entities;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts
{
    public partial class ApplicationDbContext : DbContext
    {
        //representacion en la base de datos
        public DbSet<Customer> Customers { get; set; } //code first
        public DbSet<Account> Accounts { get; set; } 
        public DbSet<Card> Cards { get; set; } 
        public DbSet<Charge> Charges { get; set; } 
        public DbSet<Payment> Payments { get; set; } 
        public DbSet<Entity> Entities { get; set; } 
        public DbSet<Product> Products { get; set; } 

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
            modelBuilder.ApplyConfiguration(new CardConfiguration());
            modelBuilder.ApplyConfiguration(new ChargeConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentConfiguration());
            modelBuilder.ApplyConfiguration(new EntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
