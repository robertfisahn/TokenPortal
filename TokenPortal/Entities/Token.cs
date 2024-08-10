using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace TokenPortal.Entities
{
    public class Token
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [JsonProperty("nazwa")]
        public string Name { get; set; }

        [JsonProperty("cena")]
        public string Price { get; set; }

        [JsonProperty("maksymalna podaż")]
        public int TotalSupply { get; set; }
    }
}

