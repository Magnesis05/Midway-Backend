namespace Backend.Models
{
    public class UserAllergies
    {
        public int UserId { get; set; } 
        public int AllergieId { get; set; }
        public User User { get; set; }
        public Allergies Allergies { get; set; }
    }
}
