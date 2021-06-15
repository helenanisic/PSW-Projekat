using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Repository.Contracts
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        Guid Create(T entity);
        bool Update(T entity);
        bool Delete(Guid id);
    }
}
