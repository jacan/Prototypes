using System.Web.Mvc;
using System.Web.Routing;
using StructureMap;
using MappingPOC.Services;
using Mvno.MappingCore.Extensions;
using MappingPOC.Domain;
using Mvno.MappingCore.Configuration;

namespace MappingPOC
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : System.Web.HttpApplication
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}

		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				"Default", // Route name
				"{controller}/{action}/{id}", // URL with parameters
				new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
			);
		}

		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			RegisterGlobalFilters(GlobalFilters.Filters);
			RegisterRoutes(RouteTable.Routes);
		
			// Register containers
			StrapIoC();

			ControllerBuilder.Current.SetControllerFactory(new MyControllerFactory());
		}

		private void StrapIoC()
		{
			ObjectFactory.Container.Configure(x =>
			{
				x.AddRegistry<AutoMapperRegistry>();
				x.For<IRepository>().Use<UserRepository>();
				x.For<IEntityMapper>().Use<AutomapEntityMapper>();
				x.For<IUserServices>().Use<UserServices>();
			});
		}

		private void StrapMappings()
		{
			
		}
	}
}