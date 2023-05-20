using AutoMapper;
using BAL.Models;
using OnlineShopingApi.Models;

namespace OnlineShopingApi.AutoMapper
{
    public class AutoMapper:Profile
    {
        public AutoMapper()
        {
            CreateMap<Product, APIProductDTo>()
            .ForMember(dist => dist.CategoryName, src => src.MapFrom(s => s.Category.Name))
             .ForMember(dist => dist.SubCategoryName, src => src.MapFrom(s => s.SubCategory.Name))
             .ReverseMap();

        }
    }
}
