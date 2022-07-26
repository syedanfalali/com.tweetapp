using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace com.tweetapp.Models
{
    [BsonIgnoreExtraElements]
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } =String.Empty;

        [BsonElement("FisrtName")]
        public string FirstName { get; set; } = String.Empty;   

        [BsonElement("LastName")]
        public string LastName { get; set; }=String.Empty;  

        [BsonElement("Email")]
        public string Email { get; set; }= String.Empty;    

        [BsonElement("LoginId")]
        public string LoginId { get; set; } = String.Empty;

        [BsonElement("Password")]
        public string Password { get; set; } =String.Empty;

        [BsonElement("ContactNumber")]
        public int ContactNumber { get; set; }
    }
}
