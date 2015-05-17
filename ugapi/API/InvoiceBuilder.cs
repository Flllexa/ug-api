using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ugapi
{
    public class InvoiceBuilder : APIBase
    {
        public InvoiceBuilder()
        {
            BaseURI += "/invoices";
        }

        public InvoiceResponse Create(InvoiceRequest request)
        {
            var result = PostAsync<InvoiceResponse>(request.CompleteInvoice).Result;
            return result;
        }

        public InvoiceResponse Get(string uid)
        {
            var result = GetAsync<InvoiceResponse>(uid).Result;
            return result;
        }

        public InvoiceResponse Change(string uid, InvoiceRequest request)
        {
            var result = PutAsync<InvoiceResponse>(uid, request.CompleteInvoice).Result;
            return result;
        }

        public InvoiceResponse Capture(string uid)
        {
            var result = PostAsync<InvoiceResponse>(uid + "/capture").Result;
            return result;
        }

        public InvoiceResponse Cancel(string uid)
        {
            var result = PutAsync<InvoiceResponse>(uid + "/cancel").Result;
            return result;
        }

        public InvoiceResponse Refund(string uid)
        {
            var result = PostAsync<InvoiceResponse>(uid + "/refund").Result;
            return result;
        }

        public InvoiceResponse Delete(string uid)
        {
            var result = DeleteAsync<InvoiceResponse>(uid).Result;
            return result;
        }

        public InvoicesResponse List(InvoicesRequest request)
        {
            var result = GetAsync<InvoicesResponse>(request).Result;
            return result;
        }

    }
}
