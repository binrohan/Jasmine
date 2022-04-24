using System.Collections.Generic;
using System.Linq;
using IqraCommerce.API.DTOs;
using IqraCommerce.API.DTOs.Category;
using IqraCommerce.API.Entities;

namespace IqraCommerce.API.Extensions
{
    public static class DtoGenerators
    {
        public static IList<CategoryDto> CreateHierarchicalOrder(this IEnumerable<Category> list)
        {
            IList<CategoryDto> categories = new List<CategoryDto>();

            foreach (var item in list)
            {
                if (item.IsRoot)
                {
                    categories.Add(new CategoryDto
                    {
                        Id = item.Id,
                        Name = item.Name,
                        ChildCategories = new List<CategoryDto>()
                    });
                }
                else
                {
                    BFS(categories, item);
                }


            }

            return categories;
        }

        public static void BFS(IList<CategoryDto> list, Category lostChild)
        {
            foreach (var item in list)
            {
                if (item.Id == lostChild.ParentId)
                {
                    item.ChildCategories.Add(new CategoryDto
                    {
                        Id = lostChild.Id,
                        Name = lostChild.Name,
                        ChildCategories = new List<CategoryDto>()
                    });

                    break;
                }
                else if (item.ChildCategories.Count() > 0)
                {
                    BFS(item.ChildCategories, lostChild);
                }

            }
        }


        public static IList<object> ToArray(this IEnumerable<CategoryDto> list)
        {
            IList<object> categoryArray = new List<object>();

            foreach (var item in list)
            {
                IList<object> itemArray = new List<object>();

                itemArray.Add(item.Id);
                itemArray.Add(item.Name);
                itemArray.Add(new List<object>());


                if (item.ChildCategories.Count() > 0)
                {
                    var children = item.ChildCategories.ToArray();
                    itemArray[2] = children;
                }

                categoryArray.Add(itemArray);
            }

            return categoryArray;
        }

        public static IList<object> ToArray(this IEnumerable<Banner> list)
        {
            IList<object> banners = new List<object>();

            foreach (var item in list)
            {
                banners.Add(new List<object>()
                {
                    item.Id,
                    item.ImageURL,
                    item.Link,
                    item.Rank,
                    item.Size
                });
            }

            return banners;
        }

        public static IList<object> ToArray(this IEnumerable<Notice> list)
        {
            IList<object> banners = new List<object>();

            foreach (var item in list)
            {
                banners.Add(new List<object>()
                {
                    item.Id,
                    item.Content,
                    item.StartDate,
                    item.EndDate,
                    item.Rank
                });
            }

            return banners;
        }
    }
}