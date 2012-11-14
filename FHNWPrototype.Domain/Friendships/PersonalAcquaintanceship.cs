//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using FHNWSimulation.Domain._Base.Entities;
//using FHNWSimulation.Domain.Behavior;
//using FHNWSimulation.Domain.Accounts;
//using FHNWSimulation.Domain.Relationships.States;

//namespace FHNWSimulation.Domain.Relationships
//{
//    public class PersonalAcquaintanceship : EntityBase, IAggregateRoot  
//    {

//        private UserAccount _nodeA = null;
//        private UserAccount _nodeB = null;
//        private RelationshipAction _state;
//        private DateTime _dateTime;

//        public PersonalAcquaintanceship(UserAccount nodeA, UserAccount nodeB, RelationshipAction state, DateTime dateTime)
//        {
//            _nodeA = nodeA;
//            _nodeB = nodeB;
//            _state = state;
//            _dateTime = dateTime;
//        }

//        public readonly UserAccount NodeA
//        {
//            get
//            {
//                return _nodeA;
//            }
//        }


//        public readonly UserAccount NodeB
//        {
//            get
//            {
//                return _nodeB;
//            }
//        }

//        public readonly RelationshipAction State
//        {
//            get
//            {
//                return _state;
//            }
//        }

//        public readonly DateTime DateTime
//        {
//            get
//            {
//                return _dateTime;
//            }
//        }

//        protected override void Validate()
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
