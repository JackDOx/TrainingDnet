using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Training.Domain.Command.ProductRoles;
using Training.Domain.Service.Interface.ProductRole;


namespace Training.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductRoleController : BaseController
    {
        private readonly IProductRoleService _productRoleService;
        public ProductRoleController(IProductRoleService productRoleService)
        {
            _productRoleService = productRoleService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> create([FromBody] CreateProductRoleCommand model)
        {
            #region Parameters validation

            // Parameter hasn't been initialized.
            if (model == null)
            {
                model = new CreateProductRoleCommand();
                TryValidateModel(model);
            }

            // Invalid modelState
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            #endregion

            var result = await _productRoleService.CreateProductRole(model);
            return Ok(result);
        }


        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteProductRole([FromBody] DeleteProductRoleCommand model)
        {
            #region Parameters validation

            // Parameter hasn't been initialized.
            if (model == null)
            {
                model = new DeleteProductRoleCommand();
                TryValidateModel(model);
            }

            // Invalid modelState
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            #endregion

            var deleteResult = await _productRoleService.DeleteProductRole(model);
            if (deleteResult)
            {
                return BadRequest("Failed to delete ProductRole");
            }

            return Ok("ProductRole deleted successfully");
        }

        [HttpPost("Listing")]
        public async Task<IActionResult> GetProductRole([FromBody] ListingProductRoleCommand model)
        {
            #region Parameters validation
            // Parameter hasn't been initialized.

  
            if (model == null)
            {
                model = new ListingProductRoleCommand();
                TryValidateModel(model);
            }

            // Invalid modelState
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            #endregion


            var result = await _productRoleService.ListingProductRole(model);
            return Ok(result);


        }

        [HttpPatch("Update")]
        public async Task<IActionResult> UpdateProductRole([FromBody] UpdateProductRoleCommand model)
        {
            #region Parameters validation
            // Parameter hasn't been initialized.
            if (model == null)
            {
                model = new UpdateProductRoleCommand();
                TryValidateModel(model);
            }

            // Invalid modelState
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            #endregion

            var updated = await _productRoleService.UpdateProductRole(model);

            return Ok(updated);


        }
    }
}
