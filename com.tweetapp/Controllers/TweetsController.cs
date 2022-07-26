using com.tweetapp.Models;
using com.tweetapp.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace com.tweetapp.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class TweetsController : ControllerBase
    {
        private readonly IUserService userService;
        public TweetsController(IUserService userService)
        {
            this.userService = userService;
        }

        // GET: api/<UserController>
        [Route("users/all")]
        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            return userService.getAll();
        }

        // GET api/<UserController>/5
       // [Route("search")]
        [HttpGet("search/{loginId}")]

        public ActionResult<User> Get(string loginId)
        {
            var user = userService.getUser(loginId);
            if(user == null)
            {
                return NotFound("No user found");
            }
            return user;
        }

       
        [HttpGet("login/{loginId}/{password}")]

        public ActionResult<User> Login(string loginId, string password)
        {
            var user = userService.getUser(loginId);
            if (user == null)
            {
                return NotFound("No user found");
            }
            else if(user.Password == password)
            {
                return user;

            }
            return NotFound("Incorrect Password");
        }

        // POST api/<UserController>
        [Route("register")]
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            userService.createUser(user);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }
            
        // PUT api/<UserController>/5
       // [Route("{LoginId}/forgot")]
        [HttpPut("{loginid}/forgot")]
        public ActionResult Put(string loginid, [FromBody] User user)
        {
            var existingUser = userService.getUser(loginid);

            if (existingUser == null)
            {
                return NotFound($"User not found");
            }
            userService.update(loginid, user);

            return NoContent();
        }

    }
}
