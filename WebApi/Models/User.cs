using Canducci.MongoDB.Repository.Attributes;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;

namespace WebApi.Models
{
    [BsonCollectionName("user")]
    public class User
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id { get; set; }

        [BsonElement("name")]
        [BsonRequired()]
        public string Name { get; set; }

        [BsonElement("email")]
        [BsonRequired()]
        public string Email { get; set; }

        [BsonElement("password")]
        [BsonRequired()]
        public string Password { get; set; }

        [BsonElement("salt")]
        [BsonRequired()]
        public string Salt { get; set; }

        [BsonElement("created")]
        [BsonRequired()]
        public DateTime Created { get; set; }
    }
}
