using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain._Base.Entities;
using FHNWPrototype.Domain._Base.Querying;

namespace FHNWPrototype.Domain._Base.Repositories
{
    //public interface IReadOnlyRepository<T, Tkey> where T : IAggregateRoot 
    //{
    //    T FindBy(Tkey key);
    //    IEnumerable<T> FindAll();
    //    IEnumerable<T> FindBy(Query query);
    //    IEnumerable<T> FindBy(Query query, int index, int count);
    //}


    public interface IReadOnlyRepository<T> where T : IAggregateRoot
    {
        T FindBy(Guid key);
        IEnumerable<T> FindAll();
        IEnumerable<T> FindBy(Query query);
        IEnumerable<T> FindBy(Query query, int index, int count);
    }

}
