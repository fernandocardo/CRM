using CRM.API.Contexto;
using CRM.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CRM.API.Repository.Base
{
    public class RepositoryBase<T> : IRepositoryBase<T>
        where T : EntidadeBase
    {

        private  IServiceScope _serviceEscope { get; set; }
        internal readonly DbContext _contexto;
        internal readonly DbSet<T> _dbSetEntidade;

        public RepositoryBase(IServiceProvider serviceProvider)
        {
            _serviceEscope = serviceProvider.CreateScope();
            _contexto = _serviceEscope.ServiceProvider.GetService<CRMContexto>();
            _dbSetEntidade = _contexto?.Set<T>();
        }

        public virtual bool Apagar(int id)
        {
            T entidade = _dbSetEntidade.Find(id);
            return Apagar(entidade);
        }


        public virtual int Count()
        {
            return _dbSetEntidade.Count();
        }

        public virtual void Criar(T entidade)
        {
            _dbSetEntidade.Add(entidade);
        }

        public virtual void Criar(params T[] entidades)
        {
            _dbSetEntidade.AddRange(entidades);
        }

        public virtual void Criar(IEnumerable<T> entidades)
        {
            _dbSetEntidade.AddRange(entidades);
        }

        public virtual bool Existe(Func<T, bool> where)
        {
            return _dbSetEntidade.Where(where).Any();
        }

        public  virtual IEnumerable<T> Obter()
        {
            return _dbSetEntidade.AsEnumerable();
        }

        public virtual T Obter(int id)
        {
            return _dbSetEntidade.Find(id);
        }

        public virtual T Obter(Expression<Func<T, bool>> predicate)
        {
            if (predicate != null)
            {
                return _dbSetEntidade.FirstOrDefault(predicate);
            }

            return null;
        }

        public virtual int Salvar()
        {
            return _contexto.SaveChanges();
        }

        public virtual bool Atualizar(T entidade)
        {
            _dbSetEntidade.Update(entidade);
            return true;
        }

        public virtual bool Apagar(T entidade)
        {
           if (entidade != null)
            {
                _dbSetEntidade.Remove(entidade);
                return true;
            }
            return false;
        }
    }
}
