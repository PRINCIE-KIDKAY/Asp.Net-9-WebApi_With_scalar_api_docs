using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Models;
using api.Dtos.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class Test_controller : ControllerBase
{
    private readonly Data.ApplicationDBContext _context;

    public Test_controller(Data.ApplicationDBContext context)
    {
        _context = context;
    }
        // private readonly DbContext _context = context;

        // GET: api/users
        [HttpGet("get_all_user")]
       public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            try
            {
                var users = await _context.Set<User>().ToListAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
    
                // Console.WriteLine($"Error fetching users: {ex.Message}");
                // Return an appropriate error response
                return StatusCode(500, ex.Message);
            }
        }


        // GET: api/users/{id}
        [HttpGet("get_user/{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Set<User>().FindAsync(id);
            if (user == null)
            {
                return StatusCode(404, "Not Found");
            }
            return user;
        }

        // POST: api/users
        [HttpPost("create_user")]
        public async Task<ActionResult<User>> CreateUser(UserDto userDto)
        {

             try
            {
                var user = new User
            {
                Name = userDto.Name,
                Surname = userDto.Surname,
                Email = userDto.Email
            };

            _context.Set<User>().Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
            }
            catch (Exception ex)
            {
                // Return an appropriate error response
                return StatusCode(500, ex.Message);
            }
        }

        // PUT: api/users/{id}
        [HttpPut("update_user/{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserDto userDto)
        {



             try
            {
                var user = await _context.Set<User>().FindAsync(id);
                if (user == null)
                {
                    return NotFound();
                }

                user.Name = userDto.Name;
                user.Surname = userDto.Surname;
                user.Email = userDto.Email;

                _context.Entry(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                // Return an appropriate error response
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE: api/users/{id}
        [HttpDelete("delete_user/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Set<User>().FindAsync(id);
            if (user == null)
            {
                return StatusCode(404, "User not Found");
            }

            _context.Set<User>().Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
