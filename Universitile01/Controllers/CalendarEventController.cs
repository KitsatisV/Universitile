using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Universitile01.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<ActionResult<IEnumerable<Session>>> GetEvents()
        {
            return await _context.Sessions.ToListAsync();
        }

        
        
        public async Task<ActionResult<Session>> PostEvent(Session session)
        {
            _context.Sessions.Add(session);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvents", new { id = session.EventId }, session);
        }

        
    }
}
