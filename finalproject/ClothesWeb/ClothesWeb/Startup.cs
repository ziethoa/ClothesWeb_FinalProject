using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClothesWeb.Startup))]
namespace ClothesWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
