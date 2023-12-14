using Backend.Models;

namespace Backend.Interfaces
{
    public interface IUsersRepository
    {
        ICollection<Users> GetUsers(); 
        Users GetUser(int id);
    }
}
