using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class VentaDto
{
    [Required(ErrorMessage = "Modelo es requerido.")]
    public int IdModelo { get; set; }

    [Required(ErrorMessage = "El centro de distribucion es requerido.")]
    public int IdCentroDistribucion { get; set; }
}
