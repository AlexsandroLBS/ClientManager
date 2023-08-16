using ClientManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClientManager.Domain.Infra.Context
{
    public class DataContext : DbContext
    {   
         public DataContext()
        {
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Client> Clients { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().ToTable("Clients");
            modelBuilder.Entity<Client>().HasKey(x => x.ClientCode);
            modelBuilder.Entity<Client>().Property(x => x.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Client>().Property(x => x.Address).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Client>().Property(x => x.DocumentNo).IsRequired().HasMaxLength(20);

            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<Order>().HasKey(x => x.Id);
            modelBuilder.Entity<Order>().Property(x => x.OrderNumber).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Order>().Property(x => x.Done).IsRequired();
            modelBuilder.Entity<Order>().Property(x => x.Canceled).IsRequired();
            modelBuilder.Entity<Order>().Property(x => x.CreatedAt).IsRequired();
            modelBuilder.Entity<Order>().Property(x => x.ArrivedAt).IsRequired();
            modelBuilder.Entity<Order>().HasOne(x => x.Client).WithMany().HasForeignKey(x => x.ClientCode);
            modelBuilder.Entity<Order>().HasOne(x => x.Vendor).WithMany().HasForeignKey(x => x.VendorCode);

            modelBuilder.Entity<Vendor>().ToTable("Vendors");
            modelBuilder.Entity<Vendor>().HasKey(x => x.VendorCode);
            modelBuilder.Entity<Vendor>().Property(x => x.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Vendor>().Property(x => x.Email).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Vendor>().Property(x => x.CellPhone).IsRequired().HasMaxLength(20);


            modelBuilder.Entity<Order>()
                .HasOne(o => o.Vendor)
                .WithMany()
                .HasForeignKey(o => o.VendorCode);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Client)
                .WithMany()
                .HasForeignKey(o => o.ClientCode);
        }
    }
}