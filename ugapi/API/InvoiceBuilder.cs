using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ug.Model.Request;
using Ug.Model.Response;

namespace Ug.Api
{
    public class InvoiceBuilder : APIBase
    {
        public InvoiceBuilder()
        {
            BaseURI += "/invoices";
        }

        public async Task<InvoiceResponse> Create(InvoiceRequest request)
        {
            var result = PostAsync<InvoiceResponse>(request.CompleteInvoice);
            return await result;
        }

        public async Task<InvoiceResponse> Get(string uid)
        {
            var result = GetAsync<InvoiceResponse>(uid);
            return await result;
        }

        public async Task<InvoiceResponse> Change(string uid, InvoiceRequest request)
        {
            var result = PutAsync<InvoiceResponse>(uid, request.CompleteInvoice);
            return await result;
        }

        public async Task<InvoiceResponse> Change(string uid, dynamic request)
        {
            var result = PutAsync<InvoiceResponse>(uid, request);
            return await result;
        }

        public async Task<InvoiceResponse> Capture(string uid)
        {
            var result = PostAsync<InvoiceResponse>(uid + "/capture");
            return await result;
        }

        public async Task<InvoiceResponse> Cancel(string uid)
        {
            var result = PutAsync<InvoiceResponse>(uid + "/cancel");
            return await result;
        }

        public async Task<InvoiceResponse> Refund(string uid)
        {
            var result = PostAsync<InvoiceResponse>(uid + "/refund");
            return await result;
        }

        public async Task<InvoiceResponse> Delete(string uid)
        {
            var result = DeleteAsync<InvoiceResponse>(uid);
            return await result;
        }

        public async Task<InvoicesResponse> List(InvoicesRequest request)
        {
            var result = GetAsync<InvoicesResponse>(request);
            return await result;
        }

    }
}
