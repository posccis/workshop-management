using Microsoft.AspNetCore.Mvc;
using Workshop.Domain.Exceptions;
using WorkshopMng.Application.Interfaces;
using WorkshopMng.Application.Services;
using WorkshopMng.Domain.Domains;
using WorkshopMng.Persistence.Context;

namespace WorkshopMng.API.Controllers
{
    [ApiController]
    [Route("api/workshops")]
    public class WorkshopController : ControllerBase
    {
        private readonly IWorkshopService<Domain.Domains.Workshop> _workshopService;

        public WorkshopController(IWorkshopService<Domain.Domains.Workshop> workshopService)
        {
            _workshopService = workshopService;
        }

        [HttpPost]
        public async Task<IActionResult> CriarWorkshop(WorkshopMng.Domain.Domains.Workshop workshop) 
        {
            try
            {
                await _workshopService.InserirWorkshop(workshop);
                return CreatedAtAction(nameof(GetWorkshopPorId), new { id = workshop.Id }, workshop);
            }
            catch (ServiceException serviceExp)
            {
                return BadRequest(serviceExp.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkshopPorId(int id)
        {
            try
            {
                var workshop = await _workshopService.ObterWorkshopPorId(id);
                return Ok(workshop);
            }
            catch (ServiceException serviceExp)
            {
                return NotFound(serviceExp.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
