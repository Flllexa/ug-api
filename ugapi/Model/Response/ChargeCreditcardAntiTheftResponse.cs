using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ugapi
{
    public class ChargeCreditcardAntiTheftResponse : ITransation
    {
        public ChargeCreditcardAntiTheftResponse()
        {
            success = true;
        }

        public dynamic errors { get; set; }

        public bool success { get; set; }

        public string message { get; set; }

        public string invoice_id { get; set; }
    }    
}
