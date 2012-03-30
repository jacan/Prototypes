using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StructureMap;
using MappingPOC.Services;

namespace MappingPOC.Controllers
{
	public class HomeController : Controller
	{
		private readonly IUserServices _userService;

		public HomeController(IUserServices userService)
		{
			_userService = userService;
		}

		public ActionResult Index()
		{
			var userViewModel = _userService.GetUser("kpo@onfone.dk");

			return View();
		}

		public ActionResult About()
		{
			return View();
		}
	}
}
