
using AutoMapper;
using PrimeiroApp.Data.Dtos;
using PrimeiroApp.Models;

namespace PrimeiroApp.Profiles;

public class FilmeProfile : Profile
{
    public FilmeProfile()
    {
        CreateMap<CriateFilmeDto, Filme>();
        CreateMap<UpdateFilmeDto, Filme>();
        CreateMap<Filme, UpdateFilmeDto>();
        CreateMap<Filme, ReadFilmeDto>();


    }
}
