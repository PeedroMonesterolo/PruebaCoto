using API.Dtos;
using API.Extensions;
using AutoMapper;
using CORE.Entities;
using CORE.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(ExecutionTimeFilter))] // Aplico el filtro para imprimir en consola el tiempo de ejecucion de cada endpoind
    public class CentroDistribucionController : ControllerBase
    {
        private readonly ICentroDistribucionRepository _centroDistribucionRepository;
        private readonly IMapper _mapper;
        private Stopwatch _stopwatch;
        public CentroDistribucionController(ICentroDistribucionRepository centroDistribucionRepository, IMapper mapper)
        {
            _centroDistribucionRepository = centroDistribucionRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<CentroDistribucion>> Get()
        {
            return Ok(_centroDistribucionRepository.GetAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CentroDistribucion> Get(int id)
        {
            var centro = _centroDistribucionRepository.GetById(id);
            if (centro == null)
                return NotFound();

            return Ok(_centroDistribucionRepository.GetById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CentroDistribucion> Post([FromBody] CentroDistribucionDto value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var centroDistribucion = _mapper.Map<CentroDistribucion>(value);
            var id = _centroDistribucionRepository.Add(centroDistribucion);
            return CreatedAtAction(nameof(Post), new { id = id }, value);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put(int id, [FromBody] CentroDistribucionDto value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var centroDistribucion = _mapper.Map<CentroDistribucion>(value);
            bool isUpdated = _centroDistribucionRepository.Update(id, centroDistribucion);
            if (!isUpdated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            bool isDeleted = _centroDistribucionRepository.Remove(id);
            if (!isDeleted)
                return NotFound();

            return NoContent();
        }
    }
}
