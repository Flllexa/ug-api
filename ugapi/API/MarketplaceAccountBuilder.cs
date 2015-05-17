using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iuguapi
{
    public class MarketplaceAccountBuilder : APIBase
    {
        public MarketplaceAccountBuilder()
        {
            BaseURI += "/accounts";
        }

        public MarketplaceAccountResponse Verification(string uid, string apikey, MarketplaceAccountRequest request)
        {
            Headers["Authorization"] = "Basic " + Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(apikey));
            BaseURI += "/" + uid + "/request_verification";
            var result = PostAsync<MarketplaceResponse>(request.ValidationAccount).Result;
            return result;
        }


    }
}
