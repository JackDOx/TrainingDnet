using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Training.Domain.Command.Categories;
using Training.Domain.Helper.Constants;
using Training.Domain.Service.Interface.Category;


namespace Training.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly ICategoryService _categoryService;
        public CategoryController(IHttpContextAccessor httpContext ,ICategoryService categoryService)
        {
            _httpContext = httpContext;
            _categoryService = categoryService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> create([FromBody] CreateCategoryCommand model)
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
                model = new CreateCategoryCommand();
                TryValidateModel(model);
            }

            // Invalid modelState
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            #endregion

            var result = await _categoryService.CreateCategory(model);
            return Ok(result);
        }


        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteCategory([FromBody] DeleteCategoryCommand model)
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
                model = new DeleteCategoryCommand();
                TryValidateModel(model);
            }

            // Invalid modelState
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            #endregion

            var deleteResult = await _categoryService.DeleteCategory(model);
            if (deleteResult)
            {
                return BadRequest("Failed to delete Category");
            }

            return Ok("Category deleted successfully");
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetCategory([FromQuery] GetCategoryCommand model)
        {

            #region Parameters validation
            // Parameter hasn't been initialized.
            if (model == null)
            {
                model = new GetCategoryCommand();
                TryValidateModel(model);
            }

            // Invalid modelState
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            #endregion

            var getCategory = await _categoryService.GetCategory(model);
            if (getCategory)
            {
                return Ok(getCategory);
            }

            return BadRequest("No Category with that Id found!");


        }

        [HttpPatch("Update")]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryCommand model)
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
                model = new UpdateCategoryCommand();
                TryValidateModel(model);
            }

            // Invalid modelState
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            #endregion

            var updated = await _categoryService.UpdateCategory(model);

            return Ok(updated);


        }
    }
}
