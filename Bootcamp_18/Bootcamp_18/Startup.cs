using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bootcamp_18.Startup))]
namespace Bootcamp_18
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
