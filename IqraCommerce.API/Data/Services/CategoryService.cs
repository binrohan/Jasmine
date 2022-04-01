using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.Data.IServices;
using IqraCommerce.API.DTOs;
using IqraCommerce.API.DTOs.Category;
using IqraCommerce.API.Entities;
using IqraCommerce.API.Extensions;
using IqraCommerce.API.Helpers;

namespace IqraCommerce.API.Data.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepo;
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepo, IProductRepository productRepo, IMapper mapper)
        {
            _mapper = mapper;
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
        }

        public async Task<object> GetChildrenWithProductsAsync(int take, Guid categoryId)
        {
            var categoriesFromRepo = await _categoryRepo.GetCategoriesAsync();

            var categoriesToReturn = categoriesFromRepo.CreateHierarchicalOrder();

            var categoryWithChildren = GetChildren(categoriesToReturn, categoryId);

            if(categoryWithChildren is null)
                return null;

            IList<CategoryWithProductDto> categoriesWithProductsToReturn = new List<CategoryWithProductDto>();
            foreach (var category in categoryWithChildren.ChildCategories)
            {
                var categoryWithProductDto = _mapper.Map<CategoryWithProductDto>(category);

                var listOfCategories = ExtractListOfCategoriesId(category.ChildCategories);

                var productsFromRepo = await _productRepo.GetProductsByCategoriesAsync(take, listOfCategories); 
                categoryWithProductDto.Products = _mapper.Map<IEnumerable<ProductShortDto>>(productsFromRepo);
                 
                categoriesWithProductsToReturn.Add(categoryWithProductDto);
            }

            return categoriesWithProductsToReturn;
        }

        private CategoryDto GetChildren(IList<CategoryDto> categories, Guid categoryId)
        {
            foreach (var category in categories)
            {
                if (category.Id == categoryId)
                    return category;

                GetChildren(category.ChildCategories, categoryId);
            }

            return null;
        }


        public IList<Guid> ExtractListOfCategoriesId(IList<CategoryDto> categories)
        {
            IList<Guid> listOfId = new List<Guid>();
            foreach (var category in categories)
            {
                listOfId.Add(category.Id);
                if(category.ChildCategories.Count() > 0)
                listOfId = listOfId.Concat(ExtractListOfCategoriesId(category.ChildCategories)).ToList();
            }

            return listOfId;
        }
    }
}