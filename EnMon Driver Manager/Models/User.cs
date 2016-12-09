using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnMon_Driver_Manager.Models
{

    public class User 

    {
        public uint ID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

        public int UserTypeID { get; set; }

        public uint MailGroupID { get; set; }

        
    }
}
