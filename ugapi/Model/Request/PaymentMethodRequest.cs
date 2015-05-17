using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iuguapi
{
    public class PaymentMethodRequest
    {
        /// <summary>
        /// (required)
        /// </summary>
        public string customer_id { get; set; }

        /// <summary>
        /// payment id (required) case change the payment method
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// (required)
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// (optional) will necessary case no have token
        /// </summary>
        public CreditCard data { get; set; }

        /// <summary>
        /// (opcional) will necessary case no have token
        /// </summary>
        public string item_type { get; set; }

        /// <summary>
        /// (opcional)
        /// </summary>
        public string token { get; set; }

        /// <summary>
        /// (opcional)
        /// </summary>
        public bool set_as_default { get; set; }

        public dynamic CreatePaymentWithoutToken
        {
            get
            {
                return new
                {
                    customer_id,
                    description,
                    data,
                    item_type,
                    set_as_default
                };
            }
        }

        public dynamic CreatePaymentWithToken
        {
            get
            {
                return new
                {
                    customer_id,
                    description,
                    token,
                    set_as_default
                };
            }
        }

        public dynamic ChangePayment
        {
            get
            {
                return new
                {
                    customer_id,
                    id,
                    description
                };
            }
        }
    }    
}
