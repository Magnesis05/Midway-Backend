using System.ComponentModel.DataAnnotations;
using Backend.Models;
using FluentValidation;
namespace Backend.Dto
    
{
    public class UserDto
    {
        public int Id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int phone_number { get; set; }
        public DateTime created_at { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string type_of_user { get; set; }
    }
}
