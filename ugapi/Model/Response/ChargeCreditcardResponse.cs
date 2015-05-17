using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ug.Model.Response
{
    public class ChargeCreditcardResponse : ITransation
    {
        public ChargeCreditcardResponse()
        {
            success = true;
        }

        public dynamic errors { get; set; }

        public bool success { get; set; }

        public string message { get; set; }

        public string invoice_id { get; set; }
    }    
}
