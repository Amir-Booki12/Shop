using AutoMapper;
using Shop.Api.ViewModels.Users;
using Shop.Application.Users.AddUserAddress;

namespace Shop.Api.Infrastructure
{

    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AddAddressUserCommand, AddUserAddressViewModel>()
                .ReverseMap();

            
        }
    }
}
