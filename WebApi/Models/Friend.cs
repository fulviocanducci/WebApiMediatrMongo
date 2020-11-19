using Canducci.MongoDB.Repository.Attributes;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace WebApi.Models
{
    [BsonCollectionName("person")]
    public class Friend
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id { get; set; }

        [BsonElement("name")]
        [BsonRequired()]
        public string Name { get; set; }

        [BsonElement("like")]
        public bool Like { get; set; }
    }
}
