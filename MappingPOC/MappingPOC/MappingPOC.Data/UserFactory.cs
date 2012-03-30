using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MappingPOC.Data
{
	public class UserFactory
	{
		
		public static User GetUser(string email)
		{
			return new Mvno3Entities().Users
				.SingleOrDefault(x => x.Email.Equals(email));
		} 
	}
}
