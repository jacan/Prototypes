using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MappingPOC.Domain.DataClasses
{
	public class UserDataClass
	{
		public Guid Id { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
	}
}
