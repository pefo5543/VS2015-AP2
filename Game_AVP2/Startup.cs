using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Game_AVP2.Startup))]
namespace Game_AVP2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
