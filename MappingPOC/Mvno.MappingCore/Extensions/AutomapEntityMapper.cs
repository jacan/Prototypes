using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using StructureMap;

namespace Mvno.MappingCore.Extensions
{
	public class AutomapEntityMapper : IEntityMapper
	{
		protected IMappingEngine _mappingEngine;
		protected IConfiguration _mappingConfiguration;

		public AutomapEntityMapper(IMappingEngine mappingEngine, IConfiguration mappingConfiguration)
		{
			_mappingEngine = mappingEngine;
			_mappingConfiguration = mappingConfiguration;
		}

		public TDestination Map<TSource, TDestination>(TSource sourceObject) 
			where TSource : class
			where TDestination : class
		{
			return _mappingEngine.Map<TSource, TDestination>(sourceObject);
		}

		public void Map<TSource, TDestination>(TSource sourceObject, TDestination destinationObject)
			where TSource : class
			where TDestination : class
		{
			_mappingEngine.Map(sourceObject, destinationObject);
		}
	}
}
