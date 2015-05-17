using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iuguapi
{
    public class PlansResponse : ITransation
    {
        public PlansResponse()
        {
            success = true;
        }

        public bool success { get; set; }

        public dynamic errors { get; set; }

        public Facets facets { get; set; }

        public int totalItems { get; set; }
        public PlanResponse[] items { get; set; }
        
    }    
}
