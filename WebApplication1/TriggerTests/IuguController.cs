using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Ug.Api;
using ugapi.Model.Trigger;

namespace WebApplication1.api
{
    public class IuguController : IuguApiController
    {
        // GET: Iugu
        public void Get()
        {
        }

        [Route("api/iugutriggers")]
        [HttpPost]
        public override void IuguTriggers([FromBody]TriggerBase value)
        {
            base.IuguTriggers(value);
        }

        public override void InvoiceReceived(InvoiceTrigger trigger, InvoiceTypeTrigger typeReceived)
        {
        }

        public override void ReferralReceived(ReferralTrigger trigger, ReferralTypeTrigger typeReceived)
        {
        }

        public override void SubscriptionReceived(SubscriptionTrigger trigger, SubscriptionTypeTrigger typeReceived)
        {
        }
    }
}