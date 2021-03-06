﻿using System;
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
        MarketplaceAccountBuilder accountBuilder = new MarketplaceAccountBuilder();

        public MarketplaceBuilder()
        {
            BaseURI += "/marketplace/create_account";
        }

        public async Task<MarketplaceResponse> Create(MarketplaceRequest request)
        {
            var result = PostAsync<MarketplaceResponse>(request.CreateAccount);
            return await result;
        }

        public async Task<MarketplaceAccountResponse> Verification(string uid, string accountId, MarketplaceAccountRequest request)
        {
            return await accountBuilder.Verification(uid, accountId, request);
        }


    }
}
