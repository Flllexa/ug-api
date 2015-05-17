using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iuguapi
{

    public class MarketplaceAccountResponse : ITransation
    {
        public MarketplaceAccountResponse()
        {
            success = true;
        }

        public bool success { get; set; }
        public dynamic errors { get; set; }

        public string id { get; set; }

        public string name { get; set; }

        public MarketplaceAccount data { get; set; }

        public string account_id { get; set; }

        public DateTime created_at { get; set; }
    }
}
