using Flurl.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ug.Model.Request;
using Ug.Model.Response;

namespace Ug.Api
{
    public enum SubscriptionType
    {
        WithPlan = 1,
        WithCredits = 2,
        WithPlainOnChargeSuccess = 4,
        WithCreditsOnChargeSuccess = 8
    }

    public class SubscriptionBuilder : APIBase
    {
        public SubscriptionBuilder()
        {
            BaseURI += "/subscriptions";
        }

        public async Task<SubscriptionResponse >Create(SubscriptionRequest request, SubscriptionType type)
        {
            dynamic context = null;

            switch (type)
            {
                case SubscriptionType.WithPlan:
                    context = request.RequestSubscriptionWithPlan;
                    break;
                case SubscriptionType.WithCredits:
                    context = request.RequestSubscriptionWithCredits;
                    break;
                case SubscriptionType.WithPlainOnChargeSuccess:
                    context = request.RequestSubscriptionWithPlanOnChargeSuccess;
                    break;
                case SubscriptionType.WithCreditsOnChargeSuccess:
                    context = request.RequestSubscriptionWithCreditsOnChargeSuccess;
                    break;
                default:
                    break;
            }

            var result = PostTestAsync<SubscriptionResponse>(context);
            return await result;
        }

        protected async Task<TResult> PostTestAsync<TResult>(object data) where TResult : ITransation
        {
            try
            {
                return await "http://postcatcher.in/catchers/56005288c721360300000c04"
                        .WithHeaders(Headers)
                        .PostJsonAsync(data)
                        .ReceiveJson<TResult>();
            }
            catch (FlurlHttpException ex)
            {
                var result = (TResult)Activator.CreateInstance<TResult>();

                if (ex.Call != null && ex.Call.ErrorResponseBody != null)
                {
                    result.errors = JsonConvert.DeserializeObject(ex.Call.ErrorResponseBody);
                }
                else
                {
                    result.errors = ex.Message;
                }

                result.success = false;
                return result;
            }
        }

        public async Task<SubscriptionResponse >Get(string uid)
        {
            var result = GetAsync<SubscriptionResponse>(uid);
            return await result;
        }

        public async Task<SubscriptionResponse >Change(string uid, SubscriptionRequest request)
        {
            var result = PutAsync<SubscriptionResponse>(uid, request);
            return await result;
        }

        public async Task<SubscriptionResponse >Change(string uid, dynamic request)
        {
            var result = PutAsync<SubscriptionResponse>(uid, request);
            return await result;
        }

        public async Task<SubscriptionResponse >ChangePlan(string uid, string planIdentifier)
        {
            var result = PostAsync<SubscriptionResponse>(uid + "/change_plan/" + planIdentifier);
            return await result;
        }

        public async Task<SubscriptionResponse >Activate(string uid)
        {
            var result = PostAsync<SubscriptionResponse>(uid + "/activate");
            return await result;
        }

        public async Task<SubscriptionResponse >AddCredits(string uid, int credits)
        {
            var result = PutAsync<SubscriptionResponse>(uid + "/add_credits", new { ID = uid, quantity = credits });
            return await result;
        }

        public async Task<SubscriptionResponse >RemoveCredits(string uid, int credits)
        {
            var result = PutAsync<SubscriptionResponse>(uid + "/remove_credits", new { ID = uid, quantity = credits });
            return await result;
        }

        public async Task<SubscriptionResponse >Suspend(string uid)
        {
            var result = PostAsync<SubscriptionResponse>(uid + "/suspend");
            return await result;
        }

        public async Task<SubscriptionResponse >Delete(string uid)
        {
            var result = DeleteAsync<SubscriptionResponse>(uid);
            return await result;
        }

        public async Task<SubscriptionsResponse> List(SubscriptionsRequest request)
        {
            var result = GetAsync<SubscriptionsResponse>(request);
            return await result;
        }

    }
}
