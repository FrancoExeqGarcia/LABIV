using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using TP_LABIV.Data.Entities;
using TP_LABIV.Data.Models;
using ErrorOr;
using TP_LABIV.Services.Interfaces;

namespace TP_LABIV.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly TodoContext _context;

        public UserService(TodoContext context)
        {
            _context = context;
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User? GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email);
        }

        public bool CheckIfUserExists(string userEmail)
        {
            return _context.Users.Any(u => u.Email == userEmail);
        }

        public BaseResponse ValidateUser(string email)
        {
            BaseResponse response = new BaseResponse();
            User? userForLogin = _context.Users.SingleOrDefault(u => u.Email == email);
            if (userForLogin != null)
            {
                response.Message = "successful login";
                response.Result = true;
            }
            else
            {
                response.Result = false;
                response.Message = "wrong email";
            }
            return response;
        }

        public User CreateUser(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User? UpdateUser(int userId, User updateUser)
        {
            var existingUser = _context.Users.Find(userId);
            if (existingUser == null)
            {
                return null;
            }
            existingUser.Name = updateUser.Name;
            existingUser.Email = updateUser.Email;

            _context.SaveChanges();
            return existingUser;
        }

        public bool DeleteUser(int userId)
        {
            User userToBeDeleted = _context.Users.SingleOrDefault(u => u.UserId == userId);
            if (userToBeDeleted != null)
            {
                if (userToBeDeleted.State != false)
                {
                    userToBeDeleted.State = false;
                    _context.Update(userToBeDeleted);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(userToBeDeleted), "El User a ser eliminado no fue encontrado.");
            }
        }

        public User? GetUserById(int userId)
        {
            return _context.Users.FirstOrDefault(u => u.UserId == userId);
        }
    }
}