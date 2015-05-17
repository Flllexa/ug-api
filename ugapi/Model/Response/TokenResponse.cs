using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ug.Model.Response
{
    public class TokenResponse : ITransation
    {
        public bool success { get; set; }

        public TokenResponse()
        {
            success = true;
        }

        public dynamic errors { get; set; }

        public string id { get; set; }
        public string method { get; set; }
    }
}
