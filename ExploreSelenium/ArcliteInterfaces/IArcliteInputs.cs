using ExploreSelenium.ArcliteInputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSelenium.ArcliteInterfaces
{
    public interface IArcliteInputs
    {
        InputVal getInput(string key);
        void setInput(string key, InputVal value);
    }
}
