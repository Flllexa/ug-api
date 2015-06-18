using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
        public override string IuguTriggers([FromBody]TriggerBase value)
        {
            return base.IuguTriggers(value);
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