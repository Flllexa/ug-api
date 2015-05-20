using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ug.Model.Request;
using Ug.Model.Response;

namespace Ug.Api
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
        
        public async Task<PaymentMethodResponse> Create(PaymentMethodRequest request, PaymentType type)
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

            var result = PostAsync<PaymentMethodResponse>(context);
            return await result;
        }

        public async Task<PaymentMethodResponse> CreateWithToken(PaymentMethodRequest request)
        {
            BaseURI = string.Format(BaseURI, request.customer_id);
            var result = PostAsync<PaymentMethodResponse>(request.CreatePaymentWithToken);
            return await result;
        }

        public async Task<PaymentMethodResponse> Get(string customerid, string uid)
        {
            BaseURI = string.Format(BaseURI, customerid);
            var result = GetAsync<PaymentMethodResponse>(uid);
            return await result;
        }

        public async Task<PaymentMethodResponse> Change(string customerid, PaymentMethodRequest request)
        {
            BaseURI = string.Format(BaseURI, customerid);
            var result = PutAsync<PaymentMethodResponse>(request.id, request.ChangePayment);
            return await result;
        }

        public async Task<PaymentMethodResponse> Change(string customerid, dynamic request)
        {
            BaseURI = string.Format(BaseURI, customerid);
            var result = PutAsync<PaymentMethodResponse>(request.id, request);
            return await result;
        }

        public async Task<PaymentMethodResponse> Delete(string customerid, string uid)
        {
            BaseURI = string.Format(BaseURI, customerid);
            var result = DeleteAsync<PaymentMethodResponse>(uid);
            return await result;
        }

        public async Task<PaymentMethodsResponse> List(string customerid)
        {
            BaseURI = string.Format(BaseURI, customerid);
            var result = GetAsync<PaymentMethodsResponse>();
            return await result;
        }

    }
}
