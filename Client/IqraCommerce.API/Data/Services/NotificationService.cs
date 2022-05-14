using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using IqraCommerce.API.Data.IRepositories;
using IqraCommerce.API.Data.IServices;

namespace IqraCommerce.API.Data.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepo;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public NotificationService(INotificationRepository notificationRepo,
                                   IMapper mapper,
                                   IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _notificationRepo = notificationRepo;
        }

        public async Task<int> MarkNotificationAsSeenAsync(IList<Guid> ids, Guid customerId)
        {
            throw new NotImplementedException();
        }
    }
}