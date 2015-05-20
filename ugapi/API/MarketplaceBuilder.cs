using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ug.Model.Request;
using Ug.Model.Response;

namespace Ug.Api
{
    public class MarketplaceBuilder : APIBase
    {
        public MarketplaceBuilder()
        {
            BaseURI += "/marketplace/create_account";
        }

        public async Task<MarketplaceResponse> Create(MarketplaceRequest request)
        {
            var result = PostAsync<MarketplaceResponse>(request.CreateAccount);
            return await result;
        }
    }
}
