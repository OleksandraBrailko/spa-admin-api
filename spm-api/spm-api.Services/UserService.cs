using Microsoft.EntityFrameworkCore;
using spm_api.Entity;
using spm_api.Interfaces.Services;
using spm_api.Services.Dtos.Models;
using spm_api.Services.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace spm_api.Services
{
    public class UserService : IUserService
    {
        private readonly SpmDbContext _dbContext;

        public UserService(SpmDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateUser(UserDto userDto)
        {
            _dbContext.Users.Add(GetUser(userDto));
            _dbContext.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            _dbContext.Users.Remove(new User { Id = id });
            _dbContext.SaveChanges();
        }

        public User GetUser(int id)
        {
            return _dbContext.Users.Include(item => item.Groups).FirstOrDefault(item => item.Id == id);
        }

        public IEnumerable<User> GetUsers()
        {
            return _dbContext.Users.Include(item => item.Groups);
        }

        public void UpdateUser(UserDto userDto)
        {
            _dbContext.Update(GetUser(userDto));
            _dbContext.SaveChanges();
        }

        public User Login(LoginDto loginDto)
        {
            var user = _dbContext.Users.FirstOrDefault(item => item.Email == loginDto.Email && item.PasswordHash == HashHelper.GetSha256Hash(loginDto.Password));

            return user;
        }

        private User GetUser(UserDto userDto)
        {
            return new User
            {
                Id = userDto.Id ?? 0,
                UserName = userDto.UserName,
                Email = userDto.Email,
                PasswordHash = HashHelper.GetSha256Hash(userDto.Password),
                IsAmin = userDto.IsAmin
            };
        }
    }
}
