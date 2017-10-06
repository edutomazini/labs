using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LlabsMVC.Startup))]
namespace LlabsMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
