using ExploreSelenium.ArcliteWebElements;
using ExploreSelenium.ArcliteXpaths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSelenium.ArcliteWebPages
{
    public class DashboardPageXAWE : IArcliteData
    {
        public Dictionary<string, IArcliteWebElement> elementXpaths;
        public KeyValuePair<string, IArcliteWebElement> search;
        public DashboardPageXAWE(IArclitePage page)
        {
            elementXpaths = new Dictionary<string, IArcliteWebElement>();
            search = new KeyValuePair<string, IArcliteWebElement>("Search Dashboard", new ArcliteTextBox("Search Dashboard", "//input[@id='grid_DXSE_I']"));
            this.elementXpaths.ToList().ForEach(x => page.pageElements.Add(x.Key, x.Value));
        }


        public void setElementXpaths()
        {
            elementXpaths.Add(search.Key, search.Value);
        }
    }
}
