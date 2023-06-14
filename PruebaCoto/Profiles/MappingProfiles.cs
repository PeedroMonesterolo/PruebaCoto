using API.Dtos;
using AutoMapper;
using CORE.Entities;

namespace API.Profiles;

public class MappingProfiles : Profile
{
    /// <summary>
    /// Mapeo de DTO a Entidades
    /// </summary>
    public MappingProfiles()
    {
        CreateMap<Venta, VentaDto>()
            .ReverseMap();

        CreateMap<Modelo, ModeloDto>()
            .ReverseMap();

        CreateMap<CentroDistribucion, CentroDistribucionDto>()
            .ReverseMap();
    }
}
