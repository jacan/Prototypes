using AutoMapper;
namespace Mvno.MappingCore.Extensions
{
	public interface IEntityMapper
	{
		TDestination Map<TSource, TDestination>(TSource sourceObject) 
			where TSource : class 
			where TDestination : class;

		void Map<TSource, TDestination>(TSource sourceObject, TDestination destinationObject)
			where TSource : class
			where TDestination : class;
	}
}
