using CRM.Domain.Models;
using System;
using System.Collections.Generic;

namespace CRM.Domain.Repository.Base
{
    public interface IRepositoryBase<T> : IReadRepositoryBase<T>
        where T : EntidadeBase
    {
        void Criar(T entidade);
        void Criar(params T[] entidades);
        void Criar(IEnumerable<T> entidades);
        Boolean Atualizar(T entidade);
        Boolean Apagar(int id);
        Boolean Apagar(T entidade);

        int Salvar();
    }
}
