namespace CORE.Entities;

public class Modelo: BaseEntity
{
    public string Nombre { get; set; }
    public int Precio { get; set; }
    public int? Impuesto { get; set; }
}
