using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ug.Model.Request
{
    public class MarketplaceRequest
    {        
        public MarketplaceRequest()
        {
            commission_percent = 30;
        }

        /// <summary>
        /// (opcional) 
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// (opcional)
        /// </summary>
        public int commission_percent { get; set; }            















        public dynamic CreateAccount
        {
            get
            {
                return new
                {
                    name,
                    commission_percent
                };
            }
        }        
    }    
}
