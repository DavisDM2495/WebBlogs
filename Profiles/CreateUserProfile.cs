using AutoMapper;
using System;
using WebsiteBlogs.Models;
using WebsiteBlogs.Models.Dtos;

namespace WebsiteBlogs.Profiles;
public class CreateUserProfile : Profile {
    public CreateUserProfile() {
        CreateMap<User, CreateUserDto>().ReverseMap();
    }
}