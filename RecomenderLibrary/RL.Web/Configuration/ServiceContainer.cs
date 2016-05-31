using Ninject;
using RL.Business.Configuration.DependencyInjection;

namespace RL.Web.Configuration
{
    public class ServicesContainer
    {
        public static void RegisterServices(IKernel kernel)
        {
            BusinessConfiguration.RegisterBusinessServices(kernel);
        }
    }
}