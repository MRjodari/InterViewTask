using AutoMapper;
using Hermes.Application.Common;
using Hermes.Application.Interfaces.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.Application.Services.UserMessages.Commands.EditUserMessages
{
    public interface IEditUserMessagesService
    {

        Task<ResultDto> Execute(RequestEdituserMessagesDto request);

    }

    public class EditUserMessagesService : IEditUserMessagesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<IUserMessageRepository> _genericRepository;
        private readonly IMapper _mapper;
        public EditUserMessagesService(IUnitOfWork unitOfWork, IGenericRepository<IUserMessageRepository> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ResultDto> Execute(RequestEdituserMessagesDto request)
        {
            var user = await _unitOfWork.UserRepository.GetById(request.Id);

            if (user == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "User Not Found"
                };
            }

            user.UserName = request.UserName;

            await _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.Save();


            return new ResultDto()
            {
                IsSuccess = true,
                Message = "User Edited "
            };

        }
    }

    public class RequestEdituserMessagesDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public Guid DeviceIdentifier { get; set; }
        public DateTime RegisterDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
    }
}
