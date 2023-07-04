using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UsersAPI.Application.Dtos.Requests;
using UsersAPI.Application.Interfaces.Application;

namespace UsersAPI.Services.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserAppService userAppService;

        public UsersController(IUserAppService userAppService)
        {
            this.userAppService = userAppService;
        }

        /// <summary>
        /// Criar conta de usuário
        /// </summary>
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Add(UserAddRequestDto userAddRequest)
        {
            return StatusCode(201, userAppService.Add(userAddRequest));
        }

        /// <summary>
        /// Alterar conta de usuário
        /// </summary>
        [HttpPut]
        public IActionResult Put()
        {
            return Ok();
        }

        /// <summary>
        /// Excluir conta de usuário
        /// </summary>
        [HttpDelete]
        public IActionResult Remove()
        {
            return Ok();
        }

        /// <summary>
        /// Consultar dados da conta de usuário
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
