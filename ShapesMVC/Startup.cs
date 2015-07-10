using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShapesMVC.Startup))]
namespace ShapesMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
