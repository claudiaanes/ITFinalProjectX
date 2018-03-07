using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ITFinalProject.Startup))]
namespace ITFinalProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
