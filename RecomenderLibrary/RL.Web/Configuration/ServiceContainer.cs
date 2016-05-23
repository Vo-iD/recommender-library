using Ninject;
using RL.OwnData.Contract.Infrastructure;
using RL.OwnData.Implementation.Infrastructure;

namespace RL.Web.Configuration
{
    public class ServicesContainer
    {
        public static void RegisterServices(IKernel kernel)
        {
            // Repositories
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}