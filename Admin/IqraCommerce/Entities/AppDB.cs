using EBonik.Data.Entities.AddressArea;
using EBonik.Data.Entities.ContactArea;
using EBonik.Data.Entities.EmployeeArea;
using EBonik.Data.Entities.HistoryArea;
using EBonik.Data.Entities.UI;
using EBonik.Data.Entities.UserArea;
using IqraCommerce.Entities.OrderArea;
using IqraCommerce.Entities.ProductArea;
using IqraCommerce.Entities.PromotionArea;
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
        public virtual DbSet<Unit> Unit { get; set; } // Used
        public virtual DbSet<Category> Category { get; set; } // Used
        public virtual DbSet<Product> Product { get; set; } // Used
        public virtual DbSet<ProductCategory> ProductCategory { get; set; } // Used
        public virtual DbSet<ProductImage> ProductImage { get; set; } // Used
        public virtual DbSet<Festival> Festival { get; set; } // Used
        public virtual DbSet<FestivalProduct> FestivalProduct { get; set; } // Used
        #endregion

        #region Miscellaneous
        public virtual DbSet<Contact> Contact { get; set; } // Used
        public virtual DbSet<Register> Register { get; set; } // Used
        public virtual DbSet<Complain> Complain { get; set; } // Used
        #endregion

        #region UI
        public virtual DbSet<Banner> Banner { get; set; } // Used
        public virtual DbSet<Display> Display { get; set; } // Used
        public virtual DbSet<DisplayProduct> DisplayProduct { get; set; } // Used
        #endregion

        #region LocationArea
        public virtual DbSet<District> Distict { get; set; } // Used
        public virtual DbSet<Province> Province { get; set; } // Used
        public virtual DbSet<Upazila> Upazila { get; set; } // Used
        #endregion LocationArea

        #region UserArea
        public virtual DbSet<Customer> Customer { get; set; } // Used
        public virtual DbSet<CustomerAddress> Address { get; set; } // Used

        #endregion UserArea

        #region Promotion
        public virtual DbSet<Promotion> Promotion { get; set; } // Used
        public virtual DbSet<Coupon> Coupon { get; set; } // Used
        public virtual DbSet<Cashback> Cashback { get; set; } // Used
        public virtual DbSet<CashbackHistory> CashbackHistory { get; set; } // Used
        public virtual DbSet<CouponRedeemHistory> CouponRedeemHistory { get; set; } // Used
        public virtual DbSet<CashbackRegister> CashbackRegister { get; set; } // Used
        #endregion Promotion

        #region Order
        public virtual DbSet<Order> Order { get; set; } // Used
        public virtual DbSet<OrderProduct> OrderProduct { get; set; } // Used
        public virtual DbSet<OrderHistory> OrderHistory { get; set; } // Used
        public virtual DbSet<ShippingAddress> ShippingAddress { get; set; } // Used
        public virtual DbSet<OrderAquiredOffer> OrderAquiredOffer { get; set; } // Used
        public virtual DbSet<PaymentHistory> PaymentHistory { get; set; } // Used

        #endregion Order

        #region DeviceArea
        //public virtual DbSet<Device> Device { get; set; } // Used
        //public virtual DbSet<Activity> Activity { get; set; } // Used
        #endregion DeviceArea

        #region HistoryArea
        public virtual DbSet<ChangeHistory> ChangeHistory { get; set; }
        #endregion

        #region EmployeeArea
        public virtual DbSet<Employee> Employee { get; set; } // Used
        #endregion EmployeeArea




        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
    }
}
