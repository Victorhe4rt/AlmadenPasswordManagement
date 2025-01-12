using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlmadenApi.Data.Interface;
using AlmadenApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace AlmadenApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LastPassCardController : ControllerBase
    {
        private readonly ILastPassCardRepository _lastPassCardRepository;


        public LastPassCardController(ILastPassCardRepository userRepository)
        {
            _lastPassCardRepository = userRepository;
        }

        // 1. GET: api/LastPassCard
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var users = await _lastPassCardRepository.GetAllAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        // 2. GET: api/LastPassCard/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var LastPassCard = await _lastPassCardRepository.GetByIdAsync(id);
                if (LastPassCard == null)
                {
                    return NotFound("LastPassCard not found.");
                }
                return Ok(LastPassCard);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        // 3. POST: api/LastPassCard
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LastPassCard LastPassCard)
        {
            try
            {
                if (LastPassCard == null)
                {
                    return BadRequest("Invalid LastPassCard object.");
                }

                await _lastPassCardRepository.AddAsync(LastPassCard);
                return CreatedAtAction(nameof(GetById), new { id = LastPassCard.Id }, LastPassCard);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        // 4. PUT: api/LastPassCard/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] LastPassCard LastPassCard)
        {
            try
            {
                if (LastPassCard == null || id != LastPassCard.Id)
                {
                    return BadRequest("LastPassCard object is invalid.");
                }

                var existingUser = await _lastPassCardRepository.GetByIdAsync(id);
                if (existingUser == null)
                {
                    return NotFound("LastPassCard not found.");
                }

                await _lastPassCardRepository.UpdateAsync(LastPassCard);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        // 5. DELETE: api/LastPassCard/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var existingUser = await _lastPassCardRepository.GetByIdAsync(id);
                if (existingUser == null)
                {
                    return NotFound("LastPassCard not found.");
                }

                await _lastPassCardRepository.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

    }
}