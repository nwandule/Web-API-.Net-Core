using AutoMapper;
using Demo_App.Model.Domain;
using Demo_App.Model.Dto;

namespace Demo_App.Mappings
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, AddProductRequestDto>().ReverseMap();
        }
    }
}
