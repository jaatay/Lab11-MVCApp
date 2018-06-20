
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
		
			public IActionResult Index()
		{
			TimePerson newList = new TimePerson();
			newList.GetPersons(1990, 2000);
			
			return View(newList);
		}
			
		
	}
}