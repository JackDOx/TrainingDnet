using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Training.Domain.Command.Roles;
using Training.Domain.Service.Interface.Role;


namespace Training.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IAuthorService _roleService;
        public RoleController(IAuthorService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> create([FromBody] CreateBookCommand model)
        {
            #region Parameters validation

            // Parameter hasn't been initialized.
            if (model == null)
            {
                model = new CreateBookCommand();
                TryValidateModel(model);
            }

            // Invalid modelState
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            #endregion

            var result = await _roleService.CreateRole(model);
            return Ok(result);
        }


        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteRole([FromBody] DeleteAuthorCommand model)
        {
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

            var deleteResult = await _roleService.DeleteRole(model);
            if (deleteResult)
            {
                return BadRequest("Failed to delete Role");
            }

            return Ok("Role deleted successfully");
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetRole([FromQuery] GetAuthorCommand model)
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

            var getRole = await _roleService.GetRole(model);
            if (getRole)
            {
                return Ok(getRole);
            }

            return BadRequest("No Role with that Id found!");


        }

        [HttpPatch("Update")]
        public async Task<IActionResult> UpdateRole([FromBody] UpdateAuthorCommand model)
        {
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

            var updated = await _roleService.UpdateRole(model);

            return Ok(updated);


        }
    }
}
