using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgencyMAnagmentSystem.Models
{
    public class MaidKin
    {
        public Guid Id { get; set; }
        public Guid MaidId { get; set; }
        public virtual Maid Maid { get; set; }

        public string Relative_name { get; set; }
        public string Relative_kinship { get; set; }
        public string Relative_phone { get; set; }
        public string Relative_address { get; set; }
        public string Relative_Id { get; set; }

    }
}

