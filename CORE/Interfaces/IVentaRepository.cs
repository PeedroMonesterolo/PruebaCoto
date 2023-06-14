using CORE.Entities;
using CORE.Entities.Response;

namespace CORE.Interfaces;

public interface IVentaRepository
{
    /// <summary>
    /// Obtener el listado de Ventas
    /// </summary>
    /// <returns></returns>
    IEnumerable<Venta> GetAll();
    /// <summary>
    /// Obtener una Venta por ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Venta GetById(int id);
    /// <summary>
    /// Agregar una nueva Venta
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    int Add(Venta entity);
    /// <summary>
    /// Eliminar Venta
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    bool Remove(int id);
    /// <summary>
    /// Actualizar Venta
    /// </summary>
    /// <param name="id"></param>
    /// <param name="entity"></param>
    /// <returns></returns>
    bool Update(int id, Venta entity);
    /// <summary>
    /// Obtener el volumen de ventas total
    /// </summary>
    /// <returns></returns>
    IEnumerable<VolumenVentaTotalModelo> VolumenVentaTotal();
    /// <summary>
    /// Obtener el volumen de ventas por centro
    /// </summary>
    /// <returns></returns>
    IEnumerable<VolumenVentaTotalPorCentro> VolumenVentaTotalPorCentro();
    /// <summary>
    /// Obtener el porcentaje de unidades de cada modelo vendido en cada centro sobre el total de ventas de la empresa
    /// </summary>
    /// <returns></returns>
    IEnumerable<PorcentajeUnidadesPorCentro> PorcentajeModelosVendidosPorCentro();
}
