using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ugapi.Model.Trigger
{
    public class ReferralTrigger
    {
        /// <summary>
        /// Invoice id
        /// </summary>
        public string id { get; set; }

        public string account_id { get; set; }

        public string status { get; set; }

        public string feedback { get; set; }

        public string charge_limit_cents { get; set; }
    }
}
