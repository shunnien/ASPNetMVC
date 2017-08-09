using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IdentityCodeFirst.Startup))]
namespace IdentityCodeFirst
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
