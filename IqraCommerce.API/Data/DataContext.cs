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
        public virtual DbSet<Category> Category { get; set; } // ** Using
        public virtual DbSet<Banner> Banner { get; set; } // ** Using
        public virtual DbSet<Notice> Notice { get; set; } // ** Using



        
        public virtual DbSet<Access> Access { get; set; }
        public virtual DbSet<AccessType> AccessType { get; set; }
        public virtual DbSet<ActionController> ActionController { get; set; }
        public virtual DbSet<ActionMethod> ActionMethod { get; set; }
        public virtual DbSet<ActionMethodGroup> ActionMethodGroup { get; set; }
        public virtual DbSet<ActionMethodGroupItem> ActionMethodGroupItem { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<AppCategory> AppCategory { get; set; }
        public virtual DbSet<AppCategoryProduct> AppCategoryProduct { get; set; }
        public virtual DbSet<AppData> AppData { get; set; }
        public virtual DbSet<AppPage> AppPage { get; set; }
        public virtual DbSet<AppReview> AppReview { get; set; }
        public virtual DbSet<AppScript> AppScript { get; set; }
        public virtual DbSet<Blog> Blog { get; set; }
        public virtual DbSet<BlogCategory> BlogCategory { get; set; }
        public virtual DbSet<Career> Career { get; set; }
        public virtual DbSet<CareerDocument> CareerDocument { get; set; }
        public virtual DbSet<CategorySlider> CategorySlider { get; set; }
        public virtual DbSet<ChangeHistory> ChangeHistory { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        
        public virtual DbSet<Coupon> Coupon { get; set; }
        public virtual DbSet<CouponHistory> CouponHistory { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerPic> CustomerPic { get; set; }
        public virtual DbSet<DataImporter> DataImporter { get; set; }
        public virtual DbSet<DealsOfTheWeek> DealsOfTheWeek { get; set; }
        public virtual DbSet<DesignationAccess> DesignationAccess { get; set; }
        public virtual DbSet<Device> Device { get; set; }
        public virtual DbSet<DeviceAccess> DeviceAccess { get; set; }
        public virtual DbSet<DeviceActivity> DeviceActivity { get; set; }
        public virtual DbSet<DiscountOffer> DiscountOffer { get; set; }
        public virtual DbSet<DiscountOfferPic> DiscountOfferPic { get; set; }
        public virtual DbSet<DisplayCategory> DisplayCategory { get; set; }
        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<ErrorOeder> ErrorOeder { get; set; }
        public virtual DbSet<FindStore> FindStore { get; set; }
        public virtual DbSet<IqraGrid> IqraGrid { get; set; }
        public virtual DbSet<IqraGridChangeHistory> IqraGridChangeHistory { get; set; }
        public virtual DbSet<Licence> Licence { get; set; }
        public virtual DbSet<Liker> Liker { get; set; }
        public virtual DbSet<MedProduct> MedProduct { get; set; }
        public virtual DbSet<MedProductPriceChanged> MedProductPriceChanged { get; set; }
        public virtual DbSet<MenuAccess> MenuAccess { get; set; }
        public virtual DbSet<MenuCategory> MenuCategory { get; set; }
        public virtual DbSet<MenuItem> MenuItem { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<MyCart> MyCart { get; set; }
        public virtual DbSet<MyWishlist> MyWishlist { get; set; }
        public virtual DbSet<NewArrival> NewArrival { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<NotificationStatus> NotificationStatus { get; set; }
        public virtual DbSet<OrderPayment> OrderPayment { get; set; }
        public virtual DbSet<OrderPaymentMethod> OrderPaymentMethod { get; set; }
        public virtual DbSet<OrderShipping> OrderShipping { get; set; }
        public virtual DbSet<OtpMessage> OtpMessage { get; set; }
        public virtual DbSet<PaymentLog> PaymentLog { get; set; }
        public virtual DbSet<PaymentTracker> PaymentTracker { get; set; }
        public virtual DbSet<Perks> Perks { get; set; }
        public virtual DbSet<PrescriptionDocument> PrescriptionDocument { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<ProductComment> ProductComment { get; set; }
        public virtual DbSet<ProductContent> ProductContent { get; set; }
        public virtual DbSet<ProductImporter> ProductImporter { get; set; }
        public virtual DbSet<ProductInfo> ProductInfo { get; set; }
        public virtual DbSet<ProductOffer> ProductOffer { get; set; }
        public virtual DbSet<ProductOrder> ProductOrder { get; set; }
        public virtual DbSet<ProductOrderItem> ProductOrderItem { get; set; }
        public virtual DbSet<ProductRating> ProductRating { get; set; }
        public virtual DbSet<ProductSubCategory> ProductSubCategory { get; set; }
        public virtual DbSet<ProductSubCategoryItem> ProductSubCategoryItem { get; set; }
        public virtual DbSet<Province> Province { get; set; }
        public virtual DbSet<Rating> Rating { get; set; }
        public virtual DbSet<RequestOrder> RequestOrder { get; set; }
        public virtual DbSet<RewardPoint> RewardPoint { get; set; }
        public virtual DbSet<RewardPointHistory> RewardPointHistory { get; set; }
        public virtual DbSet<SafetyAdvice> SafetyAdvice { get; set; }
        public virtual DbSet<SafetyItem> SafetyItem { get; set; }
        public virtual DbSet<SafetyLabel> SafetyLabel { get; set; }
        public virtual DbSet<SpecialProduct> SpecialProduct { get; set; }
        public virtual DbSet<SubMenuItem> SubMenuItem { get; set; }
        public virtual DbSet<SubMenuItemAccess> SubMenuItemAccess { get; set; }
        public virtual DbSet<Thana> Thana { get; set; }
        public virtual DbSet<Union> Union { get; set; }
        public virtual DbSet<Upazila> Upazila { get; set; }
        public virtual DbSet<UploadPrescription> UploadPrescription { get; set; }
        public virtual DbSet<UrgentOrder> UrgentOrder { get; set; }
        public virtual DbSet<WishList> WishList { get; set; }

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

            modelBuilder.Entity<AccessType>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<ActionMethodGroup>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            // modelBuilder.Entity<Address>(entity =>
            // {
            //     entity.Property(e => e.Id).ValueGeneratedNever();
            // });

            // modelBuilder.Entity<AppCategory>(entity =>
            // {
            //     entity.Property(e => e.Id).ValueGeneratedNever();
            // });

            // modelBuilder.Entity<AppCategoryProduct>(entity =>
            // {
            //     entity.Property(e => e.Id).ValueGeneratedNever();
            // });

            modelBuilder.Entity<AppData>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

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

            modelBuilder.Entity<Career>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ApplicantCv).HasColumnName("ApplicantCV");
            });

            modelBuilder.Entity<CareerDocument>(entity =>
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

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Otpid).HasColumnName("OTPId");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Phone).IsRequired();
            });

            modelBuilder.Entity<CustomerPic>(entity =>
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

            modelBuilder.Entity<OrderShipping>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<OtpMessage>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<PaymentLog>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Apiconnect).HasColumnName("APIConnect");

                entity.Property(e => e.BankTranId).HasColumnName("bank_tran_id");

                entity.Property(e => e.CardBrand).HasColumnName("card_brand");

                entity.Property(e => e.CardIssuer).HasColumnName("card_issuer");

                entity.Property(e => e.CardIssuerCountry).HasColumnName("card_issuer_country");

                entity.Property(e => e.CardIssuerCountryCode).HasColumnName("card_issuer_country_code");

                entity.Property(e => e.CardNo).HasColumnName("card_no");

                entity.Property(e => e.CardType).HasColumnName("card_type");

                entity.Property(e => e.Currency).HasColumnName("currency");

                entity.Property(e => e.CurrencyAmount).HasColumnName("currency_amount");

                entity.Property(e => e.CurrencyRate).HasColumnName("currency_rate");

                entity.Property(e => e.CurrencyType).HasColumnName("currency_type");

                entity.Property(e => e.GwVersion).HasColumnName("gw_version");

                entity.Property(e => e.RiskLevel).HasColumnName("risk_level");

                entity.Property(e => e.RiskTitle).HasColumnName("risk_title");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.StoreAmount).HasColumnName("store_amount");

                entity.Property(e => e.TranDate).HasColumnName("tran_date");

                entity.Property(e => e.TranId).HasColumnName("tran_id");

                entity.Property(e => e.ValId).HasColumnName("val_id");

                entity.Property(e => e.ValidatedOn).HasColumnName("validated_on");
            });

            modelBuilder.Entity<PaymentTracker>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Perks>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<PrescriptionDocument>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<ProductComment>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<ProductContent>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<ProductImporter>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Html).HasColumnName("HTML");

                entity.Property(e => e.Mrp).HasColumnName("MRP");
            });

            modelBuilder.Entity<ProductInfo>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<ProductOffer>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<ProductOrder>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<ProductOrderItem>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<ProductRating>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<ProductSubCategory>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<ProductSubCategoryItem>(entity =>
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

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<RequestOrder>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<RewardPoint>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<RewardPointHistory>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<SafetyAdvice>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<SafetyItem>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<SafetyLabel>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<SpecialProduct>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<SubMenuItem>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
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

            modelBuilder.Entity<UploadPrescription>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<UrgentOrder>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<WishList>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
