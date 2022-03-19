using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBonik.Data.Models.CommonArea
{
    public class AppDataModel
    {
        public AppDataModel() {
            TopCategories = new List<TopCategory>();
            DisplayCategories = new List<DisplayCategory>();
            Products = new List<DisplayCategory>();
            TopSlider = new List<Slider>();
            BottomSlider = new List<Slider>();
        }
        public List<TopCategory> TopCategories { get; set; }
        public List<DisplayCategory> DisplayCategories { get; set; }
        public List<DisplayCategory> Products { get; set; }
        public List<Slider> TopSlider { get; set; }
        public List<Slider> BottomSlider { get; set; }
    }
    public class TopCategory
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public string Nm { get; set; }
        /// <summary>
        /// Image Path
        /// </summary>
        public string Pt { get; set; }
    }
    public class DisplayCategory
    {
        public DisplayCategory() {
            Pt = new List<Products>();
        }
        public Guid Id { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public string Nm { get; set; }
        /// <summary>
        /// Products
        /// </summary>
        public List<Products> Pt { get; set; }

    }
    public class DisplayProduct
    {
        public DisplayProduct() {
            Pt = new List<Products>();
        }
        /// <summary>
        /// Name
        /// </summary>
        public string Nm { get; set; }
        /// <summary>
        /// Image Path
        /// </summary>
        public List<Products> Pt { get; set; }

    }
    public class Products
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public string Nm { get; set; }
        /// <summary>
        /// GenericName
        /// </summary>
        public string GN { get; set; }
        /// <summary>
        /// Strength
        /// </summary>
        public string St { get; set; }
        /// <summary>
        /// Category
        /// </summary>
        public string Ct { get; set; }
        /// <summary>
        /// Suplier
        /// </summary>
        public string Sp { get; set; }
        /// <summary>
        /// MRP
        /// </summary>
        public double MRP { get; set; }
        /// <summary>
        /// Discount
        /// </summary>
        public double Ds { get; set; }
        /// <summary>
        /// Image Path
        /// </summary>
        public string Pt { get; set; }
        /// <summary>
        /// Path Type
        /// </summary>
        public string Tp { get; set; }
        /// <summary>
        /// Stock
        /// </summary>
        public double Stk { get; set; }
    }
    public class Slider
    {
        /// <summary>
        /// Image Path
        /// </summary>
        public string Pt { get; set; }
        /// <summary>
        /// Url to Search
        /// </summary>
        public string Ur { get; set; }
    }
}
