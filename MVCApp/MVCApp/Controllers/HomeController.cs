using System;
using System.Collections.Generic;
using System.Linq;
using MVCApp;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCApp.Models;

namespace MVCApp.Controllers
{
	public class HomeController: Controller
	{
		/// <summary>
		/// method to direct user to landing page
		/// </summary>
		/// <returns>returns user to index view</returns>
		[HttpGet]
		public IActionResult Index()
		{
			
			return View();
		}

		/// <summary>
		/// method to receive data from form input
		/// </summary>
		/// <param name="inputBegYear">beginning year from submitted form data</param>
		/// <param name="inputEndYear">ending year from submitted form data</param>
		/// <returns>new beginning and ending years in a redirect to results page</returns>
		[HttpPost]
		public IActionResult Index(int inputBegYear, int inputEndYear)
		{
			
			return RedirectToAction("Results", new {newBegYear = inputBegYear, newEndYear = inputEndYear });
		}

		/// <summary>
		/// method to output search results to result page
		/// </summary>
		/// <param name="newBegYear">beginning year taken from above method</param>
		/// <param name="newEndYear">ending year taken from above method</param>
		/// <returns>outputs results of list to results view</returns>
		public IActionResult Results(int newBegYear, int newEndYear)
		{
			TimePerson person = new TimePerson();
		
			return View(TimePerson.GetPersons(newBegYear, newEndYear));
		}
		

	}
}