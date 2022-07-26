namespace com.tweetapp.Models
{
    public class TweetAppDatabaseSettings : ITweetAppDatabaseSettings
    {
       public string usersCollectionName { get; set; } =string.Empty;
        public string tweetsCollectionName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;

    }
}
