using CORE.Entities;

namespace CORE.Interfaces;

public interface IModeloRepository
{
    /// <summary>
    /// Obtener el listado de Modelos
    /// </summary>
    /// <returns></returns>
    IEnumerable<Modelo> GetAll();
    /// <summary>
    /// Obtener un Modelo por ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Modelo GetById(int id);
    /// <summary>
    /// Agregar un nuevo Modelo
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    int Add(Modelo entity);
    /// <summary>
    /// Eliminar Modelo
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    bool Remove(int id);
    /// <summary>
    /// Actualizar Modelo
    /// </summary>
    /// <param name="id"></param>
    /// <param name="entity"></param>
    /// <returns></returns>
    bool Update(int id, Modelo entity);
}
