using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace SMSV_mongo2.Models
{
    public class Membresias
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("codigo")]
        public string codigo { get; set; }

        [BsonElement("nombre")]
        public string nombre { get; set; }

        [BsonElement("descripcion")]
        public string descripcion { get; set; }

        [BsonElement("duracion")]
        public string duracion { get; set; }

        [BsonElement("paquete")]
        public string paquete { get; set; }

        
    }
}
