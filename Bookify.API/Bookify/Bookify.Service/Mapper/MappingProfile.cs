using AutoMapper;
using Bookify.Service.Beans;
using Domain.Entities;

namespace Bookify.Service.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegister, User>()
                .ForMember(user => user.Id, option => option.MapFrom(ur => ur.Id))
                .ForMember(user => user.FirstName, option => option.MapFrom(ur => ur.FirstName))
                .ForMember(user => user.LastName, option => option.MapFrom(ur => ur.LastName))
                .ForMember(user => user.Age, option => option.MapFrom(ur => ur.Age))
                .ForMember(user => user.UserName, option => option.MapFrom(ur => ur.Email))
                .ForMember(user => user.Email, option => option.MapFrom(ur => ur.Email))
                .ForMember(user => user.AddressLine1, option => option.MapFrom(ur => ur.AddressLine1))
                .ForMember(user => user.AddressLine2, option => option.MapFrom(ur => ur.AddressLine2))
                .ForMember(user => user.State, option => option.MapFrom(ur => ur.State))
                .ForMember(user => user.City, option => option.MapFrom(ur => ur.City))
                .ForMember(user => user.Country, option => option.MapFrom(ur => ur.Country))
                .ForMember(user => user.ZipCode, option => option.MapFrom(ur => ur.ZipCode))
                .ForMember(user => user.CardOwner, option => option.MapFrom(ur => ur.CardOwner))
                .ForMember(user => user.CreditCardNumber, option => option.MapFrom(ur => ur.CreditCardNumber))
                .ForMember(user => user.CVV, option => option.MapFrom(ur => ur.CVV))
                .ForMember(user => user.Expiration, option => option.MapFrom(ur => ur.Expiration));
        }
    }
}
