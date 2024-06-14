using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Training.Domain.Command.Books;
using Training.Domain.Helper.Constants;
using Training.Domain.Service.Interface.Book;


namespace Training.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : BaseController
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly IBookService _bookService;
        public BookController(IHttpContextAccessor httpContext ,IBookService bookService)
        {
            _httpContext = httpContext;
            _bookService = bookService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> create([FromBody] CreateBookCommand model)
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
                model = new CreateBookCommand();
                TryValidateModel(model);
            }

            // Invalid modelState
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            #endregion


            var result = await _bookService.CreateBook(model);
            return Ok(result);
        }


        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteBook([FromBody] DeleteBookCommand model)
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
                model = new DeleteBookCommand();
                TryValidateModel(model);
            }

            // Invalid modelState
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            #endregion


            var deleteResult = await _bookService.DeleteBook(model);
            if (deleteResult)
            {
                return BadRequest("Failed to delete Book");
            }

            return Ok("Book deleted successfully");
        }

        [HttpPost("Listing")]
        public async Task<IActionResult> GetBook([FromBody] ListingBookCommand model)
        {
            #region Parameters validation
            // Parameter hasn't been initialized.

  
            if (model == null)
            {
                model = new ListingBookCommand();
                TryValidateModel(model);
            }

            // Invalid modelState
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            #endregion

            model.userRole = GetCurrentUserRole(_httpContext);


            var result = await _bookService.ListingBook(model);
            return Ok(result);


        }

        [HttpPatch("Update")]
        public async Task<IActionResult> UpdateBook([FromBody] UpdateBookCommand model)
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
                model = new UpdateBookCommand();
                TryValidateModel(model);
            }

            // Invalid modelState
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            #endregion


            var updated = await _bookService.UpdateBook(model);

            return Ok(updated);


        }
    }
}
