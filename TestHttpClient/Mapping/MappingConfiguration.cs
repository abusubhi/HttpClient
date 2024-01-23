using AutoMapper;
using Posts.Business.Services;
using Posts.DataContract.DTOs;
using Posts.DataContract.Interfaces;
using Posts.DataContract.Models;

namespace TestHttpClient.Mapping
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {

            
            CreateMap<User, GetAllUsersDTO>()
                 .ForMember(e => e.Email, opt => opt.MapFrom(src => src.UserEmil));

            CreateMap<Post, GetPostByIdDTO>();
            CreateMap<Post, GetPostByUserIdDTO>();




           // CreateMap<newUserDTO, GlobalExceptionFilter>();

            CreateMap<Exception, GetUserByIdDTO>();


            CreateMap<newUserDTO, TestUser>()

            .ForMember(dest => dest.address, opt => opt.MapFrom(src =>
                $"{src.address.city}-- {src.address.street}--- {src.address.suite}-- {src.address.zipcode}-- {src.address.geo}"))
            .ForMember(dest => dest.company, opt => opt.MapFrom(src =>
                $"{src.company.name}-- {src.company.catchPhrase}--{src.company.bs}")
            );
        }
    }
}
    //             .ForMember(dest => dest.address, opt => opt.MapFrom(src => new GetUserByIdDTO.Address
    //             {
    //                 city = src.address.city,
    //                 street = src.address.street,
    //                 suite = src.address.suite,
    //                 zipcode = src.address.zipcode,
    //                 geo = src.address.geo
    //             }))
    //.ForMember(dest => dest.company, opt => opt.MapFrom(src => new GetUserByIdDTO.Company
    //{
    //    name = src.company.name,
    //    catchPhrase = src.company.catchPhrase,
    //    bs = src.company.bs
    //}));