using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using Ninject;
using RL.Entity.Own;
using RL.RemoteData.Contract.RemoteModels;
using RL.Web.Configuration;
using RL.Web.Models;

namespace RL.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutomapperConfig.CreateMaps();
        }
    }

    public static class AutomapperConfig
    {
        public static void CreateMaps()
        {
            Mapper.CreateMap<FavoriteBookModel, FavoriteBook>();
        }
    }
}
