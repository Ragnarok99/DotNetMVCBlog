using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DotNetBlog.Startup))]
namespace DotNetBlog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
