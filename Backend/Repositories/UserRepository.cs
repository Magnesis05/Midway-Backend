using Backend.Data;
using Backend.Dto;
using Backend.Interfaces;
using Backend.Models;
using Backend.Validators;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;


namespace Backend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Allergies> GetAllergieOfUser(int userId)
        {
            return _context.UserAllergies.Where(p => p.User.Id == userId).Select(o => o.Allergies).ToList();
        }
        public bool DeleteUser(User user)
        {
            _context.Remove(user);
            return Save();
        }
        public ICollection<User> GetUsers()
        {
            return _context.Users.OrderBy(p => p.Id).ToList();
        }
        

        public User GetUser(int id)
        {
            return _context.Users.Where(p => p.Id == id).FirstOrDefault();
        }
        public User  GetUserTrimToUpper(UserDto userCreate)
        {
            return GetUsers().Where(c => c.first_name.Trim().ToUpper() == userCreate.first_name.TrimEnd().ToUpper())
                .FirstOrDefault();
        }
        public bool CreateUser(int allergieId, User user)
        {

            var allergie = _context.Allergies.Where(a => a.Id == allergieId).FirstOrDefault();

            var userAllergie = new UserAllergies()
            {
                User = user,
                Allergies = allergie,
            };
            

            _context.Add(userAllergie);

            _context.Add(user);

            return Save();
        }
        public bool UserExists(int userId)
        {
            return _context.Users.Any(p => p.Id == userId);
        }
        public bool UpdateUser(int allergieId, User user)
        {
            _context.Update(user);
            return Save();
        }
        public bool Save()
            {
                var saved = _context.SaveChanges();
                return saved > 0 ? true : false;
            }
        
    }
}
