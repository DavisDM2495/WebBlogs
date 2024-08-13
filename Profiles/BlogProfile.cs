using AutoMapper;
using System;
using WebsiteBlogs.Models;
using WebsiteBlogs.Models.Dtos;

namespace WebsiteBlogs.Profiles;
public class BlogProfile : Profile {
    public BlogProfile() {
        CreateMap<Blog, BlogDto>().ReverseMap();
    }
}