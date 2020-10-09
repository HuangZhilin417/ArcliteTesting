using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSelenium.BaseClass
{
    class ArcliteVariable : IArcliteVariable
    {
        private string _arcliteUrl;
        public ArcliteVariable()
        {

        }
        public string ArcliteUrl { get => _arcliteUrl; set => _arcliteUrl = value; }
        public string ArcliteUsername { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ArclitePassword { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        
    }
}
