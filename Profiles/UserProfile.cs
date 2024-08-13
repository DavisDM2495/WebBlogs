using AutoMapper;
using System;
using WebsiteBlogs.Models;
using WebsiteBlogs.Models.Dtos;

namespace WebsiteBlogs.Profiles;
public class UserProfile : Profile {
    public UserProfile() {
        CreateMap<User, UserDto>().ReverseMap();
    }
}