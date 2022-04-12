using EBonik.Data.Entities.AddressArea;
using EBonik.Data.Entities.ContactArea;
using EBonik.Data.Entities.HistoryArea;
using EBonik.Data.Entities.UI;
using EBonik.Data.Entities.UserArea;
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
        public virtual DbSet<Brand> Brand { get; set; } // Used
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
        public virtual DbSet<Showcase> Showcase { get; set; } // Used
        #endregion

        #region LocationArea
        public virtual DbSet<District> Distict { get; set; } // Used
        public virtual DbSet<Province> Province { get; set; } // Used
        public virtual DbSet<Upazila> Upazila { get; set; } // Used
        #endregion LocationArea

        #region UserArea
        public virtual DbSet<Customer> Customer { get; set; } // Used
        public virtual DbSet<CustomerAddress> Address { get; set; } // Used
        public virtual DbSet<Wishlist> Wishlist { get; set; } // Used

        #endregion UserArea

        #region Promotion
        public virtual DbSet<Offer> Offer { get; set; } // Used
        #endregion Promotion



        #region HistoryArea
        public virtual DbSet<ChangeHistory> ChangeHistory { get; set; }
        #endregion

  


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
    }
}
