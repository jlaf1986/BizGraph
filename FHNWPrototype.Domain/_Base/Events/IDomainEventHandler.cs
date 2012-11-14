using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FHNWPrototype.Domain._Base.Events
{
    public interface IDomainEventHandler<T> where T : IDomainEvent 
    {
        void Handle(T domainEvent);
    }
}
