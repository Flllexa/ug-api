using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iuguapi
{
    public class PaymentMethodsResponse : List<PaymentMethodRequest>, ITransation
    {
        public PaymentMethodsResponse()
        {
            success = true;
        }

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
