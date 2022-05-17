using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // api/users/player1
        [HttpGet("{userName}")]
        public async Task<ActionResult<AppUser>> GetUser(string userName)
        {
            return await _context.Users.Where(x => x.UserName.ToLower() == userName.ToLower()).FirstOrDefaultAsync();
        }
    }
}