﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FHNWPrototype.Domain._Base.Entities
{
    public class ValueObjectIsInvalidException : Exception 
    {
        public ValueObjectIsInvalidException(string message) : base(message)
        {
        }
    }
}
