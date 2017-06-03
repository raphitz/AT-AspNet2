using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AT_AspNet.Presentation.Startup))]
namespace AT_AspNet.Presentation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
