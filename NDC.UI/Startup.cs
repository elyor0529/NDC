using Microsoft.Owin;

[assembly: OwinStartupAttribute(typeof(NDC.UI.Startup))]
namespace NDC.UI
{
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Configure(app); 
        }
    }
}
