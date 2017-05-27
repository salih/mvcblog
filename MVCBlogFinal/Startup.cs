using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCBlogFinal.Startup))]
namespace MVCBlogFinal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
