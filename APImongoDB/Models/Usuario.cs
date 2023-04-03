using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace APImongoDB.Models
{
    public class Usuario
    {
        public Usuario()
        {
            InternalId = Guid.NewGuid();
        }

        public Guid InternalId { get; set; }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Admin { get; set; }
    }
}
