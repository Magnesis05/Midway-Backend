using Backend.Data;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;


namespace Backend.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DataContext _context;

        public UsersRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Users> GetUsers() 
        {
            return _context.Users.OrderBy(p=>p.Id).ToList();
        }

        public Users GetUser(int id)
        {
            return _context.Users.Where(p => p.Id == id).FirstOrDefault();
        }
    }
}
