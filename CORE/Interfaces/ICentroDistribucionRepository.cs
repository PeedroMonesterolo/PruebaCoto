using CORE.Entities;
using System.Linq.Expressions;

namespace CORE.Interfaces;

public interface ICentroDistribucionRepository
{
    /// <summary>
    /// Obtener el listado de Centro de Distribucion
    /// </summary>
    /// <returns></returns>
    IEnumerable<CentroDistribucion> GetAll();
    /// <summary>
    /// Obtener un Centro de Distribucion por ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    CentroDistribucion GetById(int id);
    /// <summary>
    /// Agregar un nuevo Centro de Distribucion
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    int Add(CentroDistribucion entity);
    /// <summary>
    /// Eliminar Centro de Distribucion
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    bool Remove(int id);
    /// <summary>
    /// Actualizar Centro de Distribucion
    /// </summary>
    /// <param name="id"></param>
    /// <param name="entity"></param>
    /// <returns></returns>
    bool Update(int id, CentroDistribucion entity);
}
