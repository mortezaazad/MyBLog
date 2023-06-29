using Microsoft.EntityFrameworkCore;
using MyBLog.Models;

namespace MyBLog.Data
{
    public class BlogDbContext:DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options)
            : base(options) {  }
        public DbSet<User> User{ get; set; }
        public DbSet<Blog> Blogs{ get; set; }
        public DbSet<Post> Posts{ get; set; }
        public DbSet<Comment> Comments{ get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTags> PostTags { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Cascade
            modelBuilder.Entity<Post>()
                .HasOne(p => p.Blog)
                .WithMany(p => p.Posts);
                //.OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<PostTags>()
                .HasKey(pt => new { pt.PostId, pt.TagId });
            modelBuilder.Entity<PostTags>()
                .HasOne(pt => pt.Post)
                .WithMany(pt => pt.PostTags)
                .HasForeignKey(pt => pt.PostId);

            modelBuilder.Entity<PostTags>()
                .HasOne(pt => pt.Tag)
                .WithMany(pt => pt.PostTags)
                .HasForeignKey(pt => pt.TagId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Profile)
                .WithOne(u => u.User)
                .HasForeignKey<UserProfile>(u => u.UserId);
            base.OnModelCreating(modelBuilder);
        }

    }
}
