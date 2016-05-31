using Ninject;
using RL.Configuration.DependencyInjection;

namespace RL.DataProcessing.Contract.Configuration
{
    public class DataProcessingConfiguration
    {
        public static void RegisterDataProcessing(IKernel kernel)
        {
            DataConfiguration.RegisterDataServices(kernel);
        }
    }
}
