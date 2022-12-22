using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.Application.Services.Users.Queries.GetUsers
{
    public interface IGetUsersService
    {
    }
    public class GetUsersService : IGetUsersService
    { }

    public class GetUsersDto
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }

    public class ResultGetUserDto
    {
        public List<GetUsersDto> Users { get; set; }
    }
}
