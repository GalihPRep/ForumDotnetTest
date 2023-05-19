using Microsoft.AspNetCore.Mvc;
using Project000.Models;
using Project000.Helper;
using Project000.Services;
using AccountApp.Models.Entities;
using AccountApp.Models.Requests;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project000.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _db;
        public AccountController(AccountContext context)
        {
            _db = new AccountService(context);
        }


        // GET: api/<AccountController>
        [HttpGet]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<Account> data = _db.FindAll();
                if (!data.Any()){type = ResponseType.NotFound;}
                return Ok(AccountResponseHandler.GetSuccessResponse(type, data));
            }
            catch (Exception ex)
            {
                return BadRequest(AccountResponseHandler.GetExceptionResponse(ex));
            }
        }

        // GET api/<AccountController>/5
        [HttpGet("{username}")]
        public IActionResult Get(string username)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                Account data = _db.FindByUsername(username);
                if (data == null) { type = ResponseType.NotFound; }
                return Ok(AccountResponseHandler.GetSuccessResponse(type, data));
            }
            catch (Exception ex)
            {
                return BadRequest(AccountResponseHandler.GetExceptionResponse(ex));
            }
        }

        // POST api/<AccountController>
        [HttpPost]
        public IActionResult Post([FromBody] AccountDto request)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                _db.Save(request);
                return Ok(AccountResponseHandler.GetSuccessResponse(type, request));
            }
            catch (Exception ex)
            {
                return BadRequest(AccountResponseHandler.GetExceptionResponse(ex));
            }
        }

        // PUT api/<AccountController>/5
        
        [HttpPut("{username}")]
        public IActionResult Put([FromBody] AccountDto request, string username)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                _db.Update(request, username);
                return Ok(AccountResponseHandler.GetSuccessResponse(type, request));
            }
            catch (Exception ex)
            {
                return BadRequest(AccountResponseHandler.GetExceptionResponse(ex));
            }
        }
        

        // DELETE api/<AccountController>/5
        [HttpDelete("{username}")]
        public IActionResult Delete(string username)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                _db.Delete(username);
                return Ok(AccountResponseHandler.GetSuccessResponse(type, null));
            }
            catch (Exception ex)
            {
                return BadRequest(AccountResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
