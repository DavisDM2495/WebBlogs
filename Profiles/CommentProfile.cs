using AutoMapper;
using System;
using WebsiteBlogs.Models;
using WebsiteBlogs.Models.Dtos;

namespace WebsiteBlogs.Profiles;
public class CommentProfile : Profile {
    public CommentProfile() {
        CreateMap<Comment, CommentDto>().ReverseMap();
    }
}