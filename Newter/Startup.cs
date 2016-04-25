using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Newter.Startup))]
namespace Newter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
