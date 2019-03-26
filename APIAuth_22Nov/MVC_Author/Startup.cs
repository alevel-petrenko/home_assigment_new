using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Author.Startup))]
namespace MVC_Author
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
