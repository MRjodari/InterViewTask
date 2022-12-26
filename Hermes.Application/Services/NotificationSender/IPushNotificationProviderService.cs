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
        Task<Guid[]> GetAllUser(String Content);
        Task<Guid[]> GetRemainedUser();
        Task<bool> AddRemainedUser(string message);
        Task<bool> ModifyUserMessage(Guid deviceId, string message);
        Task Send(Guid deviceIdentifier, string payload);
        Task SendToAllUserAsync(string payload);

        Task AutoCompleteSending(CancellationToken cancellationToken);
        Task AutoCancelUnCompletedSending(CancellationToken cancellationToken);

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

        public async Task<Guid[]> GetAllUser(String Content)
        {
            Guid[] AllUsers = (await _unitOfWork.UserRepository.GetAll()).Select(s1 => s1.DeviceIdentifier).ToArray();

            //foreach (var item in AllUsers.ToList().Select(s1 => s1.DeviceIdentifier))
            //{
            //    await _unitOfWork.UserMessageRepository
            //                        .Add(new UserMessage { DeviceId = item, Content = message, Status = false });
            //}
            int AllUserCout = AllUsers.Count();

            return AllUsers;

        }

        public async Task<Guid[]> GetRemainedUser()
        {
            var AllUsers = (await _unitOfWork.UserRepository.GetAll()).ToArray();
            var AllSentMessageUsers = (await _unitOfWork.UserMessageRepository.GetAll()).ToArray();

            var RemainedUser = AllUsers.Select(s1 => s1.DeviceIdentifier).Except(AllSentMessageUsers.Select(s2 => s2.DeviceId)).ToArray();
            return RemainedUser;
        }


        public async Task<bool> AddRemainedUser(string message)
        {
            bool result = false;
            try
            {
                var ReminedUsers = await GetRemainedUser();
                if (ReminedUsers.Any())
                {
                    foreach (var item in ReminedUsers)
                    {
                        await _unitOfWork.UserMessageRepository
                            .Add(new UserMessage
                            {
                                DeviceId = item,
                                Content = message,
                                Status = false
                            });
                        _unitOfWork.Save();
                    }
                    result = true;
                }

            }
            catch
            {
                throw new Exception(ErrorMessage.ReminedUsersEmpty.ToString());

            }
            return result;
        }

        public async Task<bool> ModifyUserMessage(Guid deviceId, string message)
        {

            var userMessageFound = await _unitOfWork.UserMessageRepository.GetById(deviceId);
            userMessageFound.Status = true;

            bool result = false;
            try
            {
                await _unitOfWork.UserMessageRepository.Update(userMessageFound);
                result = true;
            }
            catch
            {
                throw new Exception(ErrorMessage.NotFound.ToString());

            }
            return result;
        }


        public async Task Send(Guid deviceIdentifier, string payload)
        {
            // insert in user message table
            if (await ModifyUserMessage(deviceIdentifier, payload))
            {
                await _unitOfWork.Save();
            }
            await Task.Delay(100);
        }

        public async Task SendToAllUserAsync(string payload)
        {
            var currentUserMessages = await _unitOfWork.UserMessageRepository.GetAll();
            var users = await _unitOfWork.UserRepository.GetAll();
            if (users.Any())
            {
                if (currentUserMessages.Count() < users.Count())
                {
                    await AddRemainedUser(payload);

                }
                var waitingUsers = await _unitOfWork.UserMessageRepository.GetUndeiveredUsers();


                foreach (var item in waitingUsers.Select(s1 => s1.DeviceId))
                {
                    
                        await Send(item, payload);
                    
                }
                
            }
            else
            {
                throw new Exception(ErrorMessage.UsersEmpty.ToString());

            }
        }


        public async Task AutoCompleteSending(CancellationToken cancellationToken)

        {
            var waitingUsers = await _unitOfWork.UserMessageRepository.GetAll();
            //var users = await _unitOfWork.UserRepository.GetAll();
            if (waitingUsers.Any())
            {
                var messageContent = waitingUsers.Select(c1 => c1.Content).FirstOrDefault();
                await SendToAllUserAsync(messageContent);
            }
        }
        public async Task AutoCancelUnCompletedSending(CancellationToken cancellationToken)
        {

        }
    }

}
