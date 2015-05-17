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

        public TResult Create<TResult>(TokenRequest request) where TResult : ITransation
        {
            dynamic context = null;

            switch (typeof(TResult).Name)
            {
                case "TokenResponse":
                    context = request.RequestToken;
                    break;
            }

            var result = PostWithoutApiKeyAsync<TResult>(context).Result;
            return result;
        }      

    }
}
