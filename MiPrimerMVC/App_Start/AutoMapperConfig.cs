using AutoMapper;
using Domain.Entities;
using MiPrimerMVC.Models;

namespace MiPrimerMVC
{
    public class AutoMapperConfig
    {
        public static void RegisterMaps()
        {
            Mapper.CreateMap<AccountRegisterModel, Account>().ReverseMap();
            Mapper.CreateMap<ClasificadosCreateModel, Clasificado>().ReverseMap();
        }
    }
}