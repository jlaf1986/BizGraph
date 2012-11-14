using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FHNWPrototype.Domain._Base.Entities
{
    public class BusinessRule
    {

        private string _property;
        private string _rule;
        
        public BusinessRule()
        {
        }

        public BusinessRule(string property, string rule)
        {
            _property = property;
            _rule = rule;
        }

        public string Property{ get; set;}

        public string Rule { get; set; }

    }
}
