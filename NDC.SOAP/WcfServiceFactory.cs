using Microsoft.Practices.Unity;
using NDC.SOAP.Models;
using NDC.SOAP.Respositories;
using System.Data.Entity;
using NDC.SOAP.Services;
using Unity.Wcf;

namespace NDC.SOAP
{
    public class WcfServiceFactory : UnityServiceHostFactory
    {
        protected override void ConfigureContainer(IUnityContainer container)
        {
            container.RegisterType<NDCDbContext>(new HierarchicalLifetimeManager())
                .RegisterType<IRepository, PersonRepository>()
                .RegisterType<IService, EmailService>()
                .RegisterType<IConfiguration, AppConfiguration>()
                .RegisterType<IPersonService, PersonService>();
        }
    }
}