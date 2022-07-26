namespace com.tweetapp.Models
{
    public interface ITweetAppDatabaseSettings
    {
       public string usersCollectionName { get; set; }
        public string tweetsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }


    }
}
