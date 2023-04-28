using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Universitile01.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Universitile01.Data;

namespace Universitile01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarEventController : ControllerBase
    {
        private readonly UniversitiledatabaseContext _context;

        public CalendarEventController(UniversitiledatabaseContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CalendarEvent>>> GetEvents()
        {
            return await _context.CalendarEvents.ToListAsync();
        }

        
        
        public async Task<ActionResult<CalendarEvent>> PostEvent(CalendarEvent calendarEvent)
        {
            _context.CalendarEvents.Add(calendarEvent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvents", new { id = calendarEvent.EventId }, calendarEvent);
        }

        
    }
}
