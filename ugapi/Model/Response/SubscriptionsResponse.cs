using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ugapi
{
    public class SubscriptionsResponse : ITransation
    {
        public SubscriptionsResponse()
        {
            success = true;
        }

        public bool success { get; set; }

        public dynamic errors { get; set; }

        public Facets facets { get; set; }

        public int totalItems { get; set; }
        public SubscriptionResponse[] items { get; set; }
        
    }    
}
