using Popravi.Business.DataTransfer;
using Popravi.Business.DataTransfer.User;
using Popravi.Business.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Popravi.Business.Services.Interfaces
{
   public interface IUserService
    {
        PagedResponse<UserDto> GetAllUsers(int pageNumber, int perPage);
        void RegisterUser(RegisterUserDto user);
        LoggedUserDto FindUser(string username, string password);
        UserDto FindById(int id);
        void UpdateUser(UserDto dto, int id);
        void UpdateUserPassword(string password, int id);
        bool IsOldPasswordCorrect(string password, int id);
        void ActivateUser(string activationCode);
    }
}
