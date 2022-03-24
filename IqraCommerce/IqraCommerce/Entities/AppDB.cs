using EBonik.Data.Entities.AddressArea;
using EBonik.Data.Entities.AppDataArea;
using EBonik.Data.Entities.BlogArea;
using EBonik.Data.Entities.CareerArea;
using EBonik.Data.Entities.CheckoutArea;
using EBonik.Data.Entities.CommonArea;
using EBonik.Data.Entities.ContactArea;
using EBonik.Data.Entities.CustomerArea;
using EBonik.Data.Entities.DataArea;
using EBonik.Data.Entities.DataCenterArea;
using EBonik.Data.Entities.FindStoreArea;
using EBonik.Data.Entities.HistoryArea;
using EBonik.Data.Entities.MessagingArea;
using EBonik.Data.Entities.NoticeArea;
using EBonik.Data.Entities.OfferArea;
using EBonik.Data.Entities.PaymentArea;
using EBonik.Data.Entities.ProductOrderArea;
using EBonik.Data.Entities.PromotionalArea;
using EBonik.Data.Entities.RequestOrderArea;
using EBonik.Data.Entities.ReviewArea;
using EBonik.Data.Entities.UI;
using EBonik.Data.Entities.UrgentOrderArea;
using EBonik.Data.Entities.WishListArea;
using IqraCommerce.Entities.ProductArea;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace IqraCommerce.Entities
{
    public class AppDB : DbContext
    {
        private static DbContextOptions<AppDB> options { get; set; }
        public static DbContextOptions<AppDB> Options
        {
            get
            {
                if (options == null)
                {
                    options = new DbContextOptionsBuilder<AppDB>()
                 .UseSqlServer(new SqlConnection(Startup.ConnectionString))
                 .Options;
                }
                return options;
            }
        }
        public AppDB(DbContextOptions<AppDB> options) : base(options) { 
        
        }

        public AppDB():base(Options)
        {

        }

        #region Product Area
        public virtual DbSet<Brand> Brand { get; set; } // Used
        public virtual DbSet<Unit> Unit { get; set; } // Used
        public virtual DbSet<Category> Category { get; set; } // Used
        public virtual DbSet<Product> Product { get; set; } // Used
        public virtual DbSet<ProductCategory> ProductCategory { get; set; } // Used
        #endregion

        #region Miscellaneous
        public virtual DbSet<Contact> Contact { get; set; } // Used
        #endregion

        #region UI
        public virtual DbSet<Banner> Banner { get; set; } // Used
        public virtual DbSet<Showcase> Showcase { get; set; } // Used
        #endregion



        #region HistoryArea
        public virtual DbSet<ChangeHistory> ChangeHistory { get; set; }
        #endregion

        #region CheckoutArea
        public virtual DbSet<MyCart> MyCart { get; set; }
        public virtual DbSet<MyWishlist> MyWishlist { get; set; }
        #endregion

        #region AppDataArea

        public virtual DbSet<DisplayCategory> DisplayCategory { get; set; }
        public virtual DbSet<AppCategory> AppCategory { get; set; }
        public virtual DbSet<AppCategoryProduct> AppCategoryProduct { get; set; }
        public virtual DbSet<CategorySlider> CategorySlider { get; set; }
        #endregion

        #region CommonArea
        public virtual DbSet<Perks> Perks { get; set; }
        #endregion



        #region Complain
        //public virtual DbSet<Complain> Complain { get; set; }
        //public virtual DbSet<ComplainImage> ComplainImage { get; set; }
        #endregion 

        #region OfferArea
        public virtual DbSet<ProductOffer> ProductOffer { get; set; }
        public virtual DbSet<DiscountOffer> DiscountOffer { get; set; }
        public virtual DbSet<DiscountOfferPic> DiscountOfferPic { get; set; }
        #endregion

        #region ProductOrderArea
        public virtual DbSet<OrderPayment> OrderPayment { get; set; }
        public virtual DbSet<OrderPaymentMethod> OrderPaymentMethod { get; set; }
        public virtual DbSet<OrderShipping> OrderShipping { get; set; }
        public virtual DbSet<ProductOrder> ProductOrder { get; set; }
        public virtual DbSet<UploadPrescription> UploadPrescription { get; set; }
        public virtual DbSet<ProductOrderItem> ProductOrderItem { get; set; }
        public virtual DbSet<PrescriptionDocument> PrescriptionDocument { get; set; }
        public virtual DbSet<PaymentLog> PaymentLog { get; set; }
        public virtual DbSet<PaymentTracker> PaymentTracker { get; set; }
        public virtual DbSet<ErrorOeder> ErrorOeder { get; set; }
        //public virtual DbSet<ShippingCharge> ShippingCharge { get; set; }
        #endregion

        #region CustomerArea
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerPic> CustomerPic { get; set; }
        //public virtual DbSet<CustomerPayment> CustomerPayment { get; set; }

        #endregion

        #region FindStoreArea
        public virtual DbSet<FindStore> MyFindStore { get; set; }

        #endregion
        #region DataArea
        public virtual DbSet<DataImporter> DataImporter { get; set; }
        public virtual DbSet<ProductImporter> ProductImporter { get; set; }

        #endregion
        #region DataCenterArea
        public virtual DbSet<MedProduct> MedProduct { get; set; }
        public virtual DbSet<MedProductPriceChanged> MedProductPriceChanged { get; set; }
        #endregion

        #region RequestOrderArea
        public virtual DbSet<RequestOrder> RequestOrder { get; set; }
        #endregion

        #region UrgentOrderArea
        public virtual DbSet<UrgentOrder> UrgentOrder { get; set; }
        #endregion

        #region PromotionalArea
        public virtual DbSet<RewardPoint> RewardPoint { get; set; }
        public virtual DbSet<RewardPointHistory> RewardPointHistory { get; set; }
        public virtual DbSet<Coupon> Coupon { get; set; }
        public virtual DbSet<CouponHistory> CouponHistory { get; set; }
        #endregion

        #region WishListArea
        public virtual DbSet<WishList> WishList { get; set; }

        #endregion

        #region BlogArea
        public virtual DbSet<Blog> Blog { get; set; }
        public virtual DbSet<BlogCategory> BlogCategory { get; set; }
        #endregion

        #region ReviewArea
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Rating> Rating { get; set; }
        public virtual DbSet<AppReview> AppReview { get; set; }
        public virtual DbSet<Liker> Liker { get; set; }
        #endregion

        #region AddressArea
        public virtual DbSet<District> Distict { get; set; }
        public virtual DbSet<Province> Province { get; set; }
        public virtual DbSet<Union> Union { get; set; }
        public virtual DbSet<Upazila> Upazila { get; set; }
        public virtual DbSet<Thana> Thana { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        #endregion

        #region CareerArea
        public virtual DbSet<Career> Career { get; set; }
        public virtual DbSet<CareerDocument> CareerDocument { get; set; }
        #endregion

        #region ContactArea
        #endregion

        #region NoticeArea
        public virtual DbSet<Notice> Notice { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<NotificationStatus> NotificationStatus { get; set; }
        #endregion
        #region MessagingArea
        public virtual DbSet<OtpMessage> OtpMessage { get; set; }
        #endregion


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
    }
}
