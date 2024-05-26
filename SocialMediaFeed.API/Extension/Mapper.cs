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
                .ForMember(d => d.User, o => o.MapFrom(s => s.User.UserName));
            CreateMap<Post, CreatePostDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<Follow, FollowDto>().ReverseMap()
                .ForMember(d => d.FollowerId, o => o.MapFrom(s => s.Follower))
                .ForMember(d => d.FolloweeId, o => o.MapFrom(s => s.Followee));
            CreateMap<Follow, CreateFollowDto>().ReverseMap();
        }
    }
}
