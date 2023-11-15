using System.ComponentModel.DataAnnotations;

namespace Backend
{
   
    public class Users
    {
        [Key]   
        public int id { get; set; }
        public string username { get; set; }
        public int role { get; set; }
        public DateTime created_at { get; set; }
    }
    public class Posts
    {
        [Key]
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public Users user_id { get; set; }
        public string status { get; set; }
        public DateTime created_at { get; set; }
    }
    public class Follows 
    {
        [Key]
        public int id { get; set; }
        public Users following_user_id { get; set; }
        public Users followed_user_id { get; set; }
        public DateTime created_at { get; set; }
    }
}