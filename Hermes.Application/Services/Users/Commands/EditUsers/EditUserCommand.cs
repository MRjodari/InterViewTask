using AutoMapper;
using Hermes.Application.Interfaces.Repos;
using Hermes.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.Application.Services.Users.Commands.EditUsers
{
    public class EditUserCommand : IRequest<EditUserCommandResponse>
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }

    public class EditUserCommandResponse
    {
        public Guid UserId { get; set; }
    }
    public class EditUserCommandHandler : IRequestHandler<EditUserCommand, EditUserCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<IUserRepository> _genericRepository;
        private readonly IMapper _mapper;

        public EditUserCommandHandler(IUnitOfWork unitOfWork, IGenericRepository<IUserRepository> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<EditUserCommandResponse> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);


            await _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.Save();

            var response = new EditUserCommandResponse
            {
                UserId = user.Id
            };

            return response;
        }
    }
}
