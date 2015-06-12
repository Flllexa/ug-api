﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ug.Model.Request;
using Ug.Model.Response;

namespace Ug.Api
{
    public class ShortcutBuilder : APIBase
    {

        public ShortcutBuilder()
        {
        }

        /// <summary>
        /// Shortcut create call with customer, plan and subscription
        /// </summary>
        /// <param name="customerName"></param>
        /// <param name="email"></param>
        /// <param name="cpfCnpj"></param>
        /// <param name="value"></param>
        /// <param name="planName"></param>
        /// <param name="interval"></param>
        /// <param name="return_url"></param>
        /// <param name="notification_url"></param>
        /// <param name="expired_url"></param>
        /// <param name="payableWith">all, credit_card, bank_slip</param>
        /// <returns></returns>
        public async Task<Ug.Model.Response.SubscriptionResponse> Subscription(
            string customerName, string email, string cpfCnpj, decimal value, string planName = null, int interval = 1, string return_url = "",
            string notification_url = "", string expired_url = "", string payableWith = "all", string planIdentifier = null)
        {
            var cvalue = string.Format("{0:0}", value * 100);

            var customer = await UgApi.Iugu.Customer.Create(new CustomerRequest()
            {
                email = email,
                name = customerName,
                cpf_cnpj = cpfCnpj,
            });

            PlanResponse plan = null;            

            if(!string.IsNullOrEmpty(planIdentifier))
            {
                var find = await UgApi.Iugu.Plan.List(new PlansRequest() { query = planIdentifier });
                if(find.items != null && find.items.Any(c => c.name.Contains(planIdentifier)))
                {
                    plan = find.items[0];
                }
            }
            
            if(plan == null)
            {
                plan = await UgApi.Iugu.Plan.Create(new PlanRequest()
                {
                    name = planName ?? customerName,
                    identifier = !string.IsNullOrEmpty(planIdentifier) ? planIdentifier : Guid.NewGuid().ToString(),
                    interval = 1,
                    payable_with = payableWith,
                    value_cents = cvalue
                });
            }            
            

            var subscription = await UgApi.Iugu.Subscription.Create(new SubscriptionRequest()
            {               
                expires_at = DateTime.UtcNow.AddDays(3).ToString("dd/MM/yyyy"),
                plan_identifier = plan.identifier,
                customer_id = customer.id,
                price_cents = cvalue,
                payable_with = payableWith
            }, SubscriptionType.WithPlan);

            return subscription;
        }

    }
}
