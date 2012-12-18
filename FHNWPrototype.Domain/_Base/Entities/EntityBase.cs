using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace FHNWPrototype.Domain._Base.Entities
{
        public abstract class EntityBase
        {
            private Guid _key;
            private int _id = 0;
            private Boolean _idHasBeenSet =false;

            private List<BusinessRule> _brokenRules = new List<BusinessRule>();

            public EntityBase()
            {
            }

            public EntityBase(Guid key)
            {
                this.Key = key;
                _idHasBeenSet = true;
            }

            protected abstract void Validate();

            public  IEnumerable<BusinessRule> GetBrokenRules()
            {
                _brokenRules.Clear();
                Validate();
                return _brokenRules;
            }

            protected void AddBrokenRule(BusinessRule businessRule)
            {
                _brokenRules.Add(businessRule);
            }

            public override bool Equals(object entity)
            {
                return entity != null && entity is EntityBase && this == (EntityBase)entity;
            }

            public override int GetHashCode()
            {
                return this.Key.GetHashCode();
            }

            public static bool operator == (EntityBase entity1, EntityBase entity2)
            {
                if ((object) entity1 == null && (object) entity2 == null)
                {
                    return true;
                }
                if ((object) entity1 == null || (object) entity2 == null)
                {
                    return false;
                }
                if (entity1.Key.ToString() == entity2.Key.ToString())
                {
                    return true;
                }
                return false;
            }

            public static bool operator !=(EntityBase entity1, EntityBase entity2)
            {
                return (!(entity1 == entity2));
            }


            public int ID
            {
                get
                {
                    return _id;
                }
                set
                {
                    _id = value;
                }
            }

            public Guid Key
            {
                get
                {
                    return _key;
                }
                set
                {
                    if (!_idHasBeenSet)
                    {
                        _key = value;
                        _idHasBeenSet = true;
                    }
                    else
                    {
                        throw new ApplicationException("Entity Id has already been set");
                    }
                }
            }

        }

}