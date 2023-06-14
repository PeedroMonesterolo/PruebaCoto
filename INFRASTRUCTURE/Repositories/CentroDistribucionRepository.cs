using CORE.Entities;
using CORE.Interfaces;

namespace INFRASTRUCTURE.Repositories;

public class CentroDistribucionRepository : ICentroDistribucionRepository
{
    private readonly List<CentroDistribucion> _centroDistribucionList;

    public CentroDistribucionRepository(List<CentroDistribucion> centroDistribucion)
    {
        // Realizo inyeccion de dependencias
        this._centroDistribucionList = centroDistribucion;
    }

    public int Add(CentroDistribucion entity)
    {
        // Obtengo el ultimo id y le sumo uno para guardar con un nuevo ID incremental
        var id = ++_centroDistribucionList.LastOrDefault().Id;
        // Agrego un nuevo CentroDistribucion
        this._centroDistribucionList.Add(new CentroDistribucion()
        {
            Id = id,
            Nombre = entity.Nombre
        });

        // Retorno el ID generado
        return id;
    }

    public IEnumerable<CentroDistribucion> GetAll()
    {
        // Obtengo el listado de Centro de Distribucion
        return _centroDistribucionList.ToList();
    }

    public CentroDistribucion GetById(int id)
    {
        // Filtro por ID para devolver el Centro de Distribucion
        return _centroDistribucionList.Find(x => x.Id == id);
    }

    public bool Remove(int id)
    {
        // Obtengo el Centro de Distribucion y verifico si existe
        CentroDistribucion centroDistribucion = GetById(id);
        if (centroDistribucion != null)
            // Elimino Centro de Distribucion si existe
            _centroDistribucionList.Remove(centroDistribucion);
        else return false;

        return true;
    }

    public bool Update(int id, CentroDistribucion entity)
    {
        // Busco el indice del centro de distribucion y verifico si es distinto de -1(es decir que no existe. IndexOf devuelve por default el -1)
        int indexOf = _centroDistribucionList.IndexOf(GetById(id));
        if (indexOf != -1)
        {
            // Seteo ID y actualizo el modelo
            entity.Id = id;
            _centroDistribucionList[indexOf] = entity;
        }
        else return false;

        return true;
    }
}
