using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DenemesignalR.Startup))]
namespace DenemesignalR
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
