using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortalTechnicalChallenge.Application.ViewModels.User;
using System.Security.Cryptography.X509Certificates;

/// <summary>
/// automapper para mapear automaticamente entidades
/// </summary>

namespace TechnicalChallenge.Application.Mapper.User
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
           

            CreateMap<CreateUserViewModel, PortalTechnicalChallenge.Domain.Entities.User>();
            CreateMap<UserViewModel, PortalTechnicalChallenge.Domain.Entities.User>();
            CreateMap<PortalTechnicalChallenge.Domain.Entities.User, UserViewModel>().ForMember(x => x.CreatedAt, o => o.MapFrom(s => s.CreatedAt.ToUniversalTime().ToString("o")));
            CreateMap<PortalTechnicalChallenge.Domain.Entities.User, UpdateUserViewModel>();
            CreateMap<UpdateUserViewModel, PortalTechnicalChallenge.Domain.Entities.User>();
        }
    }
}
