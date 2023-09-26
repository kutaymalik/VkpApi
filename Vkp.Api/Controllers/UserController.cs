// UserController.cs
using Microsoft.AspNetCore.Mvc;
using Vkp.Data.Domain;
using Vkp.Data.Repository;

namespace Vkp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // Register voter (In the first version, voters will be created. However, in the actual version to be used, voter data must be get from the required database.))
        [HttpPost("Register")]
        public async Task<IActionResult> Register(User user)
        {
            try
            {
                // Register voter
                await _userRepository.AddAsync(user);
                return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Voter Login
        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginRequest userLoginRequest)
        {
            try
            {
                // Kullanıcıyı doğrula ve oturum aç
                var user = await _userRepository.GetUserByTCKNAsync(userLoginRequest.TCKN);

                if (user == null || user.Password != userLoginRequest.Password)
                {
                    return Unauthorized("Invalid TCKN or Password");
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Get user information
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
