using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Artist.Startup))]
namespace Artist
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
