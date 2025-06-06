﻿using AutoMapper;
using DotNetCore_Angular_SocialMedia_App.DTOs;
using DotNetCore_Angular_SocialMedia_App.Entities;
using DotNetCore_Angular_SocialMedia_App.Extensions;

namespace DotNetCore_Angular_SocialMedia_App.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>()
           .ForMember(d => d.Age, o => o.MapFrom(s => s.DateOfBirth.CalculateAge()))
           .ForMember(d => d.PhotoUrl, o =>
               o.MapFrom(s => s.Photos.FirstOrDefault(x => x.IsMain)!.Url));
            CreateMap<Photo, PhotoDto>();
            CreateMap<MemberUpdateDto, AppUser>();
            CreateMap<RegisterDto, AppUser>().ReverseMap();
            CreateMap<string, DateOnly>().ConvertUsing(s => DateOnly.Parse(s));
        }
    }
}
