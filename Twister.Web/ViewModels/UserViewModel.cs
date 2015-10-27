namespace Twister.Web.ViewModels
{
    using System;
    using System.Linq.Expressions;
    using Twister.Models;
    using System.Linq;
    using System.Collections.Generic;

    public class UserViewModel
    {
        public static Expression<Func<User, UserViewModel>> ViewModel
        { 
            get
            {
                return x => new UserViewModel
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    Email = x.Email,
                    Fullname = x.Fullname,
                    Gender = x.Gender,
                    ProfileImageData = x.ProfileImageData,
                    ProfileImageDataMinified = x.ProfileImageDataMinified,
                    CoverImageData = x.CoverImageData,
                    OwnTweets = x.OwnTweets.AsQueryable().Select(TweetViewModel.ViewModel),
                    WallTweets = x.WallTweets.AsQueryable().Select(TweetViewModel.ViewModel),
                    Followers = x.Followers.AsQueryable().Select(f => f.UserName),
                    FollowedFriends = x.FollowedFriends.AsQueryable().Select(f => f.UserName)
                };
            }
        }

        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Fullname { get; set; }

        public Gender Gender { get; set; }

        public string ProfileImageData { get; set; }

        public string ProfileImageDataMinified { get; set; }

        public string CoverImageData { get; set; }

        public IEnumerable<TweetViewModel> OwnTweets { get; set; }

        public IEnumerable<TweetViewModel> WallTweets { get; set; }

        public IEnumerable<string> Followers { get; set; }

        public IEnumerable<string> FollowedFriends { get; set; }

        //public virtual ICollection<Message> Messages
        //{
        //    get { return this.messages; }
        //    set { this.messages = value; }
        //}

        //public virtual ICollection<Tweet> FavoritesTweets
        //{
        //    get { return this.favoritesTweets; }
        //    set { this.favoritesTweets = value; }
        //}

        //public virtual ICollection<User> FollowedFriends
        //{
        //    get { return this.followedFriends; }
        //    set { this.followedFriends = value; }
        //}
    }
}