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
        private List<Category> retrivedCategorise;
        private readonly ICategoryRepository _repo;
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repo, IProductRepository productRepo, IMapper mapper)
        {
            _mapper = mapper;
            _productRepo = productRepo;
            _repo = repo;
        }

        public async Task<List<List<Category>>> GetChildrenWithProducts(Guid categoryId)
        {
            var categories = await _repo.GetChildCategoriesAsync(categoryId);
            var categoryToReturn = _mapper.Map<IEnumerable<CategoryWithProductDto>>(categories);

            
            var output = new List<List<Category>>();
            
            foreach (var category in categoryToReturn)
            {
                retrivedCategorise = new List<Category>();

                GetChildrenCategory(category.Id);

                output.Add(retrivedCategorise);
            }





            return output;
        }

        private async void GetChildrenCategory(Guid categoryId)
        {
           var categories = await _repo.GetChildCategoriesAsync(categoryId);

        //    if(categories.Count() == 0)
        //         return categories;
            
           retrivedCategorise = retrivedCategorise.Concat(categories).ToList();

            foreach (var category in categories)
            {
                GetChildrenCategory(category.Id);
            }

        //    return retrivedCategorise;
        }
    }
}