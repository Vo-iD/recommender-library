using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RecomenderLibrary.Startup))]
namespace RecomenderLibrary
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
