using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace com.tweetapp.Models
{
    [BsonIgnoreExtraElements]
    public class Tweet
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("LoginId")]
        public string LoginId { get; set; } = String.Empty;

        [BsonElement("TweetMsg")]
        public string TweetMsg { get; set; } = String.Empty;

        [BsonElement("Type")]
        public string Type { get; set; } = String.Empty;
        [BsonElement("ReplyOf")]
        public Tweet? ReplyOf { get; set; }

        [BsonElement("Tag")]
        public string? Tag { get; set; } = String.Empty;

        [BsonElement("Time")]
        public DateTime Time { get; set; }

        [BsonElement("Likes")]
        public List<string>? Likes { get; set; } = new List<string>();
    }
}
