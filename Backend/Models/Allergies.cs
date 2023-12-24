using System.ComponentModel.DataAnnotations;
using Backend.Models;

namespace Backend.Models
{
    public class Allergies
    {
        
        public int Id { get; set; }
        public string name { get; set; }
        public ICollection<UserAllergies> UserAllergies { get; set; }
    }
}
