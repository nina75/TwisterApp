namespace Twister.Models
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        private ICollection<Message> messages;
        private ICollection<Tweet> ownTweets;
        private ICollection<Tweet> wallTweets;
        private ICollection<User> followers;
        private ICollection<User> followedFriends;
        private ICollection<Tweet> favoritesTweets;

        public User()
        {
            this.messages = new HashSet<Message>();
            this.ownTweets = new HashSet<Tweet>();
            this.wallTweets = new HashSet<Tweet>();
            this.followers = new HashSet<User>();
            this.followedFriends = new HashSet<User>();
            this.favoritesTweets = new HashSet<Tweet>();
        }

        public string Fullname { get; set; }

        public Gender Gender { get; set; }

        public string ProfileImageData { get; set; }

        public string ProfileImageDataMinified { get; set; }

        public string CoverImageData { get; set; }

        public virtual ICollection<Message> Messages
        {
            get { return this.messages; }
            set { this.messages = value; }
        }

        public virtual ICollection<Tweet> OwnTweets
        {
            get { return this.ownTweets; }
            set { this.ownTweets = value; }
        }

        public virtual ICollection<Tweet> FavoritesTweets
        {
            get { return this.favoritesTweets; }
            set { this.favoritesTweets = value; }
        }

        public virtual ICollection<Tweet> WallTweets
        {
            get { return this.wallTweets; }
            set { this.wallTweets = value; }
        }

        public virtual ICollection<User> Followers
        {
            get { return this.followers; }
            set { this.followers = value; }
        }

        public virtual ICollection<User> FollowedFriends
        {
            get { return this.followedFriends; }
            set { this.followedFriends = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

}

