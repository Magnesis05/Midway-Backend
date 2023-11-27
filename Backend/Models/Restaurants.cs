using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Restaurants
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public List<Address> AddressId { get; set; }  
        public string? cuisine { get; set; }

        public ICollection<Bookings> Bookings_Id { get; set; }

    }
}
