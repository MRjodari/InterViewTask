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
        Task<Guid[]> GetAllUser();
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
       
        public PushNotificationProviderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        /// <summary>
        /// this method is going to get allUsers's DeviceId
        /// </summary>
        public async Task<Guid[]> GetAllUser()
        {
            Guid[] AllUsers = (await _unitOfWork.UserRepository.GetAll()).Select(s1 => s1.DeviceIdentifier).ToArray();
            int AllUserCout = AllUsers.Count();

            return AllUsers;
        }
        // <summary>
        /// this method is going to Get Remained user who they didn't push to message queue 
        /// </summary>
        public async Task<Guid[]> GetRemainedUser()
        {
            var AllUsers = (await _unitOfWork.UserRepository.GetAll()).ToArray();
            var AllSentMessageUsers = (await _unitOfWork.UserMessageRepository.GetAll()).ToArray();

            var RemainedUser = AllUsers.Select(s1 => s1.DeviceIdentifier).Except(AllSentMessageUsers.Select(s2 => s2.DeviceId)).ToArray();
            return RemainedUser;
        }

        // <summary>
        /// this method is going to insert Remained user who they didn't push to message queue 
        /// </summary>
        /// <param name="deviceId">
        /// each user provides this property when registering
        /// </param>
        /// <param name="message">
        /// message content
        /// </param>
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
        /// <summary>
        /// this method is going to Modify a user status after sending notification 
        /// </summary>
        /// <param name="deviceId">
        /// each user provides this property when registering
        /// </param>
        /// <param name="message">
        /// message content
        /// </param>
        public async Task<bool> ModifyUserMessage(Guid deviceId, string message)
        {

            var userMessageFound = await _unitOfWork.UserMessageRepository.GetById(deviceId);
            if (userMessageFound.Status == false)
            {
                bool result = false;
                try
                {
                    userMessageFound.Status = true;
                    await _unitOfWork.UserMessageRepository.Update(userMessageFound);
                    result = true;
                }
                catch
                {
                    throw new Exception(ErrorMessage.NotFound.ToString());

                }
                return result;
            }
            return true;
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
        public async Task Send(Guid deviceIdentifier, string payload)
        {
            // insert in user message table
            if (await ModifyUserMessage(deviceIdentifier, payload))
            {
                await _unitOfWork.Save();
            }
            await Task.Delay(100);
        }

        /// <summary>
        /// this method is going to Identify current user count who inserted to UserMessage Table and compare to AllUser
        /// then decide to reFilling UserMessage Table with Remained user 
        /// or send notification to currentUser who notification delivery-status is false. Finally Call Send Methode. 
        /// </summary
        /// <param name="payload">
        /// message content
        /// </param>
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

        /// <summary>
        /// this method is going to process uncompleting push notification to Users
        /// this methode called by Job scheduler
        /// </summary>
        /// <param name="cancellationToken">
        /// message content
        /// </param>
        public async Task AutoCompleteSending(CancellationToken cancellationToken)

        {
            var waitingUsers = await _unitOfWork.UserMessageRepository.GetAll();
            var users = await _unitOfWork.UserRepository.GetAll();
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
