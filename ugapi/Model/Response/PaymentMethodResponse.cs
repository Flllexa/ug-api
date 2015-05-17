using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ug.Model.Response
{
    public class PaymentMethodResponse : ITransation
    {
        public PaymentMethodResponse()
        {
            success = true;
        }
        
        public string id { get; set; }
        public string description { get; set; }
        public string item_type { get; set; }
        public PaymentMethodData data { get; set; }

        public bool success
        {
            get;

            set;
        }

        public dynamic errors
        {
            get;
            set;
        }
    }    
}
