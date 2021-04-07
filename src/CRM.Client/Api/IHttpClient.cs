using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Client.Api
{
    public interface IHttpClient<T>
    {
            Task<T> Get(int id);
            Task<IEnumerable<T>> Get();
            T Post(T entidade);
            void Delete(int id);
    }
}
