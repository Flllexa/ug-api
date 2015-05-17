using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iuguapi
{
    public class MarketplaceBuilder : APIBase
    {
        public MarketplaceBuilder()
        {
            BaseURI += "/marketplace/create_account";
        }

        public MarketplaceResponse Create(MarketplaceRequest request)
        {
            var result = PostAsync<MarketplaceResponse>(request.CreateAccount).Result;
            return result;
        }
    }
}
