using Microsoft.AspNetCore.Mvc;
using Workshop.Domain.DTOs;
using Workshop.Domain.Exceptions;
using WorkshopMng.Application.Interfaces;
using WorkshopMng.Domain.Domains;

namespace Workshop.API.Controllers
{
    [ApiController]
    [Route("api/atas")]
    public class AtaController : ControllerBase
    {
        private readonly IAtaService<Ata> _ataService;
        private readonly IColaboradorService<Colaborador> _colaboradorService;

        public AtaController(IAtaService<Ata> ataService, IColaboradorService<Colaborador> colaboradorService)
        {
            _ataService = ataService;
            _colaboradorService = colaboradorService;

        }

        [HttpPost]
        public async Task<IActionResult> CriarAta(Ata ata)
        {
            try
            {
                await _ataService.InserirAta(ata);
                return CreatedAtAction(nameof(GetAtaPorId), new { id = ata.Id }, ata);
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

        [HttpPut("{colaboradorId}/{ataId}")]
        public async Task<IActionResult> AdicionarColaborador(int colaboradorId, int ataId) 
        {
            try
            {
                var colaborador = await _colaboradorService.ObterColaboradorPorId(colaboradorId);

                await _ataService.InserirColaboradorNaAta(colaborador, ataId);
                var ata = await _ataService.ObterAtaPorId(ataId);
                return Ok(ata);
            }
            catch (ServiceException serviceExp) 
            { 
                return BadRequest(serviceExp.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{colaboradorId}/{ataId}")]
        public async Task<IActionResult> RemoverColaborador(int colaboradorId, int ataId) 
        {
            try
            {
                var colaborador = await _colaboradorService.ObterColaboradorPorId(colaboradorId);
                _ataService.RemoverColaboradorDaAta(colaborador, ataId);

                var ata = await _ataService.ObterAtaPorId(ataId);
                return Ok(ata);
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
        public async Task<ActionResult> GetAtaPorId(int id)
        {
            try
            {
                var ata = await _ataService.ObterAtaPorId(id);
                return Ok(ata);
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
        [HttpGet]
        public ActionResult<IEnumerable<Ata>> GetTodasAsAtas()
        {
            try
            {
                var atas = _ataService.ObterTodasAtas();
                return Ok(atas);
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
        [HttpGet("filtro")]
        public ActionResult<IEnumerable<Ata>> FiltrarEmAtas([FromQuery]FiltroAtaDTO filtro)
        {
            try
            {
                var atas = _ataService.FiltrarAtas(filtro);
                return Ok(atas);
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

        [HttpGet("workshops/workshop={workshopNome}")]
        public async Task<ActionResult<IEnumerable<Colaborador>>> ObterColaboradoresPorWorkshop(string workshopNome)
        {
            try
            {
                return Ok(_ataService.RetornaColaboradoresPorWorkshop(workshopNome));
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
        [HttpGet("colaboradores/workshops")]
        public ActionResult<Dictionary<string, int>> ObterQuantidadeDeWorkshopPorColaborador()
        {
            try
            {
                return Ok(_ataService.ObterQuantidadeDeWorkshopPorColaborador());
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
        [HttpGet("workshops/colaboradores")]
        public ActionResult<Dictionary<string, int>> ObterQuantidadeDeColaboradorPorWorkshop()
        {
            try
            {
                return Ok(_ataService.ObterQuantidadeDeColaboradorPorWorkshop());
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
