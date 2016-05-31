﻿using Ninject;
using RL.DataProcessing.Contract.Configuration;
using RL.DataProcessing.Contract.Infrastructure;
using RL.DataProcessing.Implementation.Infrastructure;

namespace RL.Business.Configuration.DependencyInjection
{
    public class BusinessConfiguration
    {
        public static void RegisterBusinessServices(IKernel kernel)
        {
            DataProcessingConfiguration.RegisterDataProcessing(kernel);
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
