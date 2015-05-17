using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ugapi
{
    public class TransferResponse : ITransation
    {        
        public TransferResponse()
        {
            success = true;
        }

        public bool success
        {
            get;
            set;
        }

        public dynamic errors
        {
            get;
            set;
        }

        public string id { get; set; }
        public string created_at { get; set; }
        public string amount_cents { get; set; }
        public string amount_localized { get; set; }
        public Receiver receiver { get; set; }
    }

    public class Receiver
    {
        public string id { get; set; }
        public string name { get; set; }
    }
}
