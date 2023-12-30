using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using WorkshopMng.Domain.Domains;
using WorkshopMng.Persistence.Context;

namespace Workshop.API.Controllers
{
    [ApiController]
    [Route("api/atas")]
    public class AtaController : ControllerBase
    {
        private readonly WorkshopContext _context;

        public AtaController(WorkshopContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CriarAta(Ata ata) 
        { 
            await _context.Atas.AddAsync(ata);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAta), new { id = ata.Id }, ata);
        }

        [HttpPut("{colaboradorId}/workshops/{workshopId}")]
        public async Task<IActionResult> AdicionarColaborador(int colaboradorId, int workshopId) 
        { 
            var colaborador = await _context.Colaboradores.FirstOrDefaultAsync(col => col.Id == colaboradorId);
            var ata = await _context.Atas.Include(a => a.colaboradores).FirstOrDefaultAsync(ata => ata.Workshop.Id == workshopId);
            ata.colaboradores.Add(colaborador);
            _context.Atas.Update(ata);
            await _context.SaveChangesAsync();
            return Ok(ata);
        }

        [HttpDelete("{colaboradorId}/workshops/{workshopId}")]
        public async Task<IActionResult> RemoverColaborador(int colaboradorId, int workshopId) 
        { 
            var colaborador = await _context.Colaboradores.FirstOrDefaultAsync(col => col.Id == colaboradorId);
            var ata = await _context.Atas.Include(a => a.colaboradores).FirstOrDefaultAsync(ata => ata.Workshop.Id == workshopId);
            ata.colaboradores.Remove(colaborador);
            _context.Atas.Update(ata);
            await _context.SaveChangesAsync();
            return Ok(ata);
        }

        [HttpGet("{id}", Name = "GetAta")]
        public async Task<IActionResult> GetAta(int id)
        {
            var ata = await _context.Atas.FindAsync(id);

            if (ata == null)
            {
                return NotFound();
            }

            return Ok(ata);
        }

        [HttpGet("{workshopNome}")]
        public async Task<IActionResult> ObterAtaPorWorkshop(string workshopNome)
        {
            var ata = await _context.Atas.Include(a => a.colaboradores).FirstOrDefaultAsync(ata => ata.Workshop.Nome == workshopNome);

            return Ok(ata.colaboradores);
        }
    }
}
