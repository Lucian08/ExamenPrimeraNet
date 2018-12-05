using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExamenPrimeraInternet.Startup))]
namespace ExamenPrimeraInternet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
