using AutoMapper;
using Popravi.Business.DataTransfer;
using Popravi.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Popravi.Business.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
                //.ForMember(dest => dest.FirstName, opts => opts.MapFrom(src => src.FirstName));
        }
    }
}
