﻿using System.Collections.Generic;

namespace Controle_Veicular.Aplicacao.Interfaces
{
    public interface IAppServicoPadrao<TEntity> where TEntity : class
    {
        void Adicionar(TEntity obj);
        TEntity BuscarPorID(int id);
        IEnumerable<TEntity> RecuperarTodos();
        void Atualizar(TEntity obj);
        void Excluir(TEntity obj);
        void Dispose();
    }
}
