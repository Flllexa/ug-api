using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iuguapi
{
    public class ChargeRequest
    {
        /// <summary>
        /// (opcional) not use case token
        /// </summary>
        public string method { get; set; }

        /// <summary>
        /// (opcional) not use case bank_slip
        /// </summary>
        public string token { get; set; }

        /// <summary>
        /// (opcional) not use case bank_slip or token
        /// </summary>
        public string customer_payment_method_id { get; set; }

        /// <summary>
        /// (opcional)
        /// </summary>
        public string customer_id { get; set; }

        /// <summary>
        /// (opcional)
        /// </summary>
        public string invoice_id { get; set; }

        /// <summary>
        /// optional case use invoice_id
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// (opcional) Number of installments
        /// </summary>
        public int months { get; set; }

        /// <summary>
        /// (opcional)
        /// </summary>
        public string discount_cents { get; set; }

        /// <summary>
        /// optional case use invoice_id
        /// </summary>
        public ChargeItem[] items { get; set; }

        /// <summary>
        /// (optional) necessary case your account has antihack or for informations of boleto
        /// </summary>
        public Payer payer { get; set; }

        public dynamic RequestPaymentCreditCard
        {
            get
            {
                return new
                {
                    token,
                    email,
                    items                
                };
            }
        }

        public dynamic RequestPaymentCreditCardAntiTheft
        {
            get
            {
                return new
                {
                    token,
                    email,
                    items, 
                    payer
                };
            }
        }

        public dynamic RequestPaymentBankSlip
        {
            get
            {
                return new
                {
                    method,
                    email,
                    items,
                    payer
                };
            }
        }
    }    
}
