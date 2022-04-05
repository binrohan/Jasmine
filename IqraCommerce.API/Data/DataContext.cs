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
        public virtual DbSet<CustomerAddress> Address { get; set; } // ** Using
        public virtual DbSet<Upazila> Upazila { get; set; } // ** Using
        public virtual DbSet<Province> Province { get; set; } // ** Using
        public virtual DbSet<District> District { get; set; } // ** Using








        
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
            // modelBuilder.Entity<Access>(entity =>
            // {
            //     entity.Property(e => e.Id).ValueGeneratedNever();

            //     entity.Property(e => e.CreatedAt).HasColumnType("datetime");

            //     entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            // });



            modelBuilder.Entity<ActionMethodGroup>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });


            modelBuilder.Entity<AppPage>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<AppReview>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<AppScript>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Banner>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<BlogCategory>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });



            modelBuilder.Entity<CategorySlider>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<ChangeHistory>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Coupon>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<CouponHistory>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });



            modelBuilder.Entity<DataImporter>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Html).HasColumnName("HTML");
            });

            modelBuilder.Entity<DealsOfTheWeek>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DesignationAccess>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Device>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<DeviceAccess>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<DeviceActivity>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<DiscountOffer>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DiscountOfferPic>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DisplayCategory>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.Property(e => e.Xmax).HasColumnName("XMax");

                entity.Property(e => e.Xmin).HasColumnName("XMin");

                entity.Property(e => e.Ymax).HasColumnName("YMax");

                entity.Property(e => e.Ymin).HasColumnName("YMin");
            });

            modelBuilder.Entity<ErrorOeder>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<FindStore>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<IqraGrid>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<IqraGridChangeHistory>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Licence>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ActivateAt).HasColumnType("datetime");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Liker>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<MedProduct>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Html).HasColumnName("HTML");

                entity.Property(e => e.PackMrp).HasColumnName("PackMRP");
            });

            modelBuilder.Entity<MedProductPriceChanged>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<MenuAccess>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<MenuCategory>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<MenuItem>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<MyCart>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<MyWishlist>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<NewArrival>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Notice>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<NotificationStatus>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<OrderPayment>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<OrderPaymentMethod>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });




            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });




            modelBuilder.Entity<Province>(entity =>
            {
                entity.Property(e => e.Xmax).HasColumnName("XMax");

                entity.Property(e => e.Xmin).HasColumnName("XMin");

                entity.Property(e => e.Ymax).HasColumnName("YMax");

                entity.Property(e => e.Ymin).HasColumnName("YMin");
            });

            modelBuilder.Entity<SubMenuItemAccess>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Thana>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Union>(entity =>
            {
                entity.Property(e => e.Xmax).HasColumnName("XMax");

                entity.Property(e => e.Xmin).HasColumnName("XMin");

                entity.Property(e => e.Ymax).HasColumnName("YMax");

                entity.Property(e => e.Ymin).HasColumnName("YMin");
            });

            modelBuilder.Entity<Upazila>(entity =>
            {
                entity.Property(e => e.Xmax).HasColumnName("XMax");

                entity.Property(e => e.Xmin).HasColumnName("XMin");

                entity.Property(e => e.Ymax).HasColumnName("YMax");

                entity.Property(e => e.Ymin).HasColumnName("YMin");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
