using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iuguapi
{
    public class TokenRequest
    {
        /// <summary>
        /// (opcional) not use case token
        /// </summary>
        public string account_id { get; set; }

        /// <summary>
        /// (opcional) not use case bank_slip
        /// </summary>
        public string method { get; set; }

        /// <summary>
        /// (opcional) not use case bank_slip or token
        /// </summary>
        public bool test { get; set; }

        /// <summary>
        /// (opcional)
        /// </summary>
        public CreditCard data { get; set; }        

        public dynamic RequestToken
        {
            get
            {
                return new
                {
                    account_id,
                    method,
                    test,
                    data
                };
            }
        }
        
    }    
}
