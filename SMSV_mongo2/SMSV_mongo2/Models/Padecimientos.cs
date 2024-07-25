using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace SMSV_mongo2.Models
{
    public class Padecimientos
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("codigo")]
        public int codigo { get; set; }

        [BsonElement("descripcion")]
        public string descripcion { get; set; }
    }
}
