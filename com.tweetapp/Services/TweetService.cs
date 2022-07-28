using com.tweetapp.Models;
using MongoDB.Driver;

namespace com.tweetapp.Services
{
    public class TweetService : ITweetService
    {
        private readonly IMongoCollection<Tweet> _tweets;
        public TweetService(ITweetAppDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _tweets = database.GetCollection<Tweet>(settings.tweetsCollectionName);
        }
        public void Delete(string Id)
        {
            _tweets.DeleteOne(Tweet => Tweet.Id == Id);
        }

        public List<Tweet> GetAll()
        {
            return _tweets.Find(Tweet => true).ToList();
        }

        public List<Tweet> GetUserTweets(string LoginId)
        {
            return _tweets.Find(Tweet => Tweet.LoginId == LoginId).ToList();
        }

        public void Like(string Id, Tweet tweet)
        {
             _tweets.ReplaceOne(Tweet => Tweet.Id == Id, tweet);
        }

        public Tweet Post(Tweet tweet)
        {
             _tweets.InsertOne(tweet);
            return tweet;
        }

        public Tweet Reply(string Id, Tweet tweet)
        {
            _tweets.InsertOne(tweet);
            return tweet;
        }

        public Tweet Update(string Id, Tweet tweet)
        {
            _tweets.ReplaceOne(Tweet => Tweet.Id == Id, tweet);
            return tweet;
        }
         public Tweet GetSpecificTweet(string Id)
        {
            return _tweets.Find(Tweet => Tweet.Id == Id).FirstOrDefault();
        }
    }
}
