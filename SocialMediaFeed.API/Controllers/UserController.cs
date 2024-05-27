using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMediaFeed.API.Dtos;
using SocialMediaFeed.DataAccess.Data;
using SocialMediaFeed.Domain.Interface;
using SocialMediaFeed.Domain.Models;

namespace SocialMediaFeed.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<CreateUserDto> CreateUser([FromBody] CreateUserDto user)
        {
            var userToDb = _mapper.Map<User>(user);
            _unitOfWork.User.Add(userToDb);
            _unitOfWork.Save();
            var dtoUser = _mapper.Map<UserDto>(userToDb);
            return CreatedAtAction(nameof(GetUserById), new { id = userToDb.Id }, dtoUser);
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetAllUsers()
        {
            var user = _unitOfWork.User.GetAll();
            var userDto = _mapper.Map<IEnumerable<UserDto>>(user);
            return Ok(userDto);

        }

        [HttpGet("{id}")]
        public ActionResult<UserDto> GetUserById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var user = _unitOfWork.User.Get(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }
    }
}
