using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HungryCells.Startup))]
namespace HungryCells
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
