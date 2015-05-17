using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ugapi
{
    public class PlanRequest
    {
        public PlanRequest()
        {
            interval_type = "months";
            currency = "BRL";
            interval = 12;
            payable_with = "all";
        }
        
        /// <summary>
        /// (required) 
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// (required) 
        /// </summary>
        public string identifier { get; set; }

        /// <summary>
        /// (required) 
        /// </summary>
        public int interval { get; set; }

        /// <summary>
        /// (required)  ("weeks" or "months")
        /// </summary>
        public string interval_type { get; set; }

        /// <summary>
        /// (required)  ("BRL")
        /// </summary>
        public string currency { get; set; }

        /// <summary>
        /// (required)  ("BRL")
        /// </summary>
        public string value_cents { get; set; }

        /// <summary>
        /// (optional) ('all', 'credit_card' ou 'bank_slip')
        /// </summary>
        public string payable_with { get; set; }

        /// <summary>
        /// (optional)
        /// </summary>
        public Prices[] prices { get; set; }

        /// <summary>
        /// (optional)
        /// </summary>
        public Feature[] features { get; set; }

        /// <summary>
        /// (optional) use to find
        /// </summary>
        public string ID { get; set; }


        public dynamic CreateRequest
        {
            get
            {
                return new
                {
                    name,
                    identifier,
                    interval,
                    interval_type,
                    currency,
                    value_cents,
                    payable_with,
                    prices,
                    features
                };
            }
        }

        public dynamic StandardRequest
        {
            get
            {
                return new
                {
                    ID,
                    name,
                    identifier,
                    interval,
                    interval_type,
                    currency,
                    value_cents,
                    payable_with,
                    prices,
                    features
                };
            }
        }

        public dynamic ChangeRequest
        {
            get
            {
                return new
                {
                    ID,
                    name,
                    interval,
                    interval_type,
                    currency,
                    value_cents,
                    payable_with,
                    prices,
                    features = from f in features
                               select new
                               {
                                   f.name,
                                   f.value,
                                   identifier = f.identifier + "-" + Guid.NewGuid()
                               }
                };
            }
        }

    }    
}
