# Dotnet Interview
Imaging you are creating a project to send a push notification
to all of the customers in the system.

## System Requirement
1. we currently have 10k customers in our system; your push notification provider is a sync service with no queue.
2. Follow the **clean architecture** principles
3. have clean **git commits** that show your work progress.
4. create an API for admins to send a message to all the users
5. **provide a solution to scale the API horizontally**
6. your push notification provider is this
```csharp
    public class PushNotificationProviderService
    {
        /// <summary>
        /// this method is going to send a notification to a user's device
        /// </summary>
        /// <param name="deviceIdentifier">
        /// each user provides this property when registering
        /// </param>
        /// <param name="payload">
        /// message content
        /// </param>
        public async Task send(Guid deviceIdentifier, string payload)
        {
            await Task.Delay(100);
        }
    }
```
imagine `deviceIdentifier` is already saved in the user DB
(you can create a random `guid` or use `userId`)

## Delivery
Please clone this repository in a new GitHub repository,
then create a [pull request](https://docs.github.com/en/pull-requests/collaborating-with-pull-requests/proposing-changes-to-your-work-with-pull-requests/about-pull-requests) (code review),
then merge your pull requests

## Notes
1. you can ask questions whenever you need more information on a topic
2. mock the data as much as you want

## What We Want To See In Your Code
1. Clean architect and code
2. Simple and practical solutions to send messages to
   all users without losing the state (imaging server restarts in the middle of sending messages)
3. Providing a distributed solution so we can scale it when our users increase

## Nice to have
1. TDD
2. running the whole project in [docker compose](https://learn.microsoft.com/en-us/aspnet/core/security/docker-compose-https?view=aspnetcore-7.0)
   (including the databases or other services if you use any)
