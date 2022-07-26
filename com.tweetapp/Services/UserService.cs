using com.tweetapp.Models;
using MongoDB.Driver;

namespace com.tweetapp.Services
{

    public class UserService : IUserService        
    {
        private readonly IMongoCollection<User> _users;
        public UserService(ITweetAppDatabaseSettings settings,IMongoClient mongoClient)
        {
          var database =  mongoClient.GetDatabase(settings.DatabaseName);
            _users = database.GetCollection<User>(settings.usersCollectionName);
        }
        public User createUser(User user)
        {
            _users.InsertOne(user);
            return user;
        }

        public List<User> getAll()
        {
            return _users.Find(user => true).ToList();
        }

        public User getUser(string loginId)
        {
            return _users.Find(user => user.LoginId == loginId).FirstOrDefault();
            
        }

        public User login(string loginId, string password)
        {
            return _users.Find(user => user.LoginId == loginId && user.Password==password).FirstOrDefault();
        }

        public void update(string loginId, User user)
        {
            _users.ReplaceOne(user => user.LoginId == loginId, user);
        }
    }
}
