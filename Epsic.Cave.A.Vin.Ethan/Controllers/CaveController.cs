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
    public class CavesController : ControllerBase
    {
        private readonly ICavesService _cavesService;

        public CavesController(ICavesService cavesService)
        {
            _cavesService = cavesService;
        }

        [HttpGet("caves")]
        public async Task<IActionResult> SearchAsync([FromQuery] string name)
        {
            try
            {
                return Ok(await _cavesService.GetAll(name));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("caves/{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] UpdateCaveDto model)
        {
            try
            {
                return Ok(await _cavesService.UpdateAsync(id, model));
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

        [HttpPost("caves")]
        public async Task<IActionResult> CreateAsync(CreateCaveDto model)
        {
            try
            {
                var modelDb = await _cavesService.CreateAsync(model);

                return Created($"caves/{modelDb.Id}", modelDb);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("caves/{id}")]
        public async Task<IActionResult> GetSingleAsync(int id)
        {
            try
            {
                var result = await _cavesService.GetSingle(id);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("caves/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _cavesService.Delete(id);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
