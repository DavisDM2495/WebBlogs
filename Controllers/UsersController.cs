using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebsiteBlogs.Data;
using WebsiteBlogs.Models;
using WebsiteBlogs.Models.Dtos;

namespace WebsiteBlogs.Controllers {
    // api/Users
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UsersController(ApplicationDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }
        
        // api/users
        [HttpGet("")]
        //[HttpGet("/api/users")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers() {
            // Get the data from the database
           var users = await _context.Users
                .Select(u => u.Users)
                    // .ThenInclude(b => b.Blog)
                    // .ThenInclude(c => c.Comments)
                    // .ThenInclude(p => p.Post)
                    // .ThenInclude(t => t.Tag)
                .ToListAsync();

            // var userDtos = users
            //     .Select(u => _mapper.Map<UserDto>(u))
            //     .ToList();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id) {
            var user = await _context.Users
                .FindAsync(id);

            if(null == user) {
                return NotFound();
            }
            return Ok(user);
        }

    }
}