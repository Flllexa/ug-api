using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ugapi
{
    public class TransferRequest
    {        

        /// <summary>
        /// (opcional) not use case token
        /// </summary>
        public string receiver_id { get; set; }

        /// <summary>
        /// (opcional) not use case bank_slip
        /// </summary>
        public string amount_cents { get; set; }            

        public dynamic SendTransfer
        {
            get
            {
                return new
                {
                    receiver_id,
                    amount_cents
                };
            }
        }        
    }    
}
