using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyRecipes.Startup))]
namespace MyRecipes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
