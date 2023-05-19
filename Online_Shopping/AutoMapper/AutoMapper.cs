using AutoMapper;
using BAL.Models;
using Online_Shopping.DTOs;

namespace Online_Shopping.AutoMapper
{
    public class AutoMapper:Profile
    {
        public AutoMapper()
        {
            CreateMap<Category, CategoryDTo>().ReverseMap();
            CreateMap<SubCategory, SubCategoryDTo>().ReverseMap();
            CreateMap<Product, ProductDTo>().ReverseMap();
        }
    }
}
