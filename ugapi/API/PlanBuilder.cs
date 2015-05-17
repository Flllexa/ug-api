using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ugapi
{
    public class PlanBuilder : APIBase
    {

        public PlanBuilder()
        {
            BaseURI += "/plans";
        }

        public PlanResponse Create(PlanRequest request)
        {
            var result = PostAsync<PlanResponse>(request.CreateRequest).Result;
            return result;
        }

        public PlanResponse Get(string uid)
        {
            var result = GetAsync<PlanResponse>(uid).Result;
            return result;
        }

        public PlanResponse GetByIdentifier(string identifier)
        {
            BaseURI += "/identifier";
            var result = GetAsync<PlanResponse>(identifier).Result;
            return result;
        }

        public PlanResponse Change(string uid, PlanRequest request)
        {
            var result = PutAsync<PlanResponse>(uid, request.ChangeRequest).Result;
            return result;
        }

        public PlanResponse Delete(string uid)
        {
            var result = DeleteAsync<PlanResponse>(uid).Result;
            return result;
        }

        public PlansResponse List(PlansRequest request)
        {
            var result = GetAsync<PlansResponse>(request).Result;
            return result;
        }

    }
}
