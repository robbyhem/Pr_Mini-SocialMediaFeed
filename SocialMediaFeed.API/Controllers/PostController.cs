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
            if (id == 0)
            {
                return BadRequest("Id can not be zero");
            }

            var post = _unitOfWork.Post.Get(x => x.Id == id, include: ["User"]);
            if (post == null)
            {
                return NotFound();
            }

            var postDto = _mapper.Map<PostDto>(post);
            return Ok(postDto);
        }

        [HttpGet("feed")]
        public ActionResult<IEnumerable<PostDto>> GetFeed(
            string? nameFilter = null, 
            string? orderBy = null, 
            int? pageNumber = 1, int? 
            pageSize = 10)
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
                    case "user":
                        orderByExpression = p => p.OrderBy(p => p.User.UserName);
                        break;
                    case "likes":
                        orderByExpression = p => p.OrderByDescending(p => p.Likes);
                        break;
                    case "date":
                        orderByExpression = p => p.OrderBy(p => p.CreatedAt);
                        break;
                    case "post":
                        orderByExpression = p => p.OrderBy(p => p.Text);
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
