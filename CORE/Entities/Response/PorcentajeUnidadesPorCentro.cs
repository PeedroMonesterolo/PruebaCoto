namespace CORE.Entities.Response;

public class PorcentajeUnidadesPorCentro
{
    public int IdCentro { get; set; }
    public string Nombre { get; set; }
    public List<ModeloVendidos> ModeloVendidos { get; set; }
    public int TotalVendidos { get; set; }
}

public class ModeloVendidos: Modelo
{
    public int Cantidad { get; set; }
    public int Porcentaje { get; set; }
}
