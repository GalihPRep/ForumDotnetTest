using Microsoft.AspNetCore.Mvc;
using QuestionApp.Models;
using QuestionApp.Models.Entity;
using QuestionApp.Models.Requests.Entity;
using QuestionApp.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuestionApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly QuestionService _db;
        public QuestionController(QuestionContext context)
        {
            _db = new QuestionService(context);
        }



        // GET: api/<QuestionController>
        [HttpGet]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<Question> data = _db.FindAll();
                if (!data.Any()){type = ResponseType.NotFound;}
                return Ok(QuestionResponseHandler.GetSuccessResponse(type, data));
            }
            catch (Exception ex)
            {
                return BadRequest(QuestionResponseHandler.GetExceptionResponse(ex));
            }
        }

        // GET api/<QuestionController>/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                Question data = _db.FindById(id);
                if (data == null) { type = ResponseType.NotFound; }
                return Ok(QuestionResponseHandler.GetSuccessResponse(type, data));
            }
            catch (Exception ex)
            {
                return BadRequest(QuestionResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpGet("keyword/{keyword}")]
        public IActionResult Get(string keyword)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<Question> data = _db.FindByKeyword(keyword);
                if (!data.Any()) { type = ResponseType.NotFound; }
                return Ok(QuestionResponseHandler.GetSuccessResponse(type, data));
            }
            catch (Exception ex)
            {
                return BadRequest(QuestionResponseHandler.GetExceptionResponse(ex));
            }
        }

        // POST api/<QuestionController>
        [HttpPost]
        public IActionResult Post([FromBody] QuestionPost request)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                _db.Save(request);
                return Ok(QuestionResponseHandler.GetSuccessResponse(type, request));
            }
            catch (Exception ex)
            {
                return BadRequest(QuestionResponseHandler.GetExceptionResponse(ex));
            }
        }

        // PUT api/<QuestionController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] QuestionPut request, long id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                _db.Update(request,id);
                return Ok(QuestionResponseHandler.GetSuccessResponse(type, _db.FindById(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(QuestionResponseHandler.GetExceptionResponse(ex));
            }
        }

        // DELETE api/<QuestionController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                _db.Delete(id);
                return Ok(QuestionResponseHandler.GetSuccessResponse(type, null));
            }
            catch (Exception ex)
            {
                return BadRequest(QuestionResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
