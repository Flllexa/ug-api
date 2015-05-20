using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using Newtonsoft.Json;
using Ug.Api;
using Ug.Model.Request;
using Ug.Model.Response;

namespace Ug
{

    /// <summary>
    /// Singleton Facade api
    /// </summary>
    public class UgApi
    {
        private UgApi()
        {
        }

        private static readonly UgApi _iuguApi = new UgApi();

        public static UgApi Iugu
        {
            get
            {
                return _iuguApi;
            }
        }

        public ChargeBuilder Charge
        {
            get
            {
                return new ChargeBuilder();
            }
        }

        public TokenBuilder Token
        {
            get
            {
                return new TokenBuilder();
            }
        }

        public CustomerBuilder Customer
        {
            get
            {
                return new CustomerBuilder();
            }
        }

        public PaymentMethodBuilder PaymentMethod
        {
            get
            {
                return new PaymentMethodBuilder();
            }
        }

        public InvoiceBuilder Invoice
        {
            get
            {
                return new InvoiceBuilder();
            }
        }

        public PlanBuilder Plan
        {
            get
            {
                return new PlanBuilder();
            }
        }

        public SubscriptionBuilder Subscription
        {
            get
            {
                return new SubscriptionBuilder();
            }
        }

        public TransferBuilder Transfer
        {
            get
            {
                return new TransferBuilder();
            }
        }

        public MarketplaceBuilder Marketplace
        {
            get
            {
                return new MarketplaceBuilder();
            }
        }

        public ShortcutBuilder Shortcut
        {
            get
            {
                return new ShortcutBuilder();
            }
        }
    }    
}
