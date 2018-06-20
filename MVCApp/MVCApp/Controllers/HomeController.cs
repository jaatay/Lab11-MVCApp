using System;
using System.Collections.Generic;
using System.Linq;
using MVCApp;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;



namespace MVCApp
{
	public class HomeController: Controller
	{
		
		[HttpGet]
		public IActionResult Index()
		{
			
			return View();
		}

		[HttpPost]
		public IActionResult Index(int begYear, int endYear)
		{
			

			return RedirectToAction("Results" , new { begYear, endYear });
		}

		public IActionResult Results(int begYear, int endYear)
		{
			List<TimePerson> person = new List<TimePerson>();
			person = TimePerson.GetPersons(begYear, endYear);
			

			return View(person);
		}
		

	}
}