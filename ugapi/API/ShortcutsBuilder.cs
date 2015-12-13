using System;
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
            string notification_url = "", string expired_url = "", string payableWith = "all", string planIdentifier = null, int daysToExpires = 3, string token = "", bool itemsOnSubscription = true)
        {
            var cvalue = string.Format("{0:0}", value * 100);

            var customer = await UgApi.Iugu.Customer.Create(new CustomerRequest()
            {
                email = email,
                name = customerName,
                cpf_cnpj = cpfCnpj,
            });

            if (!string.IsNullOrEmpty(token))
            {
                var paymentRequest = new PaymentMethodRequest()
                {
                    customer_id = customer.id,
                    description = "Creditcard 1",
                    item_type = "credit_card",
                    set_as_default = true,
                    token = token
                };

                await UgApi.Iugu.PaymentMethod.Create(paymentRequest, PaymentType.WithToken);
            }

            PlanResponse plan = null;            

            if(!string.IsNullOrEmpty(planIdentifier))
            {
                plan = await UgApi.Iugu.Plan.GetByIdentifier(planIdentifier);                
            }
            
            if(plan == null || !plan.success)
            {
                plan = await UgApi.Iugu.Plan.Create(new PlanRequest()
                {
                    name = planName ?? customerName,
                    identifier = !string.IsNullOrEmpty(planIdentifier) ? planIdentifier : Guid.NewGuid().ToString(),
                    interval = interval,
                    payable_with = "all",
                    value_cents = itemsOnSubscription ? "0" : cvalue
                });
            }

            var subscription = await UgApi.Iugu.Subscription.Create(new SubscriptionRequest()
            {                
                expires_at = DateTime.Now.AddDays(daysToExpires).ToString("dd/MM/yyyy"),
                plan_identifier = plan.identifier,
                only_on_charge_success = !string.IsNullOrEmpty(token),
                customer_id = customer.id,                
                price_cents = "0",
                payable_with = payableWith,
                subitems = itemsOnSubscription ? new SubscriptionItem[] {
                    new SubscriptionItem() {
                        description = plan.name,
                        price_cents = cvalue,
                        quantity = 1,
                        recurrent = true
                    }
            } : new SubscriptionItem[] { },
            }, SubscriptionType.WithPlan);            

            return subscription;
        }

    }
}
