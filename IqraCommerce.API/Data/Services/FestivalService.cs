using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.Data.IServices;
using IqraCommerce.API.DTOs;
using IqraCommerce.API.Entities;

namespace IqraCommerce.API.Data.Services
{
    public class FestivalService : IFestivalService
    {
        private readonly IFestivalRepository _repo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public FestivalService(IFestivalRepository repo, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _repo = repo;
        }

        public async Task<IEnumerable<FestivalReturnDto>> GetFestivalsWithProductsAsync()
        {
            IList<FestivalReturnDto> list = new List<FestivalReturnDto>();

            var festivalsFromRepo = await _repo.GetFestivalsWithProductsAsync(10);

            foreach (var festival in festivalsFromRepo)
            {
                var item = _mapper.Map<FestivalReturnDto>(festival);
                item.Product = _mapper.Map<IEnumerable<ProductShortDto>>(festival.FestivalProducts);
                list.Add(item);
            }

            return list;
        }
    }
}