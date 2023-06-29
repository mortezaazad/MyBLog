using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace MyBLog.Models
{
    public class Blog
    {
        //Principal
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public Collection<Post> Posts{ get; set; }
    }
}
