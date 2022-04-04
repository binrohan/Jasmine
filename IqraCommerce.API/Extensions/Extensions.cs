using System;
using System.Collections.Generic;
using System.Linq;
using IqraCommerce.API.DTOs;
using IqraCommerce.API.DTOs.Category;
using IqraCommerce.API.Entities;

namespace IqraCommerce.API.Extensions
{
    public static class Extensions
    {
        public static IEnumerable<Guid> GetAllChidren(this IEnumerable<Category> list, Guid categoryId)
        {
            IList<Guid> listOfChildren = new List<Guid>();

            list.GetAllChidrenRecursion(new List<Guid>(){categoryId}, ref listOfChildren);
            
            return listOfChildren;
        }

        private static IList<Guid> GetAllChidrenRecursion(this IEnumerable<Category> categories,
                                                   IEnumerable<Guid> targetIds, 
                                                   ref IList<Guid> listOfChildren)
        {
            IList<Guid> newChildren = new List<Guid>();

           foreach (var category in categories)
            {
                if(targetIds.Contains(category.ParentId))
                    newChildren.Add(category.Id);
            }

            listOfChildren = listOfChildren.Concat(newChildren).ToList();

            if(newChildren.Count() == 0)
                return listOfChildren;
            else
                return categories.GetAllChidrenRecursion(newChildren, ref listOfChildren);
        }
    }
}