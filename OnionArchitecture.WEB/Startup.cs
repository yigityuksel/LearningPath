using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnionArchitecture.WEB.Startup))]
namespace OnionArchitecture.WEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
