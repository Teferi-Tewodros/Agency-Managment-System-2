using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgencyMAnagmentSystem.Models
{
    public class MaidAdress
    {
        public Guid Id { get; set; }
        public Guid MaidId { get; set; }
        public virtual Maid Maid { get; set; }
        public string Region { get; set; }
        public string Zone { get; set; }
        public string Wereda { get; set; }
        public string Kebele { get; set; }
        public string City { get; set; }
        public string SubCity { get; set; }
        public string House_No { get; set; }
    }
}
