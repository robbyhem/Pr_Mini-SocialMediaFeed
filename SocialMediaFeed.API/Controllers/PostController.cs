using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMediaFeed.API.Dtos;
using SocialMediaFeed.DataAccess.Data;
using SocialMediaFeed.Domain.Interface;
using SocialMediaFeed.Domain.Models;
using System.Linq.Expressions;

namespace SocialMediaFeed.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PostController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<CreatePostDto> CreatePost([FromBody] CreatePostDto post)
        {
            var postToDb = _mapper.Map<Post>(post);
            _unitOfWork.Post.Add(postToDb);
            _unitOfWork.Save();
            var dtoPost = _mapper.Map<PostDto>(postToDb);
            return CreatedAtAction(nameof(GetPostById), new { id = postToDb.Id }, dtoPost);
        }

        [HttpGet("{id}")]
        public ActionResult<Post> GetPostById(int id)
        {
            var post = _unitOfWork.Post.Get(x => x.Id == id, include: ["User"]);
            var postDto = _mapper.Map<PostDto>(post);
            return Ok(postDto);
        }

        [HttpGet("feed")]
        public ActionResult<IEnumerable<PostDto>> GetFeed(/*int userId,*/ string? nameFilter = null, string? orderBy = null, int? pageNumber = 1, int? pageSize = 10)
        {
            Expression<Func<Post, bool>>? filter = null;
            if (!string.IsNullOrEmpty(nameFilter))
            {
                filter = p => p.User.UserName.ToLower().Contains(nameFilter);
            }

            Func<IQueryable<Post>, IOrderedQueryable<Post>>? orderByExpression = null;
            if (!string.IsNullOrEmpty(orderBy))
            {
                switch (orderBy.ToLower())
                {
                    case "userName":
                        orderByExpression = p => p.OrderBy(p => p.User.UserName);
                        break;
                    case "userId":
                        orderByExpression = p => p.OrderBy(p => p.Likes);
                        break;
                    default:
                        orderByExpression = p => p.OrderBy(p => p.User.UserName);
                        break;
                }
            }

            var includes = "User";
            var posts = _unitOfWork.Post.GetAll(filter, includes, orderByExpression, pageNumber, pageSize);
            var postDto = _mapper.Map<IEnumerable<PostDto>>(posts);
            return Ok(postDto);
        }
    }
}
