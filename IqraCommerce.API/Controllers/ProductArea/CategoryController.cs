using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.DTOs;
using IqraCommerce.API.DTOs.Brand;
using IqraCommerce.API.DTOs.Contact;
using IqraCommerce.API.Entities;
using IqraCommerce.API.Extensions;
using IqraCommerce.API.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace IqraCommerce.API.Controllers.ProductArea
{
    public class CategoresController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repo;
        public CategoresController(IMapper mapper, IProductRepository repo)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategores()
        {
            var categoriesFromRepo = await _repo.GetCategoriesAsync();

            var categoriesToReturn = categoriesFromRepo.CreateHierarchicalOrder();

            return Ok(new ApiResponse(200, categoriesToReturn));
        }
    }
}