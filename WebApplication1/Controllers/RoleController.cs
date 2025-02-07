﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Training.Domain.Command.Roles;
using Training.Domain.Service.Interface.Role;


namespace Training.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : BaseController
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> create([FromBody] CreateRoleCommand model)
        {
            #region Parameters validation

            // Parameter hasn't been initialized.
            if (model == null)
            {
                model = new CreateRoleCommand();
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
        public async Task<IActionResult> DeleteRole([FromBody] DeleteRoleCommand model)
        {
            #region Parameters validation

            // Parameter hasn't been initialized.
            if (model == null)
            {
                model = new DeleteRoleCommand();
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
        public async Task<IActionResult> GetRole([FromQuery] GetRoleCommand model)
        {
            #region Parameters validation
            // Parameter hasn't been initialized.
            if (model == null)
            {
                model = new GetRoleCommand();
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
        public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleCommand model)
        {
            #region Parameters validation
            // Parameter hasn't been initialized.
            if (model == null)
            {
                model = new UpdateRoleCommand();
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
