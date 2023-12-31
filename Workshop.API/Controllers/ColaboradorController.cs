using Microsoft.AspNetCore.Mvc;
using Workshop.Domain.Exceptions;
using WorkshopMng.Application.Interfaces;
using WorkshopMng.Application.Services;
using WorkshopMng.Domain.Domains;
using WorkshopMng.Persistence.Context;

namespace WorkshopMng.API.Controllers
{
    [ApiController]
    [Route("api/colaboradores")]
    public class ColaboradorController : ControllerBase
    {
        private readonly IColaboradorService<Colaborador> _colaboradorService;

        public ColaboradorController(IColaboradorService<Colaborador> colaboradorService)
        {
            _colaboradorService = colaboradorService;
        }

        [HttpPost]
        public async Task<IActionResult> CriarColaborador(Colaborador colaborador) 
        {
            try
            {
                await _colaboradorService.InserirColaborador(colaborador);
                return CreatedAtAction(nameof(_colaboradorService.ObterColaboradorPorId), new { id = colaborador.Id }, colaborador);

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
        public async Task<IActionResult> GetColaboradorPorId(int id)
        {
            try
            {
                var colaborador = await _colaboradorService.ObterColaboradorPorId(id);
                return Ok(colaborador);
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
