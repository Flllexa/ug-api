using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ugapi.Model.Trigger
{
    public class InvoiceTrigger
    {
        /// <summary>
        /// Invoice id
        /// </summary>
        public string id { get; set; }

        public string status { get; set; }

        public string subscription_id { get; set; }

        public string lr { get; set; }
    }
}
