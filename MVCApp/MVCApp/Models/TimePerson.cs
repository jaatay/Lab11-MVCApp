using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

namespace MVCApp.Models
{
	/// <summary>
	/// creation of concrete class of a person
	/// </summary>
	public class TimePerson
	{
		//below are property fields of a new TimePerson object
		public int Year { get; set; }
		public string Honor { get; set; }
		public string Name { get; set; }
		public string Country { get; set; }
		public int Birth_Year { get; set; }
		public int DeathYear { get; set; }
		public string Title { get; set; }
		public string Category { get; set; }
		public string Context { get; set; }

		/// <summary>
		/// method to find list of users based on input parameters
		/// </summary>
		/// <param name="begYear">integer year beginning of search</param>
		/// <param name="endYear">integer year ending of search</param>
		/// <returns>returns list parsed from csv file</returns>
		public static List<TimePerson>GetPersons(int begYear, int endYear)
		{
			//creates enumerable list
			List<TimePerson> people = new List<TimePerson>();

			//sets string of the path to the current directory
			string path = Environment.CurrentDirectory;

			//sets path string to the root file and imported csv file
			string newPath = Path.GetFullPath(Path.Combine(path, @"wwwroot\PersonOfTheYear.csv"));

			//string array reading contents found at path
			string[] myFile = File.ReadAllLines(newPath);

			//for loop to populate array fields by splitting the strings at "," into new array values
			for(int i = 1; i < myFile.Length; i++)
			{
				string[] fields = myFile[i].Split(",");

				//method to add new person to list
				people.Add(new TimePerson
				{
					Year = Convert.ToInt32(fields[0]),
					Honor = fields[1],
					Name = fields[2],
					Country = fields[3],
					Birth_Year = (fields[4] == "") ? 0 : Convert.ToInt32(fields[4]),
					DeathYear = (fields[5] == "") ? 0 : Convert.ToInt32(fields[5]),
					Title = fields[6],
					Category = fields[7],
					Context = fields[8]
				});
			}
			
			//parses list based on year input and adds to the instantiated list
			List<TimePerson>listofPeople = people.Where(p => (p.Year >= begYear) && (p.Year <= endYear)).ToList();

			//returns list out of method for use in the code
			return listofPeople;
		}
	}
}