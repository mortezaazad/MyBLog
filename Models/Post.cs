using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace MyBLog.Models
{
    public class Post
    {
        //Dependent
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; } = string.Empty;
        public DateTime TimeCreated { get; set; }
        public int? BlogId { get; set; }

        public  List<Comment> Comments { get; set; }

        public Blog Blog { get; set; }

        public Collection<Tag> Tags { get; set; }

        public List<PostTags> PostTags { get; set; }
    }

    public class Tag
    {
        public string TagId { get; set; }
        [JsonIgnore]
        public Collection<Post> Posts { get; set; }
        [JsonIgnore]
        public List<PostTags> PostTags { get; set; }
    }

    public class PostTags
    {
        public  DateTime TimeCreated { get; set; }
        public string TagId { get; set; }
        public int PostId { get; set; }
        [JsonIgnore]
        public Post Post { get; set; }
        [JsonIgnore]
        public Tag Tag { get; set; }
    }

    public class Comment
    {
        public int Id { get; set; }
        public string Body { get; set; }

        public int PostId { get; set; }
    }
}
