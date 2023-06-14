using CORE.Entities;
using CORE.Interfaces;
using INFRASTRUCTURE.Repositories;

namespace API.Extensions;

public static class ApplicationServiceExtensions
{
    /// <summary>
    /// Repositorios para realizar inyeccion de dependencias en controllers
    /// </summary>
    /// <param name="services"></param>
    public static void AddAplicacionServices(this IServiceCollection services)
    {
        services.AddScoped<IModeloRepository, ModeloRepository>();
        services.AddScoped<IVentaRepository, VentaRepository>();
        services.AddScoped<ICentroDistribucionRepository, CentroDistribucionRepository>();
        services.AddScoped<ExecutionTimeFilter>();
    }

    /// <summary>
    /// Configuracion de Mock de Ventas, CentroDistribucion y Modelo
    /// </summary>
    /// <param name="services"></param>
    public static void ConfigureServices(this IServiceCollection services)
    {
        List<Modelo> _modelo = new List<Modelo>()
        {
            new Modelo { Id = 1, Nombre = "Sedan", Precio = 8000, Impuesto = null },
            new Modelo { Id = 2, Nombre = "SUV", Precio = 9500, Impuesto = null },
            new Modelo { Id = 3, Nombre = "Off Road", Precio = 12500, Impuesto = null },
            new Modelo { Id = 4, Nombre = "Sport", Precio = 18200, Impuesto = 7 }
        };
        services.AddSingleton(_modelo);

        List<CentroDistribucion> _centros = new List<CentroDistribucion>()
        {
            new CentroDistribucion { Id = 1, Nombre = "San Fernando" },
            new CentroDistribucion { Id = 2, Nombre = "San Francisco" },
            new CentroDistribucion { Id = 3, Nombre = "Maipu" },
            new CentroDistribucion { Id = 4, Nombre = "Cordoba" }
        };
        services.AddSingleton(_centros);

        List<Venta> _ventas = new List<Venta>()
        {
            new Venta { Id = 1, IdModelo = 1, Fecha = DateTime.Now, IdCentroDistribucion = 1, PrecioCompra = 8000 },
            new Venta { Id = 2, IdModelo = 1, Fecha = DateTime.Now, IdCentroDistribucion = 2, PrecioCompra = 8000 },
            new Venta { Id = 3, IdModelo = 1, Fecha = DateTime.Now, IdCentroDistribucion = 2, PrecioCompra = 8000 },
            new Venta { Id = 4, IdModelo = 1, Fecha = DateTime.Now, IdCentroDistribucion = 1, PrecioCompra = 8000 },

            new Venta { Id = 5, IdModelo = 2, Fecha = DateTime.Now, IdCentroDistribucion = 3, PrecioCompra = 9500 },
            new Venta { Id = 6, IdModelo = 2, Fecha = DateTime.Now, IdCentroDistribucion = 3, PrecioCompra = 9500 },
            new Venta { Id = 7, IdModelo = 2, Fecha = DateTime.Now, IdCentroDistribucion = 3, PrecioCompra = 9500 },
            new Venta { Id = 8, IdModelo = 2, Fecha = DateTime.Now, IdCentroDistribucion = 3, PrecioCompra = 9500 },

            new Venta { Id = 9, IdModelo = 3, Fecha = DateTime.Now, IdCentroDistribucion = 2, PrecioCompra = 12500 },
            new Venta { Id = 10, IdModelo = 3, Fecha = DateTime.Now, IdCentroDistribucion = 2, PrecioCompra = 12500 },
            new Venta { Id = 11, IdModelo = 3, Fecha = DateTime.Now, IdCentroDistribucion = 4, PrecioCompra = 12500 },
            new Venta { Id = 12, IdModelo = 3, Fecha = DateTime.Now, IdCentroDistribucion = 2, PrecioCompra = 12500 },

            new Venta { Id = 13, IdModelo = 4, Fecha = DateTime.Now, IdCentroDistribucion = 1, PrecioCompra = 19474 },
            new Venta { Id = 14, IdModelo = 4, Fecha = DateTime.Now, IdCentroDistribucion = 1, PrecioCompra = 19474 },
            new Venta { Id = 15, IdModelo = 4, Fecha = DateTime.Now, IdCentroDistribucion = 3, PrecioCompra = 19474 },
            new Venta { Id = 16, IdModelo = 4, Fecha = DateTime.Now, IdCentroDistribucion = 2, PrecioCompra = 19474 },
            
            new Venta { Id = 13, IdModelo = 4, Fecha = DateTime.Now, IdCentroDistribucion = 1, PrecioCompra = 19474 },
            new Venta { Id = 14, IdModelo = 4, Fecha = DateTime.Now, IdCentroDistribucion = 1, PrecioCompra = 19474 },
            new Venta { Id = 15, IdModelo = 4, Fecha = DateTime.Now, IdCentroDistribucion = 1, PrecioCompra = 19474 },
            new Venta { Id = 16, IdModelo = 4, Fecha = DateTime.Now, IdCentroDistribucion = 1, PrecioCompra = 19474 },
        };
        services.AddSingleton(_ventas);       
    }
}
