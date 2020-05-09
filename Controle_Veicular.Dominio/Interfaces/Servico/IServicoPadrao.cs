using System.Collections.Generic;

namespace Controle_Veicular.Dominio.Interfaces.Servico
{
    public interface IServicoPadrao<TEntity> where TEntity : class
    {
        void Adicionar(TEntity obj);
        TEntity BuscarPorID(int id);
        IEnumerable<TEntity> RecuperarTodos();
        void Atualizar(TEntity obj);
        void Excluir(TEntity obj);
        void Dispose();
    }
}
