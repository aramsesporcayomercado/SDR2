using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace SMSV_mongo2.Models
{
    public class ReporteFallas
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("numero")]
        public int numero { get; set; }

        [BsonElement("falla")]
        public string falla { get; set; }

        [BsonElement("cliente")]
        public int Cliente { get; set; }

        [BsonElement("fechaAlta")]
        public DateTime FechaAlta { get; set; }
    }
}
