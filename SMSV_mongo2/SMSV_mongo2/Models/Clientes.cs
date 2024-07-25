using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using SMSV_mongo2.Services;

namespace SMSV_mongo2.Models
{
    public class Clientes
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("numero")]
        public int numero { get; set; }

        [BsonElement("nombre")]
        public string nombre { get; set; }

        [BsonElement("Ape_Paterno")]
        public string ape_paterno { get; set; }

        [BsonElement("Ape_Materno")]
        public string ape_materno { get; set; }

        [BsonElement("fechaNacimiento")]
        public DateTime fecha_nac { get; set; }

        [BsonElement("correo")]
        public string correo { get; set; }

        [BsonElement("contrasena")]
        public string contrasena { get; set; }

        [BsonElement("Telefono")]
        public string telefono { get; set; }

        [BsonElement("Direccion")]
        public string direccion { get; set; }

        [BsonElement("codigoPostal")]
        public string codigo_p { get; set; }

    }
}
