using Backend.Dto;
using Backend.Models;

namespace Backend.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        User GetUser(int id);
        User GetUserTrimToUpper(UserDto userCreate);
        ICollection<Allergies> GetAllergieOfUser(int userId);
        bool CreateUser(int allergieId, User user);
        bool UserExists(int userId);
        bool UpdateUser(int allergieId, User user);
        bool DeleteUser(User user);
        bool Save();
    }
}
