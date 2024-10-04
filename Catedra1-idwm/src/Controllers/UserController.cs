using Catedra1_idwm.src.DTOs;
using Catedra1_idwm.src.Interfaces;
using Catedra1_idwm.src.Mappers;
using Catedra1_idwm.src.Models;
using Catedra1_idwm.src.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catedra1_idwm.src.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var exists = await _userRepository.ExistsByRut(createUserDto.Rut);
            if (exists)
            {
                return Conflict("El RUT ya existe");
            }
            var userModel = createUserDto.ToUserFromUserDto();
            await _userRepository.Post(userModel);
            return CreatedAtAction(nameof(CreateUser), new { code = userModel.Rut }, userModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery] string? gender, [FromQuery] string? sort)
        {
            var validGenders = new List<string> {"masculino", "femenino", "otro", "prefiero no decirlo"};
            var validSorts = new List<string> {"asc", "desc"};
            if (!string.IsNullOrEmpty(gender) && !validGenders.Contains(gender))
            {
                return BadRequest("Indique uno de los siguientes géneros: masculino, femenino, otro, prefiero no decirlo");
            }
            else if (!string.IsNullOrEmpty(sort) && !validSorts.Contains(sort))
            {
                return BadRequest("Los posibles filtros de ordenación son: asc, desc");
            }
            
            var users = await _userRepository.GetAll(gender, sort);
            var usersDto = users.Select(u => u.ToUserDto());
            if (users == null)
            {
                return BadRequest("Filtros inválidos");
            }
            return Ok(usersDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute]int id, [FromBody] UpdateUserDto updateUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Llamar al método de actualización del repositorio
            var result = await _userRepository.Put(id, updateUserDto);

            if (result == null)
            {
                return NotFound(new { message = "Usuario no encontrado" });
            }

            return Ok(new { message = "Usuario actualizado exitosamente" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            var userDeleted = await _userRepository.Delete(id);
            if (userDeleted == null)
            {
                return NotFound("Usuario no encontrado");
            }
            return Ok("Usuario eliminado exitosamente");
        }
            
    }
}