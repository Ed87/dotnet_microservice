using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ConsoleApplication.Data;
using ConsoleApplication.Entity;
using Microsoft.Extensions.Logging;

// TODO Replace direct use of database with repository.
namespace ConsoleApplication.Controllers
{
    [Route("api/[controller]")]
    public class WidgetsController : Controller
    {
        protected WidgetsContext _context;

        private readonly ILogger<WidgetsController> _logger;

        public WidgetsController(WidgetsContext context, ILogger<WidgetsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Widget> Get()
        {
            return _context.Widgets.AsEnumerable();
            //return _context.Widgets.Select(x => x.ToString()).ToArray();
        }

        // GET api/values/2
        [HttpGet("{index}")]
        public Widget Get(int index)
        {
            // FIXME. This finds by index (position in results) and not by ID!
            return _context.Widgets.Skip(index-1).Take(1).First();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Widget widget)
        {
            System.Console.WriteLine("The Magic value is: " + widget);
            _context.Widgets.Add(widget);
            _context.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{index}")]
        public void Delete(int index)
        {
            // FIXME. This deletes by index (position in results) and not by ID!
            var valToDelete = _context.Widgets.Skip(index-1).Take(1).First();
            _context.Widgets.Remove(valToDelete);
            _context.SaveChanges();
        }
    }
}
