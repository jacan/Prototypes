using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MappingPOC.Models
{
	public class UserViewModel
	{
		public Guid Id { get; set; }
		public string Username { get; set; }
		public string EMail { get; set; }
	}
}