using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; } 
         public string city { get; set; }
        public string district { get; set; }
        public string street { get; set; }
        public List<Restaurants> Restaurants { get; set;}


    }
}
