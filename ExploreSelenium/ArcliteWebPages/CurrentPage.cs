using ExploreSelenium.ArcliteWebElementActionsVisitor;
using ExploreSelenium.ArcliteWebElements;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSelenium.ArcliteWebPages
{
    //repersenting the current page the test is on
    public class CurrentPage : IArclitePage
    {
        IArclitePage currPage;
        WebDriverWait _wait;
        IActionsVisitor _visitor;
        //sets the given arclite page as current page, and takes in the current driver wait
        public CurrentPage(IArclitePage arclitePage, WebDriverWait wait, IActionsVisitor visitor)
        {
            this.currPage = arclitePage;
            this._wait = wait;
            _visitor = visitor;
        }
        public string pageTitle { get => this.currPage.pageTitle; set => this.currPage.pageTitle = value; }

        public Dictionary<string, IArcliteWebElement> pageElements { get => this.currPage.pageElements; set => this.currPage.pageElements = value; }

        public WebDriverWait wait { get => _wait; set => _wait = value; }

        public IArclitePage getToPage(string page)
        {
            pageElements[page].accept(_visitor, "");
            IArclitePage resultPage;
            switch (page)
            {
                case "Home":
                    resultPage = new HomePage(_wait, _visitor);
                    break;
                case "Order Tracking & Manangement":
                    resultPage = new OrderTrackingAndManagementPage(_wait, _visitor);
                    break;
                default:
                    throw new Exception("can't get to that page");
            }
            this.changePage(resultPage);
            return resultPage;
        }

        public void runTests()
        {
            currPage.runTests();
        }

        public void changePage(IArclitePage newPage)
        {
            this.currPage = newPage;
        }
    }
}
