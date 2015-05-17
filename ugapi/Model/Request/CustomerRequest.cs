using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ugapi
{
    public class CustomerRequest
    {
        /// <summary>
        /// (required)
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// (opcional)
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// (opcional)
        /// </summary>
        public string cpf_cnpj { get; set; }

        /// <summary>
        /// (opcional)
        /// </summary>
        public string cc_emails { get; set; }

        /// <summary>
        /// (opcional)
        /// </summary>
        public string notes { get; set; }

        /// <summary>
        /// (opcional)
        /// </summary>
        public string default_payment_method_id { get; set; }

        /// <summary>
        /// (opcional)
        /// </summary>
        public CustomVariables[] custom_variables { get; set; }        

        public dynamic CreateCustomer
        {
            get
            {
                return new
                {
                    email,
                    name,
                    cpf_cnpj,
                    cc_emails,
                    notes
                };
            }
        }
        public dynamic ChangeCustomer
        {
            get
            {
                return new
                {
                    email,
                    name,
                    cpf_cnpj,
                    cc_emails,
                    notes,
                    default_payment_method_id
                };
            }
        }
    }    
}
