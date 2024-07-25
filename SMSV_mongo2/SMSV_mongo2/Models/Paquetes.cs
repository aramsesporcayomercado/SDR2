using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace SMSV_mongo2.Models
{
    public class Paquetes
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("codigo")]
        public string codigo { get; set; }

        [BsonElement("stock_Disponible")]
        public int stock { get; set; }

        [BsonElement("monitor")]
        public string monitor { get; set; }

        [BsonElement("cama")]
        public string cama { get; set; }

        [BsonElement("administrador_creador")]
        public string administrador { get; set; }

        [BsonElement("nombre")]
        public string nombre { get; set; }

      
    }
}
