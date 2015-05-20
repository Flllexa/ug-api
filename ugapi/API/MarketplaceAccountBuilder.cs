using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using Ug.Model.Request;
using Ug.Model.Response;

namespace Ug.Api
{
    public class MarketplaceAccountBuilder : APIBase
    {
        public MarketplaceAccountBuilder()
        {
            BaseURI += "/accounts";
        }

        public async Task<MarketplaceAccountResponse> Verification(string uid, string accountId, MarketplaceAccountRequest request)
        {
            Headers["Authorization"] = "Basic " + Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(uid));
            BaseURI += "/" + accountId + "/request_verification";
            var result = PostAsync<MarketplaceResponse>(request.ValidationAccount).Result;
            return await result;
        }

        public string StrVerification(string uid, string accountId, MarketplaceAccountRequest request)
        {
            Headers["Authorization"] = "Basic " + Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(uid));
            BaseURI += "/" + accountId + "/request_verification";
            //var result = PostAsync<MarketplaceResponse>(request.ValidationAccount).Result;
            var result = GetStringAsync(request.ValidationAccount);

            return result;
        }


    }
}
