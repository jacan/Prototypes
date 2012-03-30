using MappingPOC.Data;
using MappingPOC.Domain.DataClasses;
using Mvno.MappingCore.Extensions;

namespace MappingPOC.Domain
{
	public interface IRepository
	{
		UserDataClass GetUser(string email);
	}

	public class UserRepository : IRepository
	{
		private readonly IEntityMapper _mapper;

		public UserRepository(IEntityMapper entityMapper)
		{
			_mapper = entityMapper;
		}

		private void CreateMap()
		{
			
		}

		public UserDataClass GetUser(string email)
		{
			var user = UserFactory.GetUser(email);

			return _mapper.Map<User, UserDataClass>(user);
		}
	}
}
