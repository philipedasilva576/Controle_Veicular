using System;
using System.Collections.Generic;

namespace Controle_Veicular.Dominio.Interfaces.Repositorio
{
    public interface IRepositorioPadrao<TEntity> : IDisposable
    {
        void Adicionar(TEntity obj);
        TEntity BuscarPorID(int id);
        IEnumerable<TEntity> RecuperarTodos();
        void Atualizar(TEntity obj);
        void Excluir(TEntity obj);
        new void Dispose();
    }
}
