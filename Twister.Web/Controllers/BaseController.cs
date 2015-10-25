namespace Twister.Web.Controllers
{
    using System;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Data.UnitOfWork;
    using Twister.Models;
    using System.Linq;

    public abstract class BaseController : Controller
    {
        private ITwisterData data;
        private User userProfile;

        protected BaseController(ITwisterData data)
        {
            this.Data = data;
        }

        protected BaseController(ITwisterData data, User userProfile)
            :this(data)
        {
            this.userProfile = userProfile;
        }

        protected ITwisterData Data { get; private set; }

        protected User UserProfile { get; private set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            if (requestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var username = requestContext.HttpContext.User.Identity.Name;
                var user = this.Data.Users.All().FirstOrDefault(x => x.UserName == username);
                this.UserProfile = user;
            }

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}