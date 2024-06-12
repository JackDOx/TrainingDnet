using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Training.Authentication.Handlers;

using Training.Domain.Command.Users;
using Training.Domain.Service.Interface.User;
using Training.Authentication.TokenValidators;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using Training.Domain.ViewModel.Users;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace Training.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly IUserService _userService;
        private readonly IProfileService _profileService;
        private readonly JwtModel _jwt;
        public UserController(IHttpContextAccessor httpContext, IUserService userService, IOptions<JwtModel> jwt, IProfileService ips)
        {
            _httpContext = httpContext;
            _userService = userService;
            _profileService = ips;
            _jwt = jwt.Value;
        }

        [HttpPost("signin")]
        [AllowAnonymous]
        public async Task<ActionResult<TokenViewModel>> signin([FromBody] LoginModelCommand model)
        {
            #region Parameters validation
            // Parameter hasn't been initialized
            if (model == null)
            {
                model = new LoginModelCommand();
                TryValidateModel(model);
            }

            // Invalid modelState
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            #endregion

            var loginResult = await _userService.Login(model);
            if (loginResult == null)
            {
                return Ok(false);
            }

            

            var account = loginResult.UserProfile;
            var a = account.Roles.Select(role => role.Name).ToList();
            var b =  string.Join(", ", a);
            var claims = new List<Claim>();
            claims.Add(new Claim(nameof(account.Id), account.Id.ToString()));
            claims.Add(new Claim(nameof(account.FullName), account.FullName));
            claims.Add(new Claim(nameof(account.Roles), b.ToString()));

            loginResult.Code = _profileService.GenerateJwt(claims.ToArray(), _jwt);
            loginResult.LifeTime = _jwt.LifeTime;

            // Set the token as a cookie in the HTTP response
            Response.Cookies.Append("access_token", loginResult.Code, new CookieOptions
            {
                HttpOnly = true,
                Secure = true, // Make sure to set this to true in production when using HTTPS
                SameSite = SameSiteMode.Strict // Adjust this setting based on your application's requirements
            });



            return Ok(loginResult);
        }

        [HttpPost("signup")]
        [AllowAnonymous]
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


        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteUser([FromBody] DeleteUserCommand model)
        {
            #region Parameters validation

            // Parameter hasn't been initialized.
            if (model == null)
            {
                model = new DeleteUserCommand();
                TryValidateModel(model);
            }

            // Invalid modelState
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            #endregion

            var deleteResult = await _userService.DeleteUser(model);
            if (deleteResult)
            {
                return BadRequest("Failed to delete user");
            }

            return Ok("User deleted successfully");
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetUser([FromQuery] GetUserCommand model) {
            #region Parameters validation
            // Parameter hasn't been initialized.
            if (model == null)
            {
                model = new GetUserCommand();
                TryValidateModel(model);
            }

            // Invalid modelState
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            #endregion

            var getUser = await _userService.GetUser(model);
            if (getUser)
            {
                return Ok(getUser);
            }

            return BadRequest("No User with that Id found!");


        }

        [HttpPatch("Update")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand model)
        {
            #region Parameters validation
            // Parameter hasn't been initialized.
            if (model == null)
            {
                model = new UpdateUserCommand();
                TryValidateModel(model);
            }

            // Invalid modelState
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            #endregion

            var updated = await _userService.UpdateUser(model);

            return Ok(updated);


        }

        [HttpPost("listing")]
        //[Authorize(Policy = "RolePolicy")]

        public async Task<IActionResult> Listing([FromBody] GetUserPaginationCommand model)
            {
            /*
            // Get the user's ID from the claims
              string userRole = HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("Roles"))?.Value;

            if (string.IsNullOrWhiteSpace(userRole)|| !userRole.Contains("Admin"))
            {
                return BadRequest(StatusCode(500, "UnAuthorized User!"));
            }
            */
            var role = GetCurrentUserRole(_httpContext);
            if (role.IsNullOrEmpty() || !role.Contains("Admin"))
            {
                return BadRequest(StatusCode(500, "UnAuthorized User!"));
            }


            var result = await _userService.Listing(model);
                return Ok(result);
            }
    }
}
