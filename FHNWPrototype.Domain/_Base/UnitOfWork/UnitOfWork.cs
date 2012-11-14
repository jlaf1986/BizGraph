using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using FHNWPrototype.Domain._Base.Entities;

namespace FHNWPrototype.Domain._Base.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork 
    {

        private Dictionary<IAggregateRoot, IUnitOfWorkRepository> addedEntities;
        private Dictionary<IAggregateRoot, IUnitOfWorkRepository> changedEntities;
        private Dictionary<IAggregateRoot, IUnitOfWorkRepository> deletedEntities;

        public UnitOfWork()
        {
            addedEntities = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
            changedEntities = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
            deletedEntities = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
        }

     

        public void Commit()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                foreach (IAggregateRoot entity in this.addedEntities.Keys)
                {
                    this.addedEntities[entity].PersistCreationOf(entity);
                }
                foreach (IAggregateRoot entity in this.changedEntities.Keys)
                {
                    this.changedEntities[entity].PersistUpdateOf(entity);
                }
                foreach (IAggregateRoot entity in this.deletedEntities.Keys)
                {
                    this.deletedEntities[entity].PersistDeletionOf(entity);
                }
                scope.Complete();
            }
        }

        public void RegisterAdded(IAggregateRoot entity, IUnitOfWorkRepository repository)
        {
            if (!addedEntities.ContainsKey(entity))
            {
                addedEntities.Add(entity, repository);
            };
        }

        public void RegisterChanged(IAggregateRoot entity, IUnitOfWorkRepository repository)
        {
            if (!changedEntities.ContainsKey(entity))
            {
                changedEntities.Add(entity, repository);
            }
        }

        public void RegisterRemoved(IAggregateRoot entity, IUnitOfWorkRepository repository)
        {
            if (!deletedEntities.ContainsKey(entity))
            {
                deletedEntities.Add(entity, repository);
            }
        }
    }
}
