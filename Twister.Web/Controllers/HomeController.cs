namespace Twister.Web.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Twister.Data.UnitOfWork;
    using Twister.Models;
    using System.Linq;
    using System.Web.Mvc.Expressions;

    public class HomeController : BaseController
    {
        public HomeController(ITwisterData data)
            :base(data)
        {
        }

        public ActionResult Index()
        {
            if (this.UserProfile != null)
            {
                this.ViewBag.Username = this.UserProfile.UserName;
            }

            List<Tweet> tweetsData = this.Data.Tweets.All().ToList();
           
            return this.View(tweetsData);
        }
        

        public ActionResult About()
        {
            return this.RedirectToAction(c => c.Contact());

            //return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}