using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ug.Model.Response
{
    public class TransfersResponse : ITransation
    {
        public TransfersResponse()
        {
            success = true;
        }

        public TransferResponse[] sent { get; set; }

        public TransferResponse[] received { get; set; }

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
    }    
}
