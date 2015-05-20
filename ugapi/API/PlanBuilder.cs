using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ug.Model.Request;
using Ug.Model.Response;

namespace Ug.Api
{
    public class PlanBuilder : APIBase
    {

        public PlanBuilder()
        {
            BaseURI += "/plans";
        }

        public async Task<PlanResponse> Create(PlanRequest request)
        {
            var result = PostAsync<PlanResponse>(request.CreateRequest);
            return await result;
        }

        public async Task<PlanResponse> Get(string uid)
        {
            var result = GetAsync<PlanResponse>(uid);
            return await result;
        }

        public async Task<PlanResponse> GetByIdentifier(string identifier)
        {
            BaseURI += "/identifier";
            var result = GetAsync<PlanResponse>(identifier);
            return await result;
        }

        public async Task<PlanResponse> Change(string uid, PlanRequest request)
        {
            var result = PutAsync<PlanResponse>(uid, request.ChangeRequest);
            return await result;
        }

        public async Task<PlanResponse> Change(string uid, dynamic request)
        {
            var result = PutAsync<PlanResponse>(uid, request);
            return await result;
        }

        public async Task<PlanResponse> Delete(string uid)
        {
            var result = DeleteAsync<PlanResponse>(uid);
            return await result;
        }

        public async Task<PlansResponse> List(PlansRequest request)
        {
            var result = GetAsync<PlansResponse>(request);
            return await result;
        }

    }
}
