using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using SMSV_mongo2.Services;

namespace SMSV_mongo2.Models
{
    public class MonitorSignos
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("codigo")]
        public int codigo { get; set; }

        [BsonElement("modelo")]
        public string modelo { get; set; }

        [BsonElement("stock_Disponible")]
        public int stock_Disponible { get; set; }
    }
}
