using Catedra1_idwm.src.DTOs;
using Catedra1_idwm.src.Interfaces;
using Catedra1_idwm.src.Mappers;
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

        
        
    }
}