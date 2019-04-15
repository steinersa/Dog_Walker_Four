using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DogWalkerAgain.Startup))]
namespace DogWalkerAgain
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
