namespace Twister.Web.ViewModels
{
    using System;
    using System.Linq.Expressions;
    using Twister.Models;

    public class TweetViewModel
    {
        public static Expression<Func<Tweet, TweetViewModel>> ViewModel
        {
            get
            {
                return x => new TweetViewModel
                {
                    Id = x.Id,
                    Content = x.Content,
                    PostedOn = x.PostedOn,
                    Author = x.Author.Fullname,
                    WallOwner = x.WallOwner.UserName
                };
            }
        }

        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime PostedOn { get; set; }

        public string Author { get; set; }

        public string WallOwner { get; set; }

        //public virtual ICollection<Reply> Replies
        //{
        //    get { return this.replies; }
        //    set { this.replies = value; }
        //}

        //public virtual ICollection<User> Favourites
        //{
        //    get { return this.favorites; }
        //    set { this.favorites = value; }
        //}
    }
}