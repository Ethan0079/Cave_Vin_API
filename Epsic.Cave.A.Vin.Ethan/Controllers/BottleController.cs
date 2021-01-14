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
    public class BottlesController : ControllerBase
    {
        private readonly IBottlesService _bottlesService;

        public BottlesController(IBottlesService bottlesService)
        {
            _bottlesService = bottlesService;
        }

        [HttpGet("bottles")]
        public async Task<IActionResult> SearchAsync([FromQuery] string name)
        {
            try
            {
                return Ok(await _bottlesService.GetAll(name));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("bottles/{id}")]
        public async Task<IActionResult> GetSingleAsync(int id)
        {
            try
            {
                var result = await _bottlesService.GetSingle(id);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("bottles/{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] UpdateBottleDto model)
        {
            try
            {
                return Ok(await _bottlesService.UpdateAsync(id, model));
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

        [HttpPost("bottles")]
        public async Task<IActionResult> CreateAsync(CreateBottleDto model)
        {
            try
            {
                var modelDb = await _bottlesService.CreateAsync(model);

                return Created($"bottles/{modelDb.Id}", modelDb);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("bottles/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _bottlesService.Delete(id);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpDelete("bottles/characters")]
        //public async Task<IActionResult> RemoveCharacterFromBottleAsync(RemoveCharacterFromBottleDto removeCharacterFromBottle)
        //{
        //    try
        //    {
        //        await _bottlesService.RemoveCharacterFromBottle(removeCharacterFromBottle);
        //        return Ok();
        //    }
        //    catch (DataNotFoundException ex)
        //    {
        //        return NotFound(ex.Message);
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        //[HttpPost("bottles/characters")]
        //public async Task<IActionResult> AddCharacterToBottleAsync(AddCharacterToBottleDto addCharacterToBottle)
        //{
        //    try
        //    {
        //        await _bottlesService.AddCharacterToBottle(addCharacterToBottle);
        //        return Ok();
        //    }
        //    catch (DataNotFoundException ex)
        //    {
        //        return NotFound(ex.Message);
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}
