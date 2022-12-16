using AutoMapper;
using DTO.DTOs.ProductDTOs;
using DTO.DTOs.ProductToDoListDTOs;
using DTO.DTOs.UserDTOs;
using Shoppinglist_EntityLayer.Concrete;

namespace ShoppingList_UI.Mapping.AutoMapperProfile
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductAddDto>();
            CreateMap<ProductAddDto, Product>();

            CreateMap<Product, ProductUpdateDto>();
            CreateMap<ProductUpdateDto, Product>();

            //CreateMap<AppUser, UserSignUpDto>();
            //CreateMap<UserSignUpDto, AppUser>();
        }
    }
}
