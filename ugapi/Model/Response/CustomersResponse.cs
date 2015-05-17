using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iuguapi
{
    public class CustomersResponse : ITransation
    {
        public CustomersResponse()
        {
            success = true;
        }

        public bool success { get; set; }

        public dynamic errors { get; set; }

        public int totalItems { get; set; }
        public CustomerResponse[] items { get; set; }
        
    }    
}
