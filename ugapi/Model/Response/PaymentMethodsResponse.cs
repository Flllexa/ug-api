using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ug.Model.Request;

namespace Ug.Model.Response
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
