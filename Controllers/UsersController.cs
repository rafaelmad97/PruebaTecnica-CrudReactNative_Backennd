using CarsApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarsApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsersController: ControllerBase
    {
        private readonly DBContext _context;
        public UsersController(DBContext context) { 
            this._context = context;
        } 

        [HttpGet]
        public async Task<ActionResult<List<users>>> GetUsers()
        {
            if (_context.Users == null)
            {
                return NotFound();

            }
            return await _context.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<users>> GetUserbyId(long id)
        {
            
            var user =  await _context.Users.FindAsync(id);
            if(user == null)
            {
                return NotFound();
            }

            return user;
        }


        [HttpPost]
        public async Task<ActionResult<users>> PostCars(users cars)
        {

            if(_context.Users == null)
            {
                return Problem("la entidad no esta definida");
            }

            _context.Users.Add(cars);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetUsers", new { id = cars.id }, cars);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCars(long id, users user)
        {
            if (id != user.id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;
            try
            {
                var data = _context.Users.Find(id);
                if(data == null)
                {
                    return NotFound();
                }

                await _context.SaveChangesAsync();
                return Ok();

            }catch(Exception e) {
                return BadRequest(e.Message);
            }

        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteCars(long id)
        {
            try
            {
                var car = await _context.Users.FindAsync(id);
                if(car == null)
                {   
                    return NotFound();
                }
                _context.Users.Remove(car);
                await _context.SaveChangesAsync();
                return Ok();

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
