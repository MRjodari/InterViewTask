using Hermes.Application.Common;
using Hermes.Application.Interfaces.Repos;
using Hermes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.Application.Services.NotificationSender
{
    public interface IPushNotificationProviderService
    {
        //IUnitOfWork _unitOfWork { get; }
        //IGenericRepository<IUserRepository> _userRepository { get; }
        //IGenericRepository<IUserMessageRepository> _userMessageRepository { get; }
        Task<bool> GetAllUser(String Content);

        Guid[] GetRemainedUser();
        Task Send(Guid deviceIdentifier, string payload);
        Task SendToAllUserAsync(string payload);

    }

    public class PushNotificationProviderService : IPushNotificationProviderService
    {
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IGenericRepository<IUserRepository> _userRepository;
        //private readonly IGenericRepository<IUserMessageRepository> _userMessageRepository;
        public PushNotificationProviderService(IUnitOfWork unitOfWork)
        {
            //_userRepository = userRepository;
            //_userMessageRepository = userMessageRepository;
            _unitOfWork = unitOfWork;
        }


        /// <summary>
        /// this method is going to send a notification to a user's device
        /// </summary>
        /// <param name="deviceIdentifier">
        /// each user provides this property when registering
        /// </param>
        /// <param name="payload">
        /// message content
        /// </param>

        public async Task<bool> GetAllUser(String message)
        {
            

            return true;

        }

        public Guid[] GetRemainedUser()
        {
            var AllUsers = (IEnumerable<User>)_unitOfWork.UserRepository.GetAll().Result;
            var AllSentMessageUsers = (IEnumerable<UserMessage>)_unitOfWork.UserMessageRepository.GetAll().Result;

            var RemainedUser = AllUsers.Select(s1 => s1.DeviceIdentifier).Except(AllSentMessageUsers.Select(s2 => s2.DeviceId)).ToArray();
            return RemainedUser;

        }

        public async Task Send(Guid deviceIdentifier, string payload)
        {
            // insert in user message table
            await _unitOfWork.UserMessageRepository.Add(new UserMessage { DeviceId = deviceIdentifier });
            await _unitOfWork.Save();
            await Task.Delay(100);
        }

        public async Task SendToAllUserAsync(string payload)
        {
            var ReminedUsers = GetRemainedUser();
            if (ReminedUsers.Any())
            {
                foreach (var item in ReminedUsers)
                {
                    await Send(item, payload);
                }
            }
            else
            {
                throw new Exception(ErrorMessage.ReminedUsersEmpty.ToString());
            }
        }
    }
}
