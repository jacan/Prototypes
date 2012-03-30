using MappingPOC.Domain;
using Mvno.MappingCore.Extensions;
using StructureMap;

namespace Mvno.Core
{
	public class Bootstrapper
	{
		
		public static void Initialize()
		{
			var strapper = new Bootstrapper();
			strapper.PrepareMappingInjection();
		}

		private void PrepareMappingInjection()
		{
			ObjectFactory.Initialize( x =>
			{
				x.For<IRepository>().Use<UserRepository>();
				x.For<IEntityMapper>().Use<AutomapEntityMapper>();
			});
		}

		
	}
}
