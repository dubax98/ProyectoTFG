using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(A_Contraluz.Startup))]
namespace A_Contraluz
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
