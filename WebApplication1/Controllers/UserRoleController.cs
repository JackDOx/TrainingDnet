﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Training.Domain.Command.Roles;
using Training.Domain.Command.UserRoles;
using Training.Domain.Helper.Constants;
using Training.Domain.Service.Interface.UserRole;

namespace Training.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : BaseController
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly IUserRoleService _roleService;
        public UserRoleController(IHttpContextAccessor httpContext, IUserRoleService roleService)
        {
            _httpContext = httpContext;
            _roleService = roleService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> create([FromBody] CreateUserRoleCommand model)
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
                model = new CreateUserRoleCommand();
                TryValidateModel(model);
            }

            // Invalid modelState
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            #endregion

            var result = await _roleService.CreateUserRole(model);
            return Ok(result);
        }


        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteUserRole([FromBody] DeleteUserRoleCommand model)
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
                model = new DeleteUserRoleCommand();
                TryValidateModel(model);
            }

            // Invalid modelState
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            #endregion

            var deleteResult = await _roleService.DeleteUserRole(model);
            if (deleteResult)
            {
                return BadRequest("Failed to delete Role");
            }

            return Ok("Role deleted successfully");
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetUserRole([FromQuery] GetUserRoleCommand model)
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
                model = new GetUserRoleCommand();
                TryValidateModel(model);
            }

            // Invalid modelState
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            #endregion

            var getRole = await _roleService.GetUserRole(model);
            if (getRole)
            {
                return Ok(getRole);
            }

            return BadRequest("No Role with that Id found!");


        }

        [HttpPatch("Update")]
        public async Task<IActionResult> UpdateUserRole([FromBody] UpdateUserRoleCommand model)
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
                model = new UpdateUserRoleCommand();
                TryValidateModel(model);
            }

            // Invalid modelState
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            #endregion

            var updated = await _roleService.UpdateUserRole(model);

            return Ok(updated);


        }
    }
}
