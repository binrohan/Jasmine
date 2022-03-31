using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.Data.IServices;
using IqraCommerce.API.DTOs;
using IqraCommerce.API.Entities;

namespace IqraCommerce.API.Data.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repo, IProductRepository productRepo, IMapper mapper)
        {
            _mapper = mapper;
            _productRepo = productRepo;
            _repo = repo;
        }

        public async Task<IEnumerable<CategoryWithProductDto>> GetChildrenWithProducts(Guid categoryId)
        {
            var categories = await _repo.GetChildCategoriesAsync(categoryId);
            var categoryToReturn = _mapper.Map<IEnumerable<CategoryWithProductDto>>(categories);

            // IList<Category> moreCategories = new List<Category>();
            // if(categories.Count() > 0)
            // {
            //     IList<Category> existingCategories = new List<Category>();
            //     moreCategories = await GetChildrenCategories(existingCategories, categories);
            // }


            foreach (var category in categoryToReturn)
            {
                var products = await _productRepo.GetProductsByCategoryAsync(category.Id);
                var productsToReturn = _mapper.Map<IList<ProductShortDto>>(products);
                category.Products = productsToReturn;
            }





            return null;
        }

        private async Task<IList<ProductShortDto>> GetProducts(Guid categoryId)
        {
            var categories = await _repo.GetChildCategoriesAsync(categoryId);
            var categoryToReturn = _mapper.Map<IEnumerable<CategoryWithProductDto>>(categories);

            return productsToReturn.Concat();

        }

        Task<IEnumerable<Category>> ICategoryService.GetChildrenWithProducts(Guid categoryId)
        {
            throw new NotImplementedException();
        }
    }
}