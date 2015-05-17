using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ugapi
{
    public enum PaymentType
    {
        WithToken = 1,
        WithoutToken = 2        
    }

    public class PaymentMethodBuilder : APIBase
    {        
        public PaymentMethodBuilder()
        {
            BaseURI += "/customers/{0}/payment_methods";
        }
        
        public PaymentMethodResponse Create(PaymentMethodRequest request, PaymentType type)
        {
            BaseURI = string.Format(BaseURI, request.customer_id);

            dynamic context = null;

            switch (type)
            {
                case PaymentType.WithToken:
                    context = request.CreatePaymentWithToken;
                    break;
                case PaymentType.WithoutToken:
                    context = request.CreatePaymentWithoutToken;
                    break;
                default:
                    break;
            }

            var result = PostAsync<PaymentMethodResponse>(context).Result;
            return result;
        }

        public PaymentMethodResponse CreateWithToken(PaymentMethodRequest request)
        {
            BaseURI = string.Format(BaseURI, request.customer_id);
            var result = PostAsync<PaymentMethodResponse>(request.CreatePaymentWithToken).Result;
            return result;
        }

        public PaymentMethodResponse Get(string customerid, string uid)
        {
            BaseURI = string.Format(BaseURI, customerid);
            var result = GetAsync<PaymentMethodResponse>(uid).Result;
            return result;
        }

        public PaymentMethodResponse Change(string customerid, PaymentMethodRequest request)
        {
            BaseURI = string.Format(BaseURI, customerid);
            var result = PutAsync<PaymentMethodResponse>(request.id, request.ChangePayment).Result;
            return result;
        }

        public PaymentMethodResponse Delete(string customerid, string uid)
        {
            BaseURI = string.Format(BaseURI, customerid);
            var result = DeleteAsync<PaymentMethodResponse>(uid).Result;
            return result;
        }

        public PaymentMethodsResponse List(string customerid)
        {
            BaseURI = string.Format(BaseURI, customerid);
            var result = GetAsync<PaymentMethodsResponse>().Result;
            return result;
        }

    }
}
