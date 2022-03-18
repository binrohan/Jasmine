using System.Collections.Generic;
using System.Linq;
using IqraCommerce.API.DTOs.Brand;
using IqraCommerce.API.DTOs.Category;
using IqraCommerce.API.Entities;

namespace IqraCommerce.API.Extensions
{
    public static class DtoGenerators
    {
        public static IDictionary<char, IList<BrandReturnDto>> CreateDict(this IEnumerable<Brand> list)
        {
            Dictionary<char, IList<BrandReturnDto>> dict = new();

            for (int i = 97; i <= 122; i++)
            {
                dict.Add((char)i, new List<BrandReturnDto>());
            }

            foreach (var item in list)
            {
                var c = item.Name.ToLower()[0];
                if (dict.ContainsKey(c))
                {
                    dict[c].Add(new BrandReturnDto()
                    {
                        Id = item.Id,
                        Name = item.Name
                    });
                }
            }


            return dict;
        }

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
                        ChildCategores = new List<CategoryDto>()
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
                    item.ChildCategores.Add(new CategoryDto
                    {
                        Id = lostChild.Id,
                        Name = lostChild.Name,
                        ChildCategores = new List<CategoryDto>()
                    });

                    break;
                }
                else if (item.ChildCategores.Count() > 0)
                {
                    BFS(item.ChildCategores, lostChild);
                }

            }
        }
    }
}