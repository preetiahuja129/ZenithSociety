using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZenithSociety.Data;
using ZenithSociety.Models.ActivityEventModels;
// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ZenithSociety.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class EventApiController : Controller
    {
        private ApplicationDbContext _context { get; set; }

        public EventApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var EventList = from e in _context.Events
                            join a in _context.Activities on e.ActivityId equals a.ActivityId
                            select new {  e.EventId, e.EventDate, e.DateFrom, e.DateTo, e.CreationDate, e.ActivityId, a.Description };
            return Json(EventList);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [Authorize]
        public Event Get(int id)
        {
            return _context.Events.FirstOrDefault(s => s.EventId == id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Event evnt)
        {
            _context.Events.Add(evnt);
            _context.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Event evnt)
        {
            _context.Events.Update(evnt);
            _context.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Event evnt = _context.Events.FirstOrDefault(s => s.EventId == id);
            if (evnt != null)
            {
                _context.Events.Remove(evnt);
                _context.SaveChanges();
            }
        }
    }
}
