using System.ComponentModel.DataAnnotations;
using Backend.Models;

namespace Backend.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int phone_number { get; set; }
        public DateTime created_at { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public List<Allergies> Allergies { get; set; }
        public ICollection<Bookings> Bookings_Id { get; set; }
        
    }
}
