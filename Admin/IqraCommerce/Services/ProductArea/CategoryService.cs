using EBonik.Data.Models.ContactArea;
using IqraBase.Data;
using IqraBase.Service;
using IqraCommerce.Entities;
using IqraCommerce.Entities.ProductArea;
using IqraCommerce.Helpers;
using IqraCommerce.Models.ProductArea;
using IqraCommerce.Services.HistoryArea;
using IqraService.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IqraCommerce.Services.ProductArea
{
    public class CategoryService : IqraCommerce.Services.AppBaseService<Category>
    {
        public override string GetName(string name)
        {
            switch (name.ToLower())
            {
                case "creator":
                    name = "ctr.Name";
                    break;
                case "updator":
                    name = "updtr.Name";
                    break;
                case "customer":
                    name = "cstmr.[Name]";
                    break;
                default:
                    name = "category." + name;
                    break;
            }
            return base.GetName(name);
        }

        public override async Task<ResponseList<Pagger<Dictionary<string, object>>>> Get(Page page)
        {
            page.SortBy = page.SortBy ?? "[Level] asc";
            using (var db = new DBService(this))
            {
                var data = await db.GetPages(page, CategoryQuery.Get());
                return  data;
            }
        }

        public async Task<ResponseList<Pagger<Dictionary<string, object>>>> GetExceptByProduct(Page page, Guid productId)
        {
            page.filter.Add(new FilterModel()
            {
                Operation = Operations.NotIn,
                field = "Id",
                value = @"SELECT productcategory.CategoryId 
                FROM ProductCategory productcategory
                WHERE productcategory.ProductId = '" + productId + "'"

            });
            page.SortBy = page.SortBy ?? "[Level] asc";
            using (var db = new DBService(this))
            {
                return await db.GetPages(page, CategoryQuery.GetExceptByProduct());
            }
        }

        public Response Create(CategoryModel categoryToCreate, Guid userId)
        {
            if (!categoryToCreate.IsRoot && categoryToCreate.ParentId == Guid.Empty)
                return new Response(-406, null, true, "Non root category without parent not acceptable");

            if (categoryToCreate.IsRoot)
            {
                categoryToCreate.ParentId = Guid.Empty;
                categoryToCreate.Depth = 0;
                categoryToCreate.Hierarchy = categoryToCreate.Name;
                categoryToCreate.Level = categoryToCreate.Rank.ToString();
            } 
            

            categoryToCreate.Rank = categoryToCreate.Rank == 0 ? 999 : categoryToCreate.Rank;
            

            if (!categoryToCreate.IsRoot)
            {
                var parentCategory = Entity.Find(categoryToCreate.ParentId);

                if (parentCategory is null) return new Response(404, null, true, "Parent category not found");

                categoryToCreate.Level = parentCategory.Level + "/" + categoryToCreate.Rank.ToString();
                categoryToCreate.ParentName = parentCategory.Name;
                categoryToCreate.Depth = parentCategory.Depth + 1;
                categoryToCreate.Hierarchy = parentCategory.Hierarchy + ">>" + categoryToCreate.Name;
            }

            Insert(categoryToCreate, userId);

           SaveChange();

            return new Response(201, categoryToCreate, false, "Created");
        }

        public Response Delete(Guid id)
        {
            var categoryFromRepo = Entity.Find(id);

            if (categoryFromRepo is null) return new Response(404, null, true, "Category Not Found");

            categoryFromRepo.IsDeleted = true;

            UpdateChildrenAfterDelete(categoryFromRepo);

            SaveChange();

            return new Response(204, null, false, "Deleted");
        }

        private void UpdateChildrenAfterDelete(Category parentCategory)
        {
            var categories = Entity.Where(c => c.ParentId == parentCategory.Id).ToList();
            var superCategory = Entity.Find(parentCategory.ParentId);

            foreach (var category in categories)
            {
                category.ParentId = parentCategory.ParentId;

                category.Hierarchy = superCategory.Hierarchy + ">>" + category.Name;
                category.Level = superCategory.Level + "/" + category.Rank.ToString();
                category.Depth = superCategory.Depth + 1;

                UpdateChildrenAfterDelete(category);
            }

        }

        public Response Update(CategoryModel categoryToUpdate, Guid userId)
        {
            var categoryFromRepo = Entity.Find(categoryToUpdate.Id);
            if (categoryFromRepo is null) return new Response(404, null, true, "Category Not Found");

            categoryFromRepo.Name = categoryToUpdate.Name;
            categoryFromRepo.Remarks = categoryToUpdate.Remarks;
            categoryFromRepo.IsVisible = categoryToUpdate.IsVisible;

            if (!categoryFromRepo.IsRoot && categoryToUpdate.ParentId == Guid.Empty)
                return new Response(-406, null, true, "Non root category without parent not acceptable");

            categoryFromRepo.Rank = categoryToUpdate.Rank == 0 ? 999 : categoryToUpdate.Rank;

            if (!categoryFromRepo.IsRoot)
            {
                var parentCategory = Entity.Find(categoryToUpdate.ParentId);

                if (parentCategory is null) return new Response(404, null, true, "Parent category not found");

                categoryFromRepo.Level = parentCategory.Level + "/" + categoryToUpdate.Rank.ToString();
                categoryFromRepo.Hierarchy = parentCategory.Hierarchy + ">>" + categoryToUpdate.Name;
                categoryFromRepo.ParentId = parentCategory.ParentId;
                categoryFromRepo.Depth = parentCategory.Depth + 1;

                UpdateChildren(categoryFromRepo);
            }
            else
            {
                categoryFromRepo.Level = categoryToUpdate.Rank.ToString();
                categoryFromRepo.ParentId = Guid.Empty;
                categoryFromRepo.Depth = 0;
            }

            SaveChange();

            return new Response(204, categoryToUpdate, false, "Updated");
        }

        private void UpdateChildren(Category parentCategory)
        {
            var categories = Entity.Where(c => c.ParentId == parentCategory.Id).ToList();

            foreach (var category in categories)
            {
                category.Hierarchy = parentCategory.Hierarchy + ">>" + category.Name;
                category.Level = parentCategory.Level + "/" + category.Rank.ToString();
                category.Depth = parentCategory.Depth + 1;

                UpdateChildren(category);
            }
        }
    }

    public class CategoryQuery
    {
        public static string GetExceptByProduct()
        {
            return @"[Category].[Id]
                    ,[Category].[Name]
                    ,[Category].[Hierarchy] 
            FROM Category category";
        }
        public static string Get()
        {
            return @"[Id]
                  ,[CreatedAt]
                  ,[CreatedBy]
                  ,[UpdatedAt]
                  ,[UpdatedBy]
                  ,[IsDeleted]
                  ,[Remarks]
                  ,[ActivityId]
                  ,[Name]
                  ,[IsRoot]
                  ,[ParentId]
                  ,[Rank]
                  ,[Level]
                  ,[IsVisible]
                  ,[Depth]
                  ,[IsVisibleInHome]
                  ,[Hierarchy]
	              ,0 [ChildrenCount]
                  ,0 [ProductCount]
                  ,ISNULL([ParentName], '') [ParentName]
              FROM [dbo].[Category] category";
        }
    }
}
