using CORE.Entities;
using CORE.Entities.Response;
using CORE.Interfaces;
using System.Collections.Generic;
using System.Reflection;

namespace INFRASTRUCTURE.Repositories;

public class VentaRepository : IVentaRepository
{
    private readonly List<Venta> _ventaList;
    private readonly IModeloRepository _modeloRepository;
    private readonly ICentroDistribucionRepository _centroDistribucionRepository;

    public VentaRepository(List<Venta> ventaList, IModeloRepository modeloRepository, ICentroDistribucionRepository centroDistribucionRepository)
    {
        // Realizo inyeccion de dependencias
        _ventaList = ventaList;
        _modeloRepository = modeloRepository;
        _centroDistribucionRepository = centroDistribucionRepository;
    }

    public int Add(Venta entity)
    {
        // Obtengo el ultimo id y le sumo uno para guardar con un nuevo ID incremental
        var id = ++_ventaList.LastOrDefault(new Venta()).Id;
        // Verifico buscando si existe el Modelo
        var modelo = _modeloRepository.GetById(entity.IdModelo);
        // Verifico buscando si existe el Centro de Distribucion
        var centroDistribucion = _centroDistribucionRepository.GetById(entity.IdCentroDistribucion);
        if (modelo != null && centroDistribucion != null)
        {
            // Si existe Modelo y Centro de Distribucion agrego
            this._ventaList.Add(new Venta()
            {
                Id = id,
                Fecha = DateTime.Now,
                IdCentroDistribucion = entity.IdCentroDistribucion,
                IdModelo = entity.IdModelo,
                // Calculo de precio compra aplicando descuento
                PrecioCompra = modelo.Impuesto.HasValue ? modelo.Precio + (modelo.Impuesto.Value * modelo.Precio / 100) : modelo.Precio
            });
        }
        else return -1;

        return id;
    }

    public IEnumerable<Venta> GetAll()
    {
        // Obtengo el listado de Ventas
        return _ventaList.ToList();
    }

    public Venta GetById(int id)
    {
        // Obtengo el listado de Ventas
        return _ventaList.Find(x => x.Id == id);
    }

    public IEnumerable<PorcentajeUnidadesPorCentro> PorcentajeModelosVendidosPorCentro()
    {
        List<PorcentajeUnidadesPorCentro> porcentajes = new List<PorcentajeUnidadesPorCentro>();
        // Obtengo Centros de distribucion
        List<CentroDistribucion> centros = _centroDistribucionRepository.GetAll().ToList();
        // Obtengo Modelos
        List<Modelo> modelos = _modeloRepository.GetAll().ToList();
        // Obtengo Ventas
        List<Venta> ventas = _ventaList.ToList();

        // Agrego los centros al listado y cantidad de autos vendidos
        foreach (CentroDistribucion centro in centros)
        {
            porcentajes.Add(new PorcentajeUnidadesPorCentro()
            {
                IdCentro = centro.Id,
                Nombre = centro.Nombre,
                TotalVendidos = _ventaList.Count(x => x.IdCentroDistribucion == centro.Id)
            });
        }

        // Agrego los centros al listado
        foreach (PorcentajeUnidadesPorCentro porc in porcentajes)
        {
            porc.ModeloVendidos = new List<ModeloVendidos>();
            // Recorro los modelos
            foreach (var item in modelos)
            {
                // Obtengo la cantidad para sacar el porcentaje
                int cant = _ventaList.Count(x => x.IdModelo == item.Id && x.IdCentroDistribucion == porc.IdCentro);
                // Si la cantidad de vendidos es mayor a 0 agrego a objeto para devolver a front
                if (cant > 0)
                {
                    porc.ModeloVendidos.Add(new ModeloVendidos()
                    {
                        Id = item.Id,
                        Nombre = item.Nombre,
                        Precio = item.Precio,
                        Impuesto = item.Impuesto,
                        Cantidad = cant,
                        Porcentaje = cant * 100 / porc.TotalVendidos
                    });
                }
            }
        }

        // Retorno porcentajes
        return porcentajes;
    }

    public bool Remove(int id)
    {
        // Obtengo la Venta y verifico si existe
        Venta venta = GetById(id);
        if (venta != null)
            // Elimino Venta si existe
            _ventaList.Remove(venta);
        else return false;

        return true;
    }

    public bool Update(int id, Venta entity)
    {
        // Busco el indice de Venta y verifico si es distinto de -1(es decir que no existe. IndexOf devuelve por default el -1)
        int indexOf = _ventaList.IndexOf(GetById(id));
        if (indexOf != -1)
        {
            // Seteo ID, Fecha y actualizo la venta
            entity.Id = id;
            entity.Fecha = DateTime.Now;
            _ventaList[indexOf] = entity;
        }

        else return false;

        return true;
    }

    public IEnumerable<VolumenVentaTotalModelo> VolumenVentaTotal()
    {
        // Obtengo el listado de modelos
        List<Modelo> modelos = _modeloRepository.GetAll().ToList();
        List<VolumenVentaTotalModelo> volumen = new List<VolumenVentaTotalModelo>();
        foreach (Modelo modelo in modelos)
            volumen.Add(new VolumenVentaTotalModelo()
            {
                IdModelo = modelo.Id,
                Nombre = modelo.Nombre,
                // Devuelvo la suma de precio por modelos de autos vendidos
                Total = _ventaList.Where(x => x.IdModelo == modelo.Id).Sum(venta => venta.PrecioCompra)
            });

        return volumen;
    }

    public IEnumerable<VolumenVentaTotalPorCentro> VolumenVentaTotalPorCentro()
    {
        // Ontengo Centros de distribucion
        List<CentroDistribucion> centros = _centroDistribucionRepository.GetAll().ToList();
        List<VolumenVentaTotalPorCentro> volumen = new List<VolumenVentaTotalPorCentro>();
        foreach (CentroDistribucion centro in centros)
        {
            volumen.Add(new VolumenVentaTotalPorCentro()
            {
                IdCentro = centro.Id,
                Nombre = centro.Nombre,
                // Devuelvo la suma de precio por Centro de distribucion
                Total = _ventaList.Where(x => x.IdCentroDistribucion == centro.Id).Sum(venta => venta.PrecioCompra)
            });
        }

        // Retorno volumen
        return volumen;
    }
}
