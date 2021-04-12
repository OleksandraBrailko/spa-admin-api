using spm_api.Entity;
using spm_api.Services.Dtos.Models;
using System.Collections.Generic;

namespace spm_api.Interfaces.Services
{
    public interface IUserService
    {
        void CreateUser(UserDto userDto);
        void DeleteUser(int id);
        User GetUser(int id);
        IEnumerable<User> GetUsers();
        void UpdateUser(UserDto userDto);
        User Login(LoginDto loginDto);
    }
}
