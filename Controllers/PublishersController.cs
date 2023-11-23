using libreria_JDPC.Data.Services;
using libreria_JDPC.Data.ViewModels;
using libreria_JDPC.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

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
           

            try
            {
                var newPublisher = _publishersServices.AddPublisher(publisher);
                return Created(nameof(AddPublisher), newPublisher);
            }
            catch (PublisherNameException ex)
            {

                return BadRequest($"{ex.Message}, Nombre de la editora: {ex.PublisherName}");
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
            

        [HttpGet("get-publisher-books-with-authors/{id}")]
        public IActionResult GetPublisherData(int id)
        {
            var _response = _publishersServices.GetPublisherData(id);
            return Ok(_response);
        }

        //exepciones
        [HttpGet("get-publisher-by-id/{id}")]
        public IActionResult GetPublisherById(int id)
        {
            var _response = _publishersServices.GetPublisherById(id);
            if (_response != null)
            {
                return Ok(_response);
            }
            else
            {
                return NotFound();
            }
        }
        //Controlador para eliminar un Publisher ´por medio de su id, tambien se borran los libros vinculados

        [HttpDelete("delete-publishers-by-id/{id}")]
        public IActionResult DeletePublisherByID(int id) 
        {
            try
            {
                _publishersServices.DeletePublisherById(id);
                return Ok();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
               
          
           
        }
    }
}
