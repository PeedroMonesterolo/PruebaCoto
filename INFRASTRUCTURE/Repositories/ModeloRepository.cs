using CORE.Entities;
using CORE.Interfaces;

namespace INFRASTRUCTURE.Repositories;

public class ModeloRepository : IModeloRepository
{
    private readonly List<Modelo> _modeloList;

    public ModeloRepository(List<Modelo> modeloList)
    {
        // Realizo inyeccion de dependencias
        _modeloList = modeloList;
    }

    public int Add(Modelo entity)
    {
        // Obtengo el ultimo id y le sumo uno para guardar con un nuevo ID incremental
        int id = ++_modeloList.LastOrDefault().Id;
        // Agrego un nuevo Modelo
        this._modeloList.Add(new Modelo()
        {
            Id = id,
            Impuesto = entity.Impuesto,
            Nombre = entity.Nombre,
            Precio = entity.Precio
        });

        // Retorno el ID generado
        return id;
    }

    public IEnumerable<Modelo> GetAll()
    {
        // Obtengo el listado de Modelos
        return _modeloList.ToList();
    }

    public Modelo GetById(int id)
    {
        // Filtro por ID para devolver el Modelo
        return _modeloList.Find(x => x.Id == id);
    }

    public bool Remove(int id)
    {
        // Obtengo el Modelo y verifico si existe
        Modelo modelo = GetById(id);
        if (modelo != null)
            // Elimino Modelo si existe
            _modeloList.Remove(modelo);
        else return false;

        return true;
    }

    public bool Update(int id, Modelo entity)
    {
        // Busco el indice del Modelo y verifico si es distinto de -1(es decir que no existe. IndexOf devuelve por default el -1)
        int indexOf = _modeloList.IndexOf(GetById(id));
        if (indexOf != -1)
        {
            // Seteo ID y actualizo el modelo
            entity.Id = id;
            _modeloList[indexOf] = entity;
        }
        else return false;

        return true;
    }
}
