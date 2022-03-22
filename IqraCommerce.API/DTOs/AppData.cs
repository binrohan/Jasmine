using System;
using System.Collections.Generic;

namespace IqraCommerce.API.DTOs
{
        public class AppDataModel
    {
        public AppDataModel() {
            TopCategories = new List<TopCategory>();
            DisplayCategories = new List<DisplayCategory>();
            Products = new List<DisplayCategory>();
            TopSlider = new List<Slider>();
            BottomSlider = new List<Slider>();
            Notice = new List<string>();
            Perks = new List<Perk>();
        }
        public List<TopCategory> TopCategories { get; set; }
        public List<DisplayCategory> DisplayCategories { get; set; }
        public List<DisplayCategory> Products { get; set; }
        public List<Slider> TopSlider { get; set; }
        public List<Slider> BottomSlider { get; set; }
        public List<string> Notice { get; set; }
        public List<Perk> Perks { get; set; }
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
        public string Name { get; set; }
        /// <summary>
        /// GenericName
        /// </summary>
        public string GenericName { get; set; }
        /// <summary>
        /// Strength
        /// </summary>
        public string Strength { get; set; }
        /// <summary>
        /// Category
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// Suplier
        /// </summary>
        public string Suplier { get; set; }
        /// <summary>
        /// MRP
        /// </summary>
        public double UnitSalePrice { get; set; }
        /// <summary>
        /// Discount
        /// </summary>
        public double Discount { get; set; }
        /// <summary>
        /// Image Path
        /// </summary>
        public string ImagePath { get; set; }
        /// <summary>
        /// Path Type
        /// </summary>
        public string ImageType { get; set; }
        /// <summary>
        /// Stock
        /// </summary>
        public double TotalStock { get; set; }
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
    public class Perk
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string IconPath { get; set; }
        public string Type { get; set; }
    }
}