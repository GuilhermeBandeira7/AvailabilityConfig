using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvailabilityConfig.Manager
{
    internal interface IRepository<T>
    {
        T GetById(long id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(long id, T entity);
        void Delete(long id);
    }
}
