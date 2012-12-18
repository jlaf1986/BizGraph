using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHNWPrototype.Domain._Base.Entities;


namespace FHNWPrototype.Domain._Base.UnitOfWork
{
    public interface IUnitOfWork
    {
        void RegisterAdded(IAggregateRoot entity, IUnitOfWorkRepository repository);
        void RegisterChanged(IAggregateRoot entity, IUnitOfWorkRepository repository);
        void RegisterRemoved(IAggregateRoot entity, IUnitOfWorkRepository repository);
        void Commit();
    }
}
