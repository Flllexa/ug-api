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

        public async Task<Ug.Model.Response.SubscriptionResponse> Subscription(
            string customerName, string email, string cpfCnpj, decimal value, string planName = null, int interval = 12, string return_url = "",
            string notification_url = "", string expired_url = "")
        {
            var cvalue = string.Format("{0:0}", value * 100);

            var customer = await UgApi.Iugu.Customer.Create(new CustomerRequest()
            {
                email = email,
                name = customerName,
                cpf_cnpj = cpfCnpj,
            });

            var plan = await UgApi.Iugu.Plan.Create(new PlanRequest()
            {
                name = planName ?? customerName,
                identifier = Guid.NewGuid().ToString(),
                interval = interval,
                payable_with = "all",
                value_cents = cvalue
            });

            var subscription = await UgApi.Iugu.Subscription.Create(new SubscriptionRequest()
            {               
                plan_identifier = plan.identifier,
                customer_id = customer.id,
                price_cents = cvalue,
                payable_with = "all"
            }, SubscriptionType.WithPlan);

            if (subscription.recent_invoices.Length > 0)
            {
                var invoice = await UgApi.Iugu.Invoice.Create(new InvoiceRequest() {
                    due_date = DateTime.UtcNow.AddDays(3).ToString("dd/MM/yyyy"),
                    customer_id = customer.id,
                    email = customer.email,
                    expired_url = expired_url,
                    return_url = return_url,
                    notification_url = notification_url,
                    subscription_id = subscription.id,
                    items = new ChargeItem[] { new ChargeItem() {
                        description = plan.name,
                        price_cents = cvalue,
                        quantity = 1
                    } }
                });

                subscription.recent_invoices[0] = invoice;
            }

            return subscription;
        }

    }
}
