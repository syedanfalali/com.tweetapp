using com.tweetapp.Models;
using com.tweetapp.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace com.tweetapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetsController : ControllerBase
    {
        private readonly IUserService userService;
        public TweetsController(IUserService userService)
        {
            this.userService = userService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            return userService.getAll();
        }

        // GET api/<UserController>/5
        [HttpGet("{LoginId}")]

        public ActionResult<User> Get(string loginId)
        {
            var user = userService.getUser(loginId);
            if(user == null)
            {
                return NotFound("No user found");
            }
            return user;
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            userService.createUser(user);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }
            
        // PUT api/<UserController>/5
        [HttpPut("{id}")]
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
