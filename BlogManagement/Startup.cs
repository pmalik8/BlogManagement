using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlogManagement.Startup))]
namespace BlogManagement
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
