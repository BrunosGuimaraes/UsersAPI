using Microsoft.AspNetCore.Mvc;

namespace UsersAPI.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        /// <summary>
        /// Criar conta de usuário
        /// </summary>
        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
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
        public IActionResult Delete()
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
