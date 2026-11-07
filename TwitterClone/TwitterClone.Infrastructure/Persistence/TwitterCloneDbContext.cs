using Microsoft.EntityFrameworkCore;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Persistence
{
    public class TwitterCloneDBContext : DbContext
    {
        public TwitterCloneDBContext(DbContextOptions<TwitterCloneDBContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Bookmark> Bookmarks { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Tweet> Tweets { get; set; }
        //public DbSet<Retweet> Retweets { get; set; }
        //public DbSet<Notification> Notifications { get; set; }
        //public DbSet<Tweet> Tweets { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TwitterCloneDBContext).Assembly);
        }
    }
}
