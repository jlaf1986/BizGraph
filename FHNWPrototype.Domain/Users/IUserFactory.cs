﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FHNWPrototype.Domain.Users
{
    public interface IUserFactory
    {
        User BuildEntity(IDataReader reader);
    }
}
