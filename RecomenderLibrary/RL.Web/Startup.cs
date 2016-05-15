using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RL.Web.Startup))]
namespace RL.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
