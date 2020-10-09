using ExploreSelenium.ArcliteWebElements;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSelenium.ArcliteWebPages
{
    public interface IArclitePage
    {
        string pageTitle { get; set;}
        Dictionary<string, IArcliteWebElement> pageElements {get;}
        WebDriverWait wait { get; set; }
    }
}
