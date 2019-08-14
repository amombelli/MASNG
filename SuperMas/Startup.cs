using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SuperMas.Startup))]
namespace SuperMas
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
