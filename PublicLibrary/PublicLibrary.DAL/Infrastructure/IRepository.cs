using System;
using System.Collections.Generic;
using System.Text;

namespace PublicLibrary.DAL.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        //void Add(T entity);
        //void Update(T entity);
        //T GetById(int id);
        IEnumerable<T> GetAll();
    }
}
