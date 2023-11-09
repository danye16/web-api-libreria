using libreria_JDPC.Data.Models;
using libreria_JDPC.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using libreria_JDPC.Data.ViewModels;

namespace libreria_JDPC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private AuthorsService _authorsServices;
        public AuthorsController(AuthorsService authorsServices) 
        {
            _authorsServices = authorsServices;
        }
        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody] AuthorVM author)
        {
            _authorsServices.AddAuthor(author);
            return Ok();
        }
    }
}
