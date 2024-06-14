using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Training.Domain.Command.Authors;
using Training.Domain.Helper.Constants;
using Training.Domain.Service.Interface.Author;


namespace Training.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : BaseController
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly IAuthorService _authorService;
        public AuthorController(IHttpContextAccessor httpContext ,IAuthorService authorService)
        {
            _httpContext = httpContext;
            _authorService = authorService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> create([FromBody] CreateAuthorCommand model)
        {

            #region roleAuthenticate
            if (!RoleAuthenticate(_httpContext, UserConstants.bmRole))
            {
                return BadRequest(StatusCode(401, "Unauthorized!"));
            };
            #endregion

            #region Parameters validation

            // Parameter hasn't been initialized.
            if (model == null)
            {
                model = new CreateAuthorCommand();
                TryValidateModel(model);
            }

            // Invalid modelState
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            #endregion

            var result = await _authorService.CreateAuthor(model);
            return Ok(result);
        }


        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAuthor([FromBody] DeleteAuthorCommand model)
        {

            #region roleAuthenticate
            if (!RoleAuthenticate(_httpContext, UserConstants.bmRole))
            {
                return BadRequest(StatusCode(401, "Unauthorized!"));
            };
            #endregion

            #region Parameters validation

            // Parameter hasn't been initialized.
            if (model == null)
            {
                model = new DeleteAuthorCommand();
                TryValidateModel(model);
            }

            // Invalid modelState
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            #endregion

            var deleteResult = await _authorService.DeleteAuthor(model);
            if (deleteResult)
            {
                return BadRequest("Failed to delete Author");
            }

            return Ok("Author deleted successfully");
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetAuthor([FromQuery] GetAuthorCommand model)
        {
            #region Parameters validation
            // Parameter hasn't been initialized.
            if (model == null)
            {
                model = new GetAuthorCommand();
                TryValidateModel(model);
            }

            // Invalid modelState
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            #endregion

            var getAuthor = await _authorService.GetAuthor(model);
            if (getAuthor)
            {
                return Ok(getAuthor);
            }

            return BadRequest("No Author with that Id found!");


        }

        [HttpPatch("Update")]
        public async Task<IActionResult> UpdateAuthor([FromBody] UpdateAuthorCommand model)
        {
            #region roleAuthenticate
            if (!RoleAuthenticate(_httpContext, UserConstants.adminRole))
            {
                return BadRequest(StatusCode(401, "Unauthorized!"));
            };
            #endregion

            #region Parameters validation
            // Parameter hasn't been initialized.
            if (model == null)
            {
                model = new UpdateAuthorCommand();
                TryValidateModel(model);
            }

            // Invalid modelState
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            #endregion

            var updated = await _authorService.UpdateAuthor(model);

            return Ok(updated);


        }
    }
}
