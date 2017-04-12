using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IPLForFun.Startup))]
namespace IPLForFun
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
