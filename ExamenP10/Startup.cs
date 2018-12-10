using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExamenP10.Startup))]
namespace ExamenP10
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
