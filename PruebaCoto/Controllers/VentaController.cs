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
    public class VentaController : ControllerBase
    {
        private readonly IVentaRepository _ventaRepository;
        private readonly IMapper _mapper;

        public VentaController(IVentaRepository ventaRepository, IMapper mapper)
        {
            _ventaRepository = ventaRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Venta>> Get()
        {
            return Ok(_ventaRepository.GetAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Venta> Get(int id)
        {
            var centro = _ventaRepository.GetById(id);
            if (centro == null)
                return NotFound();

            return Ok(_ventaRepository.GetById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Venta> Post([FromBody] VentaDto value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var venta = _mapper.Map<Venta>(value);

            var id = _ventaRepository.Add(venta);
            if (id > 0)
                return CreatedAtAction(nameof(Post), new { id = id });

            return BadRequest();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put(int id, [FromBody] Venta value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool isUpdated = _ventaRepository.Update(id, value);
            if (!isUpdated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            bool isDeleted = _ventaRepository.Remove(id);
            if (!isDeleted)
                return NotFound();

            return NoContent();
        }

        [HttpGet("VolumenVentaTotal")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Venta>> VolumenVentaTotal()
        {
            return Ok(_ventaRepository.VolumenVentaTotal());
        }

        [HttpGet("VolumenVentaTotalPorCentro")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Venta>> VolumenVentaTotalPorCentro()
        {
            return Ok(_ventaRepository.VolumenVentaTotalPorCentro());
        }

        [HttpGet("PorcentajeModelosVendidosPorCentro")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Venta>> PorcentajeModelosVendidosPorCentro()
        {
            return Ok(_ventaRepository.PorcentajeModelosVendidosPorCentro());
        }
    }
}
