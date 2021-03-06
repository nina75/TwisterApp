﻿namespace Twister.Web.Controllers
{
    using System.Web.Mvc;
    using Data.UnitOfWork;
    using System.Linq;
    using ViewModels;
    using System.Data.Entity;

    [Authorize]
    public class UsersController : BaseController
    {
        public UsersController(ITwisterData data)
            :base(data)
        {
        }
        
        public ActionResult Index(string username)
        {
            var user = this.Data.Users
                .All()
                .Include(x => x.OwnTweets)
                .Include("OwnTweets.Tweet")
                .Include("OwnTweets.Tweet.User")
                .Include(x => x.WallTweets)
                .Where(x => x.UserName == username)
                .Select(UserViewModel.ViewModel)
                .FirstOrDefault();

            if (user == null)
            {
                return this.HttpNotFound("User does not exist!!!");
            }

            return this.View(user);
        }
    }
}