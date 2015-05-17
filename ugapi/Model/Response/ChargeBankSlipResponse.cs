using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ug.Model.Response
{
    public class ChargeBankSlipResponse : ITransation
    {
        public ChargeBankSlipResponse()
        {
            success = true;
        }

        public dynamic errors { get; set; }

        public string url { get; set; }

        public bool success { get; set; }

        public string invoice_id { get; set; }
    }   
}
