using ExploreSelenium.ArcliteInputs;
using ExploreSelenium.ArcliteInterfaces;
using ExploreSelenium.ArcliteWebElementActionsVisitor;
using ExploreSelenium.ArcliteWebElements;
using ExploreSelenium.ArcliteWebPages.DefaultPage;
using ExploreSelenium.ArcliteXpaths;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSelenium.ArcliteWebPages
{
    public class ArcliteWebPage : IArclitePage
    {
        private string _pageTitle;
        private Dictionary<string, IArcliteWebElement> _pageElements;
        IActionsVisitor _visitor;
        IArcliteData pageInfo;
        public IArcliteInputs inputs;
        public ArcliteWebPage(IActionsVisitor visitor)
        {
            _pageTitle = "defaultPage";
            _pageElements = new Dictionary<string, IArcliteWebElement>();
            _visitor = visitor;
            pageInfo = new ArcliteWebPageXAWE(this);
            inputs = new ArcliteInputValues();
        }

        public ArcliteWebPage()
        {
            _pageTitle = "defaultPage";
            inputs = new ArcliteInputValues();
            _pageElements = new Dictionary<string, IArcliteWebElement>();
        }

        public string pageTitle { get => _pageTitle; set => _pageTitle = value; }


        public Dictionary<string, IArcliteWebElement> pageElements { get => _pageElements; set => _pageElements = value; }
       

        public void runTests()
        {
            
        }

        public void runTests(ArcliteTestAction action)
        {
            throw new NotImplementedException();
        }
    }



}
