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
        //unique page title for every page
        string pageTitle { get; set;}

        //contains the key (name of the web element or the page title it leads to)
        Dictionary<string, IArcliteWebElement> pageElements { get; set; }

        //web driver wait
        WebDriverWait wait { get; set; }

        //run tests for current page
        void runTests();
    }
}
