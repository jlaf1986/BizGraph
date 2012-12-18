using FHNWPrototype.Domain.Friendships.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHNWPrototype.Domain.DTOs
{

    /// <summary>
    /// this class is used because of an issue 'by-design' from EF
    /// <see cref="http://stackoverflow.com/questions/5325797/the-entity-cannot-be-constructed-in-a-linq-to-entities-query"/>
    /// </summary>
    public class FriendshipStateInfoDTO
    {

        public FriendshipAction Action { get; set; }

        public UserAccountDTO Sender { get; set; }

        public UserAccountDTO Receiver { get; set; }

        public DateTime ActionDateTime { get; set; }
    }
}
