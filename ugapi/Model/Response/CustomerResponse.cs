using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iuguapi
{

    public class CustomerResponse : ITransation
    {
        public CustomerResponse()
        {
            success = true;
        }

        public bool success { get; set; }
        public dynamic errors { get; set; }
        public string id { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string notes { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public CustomVariables[] custom_variables { get; set; }
    }
}
