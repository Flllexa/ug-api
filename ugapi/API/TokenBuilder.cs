using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ug.Model.Request;
using Ug.Model.Response;

namespace Ug.Api
{
    public class TokenBuilder : APIBase
    {
        public TokenBuilder()
        {
            BaseURI += "/payment_token";
        }

        public async Task<TokenResponse> Create(TokenRequest request)
        {
            var result = PostWithoutApiKeyAsync<TokenResponse>(request.RequestToken);
            return await result;
        }      

    }
}
