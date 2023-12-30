using Microsoft.AspNetCore.Mvc;
using WorkshopMng.Domain.Domains;
using WorkshopMng.Persistence.Context;

namespace WorkshopMng.API.Controllers
{
    [ApiController]
    [Route("api/workshops")]
    public class WorkshopController : ControllerBase
    {
        private readonly WorkshopContext _context;

        public WorkshopController(WorkshopContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CriarWorkshop(WorkshopMng.Domain.Domains.Workshop workshop) 
        { 
            await _context.Workshops.AddAsync(workshop);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetWorkshop), new { id = workshop.Id }, workshop);
        }

        [HttpGet("{id}", Name = "GetWorkshop")]
        public async Task<IActionResult> GetWorkshop(int id)
        {
            var workshop = await _context.Workshops.FindAsync(id);

            if (workshop == null)
            {
                return NotFound();
            }

            return Ok(workshop);
        }
    }
}
