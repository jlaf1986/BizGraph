﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FHNWPrototype.Domain._Base.Events
{
    public interface IDomainEventHandlerFactory
    {
        IEnumerable<IDomainEventHandler<T>> GetDomainEventHandlersFor<T>(T domainEvent) where T : IDomainEvent;
    }
}
