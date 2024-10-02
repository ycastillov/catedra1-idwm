using Catedra1_idwm.src.Interfaces;
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
        public async Task<IActionResult> CreateUser()
        {
            return Ok();
        }
        
    }
}