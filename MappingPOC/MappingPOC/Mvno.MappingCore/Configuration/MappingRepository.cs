using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using StructureMap;
using StructureMap.Configuration.DSL;
using AutoMapper.Mappers;

namespace Mvno.MappingCore.Extensions
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
				//.Use(x => x.GetInstance<MappingEngine>());

			Scan(x =>
				x.TheCallingAssembly()
			);
		}
	}
}