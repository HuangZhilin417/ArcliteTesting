using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSelenium.BaseClass
{
    interface IArcliteVariable
    {
        string ArcliteUrl { get; set; }
        string ArcliteUsername { get; set; }
        string ArclitePassword { get; set; }
    }
}
