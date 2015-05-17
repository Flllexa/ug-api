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

        public ChargeMethods Charge
        {
            get
            {
                return new ChargeMethods();
            }
        }

        public TokenMethods Token
        {
            get
            {
                return new TokenMethods();
            }
        }

        public CustomerMethods Customer
        {
            get
            {
                return new CustomerMethods();
            }
        }

        public PaymentMethods PaymentMethod
        {
            get
            {
                return new PaymentMethods();
            }
        }

        public InvoiceMethods Invoice
        {
            get
            {
                return new InvoiceMethods();
            }
        }

        public PlanMethods Plan
        {
            get
            {
                return new PlanMethods();
            }
        }

        public SubscriptionMethods Subscription
        {
            get
            {
                return new SubscriptionMethods();
            }
        }

        public TransferMethods Transfer
        {
            get
            {
                return new TransferMethods();
            }
        }

        public MarketplaceMethods Marketplace
        {
            get
            {
                return new MarketplaceMethods();
            }
        }
    }

    public class ChargeMethods
    {
        public ChargeCreditcardResponse CreateCreditcardPayment(ChargeRequest request)
        {
            return new ChargeBuilder().Create<ChargeCreditcardResponse>(request);
        }

        public ChargeBankSlipResponse CreateBankSlipPayment(ChargeRequest request)
        {
            return new ChargeBuilder().Create<ChargeBankSlipResponse>(request);
        }

        public ChargeCreditcardAntiTheftResponse CreateCreditcardAntiTheftPayment(ChargeRequest request)
        {
            return new ChargeBuilder().Create<ChargeCreditcardAntiTheftResponse>(request);
        }
    }

    public class TokenMethods
    {
        public TokenResponse CreateToken(TokenRequest request)
        {
            return new TokenBuilder().Create<TokenResponse>(request);
        }        
    }

    public class CustomerMethods
    {
        public CustomerResponse Create(CustomerRequest request)
        {
            return new CustomerBuilder().Create<CustomerResponse>(request);
        }

        public CustomerResponse Get(string uid)
        {
            return new CustomerBuilder().Get(uid);
        }

        public CustomerResponse Change(string uid, CustomerRequest request)
        {
            return new CustomerBuilder().Change<CustomerResponse>(uid, request);
        }

        public CustomerResponse Delete(string uid)
        {
            return new CustomerBuilder().Delete(uid);
        }

        public CustomersResponse List(CustomersRequest request)
        {
            return new CustomerBuilder().List(request);
        }
    }

    public class PaymentMethods
    {
        public PaymentMethodResponse Create(PaymentMethodRequest request, PaymentType type)
        {
            return new PaymentMethodBuilder().Create(request, type);
        }
        

        public PaymentMethodResponse Get(string customerid, string uid)
        {
            return new PaymentMethodBuilder().Get(customerid, uid);
        }

        public PaymentMethodResponse Change(string customerid, PaymentMethodRequest request)
        {
            return new PaymentMethodBuilder().Change(customerid, request);
        }

        public PaymentMethodResponse Delete(string customerid, string uid)
        {
            return new PaymentMethodBuilder().Delete(customerid, uid);
        }

        public PaymentMethodsResponse List(string customerid)
        {
            return new PaymentMethodBuilder().List(customerid);
        }
    }

    public class InvoiceMethods
    {
        public InvoiceResponse Create(InvoiceRequest request)
        {
            return new InvoiceBuilder().Create(request);
        }

        public InvoiceResponse Get(string uid)
        {
            return new InvoiceBuilder().Get(uid);
        }

        public InvoiceResponse Change(string uid, InvoiceRequest request)
        {
            return new InvoiceBuilder().Change(uid, request);
        }

        public InvoiceResponse Capture(string uid)
        {
            return new InvoiceBuilder().Capture(uid);
        }

        public InvoiceResponse Cancel(string uid)
        {
            return new InvoiceBuilder().Cancel(uid);
        }

        public InvoiceResponse Refund(string uid)
        {
            return new InvoiceBuilder().Refund(uid);
        }

        public InvoiceResponse Delete(string uid)
        {
            return new InvoiceBuilder().Delete(uid);
        }

        public InvoicesResponse List(InvoicesRequest request)
        {
            return new InvoiceBuilder().List(request);
        }
    }

    public class PlanMethods
    {
        public PlanResponse Create(PlanRequest request)
        {
            return new PlanBuilder().Create(request);
        }

        public PlanResponse Get(string uid)
        {
            return new PlanBuilder().Get(uid);
        }

        public PlanResponse GetByIdentifier(string uid)
        {
            return new PlanBuilder().GetByIdentifier(uid);
        }

        public PlanResponse Change(string uid, PlanRequest request)
        {
            return new PlanBuilder().Change(uid, request);
        }

        public PlanResponse Delete(string uid)
        {
            return new PlanBuilder().Delete(uid);
        }

        public PlansResponse List(PlansRequest request)
        {
            return new PlanBuilder().List(request);
        }
    }

    public class SubscriptionMethods
    {
        public SubscriptionResponse Create(SubscriptionRequest request, SubscriptionType type)
        {
            return new SubscriptionBuilder().Create(request, type);
        }

        public SubscriptionResponse Get(string uid)
        {
            return new SubscriptionBuilder().Get(uid);
        }        

        public SubscriptionResponse Change(string uid, SubscriptionRequest request, SubscriptionType type)
        {
            return new SubscriptionBuilder().Change(uid, request, type);
        }

        public SubscriptionResponse Suspend(string uid)
        {
            return new SubscriptionBuilder().Suspend(uid);
        }

        public SubscriptionResponse Activate(string uid)
        {
            return new SubscriptionBuilder().Activate(uid);
        }

        public SubscriptionResponse ChangePlan(string uid, string planIdentifier)
        {
            return new SubscriptionBuilder().ChangePlan(uid, planIdentifier);
        }

        public SubscriptionResponse AddCredits(string uid, int quantity)
        {
            return new SubscriptionBuilder().AddCredits(uid, quantity);
        }

        public SubscriptionResponse RemoveCredits(string uid, int quantity)
        {
            return new SubscriptionBuilder().RemoveCredits(uid, quantity);
        }

        public SubscriptionResponse Delete(string uid)
        {
            return new SubscriptionBuilder().Delete(uid);
        }

        public SubscriptionsResponse List(SubscriptionsRequest request)
        {
            return new SubscriptionBuilder().List(request);
        }
    }

    public class TransferMethods
    {
        public TransferResponse Create(TransferRequest request)
        {
            return new TransferBuilder().Create(request);
        }

        public TransfersResponse List(string uid)
        {
            return new TransferBuilder().List(uid);
        }
    }

    public class MarketplaceMethods
    {
        public MarketplaceResponse Create(MarketplaceRequest request)
        {
            return new MarketplaceBuilder().Create(request);
        }

        public MarketplaceAccountResponse Verification(string uid, string apikey, MarketplaceAccountRequest request)
        {
            return new MarketplaceAccountBuilder().Verification(uid, apikey, request);
        }
    }
}
