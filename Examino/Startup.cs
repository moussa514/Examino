using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Examino.Startup))]
namespace Examino
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
