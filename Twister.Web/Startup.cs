using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Twister.Web.Startup))]
namespace Twister.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
