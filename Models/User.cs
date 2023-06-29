using System.Text.Json.Serialization;

namespace MyBLog.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password  { get; set; }
        public UserProfile Profile { get; set; }
    }

    public class UserProfile
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
