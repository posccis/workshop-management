using Microsoft.AspNetCore.Mvc;
using System.Net;
using WorkshopMng.Domain.Domains;
using WorkshopMng.Persistence.Context;

namespace Workshop.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ColaboradorController : ControllerBase
    {
        private readonly WorkshopContext _context;

        public ColaboradorController(WorkshopContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CriarColaborador(Colaborador colaborador) 
        { 
            await _context.Colaboradores.AddAsync(colaborador);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetColaborador), new { id = colaborador.Id }, colaborador);
        }

        [HttpGet("{id}", Name = "GetColaborador")]
        public async Task<IActionResult> GetColaborador(int id)
        {
            var colaborador = await _context.Colaboradores.FindAsync(id);

            if (colaborador == null)
            {
                return NotFound();
            }

            return Ok(colaborador);
        }
    }
}
