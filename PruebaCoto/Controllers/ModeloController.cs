using API.Dtos;
using API.Extensions;
using AutoMapper;
using CORE.Entities;
using CORE.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(ExecutionTimeFilter))] // Aplico el filtro para imprimir en consola el tiempo de ejecucion de cada endpoind
    public class ModeloController : ControllerBase
    {
        private readonly IModeloRepository _modeloRepository;
        private readonly IMapper _mapper;
        public ModeloController(IModeloRepository modeloRepository, IMapper mapper)
        {
            _modeloRepository = modeloRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Modelo>> Get()
        {
            return Ok(_modeloRepository.GetAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Modelo> Get(int id)
        {
            var centro = _modeloRepository.GetById(id);
            if (centro == null)
                return NotFound();

            return Ok(_modeloRepository.GetById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Modelo> Post([FromBody] ModeloDto value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var modelo = _mapper.Map<Modelo>(value);
            var id = _modeloRepository.Add(modelo);
            return CreatedAtAction(nameof(Post), new { id = id }, value);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put(int id, [FromBody] ModeloDto value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var modelo = _mapper.Map<Modelo>(value);
            bool isUpdated = _modeloRepository.Update(id, modelo);
            if (!isUpdated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            bool isDeleted = _modeloRepository.Remove(id);
            if (!isDeleted)
                return NotFound();

            return NoContent();
        }
    }
}
