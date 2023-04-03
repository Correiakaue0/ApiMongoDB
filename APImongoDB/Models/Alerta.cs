using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace APImongoDB.Models
{
    public class Alerta
    {
        public Alerta()
        {
            InternalId = Guid.NewGuid();
        }

        public Guid InternalId { get; set; }
        public int Id { get; set; }
        public string Descricao { get; set; }
    }
}
