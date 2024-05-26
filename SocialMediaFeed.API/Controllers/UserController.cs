using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMediaFeed.API.Dtos;
using SocialMediaFeed.DataAccess.Data;
using SocialMediaFeed.Domain.Models;

namespace SocialMediaFeed.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser([FromBody] CreateUserDto user)
        {
            var userToDb = _mapper.Map<User>(user);
            _context.Users.Add(userToDb);
            await _context.SaveChangesAsync();
            var dtoUser = _mapper.Map<UserDto>(userToDb);
            return CreatedAtAction(nameof(GetUserById), new { id = userToDb.Id }, dtoUser);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}
