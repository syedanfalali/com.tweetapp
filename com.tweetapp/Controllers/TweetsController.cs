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
        private readonly ITweetService tweetService;
        public TweetsController(IUserService userService, ITweetService tweetService)
        {
            this.userService = userService;
            this.tweetService = tweetService;
        }
        [Route("all")]
        [HttpGet]
        public ActionResult<List<Tweet>> GetAllTweets()
        {
            return tweetService.GetAll();
        }

        [HttpGet("{LoginId}")]
        public ActionResult<List<Tweet>> GetUserTweets(string LoginId)
        {
            return tweetService.GetUserTweets(LoginId);
        }
        
        [HttpPost("{LoginId}/add")]
        public ActionResult<Tweet> Add(string LoginId, Tweet tweet)
        {
            tweet.LoginId = LoginId; 
            return tweetService.Post(tweet);
        }


        [HttpPut("update/{Id}")]
        public ActionResult<Tweet> UpdateTweet(string Id , Tweet tweet)
        {

            return tweetService.Update(Id, tweet);
        }

        [HttpDelete("delete/{Id}")]
        public ActionResult<string> DeleteTweet( string Id)
        {
            tweetService.Delete(Id);
            return "Deleted";
        }
        [HttpPut("like/{Id}")]
        public ActionResult<string> Like(string Id, string LoginId)
        {
            Tweet tweet = tweetService.GetSpecificTweet(Id);
            
            if(tweet.Likes == null)
            {
                tweet.Likes = new List<string>();
                
            }
            tweet.Likes.Add(LoginId);
            tweetService.Update(Id, tweet);
            return "Liked by " + LoginId;
        }

        [HttpPost("reply/{Id}")]
        public ActionResult<Tweet> Reply(string Id, Tweet tweet)
        {
            tweet.Type = "Reply";
            tweet.ReplyOf = tweetService.GetSpecificTweet(Id);
            tweetService.Reply(Id, tweet);
            return tweet;
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
