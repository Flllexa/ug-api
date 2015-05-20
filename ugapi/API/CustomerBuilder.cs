using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ug.Model.Request;
using Ug.Model.Response;

namespace Ug.Api
{
    public class CustomerBuilder : APIBase
    {
        public CustomerBuilder()
        {
            BaseURI += "/customers";
        }

        public async Task<CustomerResponse> Create(CustomerRequest request)
        {
            var result = await PostAsync<CustomerResponse>(request.CreateCustomer);
            return result;
        }

        public async Task<CustomerResponse> Get(string uid)
        {
            var result = GetAsync<CustomerResponse>(uid);
            return await result;
        }

        public async Task<CustomerResponse> Change(string uid, CustomerRequest request)
        {
            var result = PutAsync<CustomerResponse>(uid, request.ChangeCustomer);
            return await result;
        }

        public async Task<CustomerResponse> Change(string uid, dynamic request)
        {
            var result = PutAsync<CustomerResponse>(uid, request);
            return await result;
        }

        public async Task<CustomerResponse> Delete(string uid)
        {
            var result = DeleteAsync<CustomerResponse>(uid);
            return await result;
        }

        public async Task<CustomersResponse> List(CustomersRequest request)
        {
            var result = GetAsync<CustomersResponse>(request);
            return await result;
        }

    }
}
