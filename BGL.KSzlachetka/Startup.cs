using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(BGL.KSzlachetka.Startup))]
namespace BGL.KSzlachetka
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
