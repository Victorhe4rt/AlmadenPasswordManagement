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
    public class FolderController : ControllerBase
    {
        private readonly IFolderRepository _folderRepository;


        public FolderController(IFolderRepository userRepository)
        {
            _folderRepository = userRepository;
        }

        // 1. GET: api/Folder
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var users = await _folderRepository.GetAllAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        // 2. GET: api/Folder/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var Folder = await _folderRepository.GetByIdAsync(id);
                if (Folder == null)
                {
                    return NotFound("Folder not found.");
                }
                return Ok(Folder);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        // 3. POST: api/Folder
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Folder Folder)
        {
            try
            {
                if (Folder == null)
                {
                    return BadRequest("Invalid Folder object.");
                }

                await _folderRepository.AddAsync(Folder);
                return CreatedAtAction(nameof(GetById), new { id = Folder.Id }, Folder);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        // 4. PUT: api/Folder/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Folder Folder)
        {
            try
            {
                if (Folder == null || id != Folder.Id)
                {
                    return BadRequest("Folder object is invalid.");
                }

                var existingUser = await _folderRepository.GetByIdAsync(id);
                if (existingUser == null)
                {
                    return NotFound("Folder not found.");
                }

                await _folderRepository.UpdateAsync(Folder);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        // 5. DELETE: api/Folder/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var existingUser = await _folderRepository.GetByIdAsync(id);
                if (existingUser == null)
                {
                    return NotFound("Folder not found.");
                }

                await _folderRepository.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

    }
}