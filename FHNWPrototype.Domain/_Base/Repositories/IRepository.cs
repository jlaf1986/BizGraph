using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain._Base.Entities;

namespace FHNWPrototype.Domain._Base.Repositories
{
    //public interface IRepository<T, Tkey> : IReadOnlyRepository<T, Tkey> where T : IAggregateRoot
    //{
    //    void Save(T entity);
    //    void Add(T entity);
    //    void Remove(T entity);
    //}

    public interface IRepository<T> : IReadOnlyRepository<T> where T : IAggregateRoot
    {
        void Save(T entity);
        void Add(T entity);
        void Remove(T entity);
    }

}
