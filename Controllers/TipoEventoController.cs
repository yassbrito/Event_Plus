using Event_Plus.Domains;
using Event_Plus.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Event_Plus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoEventoController : ControllerBase
    {
        private readonly ITipoEventoRepository _TipoEventoRepository;

        public TipoEventoController(ITipoEventoRepository tipoEventorepository)
        {
            _TipoEventoRepository = tipoEventorepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<TipoEvento> ListaDeEvento = _TipoEventoRepository.Listar();

                return Ok(ListaDeEvento);
            }
            catch (Exception e)
            {

               return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(TipoEvento novoTipoEvento) 
        {
            try
            {
                _TipoEventoRepository.Cadastrar(novoTipoEvento);

                return Created();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("BUscarPorId/{id}")]
        public IActionResult GetById(Guid id) 
        {
            try
            {
                TipoEvento TipoEventoBuscado = _TipoEventoRepository.BuscarPorId(id);
                return Ok(TipoEventoBuscado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id) 
        {
            try
            {
                _TipoEventoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, TipoEvento tipoEvento)
        {
            try
            {
                _TipoEventoRepository.Atualizar(id, tipoEvento);
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("ListarPorTipoEvento/{id}")]
        public IActionResult GetByTipoEvento(Guid id) 
        {
            try
            {
                List<TipoEvento> listaDeTipoEvento = _TipoEventoRepository.listarDeTipoEvento(id);
                return Ok(listaDeTipoEvento);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
