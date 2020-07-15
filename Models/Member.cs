using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TeamManagementAngular.Models
{
    public class Member
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string City { get; set; }
    }
}