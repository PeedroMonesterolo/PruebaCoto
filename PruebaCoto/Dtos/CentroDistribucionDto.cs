using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class CentroDistribucionDto
{
    [Required(ErrorMessage = "Nombre es requerido.")]
    [MinLength(1)]
    public string Nombre { get; set; }
}
