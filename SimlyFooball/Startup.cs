using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimlyFooball.Startup))]
namespace SimlyFooball
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
