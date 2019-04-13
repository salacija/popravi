using Popravi.Business.DataTransfer;
using Popravi.Business.DataTransfer.User;
using Popravi.Business.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Popravi.Business.Services.Interfaces
{
   public interface IUserService : ICrudService<UserDto, RegisterUserDto, UserDto>
    {
        LoggedUserDto FindUser(string username, string password);
        void UpdateUserPassword(string password, int id);
        bool IsOldPasswordCorrect(string password, int id);
        void ActivateUser(string activationCode);
    }
}
