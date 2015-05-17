using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ug.Model.Response
{
    public class MarketplaceResponse : ITransation
    {
        public bool success { get; set; }
        public dynamic errors { get; set; }

        public MarketplaceResponse()
        {
            success = true;
        }        

        public string account_id { get; set; }

        public string live_api_token { get; set; }

        public string test_api_token { get; set; }

        public string user_token { get; set; }

    }
}
