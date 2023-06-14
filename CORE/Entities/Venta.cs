namespace CORE.Entities;

public class Venta: BaseEntity
{
    public int IdModelo { get; set; }
    public int IdCentroDistribucion { get; set; }
    public DateTime Fecha { get; set; }
    public int PrecioCompra { get; set; }
}
