using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookMVCApplication.Startup))]
namespace BookMVCApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
