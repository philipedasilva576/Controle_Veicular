﻿using Controle_Veicular.Aplicacao.Interfaces;
using Controle_Veicular.Dominio.Interfaces.Servico;
using System;
using System.Collections.Generic;

namespace Controle_Veicular.Aplicacao.Servicos
{
    public class AppServicoPadrao<TEntity> : IDisposable, IAppServicoPadrao<TEntity> where TEntity : class
    {
        private readonly IServicoPadrao<TEntity> _servicoPadrao;

        public AppServicoPadrao(IServicoPadrao<TEntity> servicoPadrao)
        {
            _servicoPadrao = servicoPadrao;
        }
        public void Adicionar(TEntity obj)
        {
            _servicoPadrao.Adicionar(obj);
        }

        public void Atualizar(TEntity obj)
        {
            _servicoPadrao.Atualizar(obj);
        }

        public TEntity BuscarPorID(int id)
        {
            return _servicoPadrao.BuscarPorID(id);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Excluir(TEntity obj)
        {
            _servicoPadrao.Excluir(obj);
        }

        public IEnumerable<TEntity> RecuperarTodos()
        {
            return _servicoPadrao.RecuperarTodos();
        }
    }
}
