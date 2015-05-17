using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ug.Model.Request
{
    public class InvoicesRequest
    {
        public InvoicesRequest()
        {
            limit = 10;
        }

        /// <summary>
        /// (opcional)
        /// </summary>
        public int limit { get; set; }

        /// <summary>
        /// (opcional)
        /// </summary>
        public int start { get; set; }

        /// <summary>
        /// (opcional)
        /// </summary>
        public string created_at_from { get; set; }

        /// <summary>
        /// (opcional)
        /// </summary>
        public string created_at_to { get; set; }

        /// <summary>
        /// (opcional)
        /// </summary>
        public string due_date { get; set; }

        /// <summary>
        /// (opcional)
        /// </summary>
        public string query { get; set; }

        /// <summary>
        /// (opcional)
        /// </summary>
        public string updated_since { get; set; }

        /// <summary>
        /// (opcional)
        /// </summary>
        public string sortBy { get; set; }

        /// <summary>
        /// (opcional)
        /// </summary>
        public string customer_id { get; set; }               
    }    
}
