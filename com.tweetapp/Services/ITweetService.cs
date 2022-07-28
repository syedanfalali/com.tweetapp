using com.tweetapp.Models;

namespace com.tweetapp.Services
{
    public interface ITweetService
    {
        List<Tweet> GetAll();
        List<Tweet> GetUserTweets(string LoginId);
        Tweet Post(Tweet tweet);
        Tweet Update(string Id,Tweet tweet);
        void Delete(string Id);
        void Like(string Id, Tweet tweet);
        Tweet Reply(string Id,Tweet tweet);
        Tweet GetSpecificTweet(string Id);

    }
}
