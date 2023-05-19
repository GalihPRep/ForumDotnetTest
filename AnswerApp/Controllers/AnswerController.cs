using AnswerApp.Models;
using AnswerApp.Models.Entity;
using AnswerApp.Models.Requests;
using AnswerApp.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnswerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly AnswerService _db;
        public AnswerController(AnswerContext context)
        {
            _db = new AnswerService(context);
        }



        // GET: api/<QuestionController>
        [HttpGet]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<Answer> data = _db.FindAll();
                if (!data.Any()){type = ResponseType.NotFound;}
                return Ok(AnswerResponseHandler.GetSuccessResponse(type, data));
            }
            catch (Exception ex)
            {
                return BadRequest(AnswerResponseHandler.GetExceptionResponse(ex));
            }
        }

        // GET api/<QuestionController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                Answer data = _db.FindById(id);
                if (data == null) { type = ResponseType.NotFound; }
                return Ok(AnswerResponseHandler.GetSuccessResponse(type, data));
            }
            catch (Exception ex)
            {
                return BadRequest(AnswerResponseHandler.GetExceptionResponse(ex));
            }
        }

        // POST api/<QuestionController>
        [HttpPost]
        public IActionResult Post([FromBody] AnswerPost request)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                _db.Save(request);
                return Ok(AnswerResponseHandler.GetSuccessResponse(type, request));
            }
            catch (Exception ex)
            {
                return BadRequest(AnswerResponseHandler.GetExceptionResponse(ex));
            }
        }

        // PUT api/<QuestionController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] AnswerPut request, string id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                _db.Update(request,id);
                return Ok(AnswerResponseHandler.GetSuccessResponse(type, _db.FindById(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(AnswerResponseHandler.GetExceptionResponse(ex));
            }
        }

        // DELETE api/<QuestionController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                _db.Delete(id);
                return Ok(AnswerResponseHandler.GetSuccessResponse(type, null));
            }
            catch (Exception ex)
            {
                return BadRequest(AnswerResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
