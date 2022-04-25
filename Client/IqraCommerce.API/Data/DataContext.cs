using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using IqraCommerce.API.Entities;
using App.Setup.Connection;

namespace IqraCommerce.API.Data
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Contact> Contact { get; set; } // ** Using
        public virtual DbSet<Unit> Unit { get; set; } // ** Using
        public virtual DbSet<Category> Category { get; set; } // ** Using
        public virtual DbSet<Banner> Banner { get; set; } // ** Using
        public virtual DbSet<Product> Product { get; set; } // ** Using
        public virtual DbSet<ProductCategory> ProductCategory { get; set; } // ** Using
        public virtual DbSet<Customer> Customer { get; set; } // ** Using
        public virtual DbSet<CustomerAddress> CustomerAddress { get; set; } // ** Using
        public virtual DbSet<Province> Province { get; set; } // ** Using
        public virtual DbSet<District> District { get; set; } // ** Using
        public virtual DbSet<Upazila> Upazila { get; set; } // ** Using
        public virtual DbSet<Register> Register { get; set; } // ** Using
        public virtual DbSet<Complain> Complain { get; set; } // ** Using
        public virtual DbSet<Promotion> Promotion { get; set; } // ** Using
        public virtual DbSet<Festival> Festival { get; set; } // ** Using
        public virtual DbSet<FestivalProduct> FestivalProduct { get; set; } // ** Using
         public virtual DbSet<Order> Order { get; set; } // Used
        public virtual DbSet<OrderProduct> OrderProduct { get; set; } // Used
        public virtual DbSet<OrderHistory> OrderHistory { get; set; } // Used
        public virtual DbSet<ShippingAddress> ShippingAddress { get; set; } // Used
        public virtual DbSet<OrderAquiredOffer> OrderAquiredOffer { get; set; } // Used
        public virtual DbSet<Device> Device { get; set; } // Used
        public virtual DbSet<Coupon> Coupon { get; set; } // Used
        public virtual DbSet<CouponRedeemHistory> CouponRedeemHistory { get; set; } // Used
        public virtual DbSet<Cashback> Cashback { get; set; } // Used
        public virtual DbSet<CashbackHistory> CashbackHistory { get; set; } // Used
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(Connection.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
            

            
        }
    }
}
