using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnMon_Driver_Manager.Models
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'User'
    public class User 
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'User'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'User.ID'
        public uint ID { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'User.ID'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'User.Name'
        public string Name { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'User.Name'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'User.Surname'
        public string Surname { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'User.Surname'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'User.Email'
        public string Email { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'User.Email'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'User.Mobile'
        public string Mobile { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'User.Mobile'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'User.UserTypeID'
        public int UserTypeID { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'User.UserTypeID'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'User.MailGroupID'
        public uint MailGroupID { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'User.MailGroupID'

        
    }
}
