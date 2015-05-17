using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ug.Model.Request
{
    public class MarketplaceAccountRequest
    {
        public MarketplaceAccountRequest()
        {            
        }

        /// <summary>
        /// (required) 
        /// </summary>
        public MarketplaceAccountRequestModel data { get; set; }

        /// <summary>
        /// (required)
        /// </summary>
        public MarketplaceFilesRequestModel files { get; set; }

        public dynamic ValidationAccount
        {
            get
            {
                return new
                {
                    data,
                    files
                };
            }
        }        
    }

    public class MarketplaceAccountRequestModel
    {
        /// <summary>
        ///  ('Até R$ 100,00', 'Entre R$ 100,00 e R$ 500,00', 'Mais que R$ 500,00')
        /// </summary>
        public string price_range { get; set; }
        public bool physical_products { get; set; }

        /// <summary>
        /// business description
        /// </summary>
        public string business_type { get; set; }

        /// <summary>
        /// 'Pessoa Física' ou 'Pessoa Jurídica'
        /// </summary>
        public string person_type { get; set; }

        /// <summary>
        /// true is recommended
        /// </summary>
        public bool automatic_transfer { get; set; }

        /// <summary>
        /// (optional)
        /// </summary>
        public string cnpj { get; set; }

        /// <summary>
        /// (optional)
        /// </summary>
        public string company_name { get; set; }

        /// <summary>
        /// (optional) case is cnpj
        /// </summary>
        public string cpf { get; set; }

        /// <summary>
        /// (optional) case is cnpj
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// (optional)
        /// </summary>
        public string address { get; set; }

        /// <summary>
        /// (optional)
        /// </summary>
        public string cep { get; set; }

        /// <summary>
        /// (optional)
        /// </summary>
        public string city { get; set; }

        /// <summary>
        /// (optional)
        /// </summary>
        public string state { get; set; }

        /// <summary>
        /// (optional)
        /// </summary>
        public string telephone { get; set; }

        /// <summary>
        /// (optional) case is cpf
        /// </summary>
        public string resp_name { get; set; }

        /// <summary>
        /// (optional) case is cpf
        /// </summary>
        public string resp_cpf { get; set; }

        /// <summary>
        /// (required)
        /// </summary>
        public string bank { get; set; }

        /// <summary>
        /// (required)
        /// </summary>
        public string bank_ag { get; set; }

        /// <summary>
        /// (required)
        /// </summary>
        public string account_type { get; set; }

        /// <summary>
        /// (required)
        /// </summary>
        public string bank_cc { get; set; }
    }

    public class MarketplaceFilesRequestModel
    {
        /// <summary>
        /// base 64 file (RG or CPF)
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// (optional) base 64 file
        /// </summary>
        public string cpf { get; set; }

        /// <summary>
        /// base 64 file
        /// </summary>
        public string activity { get; set; }
    }
}
