using AutoMapper;
using EcommerceServiceOperation.Infrastructure.Entities;

namespace EcommerceServiceOperation.Infrastructure.Mapper;

public class CategoryMapper : Profile
{
    public CategoryMapper()
        =>  CreateMap<CategoryResponses, Category>().ReverseMap();
}