using Product.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Core
{
    public interface IGenericRepository<T>
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        IEnumerable<dynamic> WhereIn<T>(BaseRequestEntity baseEntity);
        IEnumerable<T> TopOne<T>(BaseRequestEntity baseEntity);
    }
}
