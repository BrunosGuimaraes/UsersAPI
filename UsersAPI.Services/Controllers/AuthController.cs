using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UsersAPI.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        /// <summary>
        /// Autenticar o usuário
        /// </summary>
        [Route("login")]
        [HttpPost]
        public IActionResult Login()
        {
            return Ok();
        }

        /// <summary>
        /// Recuperar senha de acesso do usuário
        /// </summary>
        [Route("forgot-password")]
        [HttpPost]
        public IActionResult ForgotPassword()
        {
            return Ok();
        }

        /// <summary>
        /// Reiniciar senha de acesso do usuário
        /// </summary>
        [Route("reset-password")]
        [HttpPost]
        public IActionResult ResetPassword()
        {
            return Ok();
        }
    }
}
