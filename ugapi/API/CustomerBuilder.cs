using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iuguapi
{
    public class CustomerBuilder : APIBase
    {
        public CustomerBuilder()
        {
            BaseURI += "/customers";
        }

        public CustomerResponse Create<TResult>(CustomerRequest request)
        {
            var result = PostAsync<CustomerResponse>(request.CreateCustomer).Result;
            return result;
        }

        public CustomerResponse Get(string uid)
        {
            var result = GetAsync<CustomerResponse>(uid).Result;
            return result;
        }

        public CustomerResponse Change<TResult>(string uid, CustomerRequest request) where TResult : ITransation
        {
            var result = PutAsync<TResult>(uid, request.ChangeCustomer).Result;
            return result;
        }

        public CustomerResponse Delete(string uid)
        {
            var result = DeleteAsync<CustomerResponse>(uid).Result;
            return result;
        }

        public CustomersResponse List(CustomersRequest request)
        {
            var result = GetAsync<CustomersResponse>(request).Result;
            return result;
        }

    }
}
