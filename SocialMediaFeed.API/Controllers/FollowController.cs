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
        public ActionResult<CreateFollowDto> FollowUser([FromBody] CreateFollowDto follow)
        {
            if (follow.FollowerId == follow.FolloweeId)
            {
                return BadRequest("User cannot follow themselves.");
            }

            if (follow.FollowerId == null || follow.FolloweeId == null)
            {
                return NotFound("The input you have entered does not exist");
            }

            if (follow.FollowerId == 0 || follow.FolloweeId == 0)
            {
                return BadRequest("You have entered a wrong input");
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
