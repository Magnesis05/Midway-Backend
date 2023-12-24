using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Bookings
    {
        [Key]
        public int Id { get; set; }
        public User booking_user_id { get; set; }
        public Restaurants booking_restaurant_id { get; set; }
        public DateTime created_at { get; set; }
        public bool accepted_by_manager { get; set; }
        public uint number_of_table { get; set; }
        public DateTime booking_time_from { get; set; }
        public DateTime booking_time_by { get; set; }
        public string? description { get; set; }


    }
}
