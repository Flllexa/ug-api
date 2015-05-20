using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ug.Model.Response;

namespace Ug.Model.Request
{
    public class SubscriptionRequest
    {
        public SubscriptionRequest()
        {
            only_on_charge_success = true;
            credits_based = true;

        }
        
        /// <summary>
        /// (opcional) required for subscription not credits_based
        /// </summary>
        public string plan_identifier { get; set; }

        /// <summary>
        /// client id
        /// </summary>
        public string customer_id { get; set; }

        /// <summary>
        /// (opcional) expiration date
        /// </summary>
        public string expires_at { get; set; }

        /// <summary>
        /// (opcional) if payment is success the subscription created
        /// </summary>
        public bool only_on_charge_success { get; set; }

        /// <summary>
        /// (opcional) (all, credit_card ou bank_slip)
        /// </summary>
        public string payable_with { get; set; }

        /// <summary>
        /// optional with default true
        /// </summary>
        public bool credits_based { get; set; }

        /// <summary>
        /// (opcional) Number of installments
        /// </summary>
        public string price_cents { get; set; }

        /// <summary>
        /// (opcional)
        /// </summary>
        public string credits_cycle { get; set; }

        /// <summary>
        /// (opcional)
        /// </summary>
        public string credits_min { get; set; }

        /// <summary>
        /// (opcional)
        /// </summary>
        public CustomVariables[] custom_variables { get; set; }

        /// <summary>
        /// optional case use invoice_id
        /// </summary>
        public SubscriptionItem[] subitems { get; set; }

        /// <summary>
        /// (optional) necessary case your account has antihack or for informations of boleto
        /// </summary>
        
        public dynamic RequestSubscriptionWithPlan
        {
            get
            {
                return new
                {
                    plan_identifier,
                    customer_id,
                    subitems
                };
            }
        }

        public dynamic Standard
        {
            get
            {
                return new
                {
                    customer_id,
                    subitems
                };
            }
        }

        public dynamic RequestSubscriptionWithCredits
        {
            get
            {
                return new
                {
                    credits_based = true,
                    price_cents,
                    credits_cycle,
                    credits_min,
                    customer_id,
                    subitems
                };
            }
        }

        public dynamic RequestSubscriptionWithPlanOnChargeSuccess
        {
            get
            {
                return new
                {
                    plan_identifier,
                    customer_id,
                    subitems,
                    only_on_charge_success = true
                };
            }
        }

        public dynamic RequestSubscriptionWithCreditsOnChargeSuccess
        {
            get
            {
                return new
                {
                    credits_based = true,
                    price_cents,
                    credits_cycle,
                    credits_min,
                    customer_id,
                    subitems,
                    only_on_charge_success = true
                };
            }
        }
    }

    public class SubscriptionItem
    {
        public string description { get; set; }
        public int quantity { get; set; }
        public string price_cents { get; set; }
        public bool recurrent { get; set; }
    }    
}
