using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Nixi.Startup))]
namespace Nixi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
