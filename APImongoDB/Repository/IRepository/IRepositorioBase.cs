using System.Collections.Generic;


namespace APImongoDB.Repository.IRepository
{
    public interface IRepositorioBase<T>
    {
        IEnumerable<T> Listar();
        T ObterPorId(int id);
        void Persistir(T item);
        bool Excluir(int id);
        bool Atualizar(int id, T item);
    }
}
