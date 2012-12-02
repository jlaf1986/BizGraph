using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FHNWPrototype.Domain.Publishing
{
    public interface IPublishingCapable
    {
        DateTime PublishDateTime { get; set; }
    }
}
