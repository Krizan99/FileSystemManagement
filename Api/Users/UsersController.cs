using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Api.Users.Requests;
using Api.Users.Responses;

using Data.EntityFramework;

using Domain.Entities.Users;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, UserRequest request)
        {
            User? user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            user.Update(
                email: request.Email,
                username: request.Username,
                password: request.Password,
                request.Type
            );

            await _context.SaveChangesAsync();

            return Ok();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> CreateAsync(UserRequest request)
        {
            User user = new(
                email: request.Email, 
                username: request.Username, 
                password: request.Password, 
                request.Type
            );

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            UserResponse response = new(user);
            return CreatedAtAction(nameof(GetAsync), new { id = response.Id }, response);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            User? user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
