using Controle_Veicular.Dados.Contexto;
using Controle_Veicular.Dominio.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Controle_Veicular.Dados.Repositorio
{
    public class RepositorioPadrao<TEntity> : IDisposable, IRepositorioPadrao<TEntity> where TEntity : class
    {
        protected ControleVeicularContexto _Db = new ControleVeicularContexto();
        public void Adicionar(TEntity obj)
        {
            _Db.Set<TEntity>().Add(obj);
            _Db.SaveChanges();
        }

        public void Atualizar(TEntity obj)
        {
            _Db.Entry(obj).State = EntityState.Modified;
            _Db.SaveChanges();
        }

        public TEntity BuscarPorID(int id)
        {
            return _Db.Set<TEntity>().Find(id);
        }

        public void Excluir(TEntity obj)
        {
            _Db.Set<TEntity>().Remove(obj);
            _Db.SaveChanges();
        }

        public IEnumerable<TEntity> RecuperarTodos()
        {
            return _Db.Set<TEntity>().ToList();
        }
        public void Dispose()
        {
            _Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
