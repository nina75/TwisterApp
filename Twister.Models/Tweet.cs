namespace Twister.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Tweet
    {
        private ICollection<Reply> replies;
        private ICollection<User> favorites;

        public Tweet()
        {
            this.replies = new HashSet<Reply>();
            this.favorites = new HashSet<User>();
        }

        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime PostedOn { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public string WallOwnerId { get; set; }

        public virtual User WallOwner { get; set; }

        public virtual ICollection<Reply> Replies
        {
            get { return this.replies; }
            set { this.replies = value; }
        }

        public virtual ICollection<User> Favourites
        {
            get { return this.favorites; }
            set { this.favorites = value; }
        }
    }
}
