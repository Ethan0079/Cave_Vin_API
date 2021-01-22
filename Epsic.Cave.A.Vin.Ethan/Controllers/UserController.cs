using System;
using System.Threading.Tasks;
using Epsic_Cave_A_Vin_Ethan.Exceptions;
using Epsic_Cave_A_Vin_Ethan.Models;
using Epsic_Cave_A_Vin_Ethan.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Epsic_Cave_A_Vin_Ethan.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet("users")]
        public async Task<IActionResult> SearchAsync([FromQuery] string name)
        {
            try
            {
                return Ok(await _usersService.GetAll(name));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("users/{id}")]
        public async Task<IActionResult> GetSingleAsync(int id)
        {
            try
            {
                var result = await _usersService.GetSingle(id);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("users/{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] UpdateUserDto model)
        {
            try
            {
                return Ok(await _usersService.UpdateAsync(id, model));
            }
            catch (DataNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("users")]
        public async Task<IActionResult> CreateAsync(CreateUserDto model)
        {
            try
            {
                var modelDb = await _usersService.CreateAsync(model);

                return Created($"users/{modelDb.Id}", modelDb);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("users/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _usersService.Delete(id);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
