using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FHNWPrototype.Domain.Publishing.ContentStreams
{
    public interface IContentStreamFactory
    {
        ContentStream CreateEntity(IDataReader reader);
    }
}
