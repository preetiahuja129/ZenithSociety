using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZenithSociety.Data;
using ZenithSociety.Models.ActivityEventModels;
using ZenithSociety.Utility;

namespace ZenithSociety.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _applicationDbContext;
        private static double days;

        public HomeController(ApplicationDbContext db)
        {
            _applicationDbContext = db;
        }

        public class RenderEventActivityModel
        {
            public Event Event { get; set; }
            public Activity Activity { get; set; }
        }

        public IActionResult Index(string week)
        {
            
            var firstdayOfThisWeek = DateTime.Now.FirstDayOfWeek();
            var lastdayOfThisWeek = DateTime.Now.LastDayOfWeek();

            if (week == "prevWk")
            {
                days = days - 7;
            }
            else if (week == "nxtWk")
            {
                days = days + 7;
            }

            var eventList = from e in _applicationDbContext.Events
                            join a in _applicationDbContext.Activities on e.ActivityId equals a.ActivityId
                            where (e.DateFrom >= firstdayOfThisWeek.AddDays(days))
                            && (e.DateFrom < lastdayOfThisWeek.AddDays(days))
                            && (e.IsActive == true)
                            orderby (e.DateFrom)
                            select new RenderEventActivityModel { Event = e, Activity = a };
            return View(eventList);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}