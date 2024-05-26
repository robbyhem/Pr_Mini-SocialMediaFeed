using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SocialMediaFeed.API.Dtos;
using SocialMediaFeed.DataAccess.Data;
using SocialMediaFeed.Domain.Interface;
using SocialMediaFeed.Domain.Models;

namespace SocialMediaFeed.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FollowController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<CreateFollowDto>> FollowUser([FromBody] CreateFollowDto follow)
        {
            if (follow.Follower == follow.Followee)
            {
                return BadRequest("User cannot follow themselves.");
            }

            var existingFollow = _mapper.Map<Follow>(follow);
            _unitOfWork.Follow.Add(existingFollow);
            _unitOfWork.Save();
            var dtoFollow = _mapper.Map<FollowDto>(existingFollow);
            return CreatedAtAction(nameof(GetFollowById), new { id = existingFollow.Id }, dtoFollow);
        }

        [HttpGet("{id}")]
        public ActionResult<Follow> GetFollowById(int id)
        {
            var follow = _unitOfWork.Follow.Get(x => x.Id == id, include: ["Follower", "Followee"]);

            if (follow == null)
            {
                return NotFound();
            }
            var followDto = _mapper.Map<FollowDto>(follow);
            return Ok(followDto);
        }
    }
}
