using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ugapi
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

        public SubscriptionResponse Create(SubscriptionRequest request, SubscriptionType type)
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

            var result = PostAsync<SubscriptionResponse>(context).Result;
            return result;
        }        

        public SubscriptionResponse Get(string uid)
        {
            var result = GetAsync<SubscriptionResponse>(uid).Result;
            return result;
        }

        public SubscriptionResponse Change(string uid, SubscriptionRequest request, SubscriptionType type)
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

            var result = PutAsync<SubscriptionResponse>(uid, context).Result;
            return result;
        }

        public SubscriptionResponse ChangePlan(string uid, string planIdentifier)
        {
            var result = PostAsync<SubscriptionResponse>(uid + "/change_plan/" + planIdentifier).Result;
            return result;
        }

        public SubscriptionResponse Activate(string uid)
        {
            var result = PostAsync<SubscriptionResponse>(uid + "/activate").Result;
            return result;
        }

        public SubscriptionResponse AddCredits(string uid, int credits)
        {
            var result = PutAsync<SubscriptionResponse>(uid + "/add_credits", new { ID = uid, quantity = credits }).Result;
            return result;
        }

        public SubscriptionResponse RemoveCredits(string uid, int credits)
        {
            var result = PutAsync<SubscriptionResponse>(uid + "/remove_credits", new { ID = uid, quantity = credits }).Result;
            return result;
        }

        public SubscriptionResponse Suspend(string uid)
        {
            var result = PostAsync<SubscriptionResponse>(uid + "/suspend").Result;
            return result;
        }

        public SubscriptionResponse Delete(string uid)
        {
            var result = DeleteAsync<SubscriptionResponse>(uid).Result;
            return result;
        }

        public SubscriptionsResponse List(SubscriptionsRequest request)
        {
            var result = GetAsync<SubscriptionsResponse>(request).Result;
            return result;
        }

    }
}
