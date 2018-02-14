using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vehicle_MVC.Startup))]
namespace Vehicle_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
