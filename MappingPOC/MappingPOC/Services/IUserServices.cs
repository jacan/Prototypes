using MappingPOC.Models;
using MappingPOC.Domain;
using MappingPOC.Domain.DataClasses;
using Mvno.MappingCore.Extensions;

namespace MappingPOC.Services
{
	public interface IUserServices
	{
		UserViewModel GetUser(string email);
	}
	
	public class UserServices : IUserServices
	{
		private readonly IRepository _userRepo;
		private readonly IEntityMapper _mapper;

		public UserServices(IRepository userRepo, IEntityMapper mapper)
		{
			_userRepo = userRepo;
			_mapper = mapper;

		}
		
		public UserViewModel GetUser(string email)
		{
			var user = _userRepo.GetUser(email);

			return _mapper.Map<UserDataClass, UserViewModel>(user);
		}
	}
}