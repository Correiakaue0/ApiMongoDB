using APImongoDB.Models;
using APImongoDB.Repository.IRepository;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace APImongoDB.Repository
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        public readonly Context _context = null;

        public RepositorioUsuario(IOptions<Settings> settings)
        {
            _context = new Context(settings);
        }

        public bool Atualizar(int id, Usuario item)
        {
            try
            {
                IMongoCollection<Usuario> UsuarioCollection = _context.Usuario;
                Expression<Func<Usuario, bool>> filter = x => x.Id.Equals(id);
                var usuario = _context.Usuario.Find(filter).FirstOrDefault();

                if (usuario != null)
                {
                    usuario.Nome = item.Nome;
                    usuario.Email = item.Email;
                    usuario.Senha = item.Senha;
                    usuario.Admin = item.Admin;
                    var result = UsuarioCollection.ReplaceOne(filter, usuario);
                    return result.IsAcknowledged && result.ModifiedCount > 0;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Excluir(int id)
        {
            try
            {
                var result = _context.Usuario.DeleteOne(x => x.Id.Equals(id));
                return result.IsAcknowledged
                    && result.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Usuario> Listar()
        {
            try
            {
                return _context.Usuario.Find(x => true).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Usuario ObterPorId(int id)
        {
            try
            {
                return _context.Usuario
                    .Find(x => x.Id.Equals(id))
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Persistir(Usuario item)
        {
            try
            {
                _context.Usuario.InsertOne(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
