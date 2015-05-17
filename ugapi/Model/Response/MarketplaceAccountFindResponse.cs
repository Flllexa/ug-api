using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ug.Model.Response
{

    public class MarketplaceAccountFindResponse : ITransation
    {
        public MarketplaceAccountFindResponse()
        {
            success = true;
        }

        public bool success { get; set; }
        public dynamic errors { get; set; }

        public string id { get; set; }

        public string name { get; set; }

        public DateTime created_at { get; set; }

        public DateTime? updated_at { get; set; }

        public bool can_receive { get; set; }

        public bool is_verified { get; set; }

        public string last_verification_request_status { get; set; }

        public MarketplaceAccount last_verification_request_data { get; set; }

        public string last_verification_request_feedback { get; set; }

        public int change_plan_type { get; set; }

        public int subscriptions_trial_period { get; set; }

        public bool disable_emails { get; set; }

        public string last_withdraw { get; set; }

        public int total_subscriptions { get; set; }

        public string reply_to { get; set; }
        
        public bool webapp_on_test_mode { get; set; }

        public bool marketplace { get; set; }

        public bool auto_withdraw { get; set; }

        public string balance { get; set; }

        public string protected_balance { get; set; }

        public string payable_balance { get; set; }

        public string receivable_balance { get; set; }

        public string commission_balance { get; set; }

        public string volume_last_month { get; set; }

        public string volume_this_month { get; set; }

        public string taxes_paid_last_month { get; set; }

        public string taxes_paid_this_month { get; set; }

        public string custom_logo_url { get; set; }

        public string custom_logo_small_url { get; set; }

        public Information[] informations { get; set; }
    }

    public class Information
    {
        public string Key { get; set; }
        public string value { get; set; }

    }
}
