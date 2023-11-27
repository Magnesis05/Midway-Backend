using System.ComponentModel.DataAnnotations;
using Backend.Models;

namespace Backend.Models
{
    public class Allergies
    {
        
        public int Id { get; set; }
        public string name { get; set; }
        public List<Users> Users { get; set; }
    }
}
