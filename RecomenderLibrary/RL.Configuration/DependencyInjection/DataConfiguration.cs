using Ninject;
using RL.OwnData.Contract.Infrastructure;
using RL.OwnData.Implementation.Infrastructure;
using RL.RemoteData.Contract.Infrastructure;
using RL.RemoteData.Implementation.Infrastructure;

namespace RL.Configuration.DependencyInjection
{
    public class DataConfiguration
    {
        public static void RegisterDataServices(IKernel kernel)
        {
            // Repositories
            kernel.Bind<IDatabaseUnitOfWork>().To<DatabaseUnitOfWork>();
            kernel.Bind<IGoogleRepository>().To<GoogleRepository>();
        }
    }
}
