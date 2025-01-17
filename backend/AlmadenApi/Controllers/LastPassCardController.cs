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


        public LastPassCardController(ILastPassCardRepository lastPassCardRepository)
        {
            _lastPassCardRepository = lastPassCardRepository;
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
        // 3. GET: api/LastPassCard/user/{userId}
        [HttpGet("user/{userId}")]
        public IActionResult GetByUserId(int userId)
        {
            try
            {
                var lastPassCards = _lastPassCardRepository.GetByUserId(userId);
                if (!lastPassCards.Any())
                {
                    return NotFound("No LastPassCards found for this user.");
                }
                return Ok(lastPassCards);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        // 4. POST: api/LastPassCard
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

        // 5. PUT: api/LastPassCard/{id}
    [HttpPut("{id}")]
public async Task<IActionResult> Update(int id, [FromBody] LastPassCard updatedCard)
{
    try
    {
        if (updatedCard == null)
        {
            return BadRequest("LastPassCard object is invalid.");
        }

        var existingCard = await _lastPassCardRepository.GetByIdAsync(id);
        if (existingCard == null)
        {
            return NotFound("LastPassCard not found.");
        }

        existingCard.Url = updatedCard.Url;
        existingCard.Name = updatedCard.Name;
        existingCard.Pk_UserId = updatedCard.Pk_UserId;
        existingCard.UserName = updatedCard.UserName;
        existingCard.Password = updatedCard.Password;

        await _lastPassCardRepository.UpdateAsync(existingCard);

        return Ok(existingCard);
    }
    catch (Exception ex)
    {
        return StatusCode(500, "Internal server error: " + ex.Message);
    }
}


        // 6. DELETE: api/LastPassCard/{id}
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