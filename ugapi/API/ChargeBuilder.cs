using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ug.Model.Request;

namespace Ug.Api
{
    public class ChargeBuilder : APIBase
    {
        public ChargeBuilder()
        {
            BaseURI += "/charge";            
        }

        public TResult Create<TResult>(ChargeRequest request) where TResult : ITransation
        {
            dynamic context = null;

            switch (typeof(TResult).Name)
            {
                case "ChargeBankSlipResponse":
                    context = request.RequestPaymentBankSlip;
                    break;

                case "ChargeCreditcardResponse":
                    context = request.RequestPaymentCreditCard;
                    break;
                case "ChargeCreditcardAntiTheftResponse":
                    context = request.RequestPaymentCreditCardAntiTheft;
                    break;
                    
            }

            var result = PostAsync<TResult>(context).Result;
            return result;
        }      

    }
}
