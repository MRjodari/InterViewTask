using Hermes.Application.Common;
using Hermes.Application.Interfaces.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.Application.Services.Users.Commands.RemoveUsers
{
    public class RemoveUserService: IRemoveUserService
    {
        //private readonly IAppDbContext _context;
        //public RemoveUserService(IAppDbContext context)
        //{
        //    _context = context;
        //}

        //public ResultDto Execute(long UserId)
        //{
        //    var user = _context.Users.Find(UserId);
        //    if (user == null)
        //    {
        //        return new ResultDto
        //        {
        //            IsSuccess = false,
        //            Message = "User Not Found"
        //        };
        //    }
        //    user.IsDeleted = true;
        //    await _unitOfWork.UserRepository.delete(user);
        //    await _unitOfWork.Save(); return new ResultDto()
        //    {
        //        IsSuccess = true,
        //        Message = "User Removed Successfully"
        //    };
        //}
    }
}
