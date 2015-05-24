using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ugapi.Model.Trigger
{
    public class SubscriptionTrigger
    {
        /// <summary>
        /// Invoice id
        /// </summary>
        public string id { get; set; }

        public string customer_name { get; set; }

        public string customer_email { get; set; }

        public string expires_at { get; set; }

        public string plan_identifier { get; set; }
    }
}
