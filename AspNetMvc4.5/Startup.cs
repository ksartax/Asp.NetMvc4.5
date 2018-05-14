using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AspNetMvc4._5.Startup))]
namespace AspNetMvc4._5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
