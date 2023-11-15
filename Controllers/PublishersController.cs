using libreria_JDPC.Data.Services;
using libreria_JDPC.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace libreria_JDPC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private PublishersService _publishersServices;
        public PublishersController(PublishersService publishersServices)
        {
            _publishersServices = publishersServices;
        }
        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
           var  newPublisher= _publishersServices.AddPublisher(publisher);
            return Created(nameof(AddPublisher), newPublisher);
        }

        [HttpGet("get-publisher-books-with-authors/{id}")]
        public IActionResult GetPublisherData(int id) 
        {
            var _response = _publishersServices.GetPublisherData(id);
            return Ok(_response);
        }
        //Controlador para eliminar un Publisher ´por medio de su id, tambien se borran los libros vinculados

        [HttpDelete("delete-publishers-by-id/{id}")]
        public IActionResult DeletePublisherByID(int id) 
        {
            _publishersServices.DeletePublisherById(id);
            return Ok();
        }
    }
}
