using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TaskManagementSystem.Web.Startup))]
namespace TaskManagementSystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
