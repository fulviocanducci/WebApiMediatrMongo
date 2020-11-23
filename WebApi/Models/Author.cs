using Canducci.MongoDB.Repository.Attributes;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;

namespace WebApi.Models
{
    [BsonCollectionName("author")]
    public class Author
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id { get; set; }

        [BsonElement("name")]
        [BsonRequired()]
        public string Name { get; set; }

        [BsonElement("created")]
        [BsonRequired()]
        public DateTime Created { get; set; }
    }
}
