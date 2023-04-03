using APImongoDB.Models;
using APImongoDB.Repository.IRepository;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace APImongoDB.Repository
{
    public class RepositorioAlerta : IRepositorioAlerta
    {
        public readonly Context _context = null;

        public RepositorioAlerta (IOptions<Settings> settings)
        {
            _context = new Context(settings);
        }

        public bool Atualizar(int id, Alerta item)
        {
            try
            {
                IMongoCollection<Alerta> alert = _context.Alerta;
                Expression<Func<Alerta, bool>> filter = x => x.Id.Equals(id);
                Alerta alerta = alert.Find(filter).FirstOrDefault();

                if (alerta != null)
                {
                    alerta.Descricao = item.Descricao;
                    ReplaceOneResult result = alert.ReplaceOne(filter, alerta);
                    return result.IsAcknowledged && result.ModifiedCount > 0;
                }
                return false;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool Excluir(int id)
        {
            try
            {
                DeleteResult result = _context.Alerta.DeleteMany(x => x.Id.Equals(id));
                return result.IsAcknowledged
                    && result.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public  IEnumerable<Alerta> Listar()
        {
            try
            {
                return _context.Alerta.Find(x => true).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Persistir(Alerta item)
        {
            try
            {
                _context.Alerta.InsertOneAsync(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Alerta ObterPorId(int id)
        {
            try
            {
                return _context.Alerta
                    .Find(x => x.Id.Equals(id))
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
