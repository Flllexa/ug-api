using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ugapi.Model.Trigger
{
    public class TriggerBase
    {
        public string @event { get; set; }

        public dynamic data { get; set; }
    }
}
