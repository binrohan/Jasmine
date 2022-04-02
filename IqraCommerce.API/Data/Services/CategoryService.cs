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
        private CategoryDto category;
        private readonly ICategoryRepository _categoryRepo;
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepo, IProductRepository productRepo, IMapper mapper)
        {
            _mapper = mapper;
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
        }

        public async Task<object> GetChildrenWithProductsAsync(Guid categoryId)
        {
            var categoriesFromRepo = await _categoryRepo.GetCategoriesAsync();

            var categoriesToReturn = categoriesFromRepo.CreateHierarchicalOrder();

            GetChildren(categoriesToReturn, categoryId);

            if(category is null)
                return null;

            IList<CategoryWithProductDto> categoriesWithProductsToReturn = new List<CategoryWithProductDto>();
            foreach (var category in category.ChildCategories)
            {
                var categoryWithProductDto = _mapper.Map<CategoryWithProductDto>(category);

                var listOfCategories = ExtractListOfCategoriesId(category.ChildCategories);
                listOfCategories.Add(category.Id);

                var productsFromRepo = await _productRepo.GetProductsByCategoriesAsync(10, listOfCategories); 
                categoryWithProductDto.Products = _mapper.Map<IEnumerable<ProductShortDto>>(productsFromRepo);
                
                categoriesWithProductsToReturn.Add(categoryWithProductDto);
            }

            return categoriesWithProductsToReturn;
        }

        private void GetChildren(IList<CategoryDto> categories, Guid categoryId)
        {
            foreach (var category in categories)
            {
                if(this.category is not null)
                    break;

                if (category.Id == categoryId)
                {
                    this.category = category;
                    break;
                }
                    

                GetChildren(category.ChildCategories, categoryId);
            }
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