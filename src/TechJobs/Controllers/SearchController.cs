using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results
        public IActionResult Results(string searchType, string searchTerm)
        {
            ViewBag.title = "Search";
            ViewBag.columns = ListController.columnChoices;
            List<Dictionary<string, string>> jobs = new List<Dictionary<string, string>>();
            if (searchType != "all")
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            else
                if (string.IsNullOrEmpty(searchTerm))
                    jobs = JobData.FindAll();
                else
                    jobs = JobData.FindByValue(searchTerm);

            //var result = results[0];
            //ViewBag.columns = result;
            ViewBag.Jobs = jobs;
            return View("Views/Search/Index.cshtml");
        }

    }
}
