using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iuguapi
{
    public class InvoiceResponse : ITransation
    {
        public InvoiceResponse()
        {
            success = true;
        }

        public string id { get; set; }
        public string due_date { get; set; }
        public string currency { get; set; }
        public object discount_cents { get; set; }
        public string email { get; set; }
        public int items_total_cents { get; set; }
        public string notification_url { get; set; }
        public string return_url { get; set; }
        public string status { get; set; }
        public string tax_cents { get; set; }
        public DateTime? updated_at { get; set; }
        public string total_cents { get; set; }
        public DateTime? paid_at { get; set; }
        public string secure_id { get; set; }
        public string secure_url { get; set; }
        public string customer_id { get; set; }
        public string user_id { get; set; }
        public string total { get; set; }
        public string taxes_paid { get; set; }
        public string interest { get; set; }
        public string discount { get; set; }
        public string created_at { get; set; }
        public bool? refundable { get; set; }
        public int? installments { get; set; }
        public BankSlip bank_slip { get; set; }
        public List<ChargeItem> items { get; set; }
        public List<Variable> variables { get; set; }
        public List<CustomVariables> custom_variables { get; set; }
        public List<Logs> logs { get; set; }

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
