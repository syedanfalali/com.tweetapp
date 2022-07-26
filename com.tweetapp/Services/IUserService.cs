using com.tweetapp.Models;
namespace com.tweetapp.Services
{
    public interface IUserService
    {
        User createUser(User user);
        User login(string LoginId,string Password);
        void update(string loginId, User user);
        List<User> getAll();
        User getUser(string LoginId);
    }
}
