using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ugapi.Model.Trigger
{
    public class AllTrigger
    {
        /// <summary>
        /// Invoice id
        /// </summary>
        public string id { get; set; }

        public string status { get; set; }

        public string subscription_id { get; set; }

        public string lr { get; set; }

        public string account_id { get; set; }

        public string feedback { get; set; }

        public string charge_limit_cents { get; set; }

        public string customer_name { get; set; }

        public string customer_email { get; set; }

        public string expires_at { get; set; }

        public string plan_identifier { get; set; }
    }
}
