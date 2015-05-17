using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ug.Model.Response;

namespace Ug.Model.Request
{
    public class InvoiceRequest
    {
        public InvoiceRequest()
        {
            payable_with = "all";
        }

        /// <summary>
        /// (required)
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// (required)
        /// </summary> (DD/MM/AAAA)
        public string due_date { get; set; }

        /// <summary>
        /// (required) 
        /// </summary>
        public ChargeItem[] items { get; set; }        

        /// <summary>
        /// (optional)
        /// </summary>
        public string return_url { get; set; }

        /// <summary>
        /// (optional)
        /// </summary>
        public string expired_url { get; set; }

        /// <summary>
        /// (optional)
        /// </summary>
        public string notification_url { get; set; }

        /// <summary>
        /// (optional) tax
        /// </summary>
        public string tax_cents { get; set; }

        /// <summary>
        /// (optional)
        /// </summary>
        public bool fines { get; set; }

        /// <summary>
        /// (optional)
        /// </summary>
        public string late_payment_fine { get; set; }

        /// <summary>
        /// (optional)
        /// </summary>
        public bool per_day_interest { get; set; }

        /// <summary>
        /// (optional)
        /// </summary>
        public string discount_cents { get; set; }

        /// <summary>
        /// (optional)
        /// </summary>
        public string customer_id { get; set; }

        /// <summary>
        /// (optional)
        /// </summary>
        public bool ignore_due_email { get; set; }

        /// <summary>
        /// (optional)
        /// </summary>
        public string subscription_id { get; set; }

        /// <summary>
        /// (optional) (‘all’, ‘credit_card’ ou ‘bank_slip’)
        /// </summary>
        public string payable_with { get; set; }

        /// <summary>
        /// (optional)
        /// </summary>
        public string credits { get; set; }

        /// <summary>
        /// (optional)
        /// </summary>
        public Logs[] logs { get; set; }

        /// <summary>
        /// (optional)
        /// </summary>
        public CustomVariables[] custom_variables { get; set; }

        public dynamic CompleteInvoice
        {
            get
            {
                return new
                {
                    email,
                    due_date,
                    items,
                    expired_url,
                    notification_url,
                    return_url,
                    tax_cents,
                    fines,
                    late_payment_fine,
                    per_day_interest,
                    discount_cents,
                    customer_id,
                    ignore_due_email,
                    subscription_id,
                    payable_with,
                    credits,
                    logs,
                    custom_variables
                };
            }
        }        
    }
}
