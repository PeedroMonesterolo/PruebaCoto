using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class ModeloDto
{
    [Required(ErrorMessage = "Nombre es requerido.")]
    [MinLength(1)]
    public string Nombre { get; set; }
    
    [Required(ErrorMessage = "Precio es requerido.")]
    public int Precio { get; set; }
    
    public int? Impuesto { get; set; }
}
