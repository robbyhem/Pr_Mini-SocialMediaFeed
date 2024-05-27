using AutoMapper;
using SocialMediaFeed.API.Dtos;
using SocialMediaFeed.Domain.Models;

namespace SocialMediaFeed.API.Extension
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Post, PostDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName));
            CreateMap<CreatePostDto, Post>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<CreateUserDto, User>().ReverseMap();
            CreateMap<Follow, FollowDto>()
                .ForMember(dest => dest.FollowerUserName, opt => opt.MapFrom(src => src.Follower.UserName))
                .ForMember(dest => dest.FolloweeUserName, opt => opt.MapFrom(src => src.Followee.UserName));
            CreateMap<CreateFollowDto, Follow>().ReverseMap();
        }
    }
}
