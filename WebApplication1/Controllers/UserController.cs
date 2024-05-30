using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Training.Domain.Command.Users;
using Training.Domain.Service.Interface.User;

namespace Training.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> signup([FromBody] CreateUserCommand model)
        {
            #region Parameters validation

            // Parameter hasn't been initialized.
            if (model == null) {
                model = new CreateUserCommand();
                TryValidateModel(model);
            }

            // Invalid modelState
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            #endregion

            var loginResult = await _userService.CreateAccount(model);
            return Ok(loginResult);
        }
    }
}
