using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RegistrationPortal.Startup))]
namespace RegistrationPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
