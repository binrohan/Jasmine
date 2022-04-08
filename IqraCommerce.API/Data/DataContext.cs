using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using IqraCommerce.API.Entities;

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
        public virtual DbSet<Brand> Brand { get; set; } // ** Using
        public virtual DbSet<Unit> Unit { get; set; } // ** Using
        public virtual DbSet<Category> Category { get; set; } // ** Using
        public virtual DbSet<Banner> Banner { get; set; } // ** Using
        public virtual DbSet<Notice> Notice { get; set; } // ** Using
        public virtual DbSet<Product> Product { get; set; } // ** Using
        public virtual DbSet<ProductCategory> ProductCategory { get; set; } // ** Using
        public virtual DbSet<Showcase> Showcase { get; set; } // ** Using
        public virtual DbSet<Customer> Customer { get; set; } // ** Using
        public virtual DbSet<CustomerAddress> CustomerAddress { get; set; } // ** Using
        public virtual DbSet<Upazila> Upazila { get; set; } // ** Using
        public virtual DbSet<Province> Province { get; set; } // ** Using
        public virtual DbSet<District> District { get; set; } // ** Using
        public virtual DbSet<Register> Register { get; set; } // ** Using
        public virtual DbSet<Complain> Complain { get; set; } // ** Using
        public virtual DbSet<Offer> Offer { get; set; } // ** Using








        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("data source=DESKTOP-2T4KNKA;initial catalog=SHOPPERS_PERK_DB;persist security info=True;user id=sa;password=123;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
            

            
        }
    }
}
