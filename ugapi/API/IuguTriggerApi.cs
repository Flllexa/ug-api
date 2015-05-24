using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ug.Model.Request;
using System.Web.Http;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web;
using ugapi.Model.Trigger;
using Newtonsoft.Json;

namespace Ug.Api
{
    public enum TypeTrigger
    {
        None = 0,
        InvoiceCreated = 1,
        InvoiceStatusChanged = 2,
        InvoiceRefund = 4,
        InvoicePaymentFailed = 8,
        InvoiceDue = 16,
        InvoiceDunningAction = 32,
        SubscriptionSupended = 64,
        SubscriptionExpired = 128,
        SubscriptionActivated = 256,
        SubscriptionCreated = 512,
        SubscriptionRenewed = 1024,
        SubscriptionChanged = 2048,
        ReferralsVerification = 4096
    }

    public enum InvoiceTypeTrigger
    {
        None = 0,
        InvoiceCreated = 1,
        InvoiceStatusChanged = 2,
        InvoiceRefund = 4,
        InvoicePaymentFailed = 8,
        InvoiceDue = 16,
        InvoiceDunningAction = 32
    }

    public enum SubscriptionTypeTrigger
    {
        None = 0,
        SubscriptionSupended = 64,
        SubscriptionExpired = 128,
        SubscriptionActivated = 256,
        SubscriptionCreated = 512,
        SubscriptionRenewed = 1024,
        SubscriptionChanged = 2048
    }

    public enum ReferralTypeTrigger
    {
        None = 0,
        ReferralsVerification = 4096
    }

    public enum TypeService
    {
        None,
        Invoice,
        Subscription,
        Referrals
    }

    public class Result
    {
        private dynamic _obj;        

        public Result(TypeTrigger type, dynamic obj)
        {
            TriggerType = type;
            _obj = obj;
        }

        public T GetResult<T>()
        {
            var serialized = JsonConvert.SerializeObject(_obj);
            return JsonConvert.DeserializeObject<T>(serialized);
        }

        public TypeTrigger TriggerType { get; set; } 
    }
    
    public abstract class IuguApiController : ApiController
    {
        public InvoiceTrigger invoiceTrigger = null;
        public SubscriptionTrigger subscriptionTrigger = null;
        public ReferralTrigger referralTrigger = null;
        public TypeTrigger triggerTypeReceived = TypeTrigger.None;
        public InvoiceTypeTrigger invoiceTypeReceived = InvoiceTypeTrigger.None;
        public SubscriptionTypeTrigger subscriptionTypeReceived = SubscriptionTypeTrigger.None;
        public ReferralTypeTrigger referralTypeReceived = ReferralTypeTrigger.None;

        public TypeService serviceTypeReceived = TypeService.None;

        [Route("api/iugutriggers")]
        [HttpPost]
        public virtual void IuguTriggers([FromBody]TriggerBase value)
        {
            ReceiveTrigger(value);            
        }

        private void ReceiveTrigger(TriggerBase value)
        {
            switch (value.@event)
            {
                case "invoice.created":
                    invoiceTypeReceived = (InvoiceTypeTrigger)(triggerTypeReceived = TypeTrigger.InvoiceCreated);                    
                    break;

                case "invoice.status_changed":
                    invoiceTypeReceived = (InvoiceTypeTrigger)(triggerTypeReceived = TypeTrigger.InvoiceStatusChanged);
                    break;

                case "invoice.refund":
                    invoiceTypeReceived = (InvoiceTypeTrigger)(triggerTypeReceived = TypeTrigger.InvoiceRefund);
                    break;

                case "invoice.payment_failed":
                    invoiceTypeReceived = (InvoiceTypeTrigger)(triggerTypeReceived = TypeTrigger.InvoicePaymentFailed);
                    break;

                case "invoice.due":
                    invoiceTypeReceived = (InvoiceTypeTrigger)(triggerTypeReceived = TypeTrigger.InvoiceDue);
                    break;

                case "invoice.dunning_action":
                    invoiceTypeReceived = (InvoiceTypeTrigger)(triggerTypeReceived = TypeTrigger.InvoiceDunningAction);
                    break;

                case "subscription.expired":
                    subscriptionTypeReceived = (SubscriptionTypeTrigger)(triggerTypeReceived = TypeTrigger.SubscriptionExpired);
                    break;

                case "subscription.activated":
                    subscriptionTypeReceived = (SubscriptionTypeTrigger)(triggerTypeReceived = TypeTrigger.SubscriptionActivated);
                    break;

                case "subscription.created":
                    subscriptionTypeReceived = (SubscriptionTypeTrigger)(triggerTypeReceived = TypeTrigger.SubscriptionCreated);
                    break;

                case "subscription.renewed":
                    subscriptionTypeReceived = (SubscriptionTypeTrigger)(triggerTypeReceived = TypeTrigger.SubscriptionRenewed);
                    break;
                case "subscription.changed":
                    subscriptionTypeReceived = (SubscriptionTypeTrigger)(triggerTypeReceived = TypeTrigger.SubscriptionChanged);
                    break;
                case "referrals.verification":
                    referralTypeReceived = (ReferralTypeTrigger)(triggerTypeReceived = TypeTrigger.ReferralsVerification);
                    break;
            }

            var result = new Result(triggerTypeReceived, value.data);

            switch (triggerTypeReceived)
            {
                case TypeTrigger.InvoiceCreated:
                case TypeTrigger.InvoiceStatusChanged:
                case TypeTrigger.InvoiceRefund:
                case TypeTrigger.InvoicePaymentFailed:
                case TypeTrigger.InvoiceDue:
                case TypeTrigger.InvoiceDunningAction:
                    invoiceTrigger = result.GetResult<InvoiceTrigger>();
                    InvoiceReceived(invoiceTrigger, invoiceTypeReceived);
                    serviceTypeReceived = TypeService.Invoice;
                    break;
                case TypeTrigger.SubscriptionSupended:
                case TypeTrigger.SubscriptionExpired:
                case TypeTrigger.SubscriptionActivated:
                case TypeTrigger.SubscriptionCreated:
                case TypeTrigger.SubscriptionRenewed:
                case TypeTrigger.SubscriptionChanged:
                    subscriptionTrigger = result.GetResult<SubscriptionTrigger>();
                    SubscriptionReceived(subscriptionTrigger, subscriptionTypeReceived);
                    serviceTypeReceived = TypeService.Subscription;
                    break;
                case TypeTrigger.ReferralsVerification:
                    referralTrigger = result.GetResult<ReferralTrigger>();
                    ReferralReceived(referralTrigger, referralTypeReceived);
                    serviceTypeReceived = TypeService.Referrals;
                    break;
            }
        }

        public abstract void InvoiceReceived(InvoiceTrigger trigger, InvoiceTypeTrigger typeReceived);

        public abstract void SubscriptionReceived(SubscriptionTrigger trigger, SubscriptionTypeTrigger typeReceived);

        public abstract void ReferralReceived(ReferralTrigger trigger, ReferralTypeTrigger typeReceived);
    }
}
