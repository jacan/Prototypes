using System.Collections.Generic;
using AutoMapper;
using AutoMapper.Mappers;
using StructureMap.Configuration.DSL;

namespace Mvno.MappingCore.Configuration
{
	public class AutoMapperRegistry : Registry
	{
		public AutoMapperRegistry()
		{
			For<ConfigurationStore>()
				.Singleton()
				.Use<ConfigurationStore>()
				.Ctor<IEnumerable<IObjectMapper>>().Is(MapperRegistry.AllMappers());

			For<IConfigurationProvider>()
				.Use(x => x.GetInstance<ConfigurationStore>());

			For<IConfiguration>()
				.Use(x => x.GetInstance<ConfigurationStore>());

			For<ITypeMapFactory>()
				.Use(x => x.GetInstance<TypeMapFactory>());

			For<IMappingEngine>().Use(Mapper.Engine);

			Scan(x =>
				x.TheCallingAssembly()
			);
		}
	}
}