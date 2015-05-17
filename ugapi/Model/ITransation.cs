using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ug
{
    public interface ITransation
    {
        bool success { get; set; }
        dynamic errors { get; set; }
    }
}
