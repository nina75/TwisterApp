namespace Twister.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System.Data.Entity;
    using Migrations;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class TwisterContext : IdentityDbContext<User>, ITwisterContext
    {
        public TwisterContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TwisterContext, Configuration>());
        }

        public virtual IDbSet<Tweet> Tweets { get; set; }

        public virtual IDbSet<Message> Messages { get; set; }

        public virtual IDbSet<Notification> Notifications { get; set; }

        public virtual IDbSet<Reply> Replies { get; set; }

        public virtual IDbSet<TweetFavourite> TweetFavorites { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions
                .Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<User>()
                 .HasMany(u => u.Messages)
                 .WithOptional();

            modelBuilder.Entity<Message>()
                .HasRequired(m => m.Author)
                .WithOptional();

            modelBuilder.Entity<Message>()
                .HasRequired(m => m.Receiver)
                .WithOptional();

            modelBuilder.Entity<User>()
                .HasMany(u => u.Followers)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("ApplicationUserId");
                    m.MapRightKey("FollowerId");
                    m.ToTable("UsersFollowers");
                });

            modelBuilder.Entity<User>()
                .HasMany(u => u.FollowedFriends)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("ApplicationUserId");
                    m.MapRightKey("FollowedFriendId");
                    m.ToTable("UsersFollowedFriends");
                });

            modelBuilder.Entity<User>()
                .HasMany(u => u.WallTweets)
                .WithRequired(p => p.WallOwner)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(u => u.OwnTweets)
                .WithRequired(p => p.Author)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }

        public static TwisterContext Create()
        {
            return new TwisterContext();
        }
    }
}
