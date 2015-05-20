using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ug.Model.Request;
using Ug.Model.Response;

namespace Ug.Api
{    
    public class TransferBuilder : APIBase
    {        
        public TransferBuilder()
        {
            BaseURI += "/transfers";
        }
        
        public async Task<TransferResponse> Create(TransferRequest request)
        {
            var result = PostAsync<TransferResponse>(request.SendTransfer);
            return await result;
        }

        public async Task<TransfersResponse> List(string uid)
        {
            var result = GetAsync<TransfersResponse>(uid);
            return await result;
        }

    }
}
