using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.Data.IServices;
using IqraCommerce.API.DTOs;
using IqraCommerce.API.Helpers;
using IqraCommerce.API.Params;

namespace IqraCommerce.API.Data.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _repo;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerNotificationRepository _customerNotificationRepo;

        public NotificationService(INotificationRepository repo,
                                   IMapper mapper,
                                   IUnitOfWork unitOfWork,
                                   ICustomerNotificationRepository customerNotificationRepo)
        {
            _customerNotificationRepo = customerNotificationRepo;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<int> MarkNotificationAsSeenAsync(IList<Guid> ids, Guid customerId)
        {
            var notificationsFromRepo = await _customerNotificationRepo.GetCustomerNotificationAsync(ids, customerId);

            foreach (var notification in notificationsFromRepo)
            {
                notification.IsRead = true;
            }

            return await _unitOfWork.Complete();
        }

        public async Task<Pagination<NotificationReturnDto>> GetNotificationsAsync(NotificationParamsDto paramDto, Guid customerId)
        {
            NotificationParam param = new NotificationParam(customerId, paramDto.Index, paramDto.Take);

            var totalNotifications = await _repo.CountAsync(param);

            var notificaionsFromRepo = await _repo.GetNotificationsAsync(param);

            var notificaionsToReturn = _mapper.Map<IReadOnlyList<NotificationReturnDto>>(notificaionsFromRepo);

            return new Pagination<NotificationReturnDto>(param.Index,
                                                param.Take,
                                                totalNotifications,
                                                notificaionsToReturn);
        }
    }
}